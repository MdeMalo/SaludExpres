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
    public partial class RecetaForm : Form
    {
        public string NumeroReceta { get; private set; }
        public DateTime FechaEmision { get; private set; }
        public string Diagnostico { get; private set; }
        public string Observaciones { get; private set; }
        public string Dosis { get; private set; }
        public string Frecuencia { get; private set; }
        public string Duracion { get; private set; }

        public RecetaForm(String nombreProducto)
        {
            InitializeComponent();
            InitializeControls(nombreProducto);
            activeUI(this); // Llama a la función para aplicar el estilo de UI
        }

        private void InitializeControls(string nombreProducto)
        {
            this.Text = $"Receta para {nombreProducto}";
            this.Size = new System.Drawing.Size(800, 600);
            this.StartPosition = FormStartPosition.CenterParent;

            // Ancho total disponible para los controles (Label + TextBox + espacio)
            int labelWidth = 150; // Ancho estimado para los Labels
            int textBoxWidth = 300; // Ancho más amplio para los TextBox
            int espacioEntre = 20; // Espacio entre Label y TextBox
            int totalWidth = labelWidth + espacioEntre + textBoxWidth;
            int inicioX = (this.ClientSize.Width - totalWidth) / 2; // Centrar horizontalmente

            // Número de receta
            Label lblNumero = new Label { Text = "Número de Receta:", Location = new Point(inicioX, 20), Width = labelWidth };
            TextBox txtNumero = new TextBox { Location = new Point(inicioX + labelWidth + espacioEntre, 20), Width = textBoxWidth };
            this.Controls.Add(lblNumero);
            this.Controls.Add(txtNumero);

            // Fecha de emisión
            Label lblFecha = new Label { Text = "Fecha de Emisión:", Location = new Point(inicioX, 70), Width = labelWidth };
            DateTimePicker dtpFecha = new DateTimePicker { Location = new Point(inicioX + labelWidth + espacioEntre, 70), Width = textBoxWidth };
            this.Controls.Add(lblFecha);
            this.Controls.Add(dtpFecha);

            // Diagnóstico
            Label lblDiagnostico = new Label { Text = "Diagnóstico:", Location = new Point(inicioX, 120), Width = labelWidth };
            TextBox txtDiagnostico = new TextBox { Location = new Point(inicioX + labelWidth + espacioEntre, 120), Width = textBoxWidth, Height = 80, Multiline = true };
            this.Controls.Add(lblDiagnostico);
            this.Controls.Add(txtDiagnostico);

            // Observaciones
            Label lblObservaciones = new Label { Text = "Observaciones:", Location = new Point(inicioX, 220), Width = labelWidth };
            TextBox txtObservaciones = new TextBox { Location = new Point(inicioX + labelWidth + espacioEntre, 220), Width = textBoxWidth, Height = 80, Multiline = true };
            this.Controls.Add(lblObservaciones);
            this.Controls.Add(txtObservaciones);

            // Dosis
            Label lblDosis = new Label { Text = "Dosis:", Location = new Point(inicioX, 320), Width = labelWidth };
            TextBox txtDosis = new TextBox { Location = new Point(inicioX + labelWidth + espacioEntre, 320), Width = textBoxWidth };
            this.Controls.Add(lblDosis);
            this.Controls.Add(txtDosis);

            // Frecuencia
            Label lblFrecuencia = new Label { Text = "Frecuencia:", Location = new Point(inicioX, 370), Width = labelWidth };
            TextBox txtFrecuencia = new TextBox { Location = new Point(inicioX + labelWidth + espacioEntre, 370), Width = textBoxWidth };
            this.Controls.Add(lblFrecuencia);
            this.Controls.Add(txtFrecuencia);

            // Duración
            Label lblDuracion = new Label { Text = "Duración:", Location = new Point(inicioX, 420), Width = labelWidth };
            TextBox txtDuracion = new TextBox { Location = new Point(inicioX + labelWidth + espacioEntre, 420), Width = textBoxWidth };
            this.Controls.Add(lblDuracion);
            this.Controls.Add(txtDuracion);

            // Botones (centrados también)
            int buttonWidth = 100;
            int espacioBotones = 20;
            int totalButtonWidth = (buttonWidth * 2) + espacioBotones;
            int buttonInicioX = (this.ClientSize.Width - totalButtonWidth) / 2;

            Button btnGuardar = new Button { Text = "Guardar", Location = new Point(buttonInicioX, 470), Width = buttonWidth };
            btnGuardar.Click += (s, ev) =>
            {
                NumeroReceta = txtNumero.Text.Trim();
                FechaEmision = dtpFecha.Value;
                Diagnostico = txtDiagnostico.Text.Trim();
                Observaciones = txtObservaciones.Text.Trim();
                Dosis = txtDosis.Text.Trim();
                Frecuencia = txtFrecuencia.Text.Trim();
                Duracion = txtDuracion.Text.Trim();

                if (string.IsNullOrEmpty(NumeroReceta) || string.IsNullOrEmpty(Diagnostico))
                {
                    MessageBox.Show("El número de receta y el diagnóstico son obligatorios.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            };
            this.Controls.Add(btnGuardar);

            Button btnCancelar = new Button { Text = "Cancelar", Location = new Point(buttonInicioX + buttonWidth + espacioBotones, 470), Width = buttonWidth };
            btnCancelar.Click += (s, ev) => this.Close();
            this.Controls.Add(btnCancelar);
        }

        private void RecetaForm_Load(object sender, EventArgs e)
        {

        }
    }
}
