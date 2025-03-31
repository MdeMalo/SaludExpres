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
    public partial class EditarReceptor : Form
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["SaludExpresConnection"].ConnectionString;
        private int idReceptor;
        public EditarReceptor(int idReceptor)
        {
            InitializeComponent();
            this.idReceptor = idReceptor;
            CargarDatosReceptor();
        }

        private void CargarDatosReceptor()
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT nombre, apellidoPaterno, apellidoMaterno, RFC, calle, numeroExterior, numeroInterior, colonia, ciudad, estado, codigoPostal FROM receptor WHERE idReceptor = @idReceptor";
                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@idReceptor", idReceptor);
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                textBoxNombre.Text = reader["nombre"].ToString();
                                textBoxApellidoPaterno.Text = reader["apellidoPaterno"].ToString();
                                textBoxApellidoMaterno.Text = reader["apellidoMaterno"].ToString();
                                textBoxRFC.Text = reader["RFC"].ToString();
                                textBoxCalle.Text = reader["calle"].ToString();
                                textBoxNumeroExterior.Text = reader["numeroExterior"].ToString();
                                textBoxNumeroInterior.Text = reader["numeroInterior"].ToString();
                                textBoxColonia.Text = reader["colonia"].ToString();
                                textBoxCiudad.Text = reader["ciudad"].ToString();
                                textBoxEstado.Text = reader["estado"].ToString();
                                textBoxCodigoPostal.Text = reader["codigoPostal"].ToString();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos del receptor: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void EditarReceptor_Load(object sender, EventArgs e)
        {

        }

        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "UPDATE receptor SET nombre=@nombre, apellidoPaterno=@apellidoPaterno, apellidoMaterno=@apellidoMaterno, RFC=@RFC, calle=@calle, numeroExterior=@numeroExterior, numeroInterior=@numeroInterior, colonia=@colonia, ciudad=@ciudad, estado=@estado, codigoPostal=@codigoPostal WHERE idReceptor=@idReceptor";
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
                        cmd.Parameters.AddWithValue("@idReceptor", idReceptor);

                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Receptor actualizado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar el receptor: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
