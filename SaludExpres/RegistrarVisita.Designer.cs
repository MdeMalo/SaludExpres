namespace SaludExpres
{
    partial class RegistrarVisita
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            buttonGuardar = new Button();
            comboSucursal = new ComboBox();
            label1 = new Label();
            dateFechaVisita = new DateTimePicker();
            label2 = new Label();
            textAutoridad = new TextBox();
            label3 = new Label();
            label4 = new Label();
            textResultado = new TextBox();
            buttonCancelar = new Button();
            label5 = new Label();
            textSanciones = new TextBox();
            label6 = new Label();
            textAccionesCorrectivas = new TextBox();
            label7 = new Label();
            dateProximaVisita = new DateTimePicker();
            textObservaciones = new TextBox();
            label8 = new Label();
            SuspendLayout();
            // 
            // buttonGuardar
            // 
            buttonGuardar.Location = new Point(257, 382);
            buttonGuardar.Name = "buttonGuardar";
            buttonGuardar.Size = new Size(125, 29);
            buttonGuardar.TabIndex = 9;
            buttonGuardar.Text = "Guardar";
            buttonGuardar.UseVisualStyleBackColor = true;
            buttonGuardar.Click += buttonGuardar_Click;
            // 
            // comboSucursal
            // 
            comboSucursal.FormattingEnabled = true;
            comboSucursal.Location = new Point(211, 99);
            comboSucursal.Name = "comboSucursal";
            comboSucursal.Size = new Size(151, 28);
            comboSucursal.TabIndex = 10;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(139, 107);
            label1.Name = "label1";
            label1.Size = new Size(66, 20);
            label1.TabIndex = 11;
            label1.Text = "Sucursal:";
            // 
            // dateFechaVisita
            // 
            dateFechaVisita.Location = new Point(332, 233);
            dateFechaVisita.Name = "dateFechaVisita";
            dateFechaVisita.Size = new Size(268, 27);
            dateFechaVisita.TabIndex = 12;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(201, 238);
            label2.Name = "label2";
            label2.Size = new Size(125, 20);
            label2.TabIndex = 13;
            label2.Text = "Fecha de la visita:";
            label2.Click += label2_Click;
            // 
            // textAutoridad
            // 
            textAutoridad.Location = new Point(211, 48);
            textAutoridad.Name = "textAutoridad";
            textAutoridad.Size = new Size(151, 27);
            textAutoridad.TabIndex = 14;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(126, 55);
            label3.Name = "label3";
            label3.Size = new Size(79, 20);
            label3.TabIndex = 15;
            label3.Text = "Autoridad:";
            label3.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(366, 55);
            label4.Name = "label4";
            label4.Size = new Size(78, 20);
            label4.TabIndex = 17;
            label4.Text = "Resultado:";
            label4.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // textResultado
            // 
            textResultado.Location = new Point(449, 48);
            textResultado.Name = "textResultado";
            textResultado.Size = new Size(151, 27);
            textResultado.TabIndex = 16;
            // 
            // buttonCancelar
            // 
            buttonCancelar.Location = new Point(419, 382);
            buttonCancelar.Name = "buttonCancelar";
            buttonCancelar.Size = new Size(125, 29);
            buttonCancelar.TabIndex = 18;
            buttonCancelar.Text = "Cancelar";
            buttonCancelar.UseVisualStyleBackColor = true;
            buttonCancelar.Click += buttonCancelar_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(366, 106);
            label5.Name = "label5";
            label5.Size = new Size(78, 20);
            label5.TabIndex = 20;
            label5.Text = "Sanciones:";
            label5.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // textSanciones
            // 
            textSanciones.Location = new Point(449, 99);
            textSanciones.Name = "textSanciones";
            textSanciones.Size = new Size(151, 27);
            textSanciones.TabIndex = 19;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(59, 147);
            label6.Name = "label6";
            label6.Size = new Size(146, 20);
            label6.TabIndex = 22;
            label6.Text = "Acciones correctivas:";
            label6.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // textAccionesCorrectivas
            // 
            textAccionesCorrectivas.Location = new Point(211, 144);
            textAccionesCorrectivas.Name = "textAccionesCorrectivas";
            textAccionesCorrectivas.Size = new Size(151, 27);
            textAccionesCorrectivas.TabIndex = 21;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(221, 193);
            label7.Name = "label7";
            label7.Size = new Size(104, 20);
            label7.TabIndex = 24;
            label7.Text = "Proxima visita:";
            // 
            // dateProximaVisita
            // 
            dateProximaVisita.Location = new Point(332, 188);
            dateProximaVisita.Name = "dateProximaVisita";
            dateProximaVisita.Size = new Size(268, 27);
            dateProximaVisita.TabIndex = 23;
            // 
            // textObservaciones
            // 
            textObservaciones.Location = new Point(211, 266);
            textObservaciones.Multiline = true;
            textObservaciones.Name = "textObservaciones";
            textObservaciones.Size = new Size(379, 97);
            textObservaciones.TabIndex = 25;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(97, 269);
            label8.Name = "label8";
            label8.Size = new Size(108, 20);
            label8.TabIndex = 26;
            label8.Text = "Observaciones:";
            label8.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // RegistrarVisita
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label8);
            Controls.Add(textObservaciones);
            Controls.Add(label7);
            Controls.Add(dateProximaVisita);
            Controls.Add(label6);
            Controls.Add(textAccionesCorrectivas);
            Controls.Add(label5);
            Controls.Add(textSanciones);
            Controls.Add(buttonCancelar);
            Controls.Add(label4);
            Controls.Add(textResultado);
            Controls.Add(label3);
            Controls.Add(textAutoridad);
            Controls.Add(label2);
            Controls.Add(dateFechaVisita);
            Controls.Add(label1);
            Controls.Add(comboSucursal);
            Controls.Add(buttonGuardar);
            Name = "RegistrarVisita";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "RegistrarVisita";
            Load += RegistrarVisita_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button buttonGuardar;
        private ComboBox comboSucursal;
        private Label label1;
        private DateTimePicker dateFechaVisita;
        private Label label2;
        private TextBox textAutoridad;
        private Label label3;
        private Label label4;
        private TextBox textResultado;
        private Button buttonCancelar;
        private Label label5;
        private TextBox textSanciones;
        private Label label6;
        private TextBox textAccionesCorrectivas;
        private Label label7;
        private DateTimePicker dateProximaVisita;
        private TextBox textObservaciones;
        private Label label8;
    }
}