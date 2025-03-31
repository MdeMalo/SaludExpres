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
    public partial class AdministrarEmisores : Form
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["SaludExpresConnection"].ConnectionString;

        public AdministrarEmisores()
        {
            InitializeComponent();
            CargarEmisores();
        }
        private void CargarEmisores()
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = @"
                SELECT 
                    idEmisor, 
                    nombre, 
                    RFC, 
                    telefono, 
                    email, 
                    CONCAT(IFNULL(calle, ''), ' #', IFNULL(numeroExterior, ''), ' ', IFNULL(numeroInterior, ''), ', ', IFNULL(colonia, ''), ', ', IFNULL(ciudad, ''), ', ', IFNULL(estado, ''), ', ', IFNULL(codigoPostal, '')) AS direccion
                FROM emisor";

                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    // Asignar la DataTable al DataGridView
                    dataGridEmisores.DataSource = dt;

                    // Renombrar las columnas para mayor claridad
                    dt.Columns["idEmisor"].ColumnName = "ID";
                    dt.Columns["nombre"].ColumnName = "Nombre";
                    dt.Columns["RFC"].ColumnName = "RFC";
                    dt.Columns["telefono"].ColumnName = "Teléfono";
                    dt.Columns["email"].ColumnName = "Correo";
                    dt.Columns["direccion"].ColumnName = "Dirección";

                    // Ajustar el tamaño de las columnas automáticamente
                    dataGridEmisores.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    dataGridEmisores.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar emisores: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AdministrarEmisores_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void buttonAgregar_Click(object sender, EventArgs e)
        {
            AgregarEmisor formRegistrarEmisor = new AgregarEmisor();
            formRegistrarEmisor.ShowDialog(); // Mostrar el formulario de agregar emisor
            CargarEmisores(); // Recargar los emisores después de agregar uno nuevo
        }

        private void buttonEliminar_Click(object sender, EventArgs e)
        {
            if (dataGridEmisores.SelectedRows.Count > 0)
            {
                int idEmisor = Convert.ToInt32(dataGridEmisores.SelectedRows[0].Cells["ID"].Value);

                DialogResult resultado = MessageBox.Show("¿Está seguro de eliminar este emisor?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (resultado == DialogResult.Yes)
                {
                    try
                    {
                        using (MySqlConnection connection = new MySqlConnection(connectionString))
                        {
                            connection.Open();
                            string query = "DELETE FROM emisor WHERE idEmisor = @idEmisor";

                            using (MySqlCommand cmd = new MySqlCommand(query, connection))
                            {
                                cmd.Parameters.AddWithValue("@idEmisor", idEmisor);
                                cmd.ExecuteNonQuery();
                            }
                        }

                        MessageBox.Show("Emisor eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarEmisores(); // Recargar la lista de emisores después de eliminar uno
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al eliminar emisor: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Seleccione un emisor para eliminar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void buttonEditar_Click_1(object sender, EventArgs e)
        {
            if (dataGridEmisores.SelectedRows.Count > 0)
            {
                int idEmisor = Convert.ToInt32(dataGridEmisores.SelectedRows[0].Cells["ID"].Value);
                EditarEmisor formEditarEmisor = new EditarEmisor(idEmisor); // Suponiendo que tienes un formulario de editar emisor
                formEditarEmisor.ShowDialog();
                CargarEmisores(); // Recargar la lista de emisores después de editar
            }
            else
            {
                MessageBox.Show("Seleccione un emisor para editar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void buttonCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
