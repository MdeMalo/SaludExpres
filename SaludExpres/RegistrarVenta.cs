using System;
using System.Configuration;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace SaludExpres
{
    public partial class RegistrarVenta : Form
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["SaludExpresConnection"].ConnectionString;
        public int ClienteID { get; private set; } = -1;
        private int idEmpleado;
        private int idSucursal;

        public RegistrarVenta(int idEmpleado)
        {
            InitializeComponent();
            this.idEmpleado = idEmpleado;
            this.idSucursal = ObtenerIdSucursal(idEmpleado);
            lblEmpleado.Text = ObtenerNombreEmpleado(idEmpleado);
            lblSucursal.Text = ObtenerSucursalPorEmpleado(idEmpleado);
            CargarClientes(); // Cargar lista de clientes al iniciar
            CargarProductos(); // Cargar lista de productos al iniciar
        }

        private void RegistrarVenta_Load(object sender, EventArgs e)
        {
            if (dataGridViewCarrito.Columns.Count == 0)
            {
                dataGridViewCarrito.Columns.Add("idProducto", "ID");
                dataGridViewCarrito.Columns["idProducto"].Visible = true;

                dataGridViewCarrito.Columns.Add("nombre", "Nombre del Producto");
                dataGridViewCarrito.Columns.Add("precio", "Precio Unitario"); // Precio sin IVA
                dataGridViewCarrito.Columns["precio"].DefaultCellStyle.Format = "C2";
                dataGridViewCarrito.Columns.Add("cantidad", "Cantidad");
                dataGridViewCarrito.Columns.Add("subtotal", "Subtotal"); // Subtotal sin IVA
                dataGridViewCarrito.Columns["subtotal"].DefaultCellStyle.Format = "C2";
                dataGridViewCarrito.Columns.Add("total", "Total con IVA"); // Total con IVA
                dataGridViewCarrito.Columns["total"].DefaultCellStyle.Format = "C2";
                dataGridViewCarrito.Columns.Add("receta", "Receta");
                dataGridViewCarrito.Columns["receta"].ReadOnly = true;

                dataGridViewCarrito.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridViewCarrito.AllowUserToAddRows = false;
            }

            comboBoxMetodoPago.Items.AddRange(new string[] { "Efectivo", "Tarjeta de Crédito", "Transferencia", "Otro" });
            comboBoxMetodoPago.SelectedIndex = 0;
        }

        private void AgregarProductoAlCarrito(int idProducto, string nombre, decimal precio, int cantidad, int stock)
        {
            if (cantidad <= 0)
            {
                MessageBox.Show("Ingrese una cantidad válida.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cantidad > stock)
            {
                MessageBox.Show("No hay suficiente stock disponible.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            foreach (DataGridViewRow row in dataGridViewCarrito.Rows)
            {
                if (Convert.ToInt32(row.Cells["idProducto"].Value) == idProducto)
                {
                    int nuevaCantidad = Convert.ToInt32(row.Cells["cantidad"].Value) + cantidad;
                    if (nuevaCantidad > stock)
                    {
                        MessageBox.Show("Cantidad supera el stock disponible.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    row.Cells["cantidad"].Value = nuevaCantidad;
                    row.Cells["subtotal"].Value = precio * nuevaCantidad; // Subtotal sin IVA
                    row.Cells["total"].Value = (precio * 1.16m) * nuevaCantidad; // Total con IVA
                    CalcularTotales();
                    return;
                }
            }

            decimal subtotal = precio * cantidad; // Subtotal sin IVA
            decimal total = subtotal * 1.16m; // Total con IVA (16%)
            dataGridViewCarrito.Rows.Add(idProducto, nombre, precio, cantidad, subtotal, total, "Sin receta");
            CalcularTotales();
        }

        private void CalcularTotales()
        {
            decimal subtotal = 0;
            decimal total = 0;

            foreach (DataGridViewRow row in dataGridViewCarrito.Rows)
            {
                if (row.Cells["subtotal"].Value != null && row.Cells["total"].Value != null)
                {
                    subtotal += Convert.ToDecimal(row.Cells["subtotal"].Value);
                    total += Convert.ToDecimal(row.Cells["total"].Value);
                }
            }

            decimal iva = total - subtotal; // IVA calculado como diferencia entre total y subtotal
            labelSubtotal.Text = $"Subtotal: {subtotal:C2}";
            labelIVA.Text = $"IVA (16%): {iva:C2}";
            labelTotal.Text = $"Total: {total:C2}";
        }

        private void buttonRegistrarVenta_Click(object sender, EventArgs e)
        {
            if (dataGridViewCarrito.Rows.Count == 0)
            {
                MessageBox.Show("No se han seleccionado productos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (ClienteID == -1)
            {
                MessageBox.Show("Por favor, seleccione un cliente.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string metodoPago = comboBoxMetodoPago.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(metodoPago))
            {
                MessageBox.Show("Seleccione un método de pago.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    using (MySqlTransaction transaction = connection.BeginTransaction())
                    {
                        try
                        {
                            decimal total = Convert.ToDecimal(labelTotal.Text.Replace("Total: ", "").Replace("$", "").Trim());
                            int ventaId = RegistrarVentaEnBaseDeDatos(ClienteID, idEmpleado, idSucursal, DateTime.Now, metodoPago, total, connection, transaction);

                            foreach (DataGridViewRow row in dataGridViewCarrito.Rows)
                            {
                                int productoId = Convert.ToInt32(row.Cells["idProducto"].Value);
                                int cantidad = Convert.ToInt32(row.Cells["cantidad"].Value);
                                decimal precioUnitario = Convert.ToDecimal(row.Cells["precio"].Value); // Usar "precio" (sin IVA)
                                decimal subtotalProducto = Convert.ToDecimal(row.Cells["subtotal"].Value);

                                // Registrar detalle con precio unitario sin IVA
                                RegistrarDetalleVenta(ventaId, productoId, cantidad, precioUnitario, subtotalProducto, connection, transaction);
                                ActualizarStockProducto(productoId, cantidad, connection, transaction);
                                RegistrarMovimientoInventario(productoId, cantidad, "Salida", "Venta realizada", idEmpleado, connection, transaction);

                                // Registrar receta si existe
                                if (row.Tag is RecetaForm recetaForm)
                                {
                                    int recetaId = RegistrarReceta(ClienteID, idEmpleado, recetaForm, connection, transaction);
                                    RegistrarRecetaProducto(recetaId, productoId, recetaForm, connection, transaction);
                                }
                            }

                            RegistrarPago(ventaId, total, metodoPago, connection, transaction);
                            transaction.Commit();

                            LimpiarFormulario();
                            MessageBox.Show("Venta registrada con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            MessageBox.Show("Error al registrar la venta: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al conectar con la base de datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void RegistrarRecetaProducto(int idReceta, int idProducto, RecetaForm recetaForm, MySqlConnection connection, MySqlTransaction transaction)
        {
            string query = @"
        INSERT INTO recetaproducto (idReceta, idProducto, dosis, frecuencia, duracion)
        VALUES (@idReceta, @idProducto, @dosis, @frecuencia, @duracion);";

            using (MySqlCommand cmd = new MySqlCommand(query, connection, transaction))
            {
                cmd.Parameters.AddWithValue("@idReceta", idReceta);
                cmd.Parameters.AddWithValue("@idProducto", idProducto);
                cmd.Parameters.AddWithValue("@dosis", recetaForm.Dosis ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@frecuencia", recetaForm.Frecuencia ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@duracion", recetaForm.Duracion ?? (object)DBNull.Value);
                cmd.ExecuteNonQuery();
            }
        }
        private int RegistrarReceta(int idCliente, int idEmpleado, RecetaForm recetaForm, MySqlConnection connection, MySqlTransaction transaction)
        {
            string query = @"
        INSERT INTO receta (idCliente, idEmpleado, fechaEmision, diagnostico, observaciones)
        VALUES (@idCliente, @idEmpleado, @fechaEmision, @diagnostico, @observaciones);
        SELECT LAST_INSERT_ID();";

            using (MySqlCommand cmd = new MySqlCommand(query, connection, transaction))
            {
                cmd.Parameters.AddWithValue("@idCliente", idCliente);
                cmd.Parameters.AddWithValue("@idEmpleado", idEmpleado);
                cmd.Parameters.AddWithValue("@fechaEmision", recetaForm.FechaEmision);
                cmd.Parameters.AddWithValue("@diagnostico", recetaForm.Diagnostico);
                cmd.Parameters.AddWithValue("@observaciones", recetaForm.Observaciones ?? (object)DBNull.Value); // NULL si está vacío
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        private int RegistrarVentaEnBaseDeDatos(int clienteId, int idEmpleado, int idSucursal, DateTime fechaVenta, string metodoPago, decimal total,
            MySqlConnection connection, MySqlTransaction transaction)
        {
            string query = @"
                INSERT INTO venta (idCliente, idEmpleado, idSucursal, fecha, total, formaPago)
                VALUES (@idCliente, @idEmpleado, @idSucursal, @fechaVenta, @total, @formaPago);
                SELECT LAST_INSERT_ID();";
            using (MySqlCommand cmd = new MySqlCommand(query, connection, transaction))
            {
                cmd.Parameters.AddWithValue("@idCliente", clienteId);
                cmd.Parameters.AddWithValue("@idEmpleado", idEmpleado);
                cmd.Parameters.AddWithValue("@idSucursal", idSucursal);
                cmd.Parameters.AddWithValue("@fechaVenta", fechaVenta);
                cmd.Parameters.AddWithValue("@total", total);
                cmd.Parameters.AddWithValue("@formaPago", metodoPago);
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        private void RegistrarDetalleVenta(int ventaId, int productoId, int cantidad, decimal precioUnitario, decimal subtotal,
            MySqlConnection connection, MySqlTransaction transaction)
        {
            string query = @"
                INSERT INTO detalleventa (idVenta, idProducto, cantidad, precioUnitario, subtotal)
                VALUES (@idVenta, @idProducto, @cantidad, @precioUnitario, @subtotal);";
            using (MySqlCommand cmd = new MySqlCommand(query, connection, transaction))
            {
                cmd.Parameters.AddWithValue("@idVenta", ventaId);
                cmd.Parameters.AddWithValue("@idProducto", productoId);
                cmd.Parameters.AddWithValue("@cantidad", cantidad);
                cmd.Parameters.AddWithValue("@precioUnitario", precioUnitario);
                cmd.Parameters.AddWithValue("@subtotal", subtotal);
                cmd.ExecuteNonQuery();
            }
        }

        private void ActualizarStockProducto(int productoId, int cantidad, MySqlConnection connection, MySqlTransaction transaction)
        {
            string query = "UPDATE producto SET stock = stock - @cantidad WHERE idProducto = @idProducto";
            using (MySqlCommand cmd = new MySqlCommand(query, connection, transaction))
            {
                cmd.Parameters.AddWithValue("@cantidad", cantidad);
                cmd.Parameters.AddWithValue("@idProducto", productoId);
                cmd.ExecuteNonQuery();
            }
        }

        private void RegistrarMovimientoInventario(int idProducto, int cantidad, string tipoMovimiento, string descripcion, int idEmpleado,
            MySqlConnection connection, MySqlTransaction transaction)
        {
            string query = @"
                INSERT INTO movimientoinventario (idProducto, fechaMovimiento, tipoMovimiento, cantidad, descripcion, idEmpleado)
                VALUES (@idProducto, NOW(), @tipoMovimiento, @cantidad, @descripcion, @idEmpleado);";
            using (MySqlCommand cmd = new MySqlCommand(query, connection, transaction))
            {
                cmd.Parameters.AddWithValue("@idProducto", idProducto);
                cmd.Parameters.AddWithValue("@tipoMovimiento", tipoMovimiento);
                cmd.Parameters.AddWithValue("@cantidad", cantidad);
                cmd.Parameters.AddWithValue("@descripcion", descripcion);
                cmd.Parameters.AddWithValue("@idEmpleado", idEmpleado);
                cmd.ExecuteNonQuery();
            }
        }

        private void RegistrarPago(int idVenta, decimal monto, string metodoPago, MySqlConnection connection, MySqlTransaction transaction)
        {
            string query = @"
                INSERT INTO pago (idVenta, fechaPago, monto, metodoPago)
                VALUES (@idVenta, NOW(), @monto, @metodoPago)";
            using (MySqlCommand cmd = new MySqlCommand(query, connection, transaction))
            {
                cmd.Parameters.AddWithValue("@idVenta", idVenta);
                cmd.Parameters.AddWithValue("@monto", monto);
                cmd.Parameters.AddWithValue("@metodoPago", metodoPago);
                cmd.ExecuteNonQuery();
            }
        }

        private void CargarClientes(string filtro = "")
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT idCliente, nombre, apellidoPaterno, apellidoMaterno, telefono FROM cliente";
                    if (!string.IsNullOrWhiteSpace(filtro))
                    {
                        query += " WHERE nombre LIKE @filtro OR apellidoPaterno LIKE @filtro OR apellidoMaterno LIKE @filtro OR telefono LIKE @filtro";
                    }

                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        if (!string.IsNullOrWhiteSpace(filtro))
                        {
                            cmd.Parameters.AddWithValue("@filtro", "%" + filtro + "%");
                        }
                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);
                            dataGridViewClientes.DataSource = dt;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar clientes: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarProductos(string filtro = "")
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT idProducto, nombre, precioConIva AS precio, stock, tipo, lote, fechaCaducidad FROM producto";
                    if (!string.IsNullOrWhiteSpace(filtro))
                    {
                        query += " WHERE nombre LIKE @filtro OR lote LIKE @filtro";
                    }

                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        if (!string.IsNullOrWhiteSpace(filtro))
                        {
                            cmd.Parameters.AddWithValue("@filtro", "%" + filtro + "%");
                        }
                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);
                            dataGridViewProductos.DataSource = dt;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar productos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridViewProductos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int idProducto = Convert.ToInt32(dataGridViewProductos.Rows[e.RowIndex].Cells["idProducto"].Value);
                string nombre = dataGridViewProductos.Rows[e.RowIndex].Cells["nombre"].Value.ToString();
                decimal precio = Convert.ToDecimal(dataGridViewProductos.Rows[e.RowIndex].Cells["precio"].Value);
                int stock = Convert.ToInt32(dataGridViewProductos.Rows[e.RowIndex].Cells["stock"].Value);
                int cantidad = (int)numericCantidad.Value;
                AgregarProductoAlCarrito(idProducto, nombre, precio, cantidad, stock);
            }
        }

        private void buttonAgregarProducto_Click(object sender, EventArgs e)
        {
            if (dataGridViewProductos.SelectedRows.Count > 0)
            {
                int idProducto = Convert.ToInt32(dataGridViewProductos.SelectedRows[0].Cells["idProducto"].Value);
                string nombre = dataGridViewProductos.SelectedRows[0].Cells["nombre"].Value.ToString();
                decimal precio = Convert.ToDecimal(dataGridViewProductos.SelectedRows[0].Cells["precio"].Value);
                int stock = Convert.ToInt32(dataGridViewProductos.SelectedRows[0].Cells["stock"].Value);
                int cantidad = (int)numericCantidad.Value;
                AgregarProductoAlCarrito(idProducto, nombre, precio, cantidad, stock);
            }
            else
            {
                MessageBox.Show("Seleccione un producto.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dataGridViewClientes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                ClienteID = Convert.ToInt32(dataGridViewClientes.Rows[e.RowIndex].Cells["idCliente"].Value);
                string nombreCompleto = $"{dataGridViewClientes.Rows[e.RowIndex].Cells["nombre"].Value} " +
                                        $"{dataGridViewClientes.Rows[e.RowIndex].Cells["apellidoPaterno"].Value} " +
                                        $"{dataGridViewClientes.Rows[e.RowIndex].Cells["apellidoMaterno"].Value}";
                string telefono = dataGridViewClientes.Rows[e.RowIndex].Cells["telefono"].Value.ToString();

                textBoxClienteID.Text = ClienteID.ToString();
                lblNombreCliente.Text = nombreCompleto;
                lblTelefonoCliente.Text = telefono;
            }
        }

        private void textBoxClienteID_TextChanged(object sender, EventArgs e)
        {
            CargarClientes(textBoxClienteID.Text);
        }

        private void textBoxProducto_TextChanged(object sender, EventArgs e)
        {
            CargarProductos(textBoxBuscarProducto.Text);
        }

        private void LimpiarFormulario()
        {
            dataGridViewCarrito.Rows.Clear();
            labelIVA.Text = "__________";
            labelTotal.Text = "__________";
            labelSubtotal.Text = "__________";
            ClienteID = -1;
            lblNombreCliente.Text = "__________";
            lblTelefonoCliente.Text = "__________";
            textBoxBuscarProducto.Clear();
            textBoxClienteID.Clear();
            numericCantidad.Value = 1;
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private int ObtenerIdSucursal(int idEmpleado)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT idSucursal FROM empleado WHERE idEmpleado = @idEmpleado";
                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@idEmpleado", idEmpleado);
                        var result = cmd.ExecuteScalar();
                        return result != null ? Convert.ToInt32(result) : -1;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener la sucursal: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
        }

        private string ObtenerNombreEmpleado(int idEmpleado)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT CONCAT(nombre, ' ', apellidoPaterno) FROM empleado WHERE idEmpleado = @idEmpleado";
                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@idEmpleado", idEmpleado);
                        var result = cmd.ExecuteScalar();
                        return result?.ToString() ?? "Empleado no encontrado";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener el nombre del empleado: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "Error";
            }
        }
        private void buttonNuevoCliente_Click(object sender, EventArgs e)
        {
            RegistrarCliente registrarCliente = new RegistrarCliente();
            registrarCliente.ShowDialog();
            CargarClientes(); // Recargar lista después de registrar un cliente
        }

        private void buttonBuscarCliente_Click(object sender, EventArgs e)
        {
            if (dataGridViewClientes.SelectedRows.Count > 0)
            {
                ClienteID = Convert.ToInt32(dataGridViewClientes.SelectedRows[0].Cells["idCliente"].Value);
                string nombreCompleto = dataGridViewClientes.SelectedRows[0].Cells["nombre"].Value.ToString() + " " +
                                        dataGridViewClientes.SelectedRows[0].Cells["apellidoPaterno"].Value.ToString() + " " +
                                        dataGridViewClientes.SelectedRows[0].Cells["apellidoMaterno"].Value.ToString();
                string telefono = dataGridViewClientes.SelectedRows[0].Cells["telefono"].Value.ToString();

                textBoxClienteID.Text = ClienteID.ToString();
                lblNombreCliente.Text = nombreCompleto;
                lblTelefonoCliente.Text = telefono;
            }
            else
            {
                MessageBox.Show("Seleccione un cliente", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private string ObtenerSucursalPorEmpleado(int idEmpleado)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT s.nombre FROM sucursal s INNER JOIN empleado e ON s.idSucursal = e.idSucursal WHERE e.idEmpleado = @idEmpleado";
                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@idEmpleado", idEmpleado);
                        var result = cmd.ExecuteScalar();
                        return result?.ToString() ?? "Sucursal no encontrada";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener la sucursal: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "Error";
            }
        }

        private void dataGridViewCarrito_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string nombreProducto = dataGridViewCarrito.Rows[e.RowIndex].Cells["nombre"].Value.ToString();
                RecetaForm recetaForm = new RecetaForm(nombreProducto);
                if (recetaForm.ShowDialog() == DialogResult.OK)
                {
                    dataGridViewCarrito.Rows[e.RowIndex].Cells["receta"].Value = $"Receta #{recetaForm.NumeroReceta}";
                    dataGridViewCarrito.Rows[e.RowIndex].Tag = recetaForm; // Guardar los datos de la receta en Tag
                }
            }
        }
    }
}