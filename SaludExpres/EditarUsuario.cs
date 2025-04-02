using MySql.Data.MySqlClient;
using System;
using System.Configuration; // Para leer la cadena de conexión desde app.config
using System.Windows.Forms;
using BCrypt.Net; // Para manejar la encriptación de contraseñas con BCrypt

namespace SaludExpres
{
    public partial class EditarUsuario : Form
    {
        // Cadena de conexión obtenida desde app.config
        private string connectionString = ConfigurationManager.ConnectionStrings["SaludExpresConnection"].ConnectionString;
        private int idUsuario;
        private string nombreUsuario;

        // Constructor que recibe el idUsuario
        public EditarUsuario(int usuarioId)
        {
            InitializeComponent();
            idUsuario = usuarioId;

        }

        private void EditarUsuario_Load(object sender, EventArgs e)
        {
            // Cargar la información del usuario en el formulario
            CargarDatosUsuario();
            CargarRoles(); // Cargar los roles en el comboBox
        }

        private void CargarDatosUsuario()
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT u.usuario, u.email, u.password, u.idRol, u.activo, " +
                                   "e.nombre, e.apellidoPaterno, e.apellidoMaterno, e.cargo, e.salario " +
                                   "FROM usuario u " +
                                   "INNER JOIN empleado e ON u.idEmpleado = e.idEmpleado " +
                                   "WHERE u.idUsuario = @idUsuario";

                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@idUsuario", idUsuario);
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                textUsuario.Text = reader["usuario"].ToString();
                                textCorreo.Text = reader["email"].ToString();
                                // No mostrar el hash en el campo de contraseña; dejar vacío para indicar "mantener actual"
                                textContrasenia.Text = "";
                                comboBoxRol.SelectedItem = ObtenerRolNombre(Convert.ToInt32(reader["idRol"]));
                                checkBoxActivo.Checked = Convert.ToBoolean(reader["activo"]);
                                textNombre.Text = reader["nombre"].ToString();
                                textApellidoPaterno.Text = reader["apellidoPaterno"].ToString();
                                textApellidoMaterno.Text = reader["apellidoMaterno"].ToString();
                                textCargo.Text = reader["cargo"].ToString();
                                textSalario.Text = reader["salario"].ToString();
                            }
                            else
                            {
                                MessageBox.Show("No se encontró el usuario.");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos del usuario: " + ex.Message);
            }
        }

        private string ObtenerRolNombre(int idRol)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT nombre FROM rol WHERE idRol = @idRol";
                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@idRol", idRol);
                        return cmd.ExecuteScalar()?.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener el nombre del rol: " + ex.Message);
                return string.Empty;
            }
        }

        private void CargarRoles()
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT nombre FROM rol";
                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            comboBoxRol.Items.Add(reader["nombre"].ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los roles: " + ex.Message);
            }
        }

        // Botón Guardar: actualiza la información del usuario y del empleado
        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            string usuario = textUsuario.Text.Trim();
            string correo = textCorreo.Text.Trim();
            string contrasenia = textContrasenia.Text.Trim();
            string rolSeleccionado = comboBoxRol.SelectedItem?.ToString();
            bool activo = checkBoxActivo.Checked;

            string nombreEmpleado = textNombre.Text.Trim();
            string apellidoPaterno = textApellidoPaterno.Text.Trim();
            string apellidoMaterno = textApellidoMaterno.Text.Trim();
            string cargo = textCargo.Text.Trim();
            string salarioStr = textSalario.Text.Trim();

            // Validaciones básicas
            if (string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(correo) || string.IsNullOrEmpty(rolSeleccionado) ||
                string.IsNullOrEmpty(nombreEmpleado) || string.IsNullOrEmpty(apellidoPaterno))
            {
                MessageBox.Show("Por favor, complete todos los campos obligatorios.");
                return;
            }

            if (!correo.Contains("@") || !correo.Contains("."))
            {
                MessageBox.Show("Por favor, ingrese un correo válido.");
                return;
            }

            decimal salario = 0;
            if (!decimal.TryParse(salarioStr, out salario))
            {
                MessageBox.Show("Por favor, ingrese un salario válido.");
                return;
            }

            int idRol = ObtenerIdRol(rolSeleccionado);
            if (idRol == -1)
            {
                MessageBox.Show("Rol no encontrado.");
                return;
            }

            // Si se modifica la contraseña, generar el hash; si no se ingresa nada, se mantiene la actual.
            string hashedPassword = string.IsNullOrEmpty(contrasenia) ? null : BCrypt.Net.BCrypt.HashPassword(contrasenia, 12);

            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    using (MySqlTransaction transaction = connection.BeginTransaction())
                    {
                        // Actualizar el empleado
                        string queryEmpleado = "UPDATE empleado SET nombre = @nombre, apellidoPaterno = @apellidoPaterno, " +
                                               "apellidoMaterno = @apellidoMaterno, cargo = @cargo, salario = @salario " +
                                               "WHERE idEmpleado = (SELECT idEmpleado FROM usuario WHERE idUsuario = @idUsuario)";
                        using (MySqlCommand cmdEmpleado = new MySqlCommand(queryEmpleado, connection, transaction))
                        {
                            cmdEmpleado.Parameters.AddWithValue("@nombre", nombreEmpleado);
                            cmdEmpleado.Parameters.AddWithValue("@apellidoPaterno", apellidoPaterno);
                            cmdEmpleado.Parameters.AddWithValue("@apellidoMaterno", apellidoMaterno);
                            cmdEmpleado.Parameters.AddWithValue("@cargo", cargo);
                            cmdEmpleado.Parameters.AddWithValue("@salario", salario);
                            cmdEmpleado.Parameters.AddWithValue("@idUsuario", idUsuario);
                            cmdEmpleado.ExecuteNonQuery();
                        }

                        // Actualizar el usuario
                        string queryUsuario = "UPDATE usuario SET usuario = @usuario, email = @correo, idRol = @idRol, activo = @activo " +
                                              (hashedPassword != null ? ", password = @password" : "") +
                                              " WHERE idUsuario = @idUsuario";
                        using (MySqlCommand cmdUsuario = new MySqlCommand(queryUsuario, connection, transaction))
                        {
                            cmdUsuario.Parameters.AddWithValue("@usuario", usuario);
                            cmdUsuario.Parameters.AddWithValue("@correo", correo);
                            cmdUsuario.Parameters.AddWithValue("@idRol", idRol);
                            cmdUsuario.Parameters.AddWithValue("@activo", activo ? 1 : 0);
                            if (hashedPassword != null)
                            {
                                cmdUsuario.Parameters.AddWithValue("@password", hashedPassword);
                            }
                            cmdUsuario.Parameters.AddWithValue("@idUsuario", idUsuario);

                            cmdUsuario.ExecuteNonQuery();
                        }

                        transaction.Commit();
                    }
                }

                MessageBox.Show("Datos actualizados con éxito.");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar los datos: " + ex.Message);
            }
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private int ObtenerIdRol(string nombreRol)
        {
            int idRol = -1;
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT idRol FROM rol WHERE nombre = @nombreRol LIMIT 1";
                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@nombreRol", nombreRol);
                        var result = cmd.ExecuteScalar();
                        if (result != null)
                        {
                            idRol = Convert.ToInt32(result);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener el rol: " + ex.Message);
            }
            return idRol;
        }

        private bool UsuarioExiste(string usuario)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT COUNT(*) FROM usuario WHERE usuario = @usuario AND idUsuario != @idUsuario";
                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@usuario", usuario);
                        cmd.Parameters.AddWithValue("@idUsuario", idUsuario);
                        int count = Convert.ToInt32(cmd.ExecuteScalar());
                        return count > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al verificar el usuario: " + ex.Message);
                return true; // Para prevenir inserciones erróneas si hay un problema
            }
        }

        private void buttonGuardar_Click_1(object sender, EventArgs e)
        {
            // Extraer datos de los controles
            string usuario = textUsuario.Text.Trim();
            string correo = textCorreo.Text.Trim();
            string contrasenia = textContrasenia.Text.Trim();
            string rolSeleccionado = comboBoxRol.SelectedItem?.ToString();
            bool activo = checkBoxActivo.Checked;

            string nombreEmpleado = textNombre.Text.Trim();
            string apellidoPaterno = textApellidoPaterno.Text.Trim();
            string apellidoMaterno = textApellidoMaterno.Text.Trim();
            string cargo = textCargo.Text.Trim();
            string salarioStr = textSalario.Text.Trim();

            if (UsuarioExiste(usuario))
            {
                MessageBox.Show("El nombre de usuario ya existe. Por favor, elija otro.");
                return;
            }

            // Validaciones básicas
            if (string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(correo) || string.IsNullOrEmpty(rolSeleccionado) ||
                string.IsNullOrEmpty(nombreEmpleado) || string.IsNullOrEmpty(apellidoPaterno))
            {
                MessageBox.Show("Por favor, complete todos los campos obligatorios.");
                return;
            }

            if (!correo.Contains("@") || !correo.Contains("."))
            {
                MessageBox.Show("Por favor, ingrese un correo válido.");
                return;
            }

            if (!decimal.TryParse(salarioStr, out decimal salario))
            {
                MessageBox.Show("Por favor, ingrese un salario válido.");
                return;
            }

            int idRol = ObtenerIdRol(rolSeleccionado);
            if (idRol == -1)
            {
                MessageBox.Show("Rol no encontrado.");
                return;
            }

            // Si se ingresó una nueva contraseña, generar el hash; si el campo está vacío, se mantiene la actual.
            string hashedPassword = string.IsNullOrEmpty(contrasenia) ? null : BCrypt.Net.BCrypt.HashPassword(contrasenia, 12);

            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    using (MySqlTransaction transaction = connection.BeginTransaction())
                    {
                        // Actualizar los datos del empleado
                        string queryEmpleado = "UPDATE empleado SET nombre = @nombre, apellidoPaterno = @apellidoPaterno, " +
                                               "apellidoMaterno = @apellidoMaterno, cargo = @cargo, salario = @salario " +
                                               "WHERE idEmpleado = (SELECT idEmpleado FROM usuario WHERE idUsuario = @idUsuario)";
                        using (MySqlCommand cmdEmpleado = new MySqlCommand(queryEmpleado, connection, transaction))
                        {
                            cmdEmpleado.Parameters.AddWithValue("@nombre", nombreEmpleado);
                            cmdEmpleado.Parameters.AddWithValue("@apellidoPaterno", apellidoPaterno);
                            cmdEmpleado.Parameters.AddWithValue("@apellidoMaterno", apellidoMaterno);
                            cmdEmpleado.Parameters.AddWithValue("@cargo", cargo);
                            cmdEmpleado.Parameters.AddWithValue("@salario", salario);
                            cmdEmpleado.Parameters.AddWithValue("@idUsuario", idUsuario);
                            cmdEmpleado.ExecuteNonQuery();
                        }

                        // Actualizar los datos del usuario
                        string queryUsuario = "UPDATE usuario SET usuario = @usuario, email = @correo, idRol = @idRol, activo = @activo" +
                                              (hashedPassword != null ? ", password = @password" : "") +
                                              " WHERE idUsuario = @idUsuario";
                        using (MySqlCommand cmdUsuario = new MySqlCommand(queryUsuario, connection, transaction))
                        {
                            cmdUsuario.Parameters.AddWithValue("@usuario", usuario);
                            cmdUsuario.Parameters.AddWithValue("@correo", correo);
                            cmdUsuario.Parameters.AddWithValue("@idRol", idRol);
                            cmdUsuario.Parameters.AddWithValue("@activo", activo ? 1 : 0);
                            cmdUsuario.Parameters.AddWithValue("@idUsuario", idUsuario);
                            if (hashedPassword != null)
                            {
                                cmdUsuario.Parameters.AddWithValue("@password", hashedPassword);
                            }
                            cmdUsuario.ExecuteNonQuery();
                        }

                        transaction.Commit();
                    }
                }

                MessageBox.Show("Datos actualizados con éxito.");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar los datos: " + ex.Message);
            }
        }

        private void comboBoxSucursal_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
