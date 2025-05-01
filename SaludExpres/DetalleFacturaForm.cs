using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static SaludExpres.systemUI;

namespace SaludExpres
{
    public partial class DetalleFacturaForm : Form
    {
        public DetalleFacturaForm(int idFactura, string numeroFactura, DateTime fechaEmision, decimal subtotal, decimal impuestos, decimal total,
            string metodoPago, string usoCFDI, DataTable detallesFactura)
        {
            InitializeComponent();
            MostrarDatosFactura(idFactura, numeroFactura, fechaEmision, subtotal, impuestos, total, metodoPago, usoCFDI, detallesFactura);
            systemUI.activeUI(this); // Llama a la función para aplicar el estilo de UI
        }

        private void DetalleFacturaForm_Load(object sender, EventArgs e)
        {
        }

        private void MostrarDatosFactura(int idFactura, string numeroFactura, DateTime fechaEmision, decimal subtotal, decimal impuestos,
            decimal total, string metodoPago, string usoCFDI, DataTable detallesFactura)
        {
            labelNumeroFactura.Text = $"Número de Factura: {numeroFactura}";
            labelFechaEmision.Text = $"Fecha de Emisión: {fechaEmision:dd/MM/yyyy HH:mm:ss}";
            labelSubtotal.Text = $"Subtotal: ${subtotal:F2}";
            labelImpuestos.Text = $"Impuestos (16%): ${impuestos:F2}";
            labelTotal.Text = $"Total: ${total:F2}";
            labelMetodoPago.Text = $"Método de Pago: {metodoPago}";
            labelUsoCFDI.Text = $"Uso CFDI: {usoCFDI}";
            gridDetallesFactura.DataSource = detallesFactura;
            foreach (DataGridViewColumn column in gridDetallesFactura.Columns)
            {
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }

        }
        private void buttonCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void gridDetallesFactura_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
