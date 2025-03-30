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
    public partial class AgregarResponsableSanitario : Form
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["SaludExpresConnection"].ConnectionString;

        public AgregarResponsableSanitario()
        {
            InitializeComponent();
        }

        private void AgregarResponsableSanitario_Load(object sender, EventArgs e)
        {

        }

        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            // Obtener valores de los campos
            string nombre = textNombre.Text.Trim();
            string calle = textCalle.Text.Trim();
            string noExt = textNoExt.Text.Trim();
            string noInt = textNoInt.Text.Trim();
            string colonia = textColonia.Text.Trim();
            string ciudad = textCiudad.Text.Trim();
            string estado = textEstado.Text.Trim();
            string codigoPostal = textCodigoPostal.Text.Trim();
            string registroCOFEPRIS = textRegistroCOFEPRIS.Text.Trim();
            string correo = textCorreo.Text.Trim();
            string telefono = textTelefono.Text.Trim();

            // Validación: Campos obligatorios
            if (string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(registroCOFEPRIS) || string.IsNullOrEmpty(correo))
            {
                MessageBox.Show("Por favor, complete los campos obligatorios: Nombre, Registro COFEPRIS y Correo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = @"INSERT INTO responsablesanitario 
                                     (nombre, calle, numeroExterior, numeroInterior, colonia, ciudad, estado, codigoPostal, registroCOFEPRIS, correo, telefono) 
                                     VALUES 
                                     (@nombre, @calle, @noExt, @noInt, @colonia, @ciudad, @estado, @codigoPostal, @registroCOFEPRIS, @correo, @telefono)";

                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@nombre", nombre);
                        cmd.Parameters.AddWithValue("@calle", string.IsNullOrEmpty(calle) ? DBNull.Value : (object)calle);
                        cmd.Parameters.AddWithValue("@noExt", string.IsNullOrEmpty(noExt) ? DBNull.Value : (object)noExt);
                        cmd.Parameters.AddWithValue("@noInt", string.IsNullOrEmpty(noInt) ? DBNull.Value : (object)noInt);
                        cmd.Parameters.AddWithValue("@colonia", string.IsNullOrEmpty(colonia) ? DBNull.Value : (object)colonia);
                        cmd.Parameters.AddWithValue("@ciudad", string.IsNullOrEmpty(ciudad) ? DBNull.Value : (object)ciudad);
                        cmd.Parameters.AddWithValue("@estado", string.IsNullOrEmpty(estado) ? DBNull.Value : (object)estado);
                        cmd.Parameters.AddWithValue("@codigoPostal", string.IsNullOrEmpty(codigoPostal) ? DBNull.Value : (object)codigoPostal);
                        cmd.Parameters.AddWithValue("@registroCOFEPRIS", registroCOFEPRIS);
                        cmd.Parameters.AddWithValue("@correo", correo);
                        cmd.Parameters.AddWithValue("@telefono", string.IsNullOrEmpty(telefono) ? DBNull.Value : (object)telefono);

                        int filasAfectadas = cmd.ExecuteNonQuery();
                        if (filasAfectadas > 0)
                        {
                            MessageBox.Show("Responsable sanitario añadido con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close(); // Cierra la ventana
                        }
                        else
                        {
                            MessageBox.Show("No se pudo añadir el responsable sanitario.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar el responsable sanitario: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
