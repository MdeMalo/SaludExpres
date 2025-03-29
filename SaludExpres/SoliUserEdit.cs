using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Configuration;

namespace SaludExpres
{
    public partial class SoliUserEdit : Form
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["SaludExpresConnection"].ConnectionString;
        private int idUsuario = -1;
        private string nombreUsuario;

        public SoliUserEdit()
        {
            InitializeComponent();
        }

        private void buttonEnviar_Click(object sender, EventArgs e)
        {
            // Validación: asegurarse de que el usuario ingresó un ID válido
            if (!int.TryParse(textUser.Text.Trim(), out idUsuario))
            {
                MessageBox.Show("Por favor, ingrese un ID de usuario válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Verificar si el usuario existe en la base de datos
            if (!verificarUsuario(idUsuario))
            {
                return; // Si el usuario no existe, se detiene aquí
            }

            // Si el usuario existe, abrir el formulario de edición
            EditarUsuario editarUsuarioForm = new EditarUsuario(idUsuario);
            editarUsuarioForm.ShowDialog();

            // Cerrar la ventana actual después de la edición
            this.Close();
        }

        private bool verificarUsuario(int usuarioId)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT usuario FROM usuario WHERE idUsuario = @idUsuario";
                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@idUsuario", usuarioId);
                        string usuarioEncontrado = cmd.ExecuteScalar() as string;

                        if (!string.IsNullOrEmpty(usuarioEncontrado))
                        {
                            nombreUsuario = usuarioEncontrado;
                            return true;
                        }
                        else
                        {
                            MessageBox.Show("El usuario no existe.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al verificar el usuario: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}
