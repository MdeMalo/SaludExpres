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
    public partial class AgregarEmisor : Form
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["SaludExpresConnection"].ConnectionString;

        public AgregarEmisor()
        {
            InitializeComponent();
        }

        private void AgregarEmisor_Load(object sender, EventArgs e)
        {

        }

        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string nombre = textNombre.Text;
                string RFC = textBoxRFC.Text;
                string calle = textBoxCalle.Text;
                string numeroExterior = textBoxNumeroExterior.Text;
                string numeroInterior = textBoxNumeroInterior.Text;
                string colonia = textBoxColonia.Text;
                string ciudad = textBoxCiudad.Text;
                string estado = textBoxEstado.Text;
                string codigoPostal = textBoxCodigoPostal.Text;
                string telefono = textBoxTelefono.Text;
                string email = textBoxEmail.Text;

                // Verificar si todos los campos están completos
                if (string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(RFC))
                {
                    MessageBox.Show("Nombre y RFC son obligatorios.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "INSERT INTO emisor (nombre, RFC, calle, numeroExterior, numeroInterior, colonia, ciudad, estado, codigoPostal, telefono, email) " +
                                   "VALUES (@nombre, @RFC, @calle, @numeroExterior, @numeroInterior, @colonia, @ciudad, @estado, @codigoPostal, @telefono, @email)";

                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@nombre", nombre);
                        cmd.Parameters.AddWithValue("@RFC", RFC);
                        cmd.Parameters.AddWithValue("@calle", calle);
                        cmd.Parameters.AddWithValue("@numeroExterior", numeroExterior);
                        cmd.Parameters.AddWithValue("@numeroInterior", numeroInterior);
                        cmd.Parameters.AddWithValue("@colonia", colonia);
                        cmd.Parameters.AddWithValue("@ciudad", ciudad);
                        cmd.Parameters.AddWithValue("@estado", estado);
                        cmd.Parameters.AddWithValue("@codigoPostal", codigoPostal);
                        cmd.Parameters.AddWithValue("@telefono", telefono);
                        cmd.Parameters.AddWithValue("@email", email);

                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Emisor agregado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();  // Cerrar el formulario de agregar emisor
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar el emisor: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            this.Close();  // Cerrar el formulario de agregar emisor
        }
    }
}
