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
            this.FormBorderStyle = FormBorderStyle.None; // Esto elimina los bordes para modo pantalla completa
            CargarMetricasDelDia();

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
            RegistrarVenta formRegVentas = new RegistrarVenta(UsuarioID);
            formRegVentas.Show();
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

        private void dataGridMetricas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void buttonAuditoria_Click(object sender, EventArgs e)
        {
            AuditoriaEmpleadosForm auditoriaEmpleados = new AuditoriaEmpleadosForm();
            auditoriaEmpleados.Show();
        }
    }
}
