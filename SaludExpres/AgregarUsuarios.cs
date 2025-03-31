using MySql.Data.MySqlClient;
using System;
using System.Configuration;
using System.Windows.Forms;
using BCrypt.Net;

namespace SaludExpres
{
    public partial class AgregarUsuarios : Form
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["SaludExpresConnection"].ConnectionString;

        public AgregarUsuarios()
        {
            InitializeComponent();
        }

        private void AgregarUsuarios_Load(object sender, EventArgs e)
        {
            // Cargar los roles en comboBox1 (asumiendo que ya lo tienes)
            CargarRoles();

            // Cargar las sucursales en un ComboBox (nuevo)
            CargarSucursales();
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
                    {
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                comboBox1.Items.Add(reader["nombre"].ToString());
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los roles: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarSucursales()
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT idSucursal, nombre FROM sucursal";
                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            comboBoxSucursal.Items.Clear(); // Asegúrate de que este ComboBox exista en el formulario
                            while (reader.Read())
                            {
                                // Almacenar el idSucursal como Tag y mostrar el nombre
                                comboBoxSucursal.Items.Add(new { Id = reader.GetInt32("idSucursal"), Nombre = reader.GetString("nombre") });
                            }
                            comboBoxSucursal.DisplayMember = "Nombre"; // Mostrar solo el nombre en el ComboBox
                            if (comboBoxSucursal.Items.Count > 0) comboBoxSucursal.SelectedIndex = 0; // Seleccionar el primero por defecto
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar las sucursales: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            // Campos para el usuario
            string usuario = textUsuario.Text.Trim();
            string correo = textCorreo.Text.Trim();
            string contrasenia = textContrasenia.Text;
            string rolSeleccionado = comboBox1.SelectedItem?.ToString();
            bool activo = checkBox1.Checked;

            // Campos para el empleado
            string nombreEmpleado = textNombre.Text.Trim();
            string apellidoPaterno = textApellidoPaterno.Text.Trim();
            string apellidoMaterno = textApellidoMaterno.Text.Trim();
            string cargo = textCargo.Text.Trim();
            string salarioStr = textSalario.Text.Trim();
            int idSucursal = -1;

            // Obtener idSucursal del ComboBox
            if (comboBoxSucursal.SelectedItem != null)
            {
                idSucursal = ((dynamic)comboBoxSucursal.SelectedItem).Id;
            }

            // Validaciones básicas
            if (string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(correo) ||
                string.IsNullOrEmpty(contrasenia) || string.IsNullOrEmpty(rolSeleccionado) ||
                string.IsNullOrEmpty(nombreEmpleado) || string.IsNullOrEmpty(apellidoPaterno) ||
                idSucursal == -1)
            {
                MessageBox.Show("Por favor, complete todos los campos obligatorios (usuario, datos del empleado y sucursal).", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!correo.Contains("@") || !correo.Contains("."))
            {
                MessageBox.Show("Por favor, ingrese un correo válido.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Convertir salario a decimal
            if (!decimal.TryParse(salarioStr, out decimal salario))
            {
                MessageBox.Show("Por favor, ingrese un salario válido.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Obtener el idRol
            int idRol = ObtenerIdRol(rolSeleccionado);
            if (idRol == -1)
            {
                MessageBox.Show("Rol no encontrado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Crear hash de la contraseña
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(contrasenia, 12);

            // Insertar empleado con idSucursal
            int idEmpleado = InsertarEmpleado(nombreEmpleado, apellidoPaterno, apellidoMaterno, cargo, salario, idSucursal);
            if (idEmpleado == -1)
            {
                MessageBox.Show("Error al registrar el empleado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Insertar usuario
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
                            MessageBox.Show("Usuario y empleado registrados con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LimpiarCampos(); // Opcional: limpiar el formulario
                        }
                        else
                        {
                            MessageBox.Show("Error al registrar el usuario.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar el usuario: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show("Error al obtener el rol: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return idRol;
        }

        private int InsertarEmpleado(string nombre, string apellidoPaterno, string apellidoMaterno, string cargo, decimal salario, int idSucursal)
        {
            int idEmpleado = -1;
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "INSERT INTO empleado (nombre, apellidoPaterno, apellidoMaterno, cargo, salario, idSucursal, fechaContratacion) " +
                                   "VALUES (@nombre, @apellidoPaterno, @apellidoMaterno, @cargo, @salario, @idSucursal, NOW())";
                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@nombre", nombre);
                        cmd.Parameters.AddWithValue("@apellidoPaterno", apellidoPaterno);
                        cmd.Parameters.AddWithValue("@apellidoMaterno", apellidoMaterno);
                        cmd.Parameters.AddWithValue("@cargo", cargo);
                        cmd.Parameters.AddWithValue("@salario", salario);
                        cmd.Parameters.AddWithValue("@idSucursal", idSucursal);

                        cmd.ExecuteNonQuery();
                        idEmpleado = Convert.ToInt32(cmd.LastInsertedId);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al insertar empleado: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return idEmpleado;
        }

        private void LimpiarCampos()
        {
            textUsuario.Clear();
            textCorreo.Clear();
            textContrasenia.Clear();
            comboBox1.SelectedIndex = -1;
            checkBox1.Checked = true;
            textNombre.Clear();
            textApellidoPaterno.Clear();
            textApellidoMaterno.Clear();
            textCargo.Clear();
            textSalario.Clear();
            comboBoxSucursal.SelectedIndex = -1;
        }

        // Eventos no modificados
        private void label2_Click(object sender, EventArgs e) { }
        private void textUsuario_TextChanged(object sender, EventArgs e) { }
        private void textContrasenia_TextChanged(object sender, EventArgs e) { }
        private void textCorreo_TextChanged(object sender, EventArgs e) { }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) { }
        private void checkBox1_CheckedChanged(object sender, EventArgs e) { }
        private void groupBox1_Enter(object sender, EventArgs e) { }
    }
}