using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace SaludExpres
{
    public partial class EditarProducto : Form
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["SaludExpresConnection"].ConnectionString;
        private int idProducto;
        private int stockOriginal;
        private bool actualizando;

        public EditarProducto(int idProducto)
        {
            InitializeComponent();
            this.idProducto = idProducto;
        }

        private void EditarProducto_Load(object sender, EventArgs e)
        {
            CargarComboBox();
            CargarProducto();
        }

        private void CargarProducto()
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT * FROM producto WHERE idProducto = @idProducto";

                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@idProducto", idProducto);
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                textNombre.Text = reader["nombre"].ToString();
                                textDescripcion.Text = reader["descripcion"].ToString();
                                numericPrecioCompra.Value = Convert.ToDecimal(reader["precioCompra"]);
                                numericPrecioSinIva.Value = Convert.ToDecimal(reader["precioSinIva"]);
                                stockOriginal = Convert.ToInt32(reader["stock"]);
                                numericStock.Value = stockOriginal;

                                string tipo = reader["tipo"].ToString();
                                comboBoxTipo.SelectedIndex = tipo == "generico" ? 0 : 1; // 0 = generico, 1 = patente

                                textLote.Text = reader["lote"].ToString();
                                dateTimePickerFechaFabricacion.Value = Convert.ToDateTime(reader["fechaFabricacion"]);
                                dateTimePickerFechaCaducidad.Value = Convert.ToDateTime(reader["fechaCaducidad"]);
                                textRegistroSanitario.Text = reader["registroSanitario"].ToString();
                                textCondicionesAlmacenamiento.Text = reader["condicionesAlmacenamiento"].ToString();

                                comboBoxProveedor.SelectedValue = reader["idProveedor"];
                                comboBoxCategoria.SelectedValue = reader["idCategoria"];
                                comboBoxSucursal.SelectedValue = reader["idSucursal"];
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar el producto: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarComboBox()
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    // Llenar ComboBox Tipo manualmente (sin DataSource)
                    comboBoxTipo.Items.Clear();
                    comboBoxTipo.Items.Add("generico");
                    comboBoxTipo.Items.Add("patente");

                    // Llenar ComboBox Proveedor
                    string queryProveedor = "SELECT idProveedor, nombre FROM proveedor";
                    MySqlDataAdapter adapterProveedor = new MySqlDataAdapter(queryProveedor, connection);
                    DataTable dtProveedor = new DataTable();
                    adapterProveedor.Fill(dtProveedor);
                    comboBoxProveedor.DataSource = dtProveedor;
                    comboBoxProveedor.DisplayMember = "nombre";
                    comboBoxProveedor.ValueMember = "idProveedor";

                    // Llenar ComboBox Categoria
                    string queryCategoria = "SELECT idCategoria, nombre FROM categoria";
                    MySqlDataAdapter adapterCategoria = new MySqlDataAdapter(queryCategoria, connection);
                    DataTable dtCategoria = new DataTable();
                    adapterCategoria.Fill(dtCategoria);
                    comboBoxCategoria.DataSource = dtCategoria;
                    comboBoxCategoria.DisplayMember = "nombre";
                    comboBoxCategoria.ValueMember = "idCategoria";

                    // Llenar ComboBox Sucursal
                    string querySucursal = "SELECT idSucursal, nombre FROM sucursal";
                    MySqlDataAdapter adapterSucursal = new MySqlDataAdapter(querySucursal, connection);
                    DataTable dtSucursal = new DataTable();
                    adapterSucursal.Fill(dtSucursal);
                    comboBoxSucursal.DataSource = dtSucursal;
                    comboBoxSucursal.DisplayMember = "nombre";
                    comboBoxSucursal.ValueMember = "idSucursal";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los ComboBox: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonEditar_Click(object sender, EventArgs e)
        {
            string nombre = textNombre.Text.Trim();
            string descripcion = textDescripcion.Text.Trim();
            decimal precioCompra = numericPrecioCompra.Value;
            decimal precioSinIva = numericPrecioSinIva.Value;
            int stock = (int)numericStock.Value;
            string tipo = comboBoxTipo.SelectedItem?.ToString(); // Obtener el valor seleccionado
            string lote = textLote.Text.Trim();
            DateTime fechaFabricacion = dateTimePickerFechaFabricacion.Value;
            DateTime fechaCaducidad = dateTimePickerFechaCaducidad.Value;
            string registroSanitario = textRegistroSanitario.Text.Trim();
            string condicionesAlmacenamiento = textCondicionesAlmacenamiento.Text.Trim();
            int idProveedor = (int)comboBoxProveedor.SelectedValue;
            int idCategoria = (int)comboBoxCategoria.SelectedValue;
            int idSucursal = (int)comboBoxSucursal.SelectedValue;

            // Validar campos obligatorios
            if (string.IsNullOrEmpty(nombre))
            {
                MessageBox.Show("El nombre es obligatorio.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (comboBoxTipo.SelectedIndex == -1) // No hay selección
            {
                MessageBox.Show("Seleccione un tipo (genérico o patente).", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Asignar tipo según el índice seleccionado
            tipo = comboBoxTipo.SelectedIndex == 0 ? "generico" : "patente";

            // Depurar el valor de 'tipo' antes de la consulta
            MessageBox.Show($"Valor de tipo antes de actualizar: '{tipo}'", "Debug");

            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    using (MySqlTransaction transaction = connection.BeginTransaction())
                    {
                        try
                        {
                            // Actualizar el producto
                            string queryProducto = @"
                                UPDATE producto
                                SET nombre = @nombre,
                                    descripcion = @descripcion,
                                    precioCompra = @precioCompra,
                                    precioSinIva = @precioSinIva,
                                    stock = @stock,
                                    tipo = @tipo,
                                    lote = @lote,
                                    fechaFabricacion = @fechaFabricacion,
                                    fechaCaducidad = @fechaCaducidad,
                                    registroSanitario = @registroSanitario,
                                    condicionesAlmacenamiento = @condicionesAlmacenamiento,
                                    idProveedor = @idProveedor,
                                    idCategoria = @idCategoria,
                                    idSucursal = @idSucursal
                                WHERE idProducto = @idProducto";

                            using (MySqlCommand cmd = new MySqlCommand(queryProducto, connection, transaction))
                            {
                                cmd.Parameters.AddWithValue("@nombre", nombre);
                                cmd.Parameters.AddWithValue("@descripcion", descripcion);
                                cmd.Parameters.AddWithValue("@precioCompra", precioCompra);
                                cmd.Parameters.AddWithValue("@precioSinIva", precioSinIva);
                                cmd.Parameters.AddWithValue("@stock", stock);
                                cmd.Parameters.AddWithValue("@tipo", tipo); // Valor garantizado como "generico" o "patente"
                                cmd.Parameters.AddWithValue("@lote", lote);
                                cmd.Parameters.AddWithValue("@fechaFabricacion", fechaFabricacion);
                                cmd.Parameters.AddWithValue("@fechaCaducidad", fechaCaducidad);
                                cmd.Parameters.AddWithValue("@registroSanitario", registroSanitario);
                                cmd.Parameters.AddWithValue("@condicionesAlmacenamiento", condicionesAlmacenamiento);
                                cmd.Parameters.AddWithValue("@idProveedor", idProveedor);
                                cmd.Parameters.AddWithValue("@idCategoria", idCategoria);
                                cmd.Parameters.AddWithValue("@idSucursal", idSucursal);
                                cmd.Parameters.AddWithValue("@idProducto", idProducto);

                                cmd.ExecuteNonQuery();
                            }

                            // Verificar si el stock cambió y registrar movimiento
                            if (stock != stockOriginal)
                            {
                                string tipoMovimiento = stock > stockOriginal ? "Entrada" : "Salida";
                                int cantidadCambio = Math.Abs(stock - stockOriginal);

                                string queryMovimiento = @"
                                    INSERT INTO movimientoinventario 
                                    (idProducto, fechaMovimiento, tipoMovimiento, cantidad, descripcion, idEmpleado)
                                    VALUES 
                                    (@idProducto, NOW(), @tipoMovimiento, @cantidad, @descripcion, @idEmpleado)";

                                using (MySqlCommand cmdMovimiento = new MySqlCommand(queryMovimiento, connection, transaction))
                                {
                                    cmdMovimiento.Parameters.AddWithValue("@idProducto", idProducto);
                                    cmdMovimiento.Parameters.AddWithValue("@tipoMovimiento", tipoMovimiento);
                                    cmdMovimiento.Parameters.AddWithValue("@cantidad", cantidadCambio);
                                    cmdMovimiento.Parameters.AddWithValue("@descripcion", $"Ajuste de stock: {tipoMovimiento}");
                                    cmdMovimiento.Parameters.AddWithValue("@idEmpleado", 1); // Ajusta según el empleado actual
                                    cmdMovimiento.ExecuteNonQuery();
                                }
                            }

                            transaction.Commit();
                            MessageBox.Show("Producto actualizado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            MessageBox.Show("Error al actualizar el producto o registrar el movimiento: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al conectar con la base de datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void numericPrecioSinIva_ValueChanged(object sender, EventArgs e)
        {
            if (actualizando) return;
            actualizando = true;

            decimal precioSinIva = numericPrecioSinIva.Value;
            decimal precioConIva = precioSinIva * 1.16m;
            numericPrecioCompra.Value = precioConIva;

            actualizando = false;
        }

        private void numericPrecioCompra_ValueChanged(object sender, EventArgs e)
        {
            if (actualizando) return;
            actualizando = true;

            decimal precioConIva = numericPrecioCompra.Value;
            decimal precioSinIva = precioConIva / 1.16m;
            numericPrecioSinIva.Value = precioSinIva;

            actualizando = false;
        }
    }
}