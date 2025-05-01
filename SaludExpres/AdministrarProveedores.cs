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
using static SaludExpres.systemUI;

namespace SaludExpres
{
    public partial class AdministrarProveedores : Form
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["SaludExpresConnection"].ConnectionString;

        public AdministrarProveedores()
        {
            InitializeComponent();
            CargarProveedores();
            activeUI(this); // Aplicar el efecto de acrílico a la ventana
        }

        private void CargarProveedores()
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT idProveedor, nombre, contacto, telefono, email, CONCAT(calle, ' #', numeroExterior, ' ', numeroInterior, ', ', colonia, ', ', ciudad, ', ', estado, ', ', codigoPostal) AS direccion, registroSanitario FROM proveedor";

                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    // Asignar la DataTable al DataGridView
                    dataGridProveedores.DataSource = dt;

                    // Renombrar las columnas para mayor claridad
                    dt.Columns["idProveedor"].ColumnName = "ID";
                    dt.Columns["nombre"].ColumnName = "Nombre";
                    dt.Columns["contacto"].ColumnName = "Contacto";
                    dt.Columns["telefono"].ColumnName = "Teléfono";
                    dt.Columns["email"].ColumnName = "Correo";
                    dt.Columns["direccion"].ColumnName = "Dirección";
                    dt.Columns["registroSanitario"].ColumnName = "Registro Sanitario";

                    // Ajustar el tamaño de las columnas automáticamente
                    dataGridProveedores.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    dataGridProveedores.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar proveedores: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AdministrarProveedores_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void buttonAgregar_Click(object sender, EventArgs e)
        {
            RegistrarProveedor formRegistrarProveedor = new RegistrarProveedor();
            formRegistrarProveedor.ShowDialog(); // Mostrar el formulario de agregar proveedor
            CargarProveedores(); // Recargar los proveedores después de agregar uno nuevo

        }

        private void buttonEditar_Click(object sender, EventArgs e)
        {
            if (dataGridProveedores.SelectedRows.Count > 0)
            {
                int idProveedor = Convert.ToInt32(dataGridProveedores.SelectedRows[0].Cells["ID"].Value);
                EditarProveedor formEditarProveedor = new EditarProveedor(idProveedor); // Suponiendo que tienes un formulario de editar proveedor
                formEditarProveedor.ShowDialog();
                CargarProveedores(); // Recargar la lista de proveedores después de editar
            }
            else
            {
                MessageBox.Show("Seleccione un proveedor para editar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void buttonEliminar_Click(object sender, EventArgs e)
        {
            if (dataGridProveedores.SelectedRows.Count > 0)
            {
                int idProveedor = Convert.ToInt32(dataGridProveedores.SelectedRows[0].Cells["ID"].Value);

                DialogResult resultado = MessageBox.Show("¿Está seguro de eliminar este proveedor?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (resultado == DialogResult.Yes)
                {
                    try
                    {
                        using (MySqlConnection connection = new MySqlConnection(connectionString))
                        {
                            connection.Open();
                            string query = "DELETE FROM proveedor WHERE idProveedor = @idProveedor";

                            using (MySqlCommand cmd = new MySqlCommand(query, connection))
                            {
                                cmd.Parameters.AddWithValue("@idProveedor", idProveedor);
                                cmd.ExecuteNonQuery();
                            }
                        }

                        MessageBox.Show("Proveedor eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarProveedores(); // Recargar la lista de proveedores después de eliminar uno
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al eliminar proveedor: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Seleccione un proveedor para eliminar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void buttonCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
