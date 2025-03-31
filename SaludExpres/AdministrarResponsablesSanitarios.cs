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
    public partial class AdministrarResponsablesSanitarios : Form
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["SaludExpresConnection"].ConnectionString;

        public AdministrarResponsablesSanitarios()
        {
            InitializeComponent();
        }

        private void AdministrarResponsablesSanitarios_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            CargarResponsables();
        }

        private void CargarResponsables()
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = @"
                SELECT 
                    idResponsable, 
                    CONCAT(nombre, ' ', apellidoPaterno, ' ', apellidoMaterno) AS nombreCompleto, 
                    CONCAT(
                        calle, ' #', numeroExterior, 
                        IF(numeroInterior IS NOT NULL AND numeroInterior <> '', ' Int. ' , ''), numeroInterior, 
                        ', ', colonia, ', ', ciudad, ', ', estado, ', C.P. ', codigoPostal
                    ) AS direccion, 
                    registroCOFEPRIS, 
                    correo, 
                    telefono 
                FROM responsablesanitario";

                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        dataGridResponsables.DataSource = dt;

                        // Ajustar el tamaño de las columnas automáticamente
                        dataGridResponsables.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                        dataGridResponsables.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

                        // Renombrar las columnas para mayor claridad (opcional)
                        dt.Columns["idResponsable"].ColumnName = "ID";
                        dt.Columns["nombreCompleto"].ColumnName = "Nombre";
                        dt.Columns["direccion"].ColumnName = "Dirección";
                        dt.Columns["registroCOFEPRIS"].ColumnName = "Registro COFEPRIS";
                        dt.Columns["correo"].ColumnName = "Correo";
                        dt.Columns["telefono"].ColumnName = "Teléfono";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar responsables sanitarios: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void buttonAgregar_Click(object sender, EventArgs e)
        {
            AgregarResponsableSanitario formResp = new AgregarResponsableSanitario();
            formResp.ShowDialog();
            CargarResponsables();
        }

        private void buttonEditar_Click(object sender, EventArgs e)
        {
            if (dataGridResponsables.SelectedRows.Count > 0)
            {
                int idResponsable = Convert.ToInt32(dataGridResponsables.SelectedRows[0].Cells["ID"].Value);
                EditarResponsableSanitario formEditarResp = new EditarResponsableSanitario(idResponsable);
                formEditarResp.ShowDialog();
                CargarResponsables(); // Recargar lista después de editar
            }
            else
            {
                MessageBox.Show("Seleccione un responsable sanitario para editar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void buttonEliminar_Click(object sender, EventArgs e)
        {
            if (dataGridResponsables.SelectedRows.Count > 0)
            {
                int idResponsable = Convert.ToInt32(dataGridResponsables.SelectedRows[0].Cells["idResponsable"].Value);

                DialogResult resultado = MessageBox.Show("¿Está seguro de eliminar este responsable sanitario?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (resultado == DialogResult.Yes)
                {
                    try
                    {
                        using (MySqlConnection connection = new MySqlConnection(connectionString))
                        {
                            connection.Open();
                            string query = "DELETE FROM responsablesanitario WHERE idResponsable = @idResponsable";

                            using (MySqlCommand cmd = new MySqlCommand(query, connection))
                            {
                                cmd.Parameters.AddWithValue("@idResponsable", idResponsable);
                                cmd.ExecuteNonQuery();
                            }
                        }

                        MessageBox.Show("Responsable sanitario eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarResponsables();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al eliminar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Seleccione un responsable sanitario para eliminar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void buttonCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
