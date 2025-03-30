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
                                numericStock.Value = Convert.ToInt32(reader["stock"]);

                                // Seleccionar el tipo correctamente
                                comboBoxTipo.SelectedItem = reader["tipo"].ToString(); // usa SelectedItem ya que 'tipo' es una cadena directa

                                textLote.Text = reader["lote"].ToString();
                                dateTimePickerFechaFabricacion.Value = Convert.ToDateTime(reader["fechaFabricacion"]);
                                dateTimePickerFechaCaducidad.Value = Convert.ToDateTime(reader["fechaCaducidad"]);
                                textRegistroSanitario.Text = reader["registroSanitario"].ToString();
                                textCondicionesAlmacenamiento.Text = reader["condicionesAlmacenamiento"].ToString();

                                // Seleccionar el proveedor usando el ID
                                comboBoxProveedor.SelectedValue = reader["idProveedor"];
                                // Seleccionar la categoría usando el ID
                                comboBoxCategoria.SelectedValue = reader["idCategoria"];
                                // Seleccionar la sucursal usando el ID
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

                    // Llenar ComboBox Tipo (Ejemplo: 'generico' y 'patente')
                    string queryTipo = "SELECT 'generico' AS tipo UNION SELECT 'patente' AS tipo";
                    MySqlDataAdapter adapterTipo = new MySqlDataAdapter(queryTipo, connection);
                    DataTable dtTipo = new DataTable();
                    adapterTipo.Fill(dtTipo);
                    comboBoxTipo.DataSource = dtTipo;
                    comboBoxTipo.DisplayMember = "tipo";
                    comboBoxTipo.ValueMember = "tipo";

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
            string tipo = comboBoxTipo.SelectedItem.ToString();
            string lote = textLote.Text.Trim();
            DateTime fechaFabricacion = dateTimePickerFechaFabricacion.Value;
            DateTime fechaCaducidad = dateTimePickerFechaCaducidad.Value;
            string registroSanitario = textRegistroSanitario.Text.Trim();
            string condicionesAlmacenamiento = textCondicionesAlmacenamiento.Text.Trim();

            // Validar campos obligatorios
            if (string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(tipo))
            {
                MessageBox.Show("Todos los campos son obligatorios.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = @"
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
                        condicionesAlmacenamiento = @condicionesAlmacenamiento
                    WHERE idProducto = @idProducto";

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
                        cmd.Parameters.AddWithValue("@idProducto", idProducto);

                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Producto actualizado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar el producto: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
