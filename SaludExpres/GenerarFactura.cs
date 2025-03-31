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

namespace SaludExpres
{
    public partial class GenerarFactura : Form
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["SaludExpresConnection"].ConnectionString;
        // Propiedades públicas para almacenar los datos necesarios
        public int IdVenta { get; set; }
        public int IdReceptor { get; set; }
        public GenerarFactura()
        {
            InitializeComponent();

        }

        private void GenerarFactura_Load(object sender, EventArgs e)
        {

        }
    }
}
