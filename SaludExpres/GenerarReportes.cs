using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Configuration;

namespace SaludExpres
{
    public partial class GenerarReportes : Form
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["SaludExpresConnection"].ConnectionString;

        public GenerarReportes()
        {
            InitializeComponent();
        }

        private void GenerarReportes_Load(object sender, EventArgs e)
        {
            comboTipoReporte.Items.Add("Ventas Diarias");
            comboTipoReporte.Items.Add("Ventas Mensuales");
            comboTipoReporte.Items.Add("Productos Más Vendidos");
            comboTipoReporte.Items.Add("Inventario Actual");
            comboTipoReporte.Items.Add("Sucursales Activas");
            comboTipoReporte.Items.Add("Visitas Sanitarias");
            comboTipoReporte.SelectedIndex = 0; // Selecciona la primera opción por defecto
            this.WindowState = FormWindowState.Maximized; // Establece la ventana a pantalla completa
        }

        private void comboTipoReporte_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void buttonGenerar_Click(object sender, EventArgs e)
        {
            string tipoReporte = comboTipoReporte.SelectedItem.ToString();
            DateTime fechaInicio = dateInicio.Value;
            DateTime fechaFin = dateFin.Value;

            if (fechaInicio > fechaFin)
            {
                MessageBox.Show("La fecha de inicio no puede ser mayor que la fecha final.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataTable dtReporte = ObtenerDatosReporte(tipoReporte, fechaInicio, fechaFin);
            dataGridReportes.DataSource = dtReporte;

            // Ajustar columnas y filas del DataGridView
            dataGridReportes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridReportes.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
        }

        private DataTable ObtenerDatosReporte(string tipoReporte, DateTime fechaInicio, DateTime fechaFin)
        {
            DataTable dt = new DataTable();
            string query = "";

            switch (tipoReporte)
            {
                case "Ventas Diarias":
                    query = @"SELECT 
                            v.idVenta, 
                            v.fecha, 
                            u.usuario AS Cajero, 
                            s.nombre AS Sucursal, 
                            v.total 
                        FROM venta v
                        INNER JOIN empleado e ON v.idEmpleado = e.idEmpleado
                        INNER JOIN usuario u ON e.idEmpleado = u.idEmpleado
                        INNER JOIN sucursal s ON v.idSucursal = s.idSucursal
                        WHERE v.fecha BETWEEN @fechaInicio AND @fechaFin";
                    break;
                case "Ventas Mensuales":
                    query = @"SELECT DATE_FORMAT(v.fecha, '%Y-%m') AS Mes, SUM(v.total) AS TotalVentas 
                              FROM venta v
                              WHERE v.fecha BETWEEN @fechaInicio AND @fechaFin
                              GROUP BY Mes";
                    break;
                case "Productos Más Vendidos":
                    query = @"SELECT p.nombre AS Producto, SUM(dv.cantidad) AS CantidadVendida 
                              FROM detalleventa dv
                              INNER JOIN producto p ON dv.idProducto = p.idProducto
                              INNER JOIN venta v ON dv.idVenta = v.idVenta
                              WHERE v.fecha BETWEEN @fechaInicio AND @fechaFin
                              GROUP BY p.nombre
                              ORDER BY CantidadVendida DESC
                              LIMIT 10";
                    break;
                case "Inventario Actual":
                    query = @"SELECT p.idProducto, p.nombre AS Producto, p.stock AS Stock, p.precioSinIva AS Precio 
                              FROM producto p
                              WHERE p.stock > 0";
                    break;
                case "Sucursales Activas":
                    query = @"SELECT s.idSucursal, s.nombre AS Sucursal, s.ciudad, s.estado, rs.nombre AS Responsable
                              FROM sucursal s
                              LEFT JOIN responsablesanitario rs ON s.idResponsable = rs.idResponsable";
                    break;
                case "Visitas Sanitarias":
                    query = @"SELECT v.idVisita, s.nombre AS Sucursal, v.autoridad, v.fechaVisita, v.resultado, 
                                     v.sanciones, v.accionesCorrectivas, v.fechaProximaVisita, v.observaciones
                              FROM visitasanitaria v
                              INNER JOIN sucursal s ON v.idSucursal = s.idSucursal
                              WHERE v.fechaVisita BETWEEN @fechaInicio AND @fechaFin";
                    break;
            }

            if (string.IsNullOrEmpty(query))
                return dt;

            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        // Usamos el formato "yyyy-MM-dd" para las fechas
                        cmd.Parameters.AddWithValue("@fechaInicio", fechaInicio.ToString("yyyy-MM-dd"));
                        cmd.Parameters.AddWithValue("@fechaFin", fechaFin.ToString("yyyy-MM-dd"));

                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                        {
                            adapter.Fill(dt);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar el reporte: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return dt;
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
