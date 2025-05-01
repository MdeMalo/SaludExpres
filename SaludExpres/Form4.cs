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
    public partial class RegistrarCliente : Form
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["SaludExpresConnection"].ConnectionString;

        public RegistrarCliente()
        {
            InitializeComponent();
            activeUI(this); // Llama a la función para aplicar el estilo de UI
        }

        private void RegistrarCliente_Load(object sender, EventArgs e)
        {

        }

        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(textNombre.Text))
            {
                MessageBox.Show("El nombre es obligatorio.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (!string.IsNullOrWhiteSpace(textCorreo.Text) && !textCorreo.Text.Contains("@"))
            {
                MessageBox.Show("Ingrese un correo válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void buttonGuardar_Click_1(object sender, EventArgs e)
        {
            if (!ValidarCampos()) return;

            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "INSERT INTO cliente (nombre, apellidoPaterno, apellidoMaterno, calle, numeroExterior, numeroInterior, colonia, ciudad, estado, codigoPostal, telefono, email, fechaRegistro) " +
                                   "VALUES (@nombre, @apellidoPaterno, @apellidoMaterno, @calle, @numeroExterior, @numeroInterior, @colonia, @ciudad, @estado, @codigoPostal, @telefono, @email, CURDATE())";

                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@nombre", textNombre.Text);
                        cmd.Parameters.AddWithValue("@apellidoPaterno", textApellidoPaterno.Text);
                        cmd.Parameters.AddWithValue("@apellidoMaterno", textApellidoMaterno.Text);
                        cmd.Parameters.AddWithValue("@calle", textCalle.Text);
                        cmd.Parameters.AddWithValue("@numeroExterior", textNoExt.Text);
                        cmd.Parameters.AddWithValue("@numeroInterior", textNoInt.Text);
                        cmd.Parameters.AddWithValue("@colonia", textColonia.Text);
                        cmd.Parameters.AddWithValue("@ciudad", textCiudad.Text);
                        cmd.Parameters.AddWithValue("@estado", textEstado.Text);
                        cmd.Parameters.AddWithValue("@codigoPostal", textCodigoPostal.Text);
                        cmd.Parameters.AddWithValue("@telefono", textTelefono.Text);
                        cmd.Parameters.AddWithValue("@email", textCorreo.Text);

                        cmd.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Cliente registrado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar el cliente: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
