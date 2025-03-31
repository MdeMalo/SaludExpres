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
    public partial class AdministrarReceptores : Form
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["SaludExpresConnection"].ConnectionString;

        public AdministrarReceptores()
        {
            InitializeComponent();
            CargarReceptores();
        }

        private void CargarReceptores()
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT idReceptor, nombre, apellidoPaterno, apellidoMaterno, RFC, CONCAT(calle, ' #', numeroExterior, ' ', numeroInterior, ', ', colonia, ', ', ciudad, ', ', estado, ', ', codigoPostal) AS direccion FROM receptor";

                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    dataGridReceptores.DataSource = dt;

                    // Renombrar columnas
                    dt.Columns["idReceptor"].ColumnName = "ID";
                    dt.Columns["nombre"].ColumnName = "Nombre";
                    dt.Columns["apellidoPaterno"].ColumnName = "Apellido Paterno";
                    dt.Columns["apellidoMaterno"].ColumnName = "Apellido Materno";
                    dt.Columns["RFC"].ColumnName = "RFC";
                    dt.Columns["direccion"].ColumnName = "Dirección";

                    // Ajustar tamaño de columnas
                    dataGridReceptores.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar receptores: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AdministrarReceptores_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void buttonAgregar_Click(object sender, EventArgs e)
        {
            AgregarReceptor formAgregar = new AgregarReceptor();
            formAgregar.ShowDialog();
            CargarReceptores();
        }

        private void buttonEditar_Click(object sender, EventArgs e)
        {
            if (dataGridReceptores.SelectedRows.Count > 0)
            {
                int idReceptor = Convert.ToInt32(dataGridReceptores.SelectedRows[0].Cells["ID"].Value);
                EditarReceptor formEditar = new EditarReceptor(idReceptor);
                formEditar.ShowDialog();
                CargarReceptores();
            }
            else
            {
                MessageBox.Show("Seleccione un receptor para editar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void buttonEliminar_Click(object sender, EventArgs e)
        {
            if (dataGridReceptores.SelectedRows.Count > 0)
            {
                int idReceptor = Convert.ToInt32(dataGridReceptores.SelectedRows[0].Cells["ID"].Value);

                DialogResult resultado = MessageBox.Show("¿Está seguro de eliminar este receptor?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (resultado == DialogResult.Yes)
                {
                    try
                    {
                        using (MySqlConnection connection = new MySqlConnection(connectionString))
                        {
                            connection.Open();
                            string query = "DELETE FROM receptor WHERE idReceptor = @idReceptor";

                            using (MySqlCommand cmd = new MySqlCommand(query, connection))
                            {
                                cmd.Parameters.AddWithValue("@idReceptor", idReceptor);
                                cmd.ExecuteNonQuery();
                            }
                        }

                        MessageBox.Show("Receptor eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarReceptores();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al eliminar receptor: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Seleccione un receptor para eliminar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void buttonCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
