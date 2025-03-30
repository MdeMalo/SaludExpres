using System;
using System.Configuration;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace SaludExpres
{
    public partial class RegistrarProducto : Form
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["SaludExpresConnection"].ConnectionString;
        private bool actualizando = false;

        public RegistrarProducto()
        {
            InitializeComponent();
            CargarProveedores();
            CargarCategorias();
            CargarSucursales();
        }

        private void CargarProveedores()
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT idProveedor, nombre FROM proveedor";
                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    comboBoxProveedor.DataSource = dt;
                    comboBoxProveedor.DisplayMember = "nombre";
                    comboBoxProveedor.ValueMember = "idProveedor";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar proveedores: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarCategorias()
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT idCategoria, nombre FROM categoria";
                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    comboBoxCategoria.DataSource = dt;
                    comboBoxCategoria.DisplayMember = "nombre";
                    comboBoxCategoria.ValueMember = "idCategoria";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar categorías: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarSucursales()
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT idSucursal, nombre FROM sucursal";
                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    comboBoxSucursal.DataSource = dt;
                    comboBoxSucursal.DisplayMember = "nombre";
                    comboBoxSucursal.ValueMember = "idSucursal";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar sucursales: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Calcula el precio de compra (con IVA) a partir del precio sin IVA
        private void numericPrecioSinIva_ValueChanged(object sender, EventArgs e)
        {
            decimal precioSinIva = numericPrecioSinIva.Value;
            decimal precioConIva = precioSinIva * 1.16m;
            numericPrecioCompra.Value = precioConIva; // Actualiza el precio con IVA
        }

        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            // Obtener datos de los controles
            string nombre = textNombre.Text.Trim();
            string descripcion = textDescripcion.Text.Trim();
            decimal precioSinIva = numericPrecioSinIva.Value;
            decimal precioCompra = numericPrecioCompra.Value;
            int stock = (int)numericStock.Value;
            string tipo = comboBoxTipo.SelectedItem.ToString();
            string lote = textLote.Text.Trim();
            DateTime fechaFabricacion = dateTimePickerFechaFabricacion.Value;
            DateTime fechaCaducidad = dateTimePickerFechaCaducidad.Value;
            string registroSanitario = textRegistroSanitario.Text.Trim();
            string condicionesAlmacenamiento = textCondicionesAlmacenamiento.Text.Trim();
            int idProveedor = (int)comboBoxProveedor.SelectedValue;
            int idCategoria = (int)comboBoxCategoria.SelectedValue;
            int idSucursal = (int)comboBoxSucursal.SelectedValue;

            // Validar campos obligatorios
            if (string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(tipo))
            {
                MessageBox.Show("Todos los campos son obligatorios.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Opcional: validar que fechaCaducidad sea mayor que fechaFabricacion
            if (fechaCaducidad <= fechaFabricacion)
            {
                MessageBox.Show("La fecha de caducidad debe ser posterior a la fecha de fabricación.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = @"
                        INSERT INTO producto 
                        (nombre, descripcion, precioCompra, precioSinIva, stock, tipo, lote, fechaFabricacion, fechaCaducidad, 
                         registroSanitario, condicionesAlmacenamiento, idProveedor, idCategoria, idSucursal)
                        VALUES 
                        (@nombre, @descripcion, @precioCompra, @precioSinIva, @stock, @tipo, @lote, @fechaFabricacion, @fechaCaducidad, 
                         @registroSanitario, @condicionesAlmacenamiento, @idProveedor, @idCategoria, @idSucursal)";

                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@nombre", nombre);
                        cmd.Parameters.AddWithValue("@descripcion", descripcion);
                        cmd.Parameters.AddWithValue("@precioCompra", precioCompra);
                        cmd.Parameters.AddWithValue("@precioSinIva", precioSinIva);
                        cmd.Parameters.AddWithValue("@stock", stock);
                        cmd.Parameters.AddWithValue("@tipo", tipo);
                        cmd.Parameters.AddWithValue("@lote", lote);
                        cmd.Parameters.AddWithValue("@fechaFabricacion", fechaFabricacion);
                        cmd.Parameters.AddWithValue("@fechaCaducidad", fechaCaducidad);
                        cmd.Parameters.AddWithValue("@registroSanitario", registroSanitario);
                        cmd.Parameters.AddWithValue("@condicionesAlmacenamiento", condicionesAlmacenamiento);
                        cmd.Parameters.AddWithValue("@idProveedor", idProveedor);
                        cmd.Parameters.AddWithValue("@idCategoria", idCategoria);
                        cmd.Parameters.AddWithValue("@idSucursal", idSucursal);

                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Producto registrado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar el producto: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void RegistrarProducto_Load(object sender, EventArgs e)
        {

        }

        private void numericPrecioCompra_ValueChanged(object sender, EventArgs e)
        {
            if (actualizando) return; // Evita recursión infinita
            actualizando = true;

            decimal precioConIva = numericPrecioCompra.Value;
            decimal precioSinIva = precioConIva / 1.16m; // Se divide entre 1.16 para obtener el valor sin IVA
            numericPrecioSinIva.Value = precioSinIva;

            actualizando = false;
        }

        private void numericPrecioSinIva_ValueChanged_1(object sender, EventArgs e)
        {
            if (actualizando) return;
            actualizando = true;
                
            decimal precioSinIva = numericPrecioSinIva.Value;
            decimal precioConIva = precioSinIva * 1.16m;
            numericPrecioCompra.Value = precioConIva; // Actualiza el campo con IVA

            actualizando = false;
        }
    }
}
