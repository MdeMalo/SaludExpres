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
    public partial class EditarResponsableSanitario : Form
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["SaludExpresConnection"].ConnectionString;
        private int idResponsable;
        public EditarResponsableSanitario(int idResponsable)
        {
            InitializeComponent();
            this.idResponsable = idResponsable;
        }

        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = @"UPDATE responsablesanitario 
                                    SET nombre = @nombre, calle = @calle, numeroExterior = @noExt, numeroInterior = @noInt, 
                                        colonia = @colonia, ciudad = @ciudad, estado = @estado, codigoPostal = @codigoPostal, 
                                        registroCOFEPRIS = @registroCOFEPRIS, correo = @correo, telefono = @telefono 
                                    WHERE idResponsable = @idResponsable";

                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@nombre", textNombre.Text);
                        cmd.Parameters.AddWithValue("@calle", textCalle.Text);
                        cmd.Parameters.AddWithValue("@noExt", textNoExt.Text);
                        cmd.Parameters.AddWithValue("@noInt", textNoInt.Text);
                        cmd.Parameters.AddWithValue("@colonia", textColonia.Text);
                        cmd.Parameters.AddWithValue("@ciudad", textCiudad.Text);
                        cmd.Parameters.AddWithValue("@estado", textEstado.Text);
                        cmd.Parameters.AddWithValue("@codigoPostal", textCodigoPostal.Text);
                        cmd.Parameters.AddWithValue("@registroCOFEPRIS", textRegistroCOFEPRIS.Text);
                        cmd.Parameters.AddWithValue("@correo", textCorreo.Text);
                        cmd.Parameters.AddWithValue("@telefono", textTelefono.Text);
                        cmd.Parameters.AddWithValue("@idResponsable", idResponsable);

                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Responsable sanitario actualizado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void EditarResponsableSanitario_Load(object sender, EventArgs e)
        {
            CargarDatosResponsable();
        }

        private void CargarDatosResponsable()
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT * FROM responsablesanitario WHERE idResponsable = @idResponsable";

                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@idResponsable", idResponsable);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                textNombre.Text = reader["nombre"].ToString();
                                textCalle.Text = reader["calle"].ToString();
                                textNoExt.Text = reader["numeroExterior"].ToString();
                                textNoInt.Text = reader["numeroInterior"].ToString();
                                textColonia.Text = reader["colonia"].ToString();
                                textCiudad.Text = reader["ciudad"].ToString();
                                textEstado.Text = reader["estado"].ToString();
                                textCodigoPostal.Text = reader["codigoPostal"].ToString();
                                textRegistroCOFEPRIS.Text = reader["registroCOFEPRIS"].ToString();
                                textCorreo.Text = reader["correo"].ToString();
                                textTelefono.Text = reader["telefono"].ToString();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
