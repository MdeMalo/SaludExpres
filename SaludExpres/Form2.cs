using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SaludExpres
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            //this.FormBorderStyle = FormBorderStyle.None; // Esto elimina los bordes para modo pantalla completa

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

        }
    }
}
