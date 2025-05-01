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
    public partial class AgregarReceptor : Form
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["SaludExpresConnection"].ConnectionString;

        public AgregarReceptor()
        {
            InitializeComponent();
            activeUI(this); // Llama a la función para aplicar el estilo de UI
        }

        private void AgregarReceptor_Load(object sender, EventArgs e)
        {

        }

        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "INSERT INTO receptor (nombre, apellidoPaterno, apellidoMaterno, RFC, calle, numeroExterior, numeroInterior, colonia, ciudad, estado, codigoPostal) " +
                                   "VALUES (@nombre, @apellidoPaterno, @apellidoMaterno, @RFC, @calle, @numeroExterior, @numeroInterior, @colonia, @ciudad, @estado, @codigoPostal)";

                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@nombre", textBoxNombre.Text);
                        cmd.Parameters.AddWithValue("@apellidoPaterno", textBoxApellidoPaterno.Text);
                        cmd.Parameters.AddWithValue("@apellidoMaterno", textBoxApellidoMaterno.Text);
                        cmd.Parameters.AddWithValue("@RFC", textBoxRFC.Text);
                        cmd.Parameters.AddWithValue("@calle", textBoxCalle.Text);
                        cmd.Parameters.AddWithValue("@numeroExterior", textBoxNumeroExterior.Text);
                        cmd.Parameters.AddWithValue("@numeroInterior", textBoxNumeroInterior.Text);
                        cmd.Parameters.AddWithValue("@colonia", textBoxColonia.Text);
                        cmd.Parameters.AddWithValue("@ciudad", textBoxCiudad.Text);
                        cmd.Parameters.AddWithValue("@estado", textBoxEstado.Text);
                        cmd.Parameters.AddWithValue("@codigoPostal", textBoxCodigoPostal.Text);

                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Receptor agregado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar receptor: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
