using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Configuration;

namespace SaludExpres
{
    public partial class MenuRegularForm : Form
    {
        private int usuarioID;
        private string connectionString = ConfigurationManager.ConnectionStrings["SaludExpresConnection"].ConnectionString;

        public MenuRegularForm(int usuarioActualID)
        {
            InitializeComponent();
            this.usuarioID = usuarioActualID;
        }

        private void MenuRegularForm_Load(object sender, EventArgs e)
        {
            // Mostrar el mensaje de bienvenida en el Label existente
            string nombreUsuario = ObtenerNombreUsuario(usuarioID);
            labelBienvenida.Text = $"Bienvenido, {nombreUsuario}"; // Usa el nombre de tu Label si no es labelBienvenida
        }

        private void buttonRegistrarVentas_Click(object sender, EventArgs e)
        {
            int idEmpleado = ObtenerIdEmpleado(usuarioID);
            if (idEmpleado != -1)
            {
                RegistrarVenta registrarVenta = new RegistrarVenta(idEmpleado);
                registrarVenta.Show();
            }
            else
            {
                MessageBox.Show("No se encontró un empleado asociado a este usuario.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonRegistrarProducto_Click(object sender, EventArgs e)
        {
            Inventario inventario = new Inventario();
            inventario.Show();
        }

        private void buttonVerRecetas_Click(object sender, EventArgs e)
        {
            Recetas recetas = new Recetas();
            recetas.Show();
        }

        // Opción 1: Obtener el nombre del empleado asociado al usuario
        private string ObtenerNombreUsuario(int usuarioID)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = @"
                        SELECT CONCAT(e.nombre, ' ', e.apellidoPaterno) AS nombreCompleto
                        FROM usuario u
                        JOIN empleado e ON u.idEmpleado = e.idEmpleado
                        WHERE u.idUsuario = @idUsuario";
                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@idUsuario", usuarioID);
                        var result = cmd.ExecuteScalar();
                        return result != null ? result.ToString() : "Usuario desconocido";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener el nombre del usuario: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "Error";
            }
        }

        // Opción 2: Obtener el campo "usuario" de la tabla usuario (comenta/descomenta según prefieras)
        /*
        private string ObtenerNombreUsuario(int usuarioID)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT usuario FROM usuario WHERE idUsuario = @idUsuario";
                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@idUsuario", usuarioID);
                        var result = cmd.ExecuteScalar();
                        return result != null ? result.ToString() : "Usuario desconocido";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener el nombre del usuario: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "Error";
            }
        }
        */

        private int ObtenerIdEmpleado(int usuarioID)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT idEmpleado FROM usuario WHERE idUsuario = @idUsuario";
                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@idUsuario", usuarioID);
                        var result = cmd.ExecuteScalar();
                        return result != null ? Convert.ToInt32(result) : -1;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener el ID del empleado: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Estás seguro de que quieres cerrar sesión?", "Confirmar Logout",
                                          MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                // Crear una nueva instancia de Form1
                Form1 loginForm = new Form1();
                loginForm.Show(); // Mostrar el formulario de login

                // Cerrar el formulario actual (Form2)
                this.Close();
            }
        }

        private void labelBienvenida_Click(object sender, EventArgs e)
        {

        }
    }
}