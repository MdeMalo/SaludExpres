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
            labelSucursal = new Label();
            label5 = new Label();
            labelEmpleado = new Label();
            label2 = new Label();
            dateFecha = new DateTimePicker();
            label1 = new Label();
            groupBox2 = new GroupBox();
            labelNombreCliente = new Label();
            label6 = new Label();
            buttonNuevoCliente = new Button();
            buttonBuscarCliente = new Button();
            textBoxNombreCliente = new TextBox();
            label3 = new Label();
            labelTelefono = new Label();
            label7 = new Label();
            groupBox3 = new GroupBox();
            dataGridView1 = new DataGridView();
            groupBox4 = new GroupBox();
            label4 = new Label();
            textBoxProducto = new TextBox();
            buttonAgregarProducto = new Button();
            groupBox5 = new GroupBox();
            labelSubtotal = new Label();
            label12 = new Label();
            labelIVA = new Label();
            label9 = new Label();
            labelTotal = new Label();
            label10 = new Label();
            groupBox6 = new GroupBox();
            label16 = new Label();
            comboBoxMetodoPago = new ComboBox();
            buttonRegistrarVenta = new Button();
            buttonCancelar = new Button();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            groupBox4.SuspendLayout();
            groupBox5.SuspendLayout();
            groupBox6.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(labelSucursal);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(labelEmpleado);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(dateFecha);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1158, 83);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Datos sucursal";
            groupBox1.Enter += groupBox1_Enter;
            // 
            // labelSucursal
            // 
            labelSucursal.AutoSize = true;
            labelSucursal.Font = new Font("Segoe UI Black", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelSucursal.Location = new Point(919, 22);
            labelSucursal.Name = "labelSucursal";
            labelSucursal.Size = new Size(202, 38);
            labelSucursal.TabIndex = 5;
            labelSucursal.Text = "labelSucursal";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(847, 31);
            label5.Name = "label5";
            label5.Size = new Size(66, 20);
            label5.TabIndex = 4;
            label5.Text = "Sucursal:";
            // 
            // labelEmpleado
            // 
            labelEmpleado.AutoSize = true;
            labelEmpleado.Font = new Font("Segoe UI Black", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelEmpleado.Location = new Point(499, 22);
            labelEmpleado.Name = "labelEmpleado";
            labelEmpleado.Size = new Size(222, 38);
            labelEmpleado.TabIndex = 3;
            labelEmpleado.Text = "labelEmpleado";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(413, 31);
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
            groupBox2.Controls.Add(labelTelefono);
            groupBox2.Controls.Add(label7);
            groupBox2.Controls.Add(labelNombreCliente);
            groupBox2.Controls.Add(label6);
            groupBox2.Controls.Add(buttonNuevoCliente);
            groupBox2.Controls.Add(buttonBuscarCliente);
            groupBox2.Controls.Add(textBoxNombreCliente);
            groupBox2.Controls.Add(label3);
            groupBox2.Location = new Point(12, 101);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(1158, 149);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Datos del cliente:";
            // 
            // labelNombreCliente
            // 
            labelNombreCliente.AutoSize = true;
            labelNombreCliente.Font = new Font("Segoe UI Black", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelNombreCliente.Location = new Point(343, 90);
            labelNombreCliente.Name = "labelNombreCliente";
            labelNombreCliente.Size = new Size(199, 38);
            labelNombreCliente.TabIndex = 5;
            labelNombreCliente.Text = "labelNombre";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(270, 99);
            label6.Name = "label6";
            label6.Size = new Size(67, 20);
            label6.TabIndex = 4;
            label6.Text = "Nombre:";
            // 
            // buttonNuevoCliente
            // 
            buttonNuevoCliente.Location = new Point(751, 40);
            buttonNuevoCliente.Name = "buttonNuevoCliente";
            buttonNuevoCliente.Size = new Size(122, 29);
            buttonNuevoCliente.TabIndex = 3;
            buttonNuevoCliente.Text = "Nuevo cliente";
            buttonNuevoCliente.UseVisualStyleBackColor = true;
            // 
            // buttonBuscarCliente
            // 
            buttonBuscarCliente.Location = new Point(571, 41);
            buttonBuscarCliente.Name = "buttonBuscarCliente";
            buttonBuscarCliente.Size = new Size(122, 29);
            buttonBuscarCliente.TabIndex = 2;
            buttonBuscarCliente.Text = "Buscar cliente";
            buttonBuscarCliente.UseVisualStyleBackColor = true;
            // 
            // textBoxNombreCliente
            // 
            textBoxNombreCliente.Location = new Point(334, 42);
            textBoxNombreCliente.Name = "textBoxNombreCliente";
            textBoxNombreCliente.Size = new Size(152, 27);
            textBoxNombreCliente.TabIndex = 1;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(270, 45);
            label3.Name = "label3";
            label3.Size = new Size(58, 20);
            label3.TabIndex = 0;
            label3.Text = "Cliente:";
            // 
            // labelTelefono
            // 
            labelTelefono.AutoSize = true;
            labelTelefono.Font = new Font("Segoe UI Black", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelTelefono.Location = new Point(679, 90);
            labelTelefono.Name = "labelTelefono";
            labelTelefono.Size = new Size(210, 38);
            labelTelefono.TabIndex = 7;
            labelTelefono.Text = "labelTelefono";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(603, 99);
            label7.Name = "label7";
            label7.Size = new Size(70, 20);
            label7.TabIndex = 6;
            label7.Text = "Teléfono:";
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(dataGridView1);
            groupBox3.Location = new Point(12, 256);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(1158, 280);
            groupBox3.TabIndex = 2;
            groupBox3.TabStop = false;
            groupBox3.Text = "Detalle de venta";
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(6, 26);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(1146, 248);
            dataGridView1.TabIndex = 0;
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(buttonAgregarProducto);
            groupBox4.Controls.Add(textBoxProducto);
            groupBox4.Controls.Add(label4);
            groupBox4.Location = new Point(12, 542);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(1158, 93);
            groupBox4.TabIndex = 3;
            groupBox4.TabStop = false;
            groupBox4.Text = "Agregar productos";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(317, 36);
            label4.Name = "label4";
            label4.Size = new Size(121, 20);
            label4.TabIndex = 0;
            label4.Text = "Añadir producto:";
            // 
            // textBoxProducto
            // 
            textBoxProducto.Location = new Point(444, 33);
            textBoxProducto.Name = "textBoxProducto";
            textBoxProducto.Size = new Size(183, 27);
            textBoxProducto.TabIndex = 2;
            // 
            // buttonAgregarProducto
            // 
            buttonAgregarProducto.Location = new Point(678, 31);
            buttonAgregarProducto.Name = "buttonAgregarProducto";
            buttonAgregarProducto.Size = new Size(163, 29);
            buttonAgregarProducto.TabIndex = 3;
            buttonAgregarProducto.Text = "Agregar producto";
            buttonAgregarProducto.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            groupBox5.Controls.Add(labelTotal);
            groupBox5.Controls.Add(label10);
            groupBox5.Controls.Add(labelIVA);
            groupBox5.Controls.Add(label9);
            groupBox5.Controls.Add(labelSubtotal);
            groupBox5.Controls.Add(label12);
            groupBox5.Location = new Point(12, 641);
            groupBox5.Name = "groupBox5";
            groupBox5.Size = new Size(1158, 93);
            groupBox5.TabIndex = 4;
            groupBox5.TabStop = false;
            groupBox5.Text = "Resumen";
            // 
            // labelSubtotal
            // 
            labelSubtotal.AutoSize = true;
            labelSubtotal.Font = new Font("Segoe UI Black", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelSubtotal.ForeColor = Color.Red;
            labelSubtotal.Location = new Point(139, 27);
            labelSubtotal.Name = "labelSubtotal";
            labelSubtotal.Size = new Size(204, 38);
            labelSubtotal.TabIndex = 9;
            labelSubtotal.Text = "labelSubtotal";
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
            // labelIVA
            // 
            labelIVA.AutoSize = true;
            labelIVA.Font = new Font("Segoe UI Black", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelIVA.ForeColor = Color.Blue;
            labelIVA.Location = new Point(529, 27);
            labelIVA.Name = "labelIVA";
            labelIVA.Size = new Size(136, 38);
            labelIVA.TabIndex = 11;
            labelIVA.Text = "labelIVA";
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
            // labelTotal
            // 
            labelTotal.AutoSize = true;
            labelTotal.Font = new Font("Segoe UI Black", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelTotal.ForeColor = Color.LimeGreen;
            labelTotal.Location = new Point(862, 27);
            labelTotal.Name = "labelTotal";
            labelTotal.Size = new Size(158, 38);
            labelTotal.TabIndex = 13;
            labelTotal.Text = "labelTotal";
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
            // groupBox6
            // 
            groupBox6.Controls.Add(buttonCancelar);
            groupBox6.Controls.Add(buttonRegistrarVenta);
            groupBox6.Controls.Add(comboBoxMetodoPago);
            groupBox6.Controls.Add(label16);
            groupBox6.Location = new Point(12, 740);
            groupBox6.Name = "groupBox6";
            groupBox6.Size = new Size(1158, 93);
            groupBox6.TabIndex = 5;
            groupBox6.TabStop = false;
            groupBox6.Text = "Pago";
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
            // comboBoxMetodoPago
            // 
            comboBoxMetodoPago.FormattingEnabled = true;
            comboBoxMetodoPago.Location = new Point(196, 32);
            comboBoxMetodoPago.Name = "comboBoxMetodoPago";
            comboBoxMetodoPago.Size = new Size(151, 28);
            comboBoxMetodoPago.TabIndex = 13;
            // 
            // buttonRegistrarVenta
            // 
            buttonRegistrarVenta.Location = new Point(783, 32);
            buttonRegistrarVenta.Name = "buttonRegistrarVenta";
            buttonRegistrarVenta.Size = new Size(142, 29);
            buttonRegistrarVenta.TabIndex = 14;
            buttonRegistrarVenta.Text = "Registrar venta";
            buttonRegistrarVenta.UseVisualStyleBackColor = true;
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
            // RegistrarVenta
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1182, 854);
            Controls.Add(groupBox6);
            Controls.Add(groupBox5);
            Controls.Add(groupBox4);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Name = "RegistrarVenta";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "RegistrarVenta";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
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
        private Label labelSucursal;
        private Label label5;
        private Label labelEmpleado;
        private Label label2;
        private GroupBox groupBox2;
        private Label labelNombreCliente;
        private Label label6;
        private Button buttonNuevoCliente;
        private Button buttonBuscarCliente;
        private TextBox textBoxNombreCliente;
        private Label label3;
        private Label labelTelefono;
        private Label label7;
        private GroupBox groupBox3;
        private DataGridView dataGridView1;
        private GroupBox groupBox4;
        private Label label4;
        private Button buttonAgregarProducto;
        private TextBox textBoxProducto;
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
    }
}