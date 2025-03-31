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

        }
        private void AgregarProductoAlCarrito(int idProducto, string nombre, decimal precio, int cantidad, int stock)
        {
            // Validar si hay suficiente stock
            if (cantidad > stock)
            {
                MessageBox.Show("No hay suficiente stock disponible.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Revisar si ya está en el carrito
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
                    row.Cells["subtotal"].Value = precio * nuevaCantidad;
                    row.Cells["total"].Value = precio * nuevaCantidad;
                    return;
                }
            }

            // Si no está en el carrito, agregarlo
            decimal subtotal = precio * cantidad;
            decimal precioConIva = precio * 1.16m; // Precio con IVA
            decimal total = precioConIva * cantidad; // Total con IVA

            dataGridViewCarrito.Rows.Add(idProducto, nombre, precio, cantidad, subtotal, total);
        }
        private void dataGridViewProductos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int idProducto = Convert.ToInt32(dataGridViewProductos.Rows[e.RowIndex].Cells["idProducto"].Value);
                string nombre = dataGridViewProductos.Rows[e.RowIndex].Cells["nombre"].Value.ToString();
                decimal precio = Convert.ToDecimal(dataGridViewProductos.Rows[e.RowIndex].Cells["precioConIva"].Value);
                int stock = Convert.ToInt32(dataGridViewProductos.Rows[e.RowIndex].Cells["stock"].Value);
                int cantidad = (int)numericCantidad.Value;

                if (cantidad > 0)
                {
                    AgregarProductoAlCarrito(idProducto, nombre, precio, cantidad, stock);
                }
                else
                {
                    MessageBox.Show("Ingrese una cantidad válida.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
        private void CargarClientes(string filtro = "")
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

        private int ObtenerIdSucursal(int idEmpleado)
        {
            int idSucursal = -1;
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
                        if (result != null)
                            idSucursal = Convert.ToInt32(result);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener la sucursal: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return idSucursal;
        }

        private string ObtenerNombreEmpleado(int idEmpleado)
        {
            string nombre = "";
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
                        if (result != null)
                            nombre = result.ToString();
                    }
                }
            }
            catch { }
            return nombre;
        }

        private string ObtenerSucursalPorEmpleado(int idEmpleado)
        {
            string nombreSucursal = "No encontrada";
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = @"
                SELECT s.nombre 
                FROM sucursal s
                INNER JOIN empleado e ON s.idSucursal = e.idSucursal
                WHERE e.idEmpleado = @idEmpleado";

                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@idEmpleado", idEmpleado);
                        var result = cmd.ExecuteScalar();
                        if (result != null)
                            nombreSucursal = result.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener la sucursal: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return nombreSucursal;
        }

        private void CargarProductos(string filtro = "")
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = @"
            SELECT idProducto, nombre, precioConIva, stock, tipo, lote, fechaCaducidad 
            FROM producto";

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



        // **Seleccionar cliente con doble clic**
        private void dataGridViewClientes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                ClienteID = Convert.ToInt32(dataGridViewClientes.Rows[e.RowIndex].Cells["idCliente"].Value);
                string nombreCompleto = dataGridViewClientes.Rows[e.RowIndex].Cells["nombre"].Value.ToString() + " " +
                                        dataGridViewClientes.Rows[e.RowIndex].Cells["apellidoPaterno"].Value.ToString() + " " +
                                        dataGridViewClientes.Rows[e.RowIndex].Cells["apellidoMaterno"].Value.ToString();
                string telefono = dataGridViewClientes.Rows[e.RowIndex].Cells["telefono"].Value.ToString();

                textBoxClienteID.Text = ClienteID.ToString();
                lblNombreCliente.Text = nombreCompleto;
                lblTelefonoCliente.Text = telefono;
            }
        }

        // **Seleccionar cliente con botón**
        private void buttonSeleccionarCliente_Click(object sender, EventArgs e)
        {
            if (dataGridViewClientes.SelectedRows.Count > 0)
            {
                ClienteID = Convert.ToInt32(dataGridViewClientes.SelectedRows[0].Cells["idCliente"].Value);
                textBoxClienteID.Text = ClienteID.ToString();
            }
            else
            {
                MessageBox.Show("Seleccione un cliente", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // **Abrir ventana para registrar un nuevo cliente**
        private void buttonNuevoCliente_Click(object sender, EventArgs e)
        {
            RegistrarCliente registrarCliente = new RegistrarCliente();
            registrarCliente.ShowDialog();
            CargarClientes(); // Recargar lista después de registrar un cliente
        }

        private void textBoxClienteID_TextChanged(object sender, EventArgs e)
        {
            CargarClientes(textBoxClienteID.Text);
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

        private void textBoxProducto_TextChanged(object sender, EventArgs e)
        {

            CargarProductos(textBoxBuscarProducto.Text);
        }

        private void buttonAgregarProducto_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewProductos.SelectedRows.Count > 0)
                {
                    int idProducto = Convert.ToInt32(dataGridViewProductos.SelectedRows[0].Cells["idProducto"].Value);
                    string nombre = dataGridViewProductos.SelectedRows[0].Cells["nombre"].Value.ToString();
                    decimal precio = Convert.ToDecimal(dataGridViewProductos.SelectedRows[0].Cells["precioConIva"].Value);
                    int stock = Convert.ToInt32(dataGridViewProductos.SelectedRows[0].Cells["stock"].Value);
                    int cantidad = (int)numericCantidad.Value;

                    if (cantidad > 0)
                    {
                        AgregarProductoAlCarrito(idProducto, nombre, precio, cantidad, stock);
                        CalcularTotales();
                    }
                    else
                    {
                        MessageBox.Show("Ingrese una cantidad válida.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Seleccione un producto", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar el producto al carrito: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RegistrarVenta_Load(object sender, EventArgs e)
        {
            if (dataGridViewCarrito.Columns.Count == 0)
            {
                // Limpiar columnas antes de agregar (evita duplicados si recargas el formulario)
                dataGridViewCarrito.Columns.Clear();

                // Definir columnas
                dataGridViewCarrito.Columns.Add("idProducto", "ID");
                dataGridViewCarrito.Columns["idProducto"].Visible = true; // Ocultar ID si no es necesario

                dataGridViewCarrito.Columns.Add("nombre", "Nombre del Producto");

                dataGridViewCarrito.Columns.Add("precioConIva", "Precio con IVA");
                dataGridViewCarrito.Columns["precioConIva"].DefaultCellStyle.Format = "C2"; // Formato moneda

                dataGridViewCarrito.Columns.Add("cantidad", "Cantidad");

                dataGridViewCarrito.Columns.Add("subtotal", "Subtotal");
                dataGridViewCarrito.Columns["subtotal"].DefaultCellStyle.Format = "C2"; // Formato moneda

                dataGridViewCarrito.Columns.Add("total", "Total");
                dataGridViewCarrito.Columns["subtotal"].DefaultCellStyle.Format = "C2";

                // Ajuste automático de tamaño de columnas
                dataGridViewCarrito.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridViewCarrito.AllowUserToAddRows = false;
            }

            // Llenar el ComboBox con métodos de pago disponibles
            comboBoxMetodoPago.Items.Add("Efectivo");
            comboBoxMetodoPago.Items.Add("Tarjeta de Crédito");
            comboBoxMetodoPago.Items.Add("Transferencia");
            comboBoxMetodoPago.Items.Add("Otro");

            // Seleccionar un valor predeterminado (por ejemplo, "Efectivo")
            comboBoxMetodoPago.SelectedIndex = 0;

        }

        private void CalcularTotales()
        {
            decimal subtotal = 0;
            decimal total = 0;

            // Recorrer los productos en el carrito y sumar el subtotal
            foreach (DataGridViewRow row in dataGridViewCarrito.Rows)
            {
                if (row.Cells["subtotal"].Value != null)
                {
                    subtotal += Convert.ToDecimal(row.Cells["subtotal"].Value); // Subtotal de todos los productos sin IVA
                    total += Convert.ToDecimal(row.Cells["total"].Value); // Total de todos los productos con IVA
                }
            }

            // Calcular IVA (16%)
            decimal iva = subtotal * 0.16m;

            // Mostrar en los Labels
            labelIVA.Text = $"IVA (16%): {iva:C2}";
            labelTotal.Text = $"Total: {total:C2}";
            labelSubtotal.Text = $"Subtotal: {subtotal:C2}";
        }

        private void buttonRegistrarVenta_Click(object sender, EventArgs e)
        {
            try
            {
                // Validar si se ha seleccionado algún producto
                if (dataGridViewCarrito.Rows.Count == 0)
                {
                    MessageBox.Show("No se han seleccionado productos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Validar que el cliente haya sido seleccionado
                if (ClienteID == -1)
                {
                    MessageBox.Show("Por favor, seleccione un cliente.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Validar que se haya seleccionado un método de pago
                string metodoPago = comboBoxMetodoPago.SelectedItem?.ToString();
                if (string.IsNullOrEmpty(metodoPago))
                {
                    MessageBox.Show("Seleccione un método de pago.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Obtener la fecha de la venta (podría ser la fecha actual)
                DateTime fechaVenta = DateTime.Now;

                // Registrar la venta en la base de datos
                int ventaId = RegistrarVentaEnBaseDeDatos(ClienteID, idEmpleado, idSucursal, fechaVenta, metodoPago);

                // Registrar cada producto en la venta (en detalleventa)
                foreach (DataGridViewRow row in dataGridViewCarrito.Rows)
                {
                    if (row.Cells["idProducto"].Value != null && row.Cells["cantidad"].Value != null)
                    {
                        int productoId = Convert.ToInt32(row.Cells["idProducto"].Value);
                        int cantidad = Convert.ToInt32(row.Cells["cantidad"].Value);
                        decimal precioUnitario = Convert.ToDecimal(row.Cells["precioConIVA"].Value);
                        decimal subtotalProducto = Convert.ToDecimal(row.Cells["subtotal"].Value);

                        // Registrar el producto en el detalle de la venta
                        RegistrarDetalleVenta(ventaId, productoId, cantidad, precioUnitario, subtotalProducto);

                        // Actualizar el stock del producto
                        ActualizarStockProducto(productoId, cantidad);
                    }
                }

                // Limpiar el formulario después de registrar la venta
                LimpiarFormulario();

                MessageBox.Show("Venta registrada con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar la venta: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }
        private int RegistrarVentaEnBaseDeDatos(int clienteId, int idEmpleado, int idSucursal, DateTime fechaVenta, string metodoPago)
        {
            int ventaId = -1;
            try
            {
                decimal total = 0;

                // Convertir el total a decimal (remover texto como "Total: $" antes de convertir)
                if (!decimal.TryParse(labelTotal.Text.Replace("Total: ", "").Replace("$", "").Trim(), out total))
                {
                    MessageBox.Show("Error al obtener el total de la venta.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return ventaId; // Salir si hay un error al convertir el total
                }

                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = @"
                INSERT INTO venta (idCliente, idEmpleado, idSucursal, fecha, total, formaPago)
                VALUES (@idCliente, @idEmpleado, @idSucursal, @fechaVenta, @total, @formaPago);
                SELECT LAST_INSERT_ID();"; // Obtener el ID de la venta recién insertada

                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@idCliente", clienteId);
                        cmd.Parameters.AddWithValue("@idEmpleado", idEmpleado);
                        cmd.Parameters.AddWithValue("@idSucursal", idSucursal);
                        cmd.Parameters.AddWithValue("@fechaVenta", fechaVenta);
                        cmd.Parameters.AddWithValue("@total", total); // Pasar el total como decimal
                        cmd.Parameters.AddWithValue("@formaPago", metodoPago);

                        ventaId = Convert.ToInt32(cmd.ExecuteScalar());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar la venta: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return ventaId;
        }


        private void RegistrarDetalleVenta(int ventaId, int productoId, int cantidad, decimal precioUnitario, decimal subtotal)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = @"
                INSERT INTO detalleventa (idVenta, idProducto, cantidad, precioUnitario, subtotal)
                VALUES (@idVenta, @idProducto, @cantidad, @precioUnitario, @subtotal);";

                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@idVenta", ventaId);
                        cmd.Parameters.AddWithValue("@idProducto", productoId);
                        cmd.Parameters.AddWithValue("@cantidad", cantidad);
                        cmd.Parameters.AddWithValue("@precioUnitario", precioUnitario);
                        cmd.Parameters.AddWithValue("@subtotal", subtotal);

                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar el detalle de la venta: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ActualizarStockProducto(int productoId, int cantidad)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "UPDATE producto SET stock = stock - @cantidad WHERE idProducto = @idProducto";

                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@cantidad", cantidad);
                        cmd.Parameters.AddWithValue("@idProducto", productoId);

                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar el stock: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimpiarFormulario()
        {
            // Limpiar el carrito de productos
            dataGridViewCarrito.Rows.Clear();

            // Limpiar los labels de totales
            labelIVA.Text = "__________";
            labelTotal.Text = "__________";
            labelSubtotal.Text = "__________";

            // Limpiar el campo del cliente seleccionado
            ClienteID = -1;
            lblNombreCliente.Text = "__________";
            lblTelefonoCliente.Text = "__________";

            // Limpiar cualquier otro campo necesario (como el filtro de búsqueda de productos)
            textBoxBuscarProducto.Clear();
        }
    }
}
