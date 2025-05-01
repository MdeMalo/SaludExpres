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
    public partial class EditarProveedor : Form
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["SaludExpresConnection"].ConnectionString;
        private int idProveedor; // ID del proveedor a editar
        public EditarProveedor(int idProveedor)
        {
            InitializeComponent();
            this.idProveedor = idProveedor;
            CargarProveedor();
            activeUI(this); // Llama a la función para aplicar el estilo de UI
        }

        private void CargarProveedor()
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT * FROM proveedor WHERE idProveedor = @idProveedor";

                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@idProveedor", idProveedor);
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                textNombre.Text = reader["nombre"].ToString();
                                textContacto.Text = reader["contacto"].ToString();
                                textTelefono.Text = reader["telefono"].ToString();
                                textEmail.Text = reader["email"].ToString();
                                textCalle.Text = reader["calle"].ToString();
                                textNumeroExterior.Text = reader["numeroExterior"].ToString();
                                textNumeroInterior.Text = reader["numeroInterior"].ToString();
                                textColonia.Text = reader["colonia"].ToString();
                                textCiudad.Text = reader["ciudad"].ToString();
                                textEstado.Text = reader["estado"].ToString();
                                textCodigoPostal.Text = reader["codigoPostal"].ToString();
                                textRegistroSanitario.Text = reader["registroSanitario"].ToString();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar el proveedor: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void EditarProveedor_Load(object sender, EventArgs e)
        {

        }

        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            string nombre = textNombre.Text;
            string contacto = textContacto.Text;
            string telefono = textTelefono.Text;
            string email = textEmail.Text;
            string calle = textCalle.Text;
            string numeroExterior = textNumeroExterior.Text;
            string numeroInterior = textNumeroInterior.Text;
            string colonia = textColonia.Text;
            string ciudad = textCiudad.Text;
            string estado = textEstado.Text;
            string codigoPostal = textCodigoPostal.Text;
            string registroSanitario = textRegistroSanitario.Text;

            if (string.IsNullOrWhiteSpace(nombre))
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
                        UPDATE proveedor 
                        SET nombre = @nombre, contacto = @contacto, telefono = @telefono, email = @email, 
                            calle = @calle, numeroExterior = @numeroExterior, numeroInterior = @numeroInterior, 
                            colonia = @colonia, ciudad = @ciudad, estado = @estado, 
                            codigoPostal = @codigoPostal, registroSanitario = @registroSanitario
                        WHERE idProveedor = @idProveedor";

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
                        cmd.Parameters.AddWithValue("@idProveedor", idProveedor);

                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Proveedor actualizado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close(); // Cerrar la ventana después de guardar
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar el proveedor: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
