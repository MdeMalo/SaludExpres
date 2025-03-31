using MySql.Data.MySqlClient;
using System;
using System.Configuration;
using System.Windows.Forms;
using BCrypt.Net;
using Microsoft.VisualBasic.ApplicationServices;

namespace SaludExpres
{
    public partial class Form1 : Form
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["SaludExpresConnection"].ConnectionString;

        // Usuario root que tiene permisos para registrar nuevos usuarios
        private const string RootUsuario = "root";
        public int UsuarioActualID { get; private set; }

        public Form1()
        {
            InitializeComponent();
        }

        private void buttonIngresar_Click(object sender, EventArgs e)
        {
            string usuario = textBoxCorreo.Text.Trim();
            string contrasenia = textBoxContrasenia.Text;

            if (string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(contrasenia))
            {
                MessageBox.Show("Por favor, ingrese su usuario y contraseña.");
                return;
            }

            if (VerificarCredenciales(usuario, contrasenia))
            {
                if (usuario == RootUsuario)
                {
                    MessageBox.Show("Bienvenido, usuario root.");
                    // Redirigir al usuario a la siguiente ventana (Form2)
                    Form2 form2 = new Form2();
                    form2.UsuarioID = UsuarioActualID;
                    form2.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Bienvenido, " + usuario + ".");
                }

            }
            else
            {
                MessageBox.Show("Credenciales incorrectas. Intente nuevamente.");
            }
        }

        private bool VerificarCredenciales(string usuario, string contrasenia)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT idUsuario, password FROM usuario WHERE usuario = @usuario AND activo = 1";
                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@usuario", usuario);
                        var result = cmd.ExecuteScalar();
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                int userId = reader.GetInt32("idUsuario");
                                string storedHash = reader.GetString("password");

                                if (usuario == "root" && storedHash == "root")
                                {
                                    UsuarioActualID = userId; // Guardar el ID
                                    return true;
                                }

                                bool verified = BCrypt.Net.BCrypt.Verify(contrasenia, storedHash);
                                if (verified)
                                {
                                    UsuarioActualID = userId; // Guardar el ID
                                }
                                return verified;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al conectarse a la base de datos: " + ex.Message);
            }
            return false;
        }

        private bool UsuarioExiste(string usuario)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT COUNT(*) FROM usuario WHERE usuario = @usuario";
                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@usuario", usuario);
                        int count = Convert.ToInt32(cmd.ExecuteScalar());
                        return count > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al verificar el usuario: " + ex.Message);
                return false;
            }
        }

        private void RegistrarNuevoUsuario(string usuario, string contrasenia)
        {
            if (usuario.ToLower() != RootUsuario)
            {
                MessageBox.Show("Solo el usuario root puede registrar nuevos usuarios.");
                return;
            }

            if (string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(contrasenia))
            {
                MessageBox.Show("Por favor, ingrese un usuario y contraseña válidos.");
                return;
            }

            if (UsuarioExiste(usuario))
            {
                MessageBox.Show("El usuario ya está registrado.");
                return;
            }

            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(contrasenia);

            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "INSERT INTO usuario (usuario, password, activo, fechaCreacion) " +
                                   "VALUES (@usuario, @password, 1, NOW())";
                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@usuario", usuario);
                        cmd.Parameters.AddWithValue("@password", hashedPassword);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Usuario registrado con éxito.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar el usuario: " + ex.Message);
            }
        }

        private void buttonRecContra_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Solicita ayuda a tu encargado de Area");
        }

        private void buttonCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
