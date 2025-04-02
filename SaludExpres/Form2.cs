using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO.Packaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace SaludExpres
{
    public partial class Form2 : Form
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["SaludExpresConnection"].ConnectionString;
        public int UsuarioID { get; set; }
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = FormBorderStyle.None;
            CargarMetricasDelDia();
            string nombreUsuario = ObtenerNombreUsuario(UsuarioID); // Usa UsuarioID directamente
            labelBienvenida.Text = $"Bienvenido, {nombreUsuario}";
        }

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

        private void CargarMetricasDelDia()
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    // Consulta de métricas: Total de ventas, monto total y promedio de ventas del día actual.
                    string query = @"
                SELECT 
                    COUNT(*) AS TotalVentas, 
                    IFNULL(SUM(total), 0) AS MontoTotal, 
                    IFNULL(AVG(total), 0) AS PromedioVenta
                FROM venta 
                WHERE DATE(fecha) = CURDATE();";

                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dataGridMetricas.DataSource = dt;

                    // Ajustar automáticamente el tamaño de las columnas
                    dataGridMetricas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar las métricas del día: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void buttonUsuarios_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.Show();
        }

        private void buttonSucursales_Click(object sender, EventArgs e)
        {
            SucursalesAdmin formSucursales = new SucursalesAdmin();
            formSucursales.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            GenerarReportes formReportes = new GenerarReportes();
            formReportes.Show();
        }

        private void buttonRegVisita_Click(object sender, EventArgs e)
        {
            RegistrarVisita formRegVisita = new RegistrarVisita();
            formRegVisita.Show();
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void buttonAniadirResp_Click(object sender, EventArgs e)
        {
            AgregarResponsableSanitario formResp = new AgregarResponsableSanitario();
            formResp.Show();
        }

        private void buttonAdminResp_Click(object sender, EventArgs e)
        {
            AdministrarResponsablesSanitarios formAdminResp = new AdministrarResponsablesSanitarios();
            formAdminResp.Show();
        }

        private void buttonRegistrarProducto_Click(object sender, EventArgs e)
        {
            Inventario formRegProd = new Inventario();
            formRegProd.Show();
        }

        private void buttonRegistrarProveedor_Click(object sender, EventArgs e)
        {
            AdministrarProveedores formAdminProv = new AdministrarProveedores();
            formAdminProv.Show();
        }

        private void buttonRegistrarVentas_Click(object sender, EventArgs e)
        {
            int idEmpleado = ObtenerIdEmpleado(UsuarioID);
            if (idEmpleado != -1)
            {
                RegistrarVenta formRegVentas = new RegistrarVenta(idEmpleado);
                formRegVentas.Show();
            }
            else
            {
                MessageBox.Show("No se pudo obtener el idEmpleado para este usuario.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonFactura_Click(object sender, EventArgs e)
        {
            GenerarFactura formGenFactura = new GenerarFactura();
            formGenFactura.Show();
        }

        private void buttonMovsInventario_Click(object sender, EventArgs e)
        {
            MovimientosInventario movimientosInventario = new MovimientosInventario();
            movimientosInventario.Show();
        }

        private void buttonVerRecetas_Click(object sender, EventArgs e)
        {
            Recetas recetas = new Recetas();
            recetas.Show();
        }
        private int ObtenerIdEmpleado(int idUsuario)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT idEmpleado FROM usuario WHERE idUsuario = @idUsuario";
                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@idUsuario", idUsuario);
                        object result = cmd.ExecuteScalar();
                        return result != null ? Convert.ToInt32(result) : -1;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener idEmpleado: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
        }

        private void dataGridMetricas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void buttonAuditoria_Click(object sender, EventArgs e)
        {
            AuditoriaEmpleadosForm auditoriaEmpleados = new AuditoriaEmpleadosForm();
            auditoriaEmpleados.Show();
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


    }
}
