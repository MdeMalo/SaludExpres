namespace SaludExpres
{
    partial class RegistrarVenta
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
            groupBox1 = new GroupBox();
            lblSucursal = new Label();
            label5 = new Label();
            lblEmpleado = new Label();
            label2 = new Label();
            dateFecha = new DateTimePicker();
            label1 = new Label();
            groupBox2 = new GroupBox();
            dataGridViewClientes = new DataGridView();
            lblTelefonoCliente = new Label();
            label7 = new Label();
            lblNombreCliente = new Label();
            label6 = new Label();
            buttonNuevoCliente = new Button();
            buttonBuscarCliente = new Button();
            textBoxClienteID = new TextBox();
            label3 = new Label();
            groupBox3 = new GroupBox();
            dataGridViewCarrito = new DataGridView();
            groupBox4 = new GroupBox();
            dataGridViewProductos = new DataGridView();
            label13 = new Label();
            numericCantidad = new NumericUpDown();
            buttonAgregarProducto = new Button();
            textBoxBuscarProducto = new TextBox();
            label4 = new Label();
            groupBox5 = new GroupBox();
            labelTotal = new Label();
            label10 = new Label();
            labelIVA = new Label();
            label9 = new Label();
            labelSubtotal = new Label();
            label12 = new Label();
            groupBox6 = new GroupBox();
            buttonCancelar = new Button();
            buttonRegistrarVenta = new Button();
            comboBoxMetodoPago = new ComboBox();
            label16 = new Label();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewClientes).BeginInit();
            groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewCarrito).BeginInit();
            groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewProductos).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericCantidad).BeginInit();
            groupBox5.SuspendLayout();
            groupBox6.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(lblSucursal);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(lblEmpleado);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(dateFecha);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1400, 83);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Datos sucursal";
            // 
            // lblSucursal
            // 
            lblSucursal.AutoSize = true;
            lblSucursal.Font = new Font("Segoe UI Black", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblSucursal.Location = new Point(823, 17);
            lblSucursal.Name = "lblSucursal";
            lblSucursal.Size = new Size(202, 38);
            lblSucursal.TabIndex = 5;
            lblSucursal.Text = "labelSucursal";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(751, 26);
            label5.Name = "label5";
            label5.Size = new Size(66, 20);
            label5.TabIndex = 4;
            label5.Text = "Sucursal:";
            // 
            // lblEmpleado
            // 
            lblEmpleado.AutoSize = true;
            lblEmpleado.Font = new Font("Segoe UI Black", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblEmpleado.Location = new Point(447, 17);
            lblEmpleado.Name = "lblEmpleado";
            lblEmpleado.Size = new Size(222, 38);
            lblEmpleado.TabIndex = 3;
            lblEmpleado.Text = "labelEmpleado";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(361, 26);
            label2.Name = "label2";
            label2.Size = new Size(80, 20);
            label2.TabIndex = 2;
            label2.Text = "Empleado:";
            // 
            // dateFecha
            // 
            dateFecha.Enabled = false;
            dateFecha.Location = new Point(74, 26);
            dateFecha.Name = "dateFecha";
            dateFecha.Size = new Size(269, 27);
            dateFecha.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(18, 31);
            label1.Name = "label1";
            label1.Size = new Size(50, 20);
            label1.TabIndex = 0;
            label1.Text = "Fecha:";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(dataGridViewClientes);
            groupBox2.Controls.Add(lblTelefonoCliente);
            groupBox2.Controls.Add(label7);
            groupBox2.Controls.Add(lblNombreCliente);
            groupBox2.Controls.Add(label6);
            groupBox2.Controls.Add(buttonNuevoCliente);
            groupBox2.Controls.Add(buttonBuscarCliente);
            groupBox2.Controls.Add(textBoxClienteID);
            groupBox2.Controls.Add(label3);
            groupBox2.Location = new Point(12, 101);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(1400, 149);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Datos del cliente:";
            // 
            // dataGridViewClientes
            // 
            dataGridViewClientes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewClientes.Location = new Point(648, 30);
            dataGridViewClientes.Name = "dataGridViewClientes";
            dataGridViewClientes.RowHeadersWidth = 51;
            dataGridViewClientes.Size = new Size(746, 107);
            dataGridViewClientes.TabIndex = 10;
            // 
            // lblTelefonoCliente
            // 
            lblTelefonoCliente.AutoSize = true;
            lblTelefonoCliente.Font = new Font("Segoe UI Black", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTelefonoCliente.Location = new Point(419, 80);
            lblTelefonoCliente.Name = "lblTelefonoCliente";
            lblTelefonoCliente.Size = new Size(137, 38);
            lblTelefonoCliente.TabIndex = 7;
            lblTelefonoCliente.Text = "__________";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(343, 89);
            label7.Name = "label7";
            label7.Size = new Size(70, 20);
            label7.TabIndex = 6;
            label7.Text = "Teléfono:";
            // 
            // lblNombreCliente
            // 
            lblNombreCliente.AutoSize = true;
            lblNombreCliente.Font = new Font("Segoe UI Black", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblNombreCliente.Location = new Point(83, 80);
            lblNombreCliente.Name = "lblNombreCliente";
            lblNombreCliente.Size = new Size(137, 38);
            lblNombreCliente.TabIndex = 5;
            lblNombreCliente.Text = "__________";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(10, 89);
            label6.Name = "label6";
            label6.Size = new Size(67, 20);
            label6.TabIndex = 4;
            label6.Text = "Nombre:";
            // 
            // buttonNuevoCliente
            // 
            buttonNuevoCliente.Location = new Point(491, 30);
            buttonNuevoCliente.Name = "buttonNuevoCliente";
            buttonNuevoCliente.Size = new Size(122, 29);
            buttonNuevoCliente.TabIndex = 3;
            buttonNuevoCliente.Text = "Nuevo cliente";
            buttonNuevoCliente.UseVisualStyleBackColor = true;
            buttonNuevoCliente.Click += buttonNuevoCliente_Click;
            // 
            // buttonBuscarCliente
            // 
            buttonBuscarCliente.Location = new Point(311, 31);
            buttonBuscarCliente.Name = "buttonBuscarCliente";
            buttonBuscarCliente.Size = new Size(122, 29);
            buttonBuscarCliente.TabIndex = 2;
            buttonBuscarCliente.Text = "Buscar cliente";
            buttonBuscarCliente.UseVisualStyleBackColor = true;
            buttonBuscarCliente.Click += buttonBuscarCliente_Click;
            // 
            // textBoxClienteID
            // 
            textBoxClienteID.Location = new Point(74, 32);
            textBoxClienteID.Name = "textBoxClienteID";
            textBoxClienteID.Size = new Size(152, 27);
            textBoxClienteID.TabIndex = 1;
            textBoxClienteID.TextChanged += textBoxClienteID_TextChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(10, 35);
            label3.Name = "label3";
            label3.Size = new Size(58, 20);
            label3.TabIndex = 0;
            label3.Text = "Cliente:";
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(dataGridViewCarrito);
            groupBox3.Location = new Point(12, 256);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(1400, 280);
            groupBox3.TabIndex = 2;
            groupBox3.TabStop = false;
            groupBox3.Text = "Detalle de venta";
            // 
            // dataGridViewCarrito
            // 
            dataGridViewCarrito.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCarrito.Location = new Point(6, 26);
            dataGridViewCarrito.Name = "dataGridViewCarrito";
            dataGridViewCarrito.RowHeadersWidth = 51;
            dataGridViewCarrito.Size = new Size(1388, 248);
            dataGridViewCarrito.TabIndex = 0;
            dataGridViewCarrito.CellDoubleClick += dataGridViewCarrito_CellDoubleClick;
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(dataGridViewProductos);
            groupBox4.Controls.Add(label13);
            groupBox4.Controls.Add(numericCantidad);
            groupBox4.Controls.Add(buttonAgregarProducto);
            groupBox4.Controls.Add(textBoxBuscarProducto);
            groupBox4.Controls.Add(label4);
            groupBox4.Location = new Point(12, 542);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(1400, 202);
            groupBox4.TabIndex = 3;
            groupBox4.TabStop = false;
            groupBox4.Text = "Agregar productos";
            // 
            // dataGridViewProductos
            // 
            dataGridViewProductos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewProductos.Location = new Point(648, 16);
            dataGridViewProductos.Name = "dataGridViewProductos";
            dataGridViewProductos.RowHeadersWidth = 51;
            dataGridViewProductos.Size = new Size(746, 180);
            dataGridViewProductos.TabIndex = 11;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(405, 40);
            label13.Name = "label13";
            label13.Size = new Size(72, 20);
            label13.TabIndex = 9;
            label13.Text = "Cantidad:";
            // 
            // numericCantidad
            // 
            numericCantidad.Location = new Point(483, 36);
            numericCantidad.Name = "numericCantidad";
            numericCantidad.Size = new Size(150, 27);
            numericCantidad.TabIndex = 8;
            // 
            // buttonAgregarProducto
            // 
            buttonAgregarProducto.Location = new Point(278, 122);
            buttonAgregarProducto.Name = "buttonAgregarProducto";
            buttonAgregarProducto.Size = new Size(163, 29);
            buttonAgregarProducto.TabIndex = 3;
            buttonAgregarProducto.Text = "Agregar producto";
            buttonAgregarProducto.UseVisualStyleBackColor = true;
            buttonAgregarProducto.Click += buttonAgregarProducto_Click;
            // 
            // textBoxBuscarProducto
            // 
            textBoxBuscarProducto.Location = new Point(164, 38);
            textBoxBuscarProducto.Name = "textBoxBuscarProducto";
            textBoxBuscarProducto.Size = new Size(183, 27);
            textBoxBuscarProducto.TabIndex = 2;
            textBoxBuscarProducto.TextChanged += textBoxProducto_TextChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(37, 41);
            label4.Name = "label4";
            label4.Size = new Size(121, 20);
            label4.TabIndex = 0;
            label4.Text = "Añadir producto:";
            // 
            // groupBox5
            // 
            groupBox5.Controls.Add(labelTotal);
            groupBox5.Controls.Add(label10);
            groupBox5.Controls.Add(labelIVA);
            groupBox5.Controls.Add(label9);
            groupBox5.Controls.Add(labelSubtotal);
            groupBox5.Controls.Add(label12);
            groupBox5.Location = new Point(12, 750);
            groupBox5.Name = "groupBox5";
            groupBox5.Size = new Size(1400, 93);
            groupBox5.TabIndex = 4;
            groupBox5.TabStop = false;
            groupBox5.Text = "Resumen";
            // 
            // labelTotal
            // 
            labelTotal.AutoSize = true;
            labelTotal.Font = new Font("Segoe UI Black", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelTotal.ForeColor = Color.LimeGreen;
            labelTotal.Location = new Point(862, 27);
            labelTotal.Name = "labelTotal";
            labelTotal.Size = new Size(137, 38);
            labelTotal.TabIndex = 13;
            labelTotal.Text = "__________";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(811, 36);
            label10.Name = "label10";
            label10.Size = new Size(45, 20);
            label10.TabIndex = 12;
            label10.Text = "Total:";
            // 
            // labelIVA
            // 
            labelIVA.AutoSize = true;
            labelIVA.Font = new Font("Segoe UI Black", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelIVA.ForeColor = Color.Blue;
            labelIVA.Location = new Point(529, 27);
            labelIVA.Name = "labelIVA";
            labelIVA.Size = new Size(137, 38);
            labelIVA.TabIndex = 11;
            labelIVA.Text = "__________";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(489, 36);
            label9.Name = "label9";
            label9.Size = new Size(34, 20);
            label9.TabIndex = 10;
            label9.Text = "IVA:";
            // 
            // labelSubtotal
            // 
            labelSubtotal.AutoSize = true;
            labelSubtotal.Font = new Font("Segoe UI Black", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelSubtotal.ForeColor = Color.Red;
            labelSubtotal.Location = new Point(139, 27);
            labelSubtotal.Name = "labelSubtotal";
            labelSubtotal.Size = new Size(137, 38);
            labelSubtotal.TabIndex = 9;
            labelSubtotal.Text = "__________";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(65, 36);
            label12.Name = "label12";
            label12.Size = new Size(68, 20);
            label12.TabIndex = 8;
            label12.Text = "Subtotal:";
            // 
            // groupBox6
            // 
            groupBox6.Controls.Add(buttonCancelar);
            groupBox6.Controls.Add(buttonRegistrarVenta);
            groupBox6.Controls.Add(comboBoxMetodoPago);
            groupBox6.Controls.Add(label16);
            groupBox6.Location = new Point(12, 849);
            groupBox6.Name = "groupBox6";
            groupBox6.Size = new Size(1400, 93);
            groupBox6.TabIndex = 5;
            groupBox6.TabStop = false;
            groupBox6.Text = "Pago";
            // 
            // buttonCancelar
            // 
            buttonCancelar.Location = new Point(949, 32);
            buttonCancelar.Name = "buttonCancelar";
            buttonCancelar.Size = new Size(142, 29);
            buttonCancelar.TabIndex = 15;
            buttonCancelar.Text = "Cancelar";
            buttonCancelar.UseVisualStyleBackColor = true;
            // 
            // buttonRegistrarVenta
            // 
            buttonRegistrarVenta.Location = new Point(783, 32);
            buttonRegistrarVenta.Name = "buttonRegistrarVenta";
            buttonRegistrarVenta.Size = new Size(142, 29);
            buttonRegistrarVenta.TabIndex = 14;
            buttonRegistrarVenta.Text = "Registrar venta";
            buttonRegistrarVenta.UseVisualStyleBackColor = true;
            buttonRegistrarVenta.Click += buttonRegistrarVenta_Click;
            // 
            // comboBoxMetodoPago
            // 
            comboBoxMetodoPago.FormattingEnabled = true;
            comboBoxMetodoPago.Location = new Point(196, 32);
            comboBoxMetodoPago.Name = "comboBoxMetodoPago";
            comboBoxMetodoPago.Size = new Size(151, 28);
            comboBoxMetodoPago.TabIndex = 13;
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Location = new Point(65, 36);
            label16.Name = "label16";
            label16.Size = new Size(125, 20);
            label16.TabIndex = 8;
            label16.Text = "Metodo de pago:";
            // 
            // RegistrarVenta
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1424, 947);
            Controls.Add(groupBox6);
            Controls.Add(groupBox5);
            Controls.Add(groupBox4);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Name = "RegistrarVenta";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "RegistrarVenta";
            Load += RegistrarVenta_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewClientes).EndInit();
            groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridViewCarrito).EndInit();
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewProductos).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericCantidad).EndInit();
            groupBox5.ResumeLayout(false);
            groupBox5.PerformLayout();
            groupBox6.ResumeLayout(false);
            groupBox6.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private DateTimePicker dateFecha;
        private Label label1;
        private Label lblSucursal;
        private Label label5;
        private Label lblEmpleado;
        private Label label2;
        private GroupBox groupBox2;
        private Label lblNombreCliente;
        private Label label6;
        private Button buttonNuevoCliente;
        private Button buttonBuscarCliente;
        private TextBox textBoxClienteID;
        private Label label3;
        private Label lblTelefonoCliente;
        private Label label7;
        private GroupBox groupBox3;
        private DataGridView dataGridViewCarrito;
        private GroupBox groupBox4;
        private Label label4;
        private Button buttonAgregarProducto;
        private TextBox textBoxBuscarProducto;
        private GroupBox groupBox5;
        private Label labelIVA;
        private Label label9;
        private Label labelSubtotal;
        private Label label12;
        private Label labelTotal;
        private Label label10;
        private GroupBox groupBox6;
        private Label label16;
        private Button buttonCancelar;
        private Button buttonRegistrarVenta;
        private ComboBox comboBoxMetodoPago;
        private Label label13;
        private NumericUpDown numericCantidad;
        private DataGridView dataGridViewClientes;
        private DataGridView dataGridViewProductos;
    }
}