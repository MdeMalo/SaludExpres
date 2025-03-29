using MySql.Data.MySqlClient;
using System;
using System.Configuration;
using System.Windows.Forms;

namespace SaludExpres
{
    public partial class EditarSucursal : Form
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["SaludExpresConnection"].ConnectionString;
        private int idSucursal;

        public EditarSucursal(int idSucursal)
        {
            InitializeComponent();
            this.idSucursal = idSucursal;
        }

        private void EditarSucursal_Load(object sender, EventArgs e)
        {
            // Cargar los datos de la sucursal seleccionada al formulario
            CargarSucursal();
        }

        // Cargar los datos de la sucursal en los campos del formulario
        private void CargarSucursal()
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = @"SELECT nombre, calle, numeroExterior, numeroInterior, colonia, ciudad, estado, codigoPostal, telefono, idResponsable 
                                     FROM sucursal 
                                     WHERE idSucursal = @idSucursal";

                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@idSucursal", idSucursal);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Asignar los datos de la sucursal a los controles del formulario
                                textNombre.Text = reader["nombre"].ToString();
                                textCalle.Text = reader["calle"].ToString();
                                textNoExt.Text = reader["numeroExterior"].ToString();
                                textNoInt.Text = reader["numeroInterior"].ToString();
                                textColonia.Text = reader["colonia"].ToString();
                                textCiudad.Text = reader["ciudad"].ToString();
                                textEstado.Text = reader["estado"].ToString();
                                textCodigoPostal.Text = reader["codigoPostal"].ToString();
                                textTelefono.Text = reader["telefono"].ToString();
                                textIDRespSanitario.Text = reader["idResponsable"].ToString(); // Si es necesario mostrar el idResponsable
                            }
                            else
                            {
                                MessageBox.Show("No se encontró la sucursal.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos de la sucursal: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void buttonGuardar_Click_1(object sender, EventArgs e)
        {
            // Extraer valores de los controles
            string nombre = textNombre.Text.Trim();
            string calle = textCalle.Text.Trim();
            string noExt = textNoExt.Text.Trim();
            string noInt = textNoInt.Text.Trim();
            string colonia = textColonia.Text.Trim();
            string ciudad = textCiudad.Text.Trim();
            string estado = textEstado.Text.Trim();
            string codigoPostal = textCodigoPostal.Text.Trim();
            string telefono = textTelefono.Text.Trim();

            // Para idResponsable: si el campo está vacío o no es convertible, se usará NULL
            int idResponsable;
            object idRespParam = null;
            if (!string.IsNullOrEmpty(textIDRespSanitario.Text.Trim()) && int.TryParse(textIDRespSanitario.Text.Trim(), out idResponsable))
            {
                idRespParam = idResponsable;
            }

            // Validar campos obligatorios (por ejemplo, nombre, calle, colonia, ciudad, estado, codigo postal y teléfono)
            if (string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(calle) || string.IsNullOrEmpty(colonia) ||
                string.IsNullOrEmpty(ciudad) || string.IsNullOrEmpty(estado) || string.IsNullOrEmpty(codigoPostal) ||
                string.IsNullOrEmpty(telefono))
            {
                MessageBox.Show("Por favor, complete todos los campos obligatorios.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Actualizar en la base de datos
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = @"UPDATE sucursal 
                                     SET nombre = @nombre, 
                                         calle = @calle, 
                                         numeroExterior = @noExt, 
                                         numeroInterior = @noInt, 
                                         colonia = @colonia, 
                                         ciudad = @ciudad, 
                                         estado = @estado, 
                                         codigoPostal = @codigoPostal, 
                                         telefono = @telefono, 
                                         idResponsable = @idResponsable
                                     WHERE idSucursal = @idSucursal";

                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@nombre", nombre);
                        cmd.Parameters.AddWithValue("@calle", calle);
                        cmd.Parameters.AddWithValue("@noExt", noExt);
                        cmd.Parameters.AddWithValue("@noInt", noInt);
                        cmd.Parameters.AddWithValue("@colonia", colonia);
                        cmd.Parameters.AddWithValue("@ciudad", ciudad);
                        cmd.Parameters.AddWithValue("@estado", estado);
                        cmd.Parameters.AddWithValue("@codigoPostal", codigoPostal);
                        cmd.Parameters.AddWithValue("@telefono", telefono);

                        // Si idResponsable es null, se asigna DBNull.Value
                        if (idRespParam == null)
                            cmd.Parameters.AddWithValue("@idResponsable", DBNull.Value);
                        else
                            cmd.Parameters.AddWithValue("@idResponsable", idRespParam);

                        cmd.Parameters.AddWithValue("@idSucursal", idSucursal);

                        int filasAfectadas = cmd.ExecuteNonQuery();
                        if (filasAfectadas > 0)
                        {
                            MessageBox.Show("Sucursal actualizada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close(); // Cierra el formulario
                        }
                        else
                        {
                            MessageBox.Show("No se pudo actualizar la sucursal.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar la sucursal: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonCancelar_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
