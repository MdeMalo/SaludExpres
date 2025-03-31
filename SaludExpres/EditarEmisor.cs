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
    public partial class EditarEmisor : Form
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["SaludExpresConnection"].ConnectionString;
        private int idEmisor; // ID del emisor a editar
        public EditarEmisor(int id)
        {
            InitializeComponent();
            idEmisor = id;
            CargarDatosEmisor();
        }
        private void CargarDatosEmisor()
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT * FROM emisor WHERE idEmisor = @idEmisor";

                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@idEmisor", idEmisor);
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                textBoxNombre.Text = reader["nombre"].ToString();
                                textBoxRFC.Text = reader["RFC"].ToString();
                                textBoxCalle.Text = reader["calle"].ToString();
                                textBoxNumeroExterior.Text = reader["numeroExterior"].ToString();
                                textBoxNumeroInterior.Text = reader["numeroInterior"].ToString();
                                textBoxColonia.Text = reader["colonia"].ToString();
                                textBoxCiudad.Text = reader["ciudad"].ToString();
                                textBoxEstado.Text = reader["estado"].ToString();
                                textBoxCodigoPostal.Text = reader["codigoPostal"].ToString();
                                textBoxTelefono.Text = reader["telefono"].ToString();
                                textBoxEmail.Text = reader["email"].ToString();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos del emisor: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void EditarEmisor_Load(object sender, EventArgs e)
        {

        }

        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "UPDATE emisor SET nombre=@nombre, RFC=@RFC, calle=@calle, numeroExterior=@numeroExterior, " +
                                   "numeroInterior=@numeroInterior, colonia=@colonia, ciudad=@ciudad, estado=@estado, " +
                                   "codigoPostal=@codigoPostal, telefono=@telefono, email=@email WHERE idEmisor=@idEmisor";

                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@nombre", textBoxNombre.Text);
                        cmd.Parameters.AddWithValue("@RFC", textBoxRFC.Text);
                        cmd.Parameters.AddWithValue("@calle", textBoxCalle.Text);
                        cmd.Parameters.AddWithValue("@numeroExterior", textBoxNumeroExterior.Text);
                        cmd.Parameters.AddWithValue("@numeroInterior", textBoxNumeroInterior.Text);
                        cmd.Parameters.AddWithValue("@colonia", textBoxColonia.Text);
                        cmd.Parameters.AddWithValue("@ciudad", textBoxCiudad.Text);
                        cmd.Parameters.AddWithValue("@estado", textBoxEstado.Text);
                        cmd.Parameters.AddWithValue("@codigoPostal", textBoxCodigoPostal.Text);
                        cmd.Parameters.AddWithValue("@telefono", textBoxTelefono.Text);
                        cmd.Parameters.AddWithValue("@email", textBoxEmail.Text);
                        cmd.Parameters.AddWithValue("@idEmisor", idEmisor);

                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Emisor actualizado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close(); // Cerrar el formulario después de actualizar
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar el emisor: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            this.Close(); // Cerrar el formulario sin guardar cambios
        }
    }
}
