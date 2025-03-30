using MySql.Data.MySqlClient;
using System;
using System.Configuration;
using System.Data;
using System.Windows.Forms;

namespace SaludExpres
{
    public partial class SeleccionarResponsable : Form
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["SaludExpresConnection"].ConnectionString;
        public int IdResponsableSeleccionado { get; private set; }
        public string NombreResponsableSeleccionado { get; private set; }
        public SeleccionarResponsable()
        {
            InitializeComponent();
            CargarResponsables();
        }

        private void CargarResponsables()
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT idResponsable, nombre FROM responsablesanitario";

                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        comboBox1.DisplayMember = "nombre";
                        comboBox1.ValueMember = "idResponsable";
                        comboBox1.DataSource = dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los responsables: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void buttonAceptar_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedValue != null)
            {
                IdResponsableSeleccionado = Convert.ToInt32(comboBox1.SelectedValue);
                NombreResponsableSeleccionado = comboBox1.Text;
                try
                {
                    EditarResponsableSanitario form = new EditarResponsableSanitario(IdResponsableSeleccionado);
                    form.ShowDialog();  

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar el responsable: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Seleccione un responsable sanitario.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
