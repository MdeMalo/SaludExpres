using System;
using System.Configuration;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace SaludExpres
{
    public partial class RegistrarProveedor : Form
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["SaludExpresConnection"].ConnectionString;

        public RegistrarProveedor()
        {
            InitializeComponent();
        }

        private void RegistrarProveedor_Load(object sender, EventArgs e)
        {

        }

        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            // Obtener los datos del formulario
            string nombre = textNombre.Text.Trim();
            string contacto = textContacto.Text.Trim();
            string telefono = textTelefono.Text.Trim();
            string email = textEmail.Text.Trim();
            string calle = textCalle.Text.Trim();
            string numeroExterior = textNumeroExterior.Text.Trim();
            string numeroInterior = textNumeroInterior.Text.Trim();
            string colonia = textColonia.Text.Trim();
            string ciudad = textCiudad.Text.Trim();
            string estado = textEstado.Text.Trim();
            string codigoPostal = textCodigoPostal.Text.Trim();
            string registroSanitario = textRegistroSanitario.Text.Trim();

            // Validar campos obligatorios
            if (string.IsNullOrEmpty(nombre))
            {
                MessageBox.Show("El nombre del proveedor es obligatorio.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = @"
                        INSERT INTO proveedor (nombre, contacto, telefono, email, calle, numeroExterior, numeroInterior, colonia, ciudad, estado, codigoPostal, registroSanitario)
                        VALUES (@nombre, @contacto, @telefono, @email, @calle, @numeroExterior, @numeroInterior, @colonia, @ciudad, @estado, @codigoPostal, @registroSanitario)";

                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@nombre", nombre);
                        cmd.Parameters.AddWithValue("@contacto", contacto);
                        cmd.Parameters.AddWithValue("@telefono", telefono);
                        cmd.Parameters.AddWithValue("@email", email);
                        cmd.Parameters.AddWithValue("@calle", calle);
                        cmd.Parameters.AddWithValue("@numeroExterior", numeroExterior);
                        cmd.Parameters.AddWithValue("@numeroInterior", numeroInterior);
                        cmd.Parameters.AddWithValue("@colonia", colonia);
                        cmd.Parameters.AddWithValue("@ciudad", ciudad);
                        cmd.Parameters.AddWithValue("@estado", estado);
                        cmd.Parameters.AddWithValue("@codigoPostal", codigoPostal);
                        cmd.Parameters.AddWithValue("@registroSanitario", registroSanitario);

                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Proveedor registrado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close(); // Cerrar el formulario después de guardar
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar el proveedor: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
