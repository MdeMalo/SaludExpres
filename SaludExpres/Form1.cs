using System;
using System.Configuration;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using BCrypt.Net;

namespace SaludExpres
{
    public partial class Form1 : Form
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["SaludExpresConnection"].ConnectionString;
        public int UsuarioActualID { get; private set; }
        public string RolUsuario { get; private set; } // Guardar el nombre del rol

        public Form1()
        {
            InitializeComponent();
        }

        private void buttonIngresar_Click(object sender, EventArgs e)
        {
            string usuario = textBoxCorreo.Text.Trim(); // Asumiendo que este es el campo para "usuario" o "email"
            string contrasenia = textBoxContrasenia.Text;

            if (string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(contrasenia))
            {
                MessageBox.Show("Por favor, ingrese su usuario y contraseña.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (VerificarCredenciales(usuario, contrasenia))
            {
                if (RolUsuario == "Administrador")
                {
                    MessageBox.Show($"Bienvenido, {usuario} (Administrador).", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Form2 form2 = new Form2();
                    form2.UsuarioID = UsuarioActualID;
                    form2.Show();
                    this.Hide();
                }
                else // Cualquier otro rol (Regular u otros)
                {
                    MessageBox.Show($"Bienvenido, {usuario}.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MenuRegularForm menuRegular = new MenuRegularForm(UsuarioActualID);
                    menuRegular.Show();
                    this.Hide();
                }
            }
            else
            {
                MessageBox.Show("Credenciales incorrectas. Intente nuevamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool VerificarCredenciales(string usuario, string contrasenia)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    // Consulta que une usuario con rol para obtener el nombre del rol
                    string query = @"
                        SELECT u.idUsuario, u.password, r.nombre AS rol
                        FROM usuario u
                        LEFT JOIN rol r ON u.idRol = r.idRol
                        WHERE (u.usuario = @usuario OR u.email = @usuario) AND u.activo = 1";
                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@usuario", usuario);
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                int userId = reader.GetInt32("idUsuario");
                                string storedHash = reader.GetString("password");
                                string rol = reader.IsDBNull(reader.GetOrdinal("rol")) ? "Regular" : reader.GetString("rol"); // Default a "Regular" si no hay rol

                                // Verificación especial para "root" (opcional)
                                if (usuario == "root" && storedHash == "root")
                                {
                                    UsuarioActualID = userId;
                                    RolUsuario = "Administrador";
                                    return true;
                                }

                                // Verificación con BCrypt para contraseñas hasheadas
                                bool verified = BCrypt.Net.BCrypt.Verify(contrasenia, storedHash);
                                if (verified)
                                {
                                    UsuarioActualID = userId;
                                    RolUsuario = rol; // Guardar el nombre del rol
                                }
                                return verified;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al conectarse a la base de datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return false;
        }

        private void buttonRecContra_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Solicita ayuda a tu encargado de área.", "Recuperar contraseña", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void buttonCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}