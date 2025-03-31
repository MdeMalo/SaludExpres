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
    public partial class MovimientosInventario : Form
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["SaludExpresConnection"].ConnectionString;
        public MovimientosInventario()
        {
            InitializeComponent();
            CargarMovimientosInventario();
            AjustarColumnasDataGridView();
        }
        private void CargarMovimientosInventario()
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    string query = @"
                            SELECT mi.idMovimiento, p.nombre AS nombreProducto, e.nombre AS nombreEmpleado, mi.fechaMovimiento, mi.tipoMovimiento, mi.cantidad, mi.descripcion 
                            FROM movimientoinventario mi
                            JOIN producto p ON mi.idProducto = p.idProducto
                            JOIN empleado e ON mi.idEmpleado = e.idEmpleado
                            ORDER BY mi.fechaMovimiento DESC;";

                    MySqlDataAdapter da = new MySqlDataAdapter(query, connection);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridViewMovimientos.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los movimientos de inventario: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void AjustarColumnasDataGridView()
        {
            dataGridViewMovimientos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        private void MovimientosInventario_Load(object sender, EventArgs e)
        {

        }

        private void buttonCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
