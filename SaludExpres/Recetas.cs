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
using static SaludExpres.systemUI;

namespace SaludExpres
{
    public partial class Recetas : Form
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["SaludExpresConnection"].ConnectionString;
        private DataGridView dataGridViewRecetas;
        public Recetas()
        {
            InitializeComponent();
            CargarDatosRecetas();
            AjustarAnchoColumnas();
            activeUI(this); // Llama a la función para aplicar el estilo de UI
        }

        private void CargarDatosRecetas()
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = @"
                            SELECT 
                                r.idReceta AS 'ID Receta',
                                CONCAT(c.nombre, ' ', c.apellidoPaterno, ' ', c.apellidoMaterno) AS 'Nombre Cliente',
                                CONCAT(e.nombre, ' ', e.apellidoPaterno) AS 'Nombre Empleado',
                                r.fechaEmision AS 'Fecha Emisión',
                                r.diagnostico AS 'Diagnóstico',
                                r.observaciones AS 'Observaciones',
                                p.nombre AS 'Nombre Producto',
                                rp.dosis AS 'Dosis',
                                rp.frecuencia AS 'Frecuencia',
                                rp.duracion AS 'Duración'
                            FROM receta r
                            INNER JOIN cliente c ON r.idCliente = c.idCliente
                            INNER JOIN empleado e ON r.idEmpleado = e.idEmpleado
                            LEFT JOIN recetaproducto rp ON r.idReceta = rp.idReceta
                            LEFT JOIN producto p ON rp.idProducto = p.idProducto
                            ORDER BY r.idReceta, p.nombre";

                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);
                            dataGridRecetas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                            dataGridRecetas.DataSource = dt; // Asignar datos al DataGridView existente
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar las recetas: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AjustarAnchoColumnas()
        {
            foreach (DataGridViewColumn column in dataGridRecetas.Columns)
            {
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
        }

        private void buttonCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
