using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data;

namespace SaludExpres
{
    public partial class SucursalesAdmin : Form
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["SaludExpresConnection"].ConnectionString;

        public SucursalesAdmin()
        {
            InitializeComponent();
        }

        private void SucursalesAdmin_Load(object sender, EventArgs e)
        {
            // Cargar la lista de sucursales cuando se abra la ventana
            CargarSucursales();

            // Hacer la ventana de pantalla completa
            this.WindowState = FormWindowState.Maximized;
        }

        // Método para cargar las sucursales en el DataGrid
        private void CargarSucursales()
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = @"SELECT s.idSucursal, s.nombre, s.calle, s.numeroExterior, s.numeroInterior, 
                                    s.colonia, s.ciudad, s.estado, s.codigoPostal, s.telefono, r.nombre AS Responsable 
                             FROM sucursal s
                             LEFT JOIN responsablesanitario r ON s.idResponsable = r.idResponsable";

                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        dataGridSucursales.DataSource = dt;

                        // Ajustar automáticamente el tamaño de las columnas
                        dataGridSucursales.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                        dataGridSucursales.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar las sucursales: " + ex.Message);
            }
        }


        // Añadir nueva sucursal


        private void buttonAddSucursal_Click_1(object sender, EventArgs e)
        {
            AgregarSucursal formAddSucursal = new AgregarSucursal();
            formAddSucursal.Show();
        }

        private void buttonEditSucursal_Click(object sender, EventArgs e)
        {
            if (dataGridSucursales.SelectedRows.Count == 0)
            {
                MessageBox.Show("Por favor, selecciona una sucursal para editar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Obtener el ID de la sucursal seleccionada
            int idSucursal = Convert.ToInt32(dataGridSucursales.SelectedRows[0].Cells["idSucursal"].Value);

            // Obtener los detalles de la sucursal desde la base de datos
            EditarSucursal formEditSucursal = new EditarSucursal(idSucursal);
            formEditSucursal.Show();
        }

        private void buttonDeleteSucursal_Click_1(object sender, EventArgs e)
        {
            if (dataGridSucursales.SelectedRows.Count == 0)
            {
                MessageBox.Show("Por favor, selecciona una sucursal para eliminar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int idSucursal = Convert.ToInt32(dataGridSucursales.SelectedRows[0].Cells["idSucursal"].Value);

            if (MessageBox.Show("¿Estás seguro de que deseas eliminar esta sucursal?", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    using (MySqlConnection connection = new MySqlConnection(connectionString))
                    {
                        connection.Open();
                        string query = "DELETE FROM sucursal WHERE idSucursal = @idSucursal";

                        using (MySqlCommand cmd = new MySqlCommand(query, connection))
                        {
                            cmd.Parameters.AddWithValue("@idSucursal", idSucursal);
                            int filasAfectadas = cmd.ExecuteNonQuery();

                            if (filasAfectadas > 0)
                            {
                                MessageBox.Show("Sucursal eliminada correctamente.");
                                CargarSucursales(); // Refresca la lista de sucursales
                            }
                            else
                            {
                                MessageBox.Show("No se pudo eliminar la sucursal.");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al eliminar la sucursal: " + ex.Message);
                }
            }
        }

        private void buttonCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
