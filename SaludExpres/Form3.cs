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
    public partial class Form3 : Form
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["SaludExpresConnection"].ConnectionString;

        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            CargarUsuarios();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void buttonAgregarUsuario_Click(object sender, EventArgs e)
        {
            AgregarUsuarios formAgUs = new AgregarUsuarios();
            formAgUs.Show();
        }

        private void buttonEditUs_Click(object sender, EventArgs e)
        {
            SoliUserEdit editar = new SoliUserEdit();
            editar.Show();
        }

        private void buttonEliminarUs_Click(object sender, EventArgs e)
        {
            if (dataGridUsuarios.SelectedRows.Count == 0)
            {
                MessageBox.Show("Por favor, selecciona un usuario para eliminar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int idUsuario = Convert.ToInt32(dataGridUsuarios.SelectedRows[0].Cells["idUsuario"].Value);

            if (MessageBox.Show("¿Estás seguro de que deseas eliminar este usuario?", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    using (MySqlConnection connection = new MySqlConnection(connectionString))
                    {
                        connection.Open();
                        string query = "DELETE FROM usuario WHERE idUsuario = @idUsuario";

                        using (MySqlCommand cmd = new MySqlCommand(query, connection))
                        {
                            cmd.Parameters.AddWithValue("@idUsuario", idUsuario);
                            int filasAfectadas = cmd.ExecuteNonQuery();

                            if (filasAfectadas > 0)
                            {
                                MessageBox.Show("Usuario eliminado correctamente.");
                                CargarUsuarios(); // Refresca la lista de usuarios
                            }
                            else
                            {
                                MessageBox.Show("No se pudo eliminar el usuario.");
                            }
                        }
                    }
                }
                catch (MySqlException ex) when (ex.Number == 1451) // Error de clave foránea
                {
                    MessageBox.Show("No se puede eliminar este usuario porque tiene datos asociados en otras tablas.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al eliminar el usuario: " + ex.Message);
                }
            }
        }

        private void CargarUsuarios()
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = @"SELECT u.idUsuario, u.usuario, u.email, u.activo, 
                                    e.nombre, e.apellidoPaterno, e.apellidoMaterno, 
                                    e.cargo, e.salario, r.nombre AS rol
                             FROM usuario u
                             INNER JOIN empleado e ON u.idEmpleado = e.idEmpleado
                             INNER JOIN rol r ON u.idRol = r.idRol";  // Agregado JOIN con rol

                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        dataGridUsuarios.DataSource = dt;

                        // Ajustar automáticamente el tamaño de las columnas
                        dataGridUsuarios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                        dataGridUsuarios.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los usuarios y empleados: " + ex.Message);
            }
        }



        private void dataGridUsuarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBusUser_TextChanged(object sender, EventArgs e)
        {
            (dataGridUsuarios.DataSource as DataTable).DefaultView.RowFilter =
                string.Format("usuario LIKE '%{0}%' OR email LIKE '%{0}%' OR nombre LIKE '%{0}%'", textBusUser.Text.Trim());
        }

        private void comboFiltroRol_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (dataGridUsuarios.DataSource is DataTable dt)
                {
                    string filtro = comboFiltroRol.SelectedItem.ToString();

                    if (filtro == "Todos")
                    {
                        dt.DefaultView.RowFilter = ""; // Muestra todos los usuarios
                    }
                    else
                    {
                        dt.DefaultView.RowFilter = string.Format("rol LIKE '%{0}%'", filtro);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al filtrar por rol: " + ex.Message);
            }
        }

        private void comboFiltroEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (dataGridUsuarios.DataSource is DataTable dt)
                {
                    string filtro = comboFiltroEstado.SelectedItem.ToString();

                    if (filtro == "Todos")
                    {
                        dt.DefaultView.RowFilter = ""; // Muestra todos los usuarios
                    }
                    else if (filtro == "Contratado")
                    {
                        dt.DefaultView.RowFilter = "activo = 1"; // Filtra por usuarios activos
                    }
                    else if (filtro == "Despedido")
                    {
                        dt.DefaultView.RowFilter = "activo = 0"; // Filtra por usuarios inactivos
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al aplicar el filtro de estado: " + ex.Message);
            }
        }

        private void buttonCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
