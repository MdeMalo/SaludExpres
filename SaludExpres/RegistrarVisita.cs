using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Configuration;
using System.Windows.Forms;


namespace SaludExpres
{
    public partial class RegistrarVisita : Form
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["SaludExpresConnection"].ConnectionString;

        public RegistrarVisita()
        {
            InitializeComponent();
        }

        private void CargarSucursales()
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT idSucursal, nombre FROM sucursal";
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        comboSucursal.DataSource = dt;
                        comboSucursal.DisplayMember = "nombre";
                        comboSucursal.ValueMember = "idSucursal";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar las sucursales: " + ex.Message);
            }
        }

        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            // Extraer datos de los controles
            if (comboSucursal.SelectedValue == null)
            {
                MessageBox.Show("Seleccione una sucursal.");
                return;
            }

            int idSucursal = Convert.ToInt32(comboSucursal.SelectedValue);
            DateTime fechaVisita = dateFechaVisita.Value;
            string autoridad = textAutoridad.Text.Trim();
            string resultado = textResultado.Text.Trim();
            string sanciones = textSanciones.Text.Trim();
            string accionesCorrectivas = textAccionesCorrectivas.Text.Trim();
            DateTime? fechaProximaVisita = dateProximaVisita.Checked ? (DateTime?)dateProximaVisita.Value : null;
            string observaciones = textObservaciones.Text.Trim();

            // Validar campos obligatorios (por ejemplo, sucursal, fecha, autoridad y resultado)
            if (string.IsNullOrEmpty(autoridad) || string.IsNullOrEmpty(resultado))
            {
                MessageBox.Show("Por favor, complete los campos obligatorios: autoridad y resultado.");
                return;
            }

            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = @"INSERT INTO visitasanitaria 
                                     (idSucursal, fechaVisita, autoridad, resultado, sanciones, accionesCorrectivas, fechaProximaVisita, observaciones)
                                     VALUES
                                     (@idSucursal, @fechaVisita, @autoridad, @resultado, @sanciones, @accionesCorrectivas, @fechaProximaVisita, @observaciones)";

                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@idSucursal", idSucursal);
                        cmd.Parameters.AddWithValue("@fechaVisita", fechaVisita.ToString("yyyy-MM-dd"));
                        cmd.Parameters.AddWithValue("@autoridad", autoridad);
                        cmd.Parameters.AddWithValue("@resultado", resultado);
                        cmd.Parameters.AddWithValue("@sanciones", string.IsNullOrEmpty(sanciones) ? DBNull.Value : (object)sanciones);
                        cmd.Parameters.AddWithValue("@accionesCorrectivas", string.IsNullOrEmpty(accionesCorrectivas) ? DBNull.Value : (object)accionesCorrectivas);

                        // Fecha de próxima visita es opcional
                        if (fechaProximaVisita.HasValue)
                            cmd.Parameters.AddWithValue("@fechaProximaVisita", fechaProximaVisita.Value.ToString("yyyy-MM-dd"));
                        else
                            cmd.Parameters.AddWithValue("@fechaProximaVisita", DBNull.Value);

                        cmd.Parameters.AddWithValue("@observaciones", string.IsNullOrEmpty(observaciones) ? DBNull.Value : (object)observaciones);

                        int filasAfectadas = cmd.ExecuteNonQuery();
                        if (filasAfectadas > 0)
                        {
                            MessageBox.Show("Visita sanitaria registrada con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close(); // Cierra el formulario
                        }
                        else
                        {
                            MessageBox.Show("No se pudo registrar la visita sanitaria.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar la visita sanitaria: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void RegistrarVisita_Load(object sender, EventArgs e)
        {
            CargarSucursales();
        }
    }
}
