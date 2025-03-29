using MySql.Data.MySqlClient;
using System;
using System.Configuration; // Para leer la cadena de conexión desde app.config
using System.Windows.Forms;
using BCrypt.Net; // Asegúrate de tener instalado el paquete NuGet BCrypt.Net-Next

namespace SaludExpres
{
    public partial class AgregarUsuarios : Form
    {
        // Cadena de conexión obtenida desde app.config
        private string connectionString = ConfigurationManager.ConnectionStrings["SaludExpresConnection"].ConnectionString;

        public AgregarUsuarios()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            // Acción opcional al hacer clic en la etiqueta
        }

        private void textUsuario_TextChanged(object sender, EventArgs e)
        {
            // Validaciones en tiempo real para el usuario (opcional)
        }

        private void textContrasenia_TextChanged(object sender, EventArgs e)
        {
            // Validaciones en tiempo real para la contraseña (opcional)
        }

        private void textCorreo_TextChanged(object sender, EventArgs e)
        {
            // Validaciones en tiempo real para el correo (opcional)
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Capturar el rol seleccionado, por ejemplo "Cajero", "Administrador", etc.
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            // Este checkBox define si el usuario estará activo o inactivo.
        }

        // Botón Guardar: registra el nuevo usuario y crea el empleado asociado
        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            // Campos para el usuario
            string usuario = textUsuario.Text.Trim();
            string correo = textCorreo.Text.Trim();
            string contrasenia = textContrasenia.Text; // La contraseña puede contener espacios
            string rolSeleccionado = comboBox1.SelectedItem?.ToString();
            bool activo = checkBox1.Checked;

            // Campos para el empleado
            string nombreEmpleado = textNombre.Text.Trim();
            string apellidoPaterno = textApellidoPaterno.Text.Trim();
            string apellidoMaterno = textApellidoMaterno.Text.Trim();
            string cargo = textCargo.Text.Trim();
            string salarioStr = textSalario.Text.Trim();

            // Validaciones básicas para usuario y empleado
            if (string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(correo) ||
                string.IsNullOrEmpty(contrasenia) || string.IsNullOrEmpty(rolSeleccionado) ||
                string.IsNullOrEmpty(nombreEmpleado) || string.IsNullOrEmpty(apellidoPaterno))
            {
                MessageBox.Show("Por favor, complete todos los campos obligatorios (usuario y datos del empleado).");
                return;
            }

            if (!correo.Contains("@") || !correo.Contains("."))
            {
                MessageBox.Show("Por favor, ingrese un correo válido.");
                return;
            }

            // Convertir salario a decimal (opcional)
            decimal salario = 0;
            if (!decimal.TryParse(salarioStr, out salario))
            {
                MessageBox.Show("Por favor, ingrese un salario válido.");
                return;
            }

            // Obtener el idRol a partir del rol seleccionado
            int idRol = ObtenerIdRol(rolSeleccionado);
            if (idRol == -1)
            {
                MessageBox.Show("Rol no encontrado.");
                return;
            }

            // Crear hash de la contraseña usando BCrypt
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(contrasenia, 12);

            // Insertar el nuevo empleado y obtener su id
            int idEmpleado = InsertarEmpleado(nombreEmpleado, apellidoPaterno, apellidoMaterno, cargo, salario);
            if (idEmpleado == -1)
            {
                MessageBox.Show("Error al registrar el empleado.");
                return;
            }

            // Insertar el usuario asociado al empleado recién creado
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "INSERT INTO usuario (usuario, email, password, idEmpleado, idRol, activo, fechaCreacion) " +
                                   "VALUES (@usuario, @correo, @password, @idEmpleado, @idRol, @activo, NOW())";
                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@usuario", usuario);
                        cmd.Parameters.AddWithValue("@correo", correo);
                        cmd.Parameters.AddWithValue("@password", hashedPassword);
                        cmd.Parameters.AddWithValue("@idEmpleado", idEmpleado);
                        cmd.Parameters.AddWithValue("@idRol", idRol);
                        cmd.Parameters.AddWithValue("@activo", activo ? 1 : 0);

                        int result = cmd.ExecuteNonQuery();
                        if (result > 0)
                        {
                            MessageBox.Show("Usuario y empleado registrados con éxito.");
                            // Opcional: Limpiar campos o cerrar el formulario
                        }
                        else
                        {
                            MessageBox.Show("Error al registrar el usuario.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar el usuario: " + ex.Message);
            }
        }

        // Botón Cancelar: cierra el formulario sin guardar
        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Obtiene el id del rol a partir del nombre del rol.
        /// </summary>
        /// <param name="nombreRol">Nombre del rol seleccionado</param>
        /// <returns>El idRol si se encuentra, -1 en caso contrario</returns>
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

        /// <summary>
        /// Inserta un nuevo empleado en la base de datos y retorna su id.
        /// </summary>
        /// <param name="nombre">Nombre del empleado</param>
        /// <param name="apellidoPaterno">Apellido paterno</param>
        /// <param name="apellidoMaterno">Apellido materno</param>
        /// <param name="cargo">Cargo del empleado</param>
        /// <param name="salario">Salario del empleado</param>
        /// <returns>El id del empleado insertado o -1 en caso de error</returns>
        private int InsertarEmpleado(string nombre, string apellidoPaterno, string apellidoMaterno, string cargo, decimal salario)
        {
            int idEmpleado = -1;
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "INSERT INTO empleado (nombre, apellidoPaterno, apellidoMaterno, cargo, salario, fechaContratacion) " +
                                   "VALUES (@nombre, @apellidoPaterno, @apellidoMaterno, @cargo, @salario, NOW())";
                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@nombre", nombre);
                        cmd.Parameters.AddWithValue("@apellidoPaterno", apellidoPaterno);
                        cmd.Parameters.AddWithValue("@apellidoMaterno", apellidoMaterno);
                        cmd.Parameters.AddWithValue("@cargo", cargo);
                        cmd.Parameters.AddWithValue("@salario", salario);

                        cmd.ExecuteNonQuery();
                        idEmpleado = Convert.ToInt32(cmd.LastInsertedId);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al insertar empleado: " + ex.Message);
            }
            return idEmpleado;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
