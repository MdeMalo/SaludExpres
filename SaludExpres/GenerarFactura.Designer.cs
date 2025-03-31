namespace SaludExpres
{
    partial class GenerarFactura
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
            gridVentas = new DataGridView();
            gridReceptor = new DataGridView();
            gridEmisor = new DataGridView();
            comboBoxMetodoPago = new ComboBox();
            buttonGenerarFactura = new Button();
            lblReceptorSeleccionado = new Label();
            lblEmisorSeleccionado = new Label();
            lblVentaSeleccionada = new Label();
            groupBox5 = new GroupBox();
            buttonCerrar = new Button();
            button3 = new Button();
            label8 = new Label();
            comboBoxCFDI = new ComboBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            groupBox1 = new GroupBox();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            groupBox2 = new GroupBox();
            pictureBoxQR = new PictureBox();
            groupBox3 = new GroupBox();
            button2 = new Button();
            button1 = new Button();
            groupBox4 = new GroupBox();
            gridFacturas = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)gridVentas).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridReceptor).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridEmisor).BeginInit();
            groupBox5.SuspendLayout();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxQR).BeginInit();
            groupBox3.SuspendLayout();
            groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridFacturas).BeginInit();
            SuspendLayout();
            // 
            // gridVentas
            // 
            gridVentas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridVentas.Location = new Point(66, 111);
            gridVentas.Name = "gridVentas";
            gridVentas.RowHeadersWidth = 51;
            gridVentas.Size = new Size(595, 99);
            gridVentas.TabIndex = 0;
            gridVentas.CellContentClick += gridVentas_CellContentClick;
            gridVentas.CellDoubleClick += gridVentas_CellDoubleClick_1;
            // 
            // gridReceptor
            // 
            gridReceptor.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridReceptor.Location = new Point(66, 272);
            gridReceptor.Name = "gridReceptor";
            gridReceptor.RowHeadersWidth = 51;
            gridReceptor.Size = new Size(595, 99);
            gridReceptor.TabIndex = 1;
            gridReceptor.CellDoubleClick += gridReceptor_CellDoubleClick_1;
            // 
            // gridEmisor
            // 
            gridEmisor.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridEmisor.Location = new Point(66, 433);
            gridEmisor.Name = "gridEmisor";
            gridEmisor.RowHeadersWidth = 51;
            gridEmisor.Size = new Size(595, 99);
            gridEmisor.TabIndex = 2;
            gridEmisor.CellDoubleClick += gridEmisor_CellDoubleClick_1;
            // 
            // comboBoxMetodoPago
            // 
            comboBoxMetodoPago.FormattingEnabled = true;
            comboBoxMetodoPago.Location = new Point(264, 267);
            comboBoxMetodoPago.Name = "comboBoxMetodoPago";
            comboBoxMetodoPago.Size = new Size(151, 28);
            comboBoxMetodoPago.TabIndex = 3;
            // 
            // buttonGenerarFactura
            // 
            buttonGenerarFactura.Location = new Point(202, 342);
            buttonGenerarFactura.Name = "buttonGenerarFactura";
            buttonGenerarFactura.Size = new Size(151, 29);
            buttonGenerarFactura.TabIndex = 4;
            buttonGenerarFactura.Text = "Generar factura";
            buttonGenerarFactura.UseVisualStyleBackColor = true;
            buttonGenerarFactura.Click += buttonGenerarFactura_Click;
            // 
            // lblReceptorSeleccionado
            // 
            lblReceptorSeleccionado.AutoSize = true;
            lblReceptorSeleccionado.Font = new Font("Segoe UI Black", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblReceptorSeleccionado.Location = new Point(132, 27);
            lblReceptorSeleccionado.Name = "lblReceptorSeleccionado";
            lblReceptorSeleccionado.Size = new Size(142, 38);
            lblReceptorSeleccionado.TabIndex = 5;
            lblReceptorSeleccionado.Text = "Receptor";
            // 
            // lblEmisorSeleccionado
            // 
            lblEmisorSeleccionado.AutoSize = true;
            lblEmisorSeleccionado.Font = new Font("Segoe UI Black", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblEmisorSeleccionado.Location = new Point(132, 111);
            lblEmisorSeleccionado.Name = "lblEmisorSeleccionado";
            lblEmisorSeleccionado.Size = new Size(112, 38);
            lblEmisorSeleccionado.TabIndex = 6;
            lblEmisorSeleccionado.Text = "Emisor";
            // 
            // lblVentaSeleccionada
            // 
            lblVentaSeleccionada.AutoSize = true;
            lblVentaSeleccionada.Font = new Font("Segoe UI Black", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblVentaSeleccionada.Location = new Point(132, 184);
            lblVentaSeleccionada.Name = "lblVentaSeleccionada";
            lblVentaSeleccionada.Size = new Size(99, 38);
            lblVentaSeleccionada.TabIndex = 7;
            lblVentaSeleccionada.Text = "Venta";
            // 
            // groupBox5
            // 
            groupBox5.Controls.Add(buttonCerrar);
            groupBox5.Controls.Add(button3);
            groupBox5.Controls.Add(label8);
            groupBox5.Controls.Add(comboBoxCFDI);
            groupBox5.Location = new Point(12, 620);
            groupBox5.Name = "groupBox5";
            groupBox5.Size = new Size(1753, 93);
            groupBox5.TabIndex = 8;
            groupBox5.TabStop = false;
            groupBox5.Text = "Resumen";
            // 
            // buttonCerrar
            // 
            buttonCerrar.Location = new Point(1653, 58);
            buttonCerrar.Name = "buttonCerrar";
            buttonCerrar.Size = new Size(94, 29);
            buttonCerrar.TabIndex = 20;
            buttonCerrar.Text = "Cerrar";
            buttonCerrar.UseVisualStyleBackColor = true;
            buttonCerrar.Click += buttonCerrar_Click;
            // 
            // button3
            // 
            button3.Location = new Point(834, 25);
            button3.Name = "button3";
            button3.Size = new Size(143, 29);
            button3.TabIndex = 19;
            button3.Text = "Acerca CFDI";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(213, 29);
            label8.Name = "label8";
            label8.Size = new Size(93, 20);
            label8.TabIndex = 18;
            label8.Text = "Uso de CFDI:";
            // 
            // comboBoxCFDI
            // 
            comboBoxCFDI.FormattingEnabled = true;
            comboBoxCFDI.Location = new Point(312, 26);
            comboBoxCFDI.Name = "comboBoxCFDI";
            comboBoxCFDI.Size = new Size(516, 28);
            comboBoxCFDI.TabIndex = 17;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(66, 70);
            label1.Name = "label1";
            label1.Size = new Size(104, 20);
            label1.TabIndex = 9;
            label1.Text = "ID´s de ventas:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(66, 231);
            label2.Name = "label2";
            label2.Size = new Size(86, 20);
            label2.TabIndex = 10;
            label2.Text = "Receptores:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(66, 392);
            label3.Name = "label3";
            label3.Size = new Size(71, 20);
            label3.TabIndex = 11;
            label3.Text = "Emisores:";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(gridEmisor);
            groupBox1.Controls.Add(gridReceptor);
            groupBox1.Controls.Add(gridVentas);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(727, 602);
            groupBox1.TabIndex = 12;
            groupBox1.TabStop = false;
            groupBox1.Text = "Busqueda";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(40, 45);
            label4.Name = "label4";
            label4.Size = new Size(72, 20);
            label4.TabIndex = 13;
            label4.Text = "Receptor:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(55, 125);
            label5.Name = "label5";
            label5.Size = new Size(57, 20);
            label5.TabIndex = 14;
            label5.Text = "Emisor:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(14, 198);
            label6.Name = "label6";
            label6.Size = new Size(98, 20);
            label6.TabIndex = 15;
            label6.Text = "ID´s de venta:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(140, 275);
            label7.Name = "label7";
            label7.Size = new Size(104, 20);
            label7.TabIndex = 16;
            label7.Text = "Metodo pago:";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(pictureBoxQR);
            groupBox2.Controls.Add(label7);
            groupBox2.Controls.Add(label6);
            groupBox2.Controls.Add(label5);
            groupBox2.Controls.Add(label4);
            groupBox2.Controls.Add(lblVentaSeleccionada);
            groupBox2.Controls.Add(lblEmisorSeleccionado);
            groupBox2.Controls.Add(lblReceptorSeleccionado);
            groupBox2.Controls.Add(buttonGenerarFactura);
            groupBox2.Controls.Add(comboBoxMetodoPago);
            groupBox2.Location = new Point(745, 12);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(555, 407);
            groupBox2.TabIndex = 17;
            groupBox2.TabStop = false;
            groupBox2.Text = "Datos";
            // 
            // pictureBoxQR
            // 
            pictureBoxQR.Location = new Point(299, 26);
            pictureBoxQR.Name = "pictureBoxQR";
            pictureBoxQR.Size = new Size(250, 211);
            pictureBoxQR.TabIndex = 0;
            pictureBoxQR.TabStop = false;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(button2);
            groupBox3.Controls.Add(button1);
            groupBox3.Location = new Point(745, 425);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(555, 189);
            groupBox3.TabIndex = 18;
            groupBox3.TabStop = false;
            groupBox3.Text = "Grupos";
            // 
            // button2
            // 
            button2.Location = new Point(299, 80);
            button2.Name = "button2";
            button2.Size = new Size(189, 29);
            button2.TabIndex = 18;
            button2.Text = "Administar receptores";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.Location = new Point(66, 80);
            button1.Name = "button1";
            button1.Size = new Size(189, 29);
            button1.TabIndex = 17;
            button1.Text = "Administar emisores";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(gridFacturas);
            groupBox4.Location = new Point(1306, 12);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(459, 602);
            groupBox4.TabIndex = 19;
            groupBox4.TabStop = false;
            groupBox4.Text = "Facturas";
            // 
            // gridFacturas
            // 
            gridFacturas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridFacturas.Location = new Point(6, 26);
            gridFacturas.Name = "gridFacturas";
            gridFacturas.RowHeadersWidth = 51;
            gridFacturas.Size = new Size(447, 570);
            gridFacturas.TabIndex = 0;
            gridFacturas.CellDoubleClick += gridFacturas_CellDoubleClick;
            // 
            // GenerarFactura
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1777, 726);
            Controls.Add(groupBox4);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(groupBox5);
            Name = "GenerarFactura";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "GenerarFactura";
            Load += GenerarFactura_Load;
            ((System.ComponentModel.ISupportInitialize)gridVentas).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridReceptor).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridEmisor).EndInit();
            groupBox5.ResumeLayout(false);
            groupBox5.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxQR).EndInit();
            groupBox3.ResumeLayout(false);
            groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)gridFacturas).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView gridVentas;
        private DataGridView gridReceptor;
        private DataGridView gridEmisor;
        private ComboBox comboBoxMetodoPago;
        private Button buttonGenerarFactura;
        private Label lblReceptorSeleccionado;
        private Label lblEmisorSeleccionado;
        private Label lblVentaSeleccionada;
        private GroupBox groupBox5;
        private Label label1;
        private Label label2;
        private Label label3;
        private GroupBox groupBox1;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private GroupBox groupBox2;
        private GroupBox groupBox3;
        private Button button1;
        private Button button2;
        private Button button3;
        private Label label8;
        private ComboBox comboBoxCFDI;
        private PictureBox pictureBoxQR;
        private Button buttonCerrar;
        private GroupBox groupBox4;
        private DataGridView gridFacturas;
    }
}