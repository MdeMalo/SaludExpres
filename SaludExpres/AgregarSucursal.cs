using MySql.Data.MySqlClient;
using System;
using System.Configuration; // Para leer la cadena de conexión desde app.config
using System.Windows.Forms;
using static SaludExpres.systemUI;

namespace SaludExpres
{
    public partial class AgregarSucursal : Form
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["SaludExpresConnection"].ConnectionString;

        public AgregarSucursal()
        {
            InitializeComponent();
            activeUI(this); // Llama a la función para aplicar el estilo de UI
        }

        private void AgregarSucursal_Load(object sender, EventArgs e)
        {
            // Puedes inicializar controles aquí si lo deseas.
        }

        private void textNombre_TextChanged(object sender, EventArgs e)
        {
            // Opcional: validaciones en tiempo real.
        }

        private void textCalle_TextChanged(object sender, EventArgs e)
        {
            // Opcional
        }

        private void textNoExt_TextChanged(object sender, EventArgs e)
        {
            // Opcional
        }

        private void textNoInt_TextChanged(object sender, EventArgs e)
        {
            // Opcional
        }

        private void textIDRespSanitario_TextChanged(object sender, EventArgs e)
        {
            // Opcional: puedes validar que se ingrese un número válido.
        }

        private void textColonia_TextChanged(object sender, EventArgs e)
        {
            // Opcional
        }

        private void textCiudad_TextChanged(object sender, EventArgs e)
        {
            // Opcional
        }

        private void textEstado_TextChanged(object sender, EventArgs e)
        {
            // Opcional
        }

        private void textCodigoPostal_TextChanged(object sender, EventArgs e)
        {
            // Opcional
        }

        private void textTelefono_TextChanged(object sender, EventArgs e)
        {
            // Opcional
        }

        // Botón Guardar: insertar nueva sucursal en la base de datos
        private void buttonGuardar_Click(object sender, EventArgs e)
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

            // Insertar en la base de datos
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = @"INSERT INTO sucursal 
                                     (nombre, calle, numeroExterior, numeroInterior, colonia, ciudad, estado, codigoPostal, telefono, idResponsable) 
                                     VALUES 
                                     (@nombre, @calle, @noExt, @noInt, @colonia, @ciudad, @estado, @codigoPostal, @telefono, @idResponsable)";

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

                        int filasAfectadas = cmd.ExecuteNonQuery();
                        if (filasAfectadas > 0)
                        {
                            MessageBox.Show("Sucursal agregada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close(); // Cierra el formulario
                        }
                        else
                        {
                            MessageBox.Show("No se pudo agregar la sucursal.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar la sucursal: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Botón Cancelar: cierra el formulario sin realizar cambios
        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
