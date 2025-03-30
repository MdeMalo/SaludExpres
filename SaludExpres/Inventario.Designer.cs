namespace SaludExpres
{
    partial class Inventario
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
            groupBox3 = new GroupBox();
            buttonEliminar = new Button();
            buttonCerrar = new Button();
            buttonEliminarUs = new Button();
            buttonEditUs = new Button();
            buttonAgregarProducto = new Button();
            groupBox2 = new GroupBox();
            dataGridViewProductos = new DataGridView();
            groupBox1 = new GroupBox();
            buttonBuscar = new Button();
            checkBoxProxCaducidad = new CheckBox();
            checkBoxStockBajo = new CheckBox();
            numericPrecioMax = new NumericUpDown();
            label5 = new Label();
            numericPrecioMin = new NumericUpDown();
            label4 = new Label();
            comboBoxCategoria = new ComboBox();
            label3 = new Label();
            label2 = new Label();
            comboBoxProveedor = new ComboBox();
            textBoxBuscar = new TextBox();
            label1 = new Label();
            label6 = new Label();
            groupBox3.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewProductos).BeginInit();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericPrecioMax).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericPrecioMin).BeginInit();
            SuspendLayout();
            // 
            // groupBox3
            // 
            groupBox3.Anchor = AnchorStyles.Bottom;
            groupBox3.Controls.Add(buttonEliminar);
            groupBox3.Controls.Add(buttonCerrar);
            groupBox3.Controls.Add(buttonEliminarUs);
            groupBox3.Controls.Add(buttonEditUs);
            groupBox3.Controls.Add(buttonAgregarProducto);
            groupBox3.Location = new Point(47, 729);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(1456, 79);
            groupBox3.TabIndex = 6;
            groupBox3.TabStop = false;
            groupBox3.Text = "Gestión";
            // 
            // buttonEliminar
            // 
            buttonEliminar.Anchor = AnchorStyles.Top;
            buttonEliminar.Location = new Point(886, 25);
            buttonEliminar.Name = "buttonEliminar";
            buttonEliminar.Size = new Size(180, 29);
            buttonEliminar.TabIndex = 4;
            buttonEliminar.Text = "Eliminar producto";
            buttonEliminar.UseVisualStyleBackColor = true;
            buttonEliminar.Click += buttonEliminar_Click;
            // 
            // buttonCerrar
            // 
            buttonCerrar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonCerrar.Location = new Point(1356, 44);
            buttonCerrar.Name = "buttonCerrar";
            buttonCerrar.Size = new Size(94, 29);
            buttonCerrar.TabIndex = 3;
            buttonCerrar.Text = "Cerrar";
            buttonCerrar.UseVisualStyleBackColor = true;
            buttonCerrar.Click += buttonCerrar_Click;
            // 
            // buttonEliminarUs
            // 
            buttonEliminarUs.Anchor = AnchorStyles.Top;
            buttonEliminarUs.Location = new Point(1537, 25);
            buttonEliminarUs.Name = "buttonEliminarUs";
            buttonEliminarUs.Size = new Size(180, 29);
            buttonEliminarUs.TabIndex = 2;
            buttonEliminarUs.Text = "Eliminar Usuario";
            buttonEliminarUs.UseVisualStyleBackColor = true;
            // 
            // buttonEditUs
            // 
            buttonEditUs.Anchor = AnchorStyles.Top;
            buttonEditUs.Location = new Point(638, 25);
            buttonEditUs.Name = "buttonEditUs";
            buttonEditUs.Size = new Size(180, 29);
            buttonEditUs.TabIndex = 1;
            buttonEditUs.Text = "Editar producto";
            buttonEditUs.UseVisualStyleBackColor = true;
            buttonEditUs.Click += buttonEditUs_Click;
            // 
            // buttonAgregarProducto
            // 
            buttonAgregarProducto.Anchor = AnchorStyles.Top;
            buttonAgregarProducto.Location = new Point(390, 25);
            buttonAgregarProducto.Name = "buttonAgregarProducto";
            buttonAgregarProducto.Size = new Size(180, 29);
            buttonAgregarProducto.TabIndex = 0;
            buttonAgregarProducto.Text = "Agregar Producto";
            buttonAgregarProducto.UseVisualStyleBackColor = true;
            buttonAgregarProducto.Click += buttonAgregarProducto_Click;
            // 
            // groupBox2
            // 
            groupBox2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            groupBox2.Controls.Add(dataGridViewProductos);
            groupBox2.Location = new Point(47, 138);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(1456, 585);
            groupBox2.TabIndex = 5;
            groupBox2.TabStop = false;
            groupBox2.Text = "Productos";
            // 
            // dataGridViewProductos
            // 
            dataGridViewProductos.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            dataGridViewProductos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewProductos.Location = new Point(3, 26);
            dataGridViewProductos.Name = "dataGridViewProductos";
            dataGridViewProductos.RowHeadersWidth = 51;
            dataGridViewProductos.Size = new Size(1447, 553);
            dataGridViewProductos.TabIndex = 0;
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Top;
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(buttonBuscar);
            groupBox1.Controls.Add(checkBoxProxCaducidad);
            groupBox1.Controls.Add(checkBoxStockBajo);
            groupBox1.Controls.Add(numericPrecioMax);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(numericPrecioMin);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(comboBoxCategoria);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(comboBoxProveedor);
            groupBox1.Controls.Add(textBoxBuscar);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(47, 6);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1456, 126);
            groupBox1.TabIndex = 4;
            groupBox1.TabStop = false;
            groupBox1.Text = "Filtros";
            // 
            // buttonBuscar
            // 
            buttonBuscar.Anchor = AnchorStyles.Top;
            buttonBuscar.Location = new Point(638, 78);
            buttonBuscar.Name = "buttonBuscar";
            buttonBuscar.Size = new Size(180, 29);
            buttonBuscar.TabIndex = 5;
            buttonBuscar.Text = "Buscar";
            buttonBuscar.UseVisualStyleBackColor = true;
            buttonBuscar.Click += buttonBuscar_Click;
            // 
            // checkBoxProxCaducidad
            // 
            checkBoxProxCaducidad.AutoSize = true;
            checkBoxProxCaducidad.Location = new Point(1339, 47);
            checkBoxProxCaducidad.Name = "checkBoxProxCaducidad";
            checkBoxProxCaducidad.Size = new Size(109, 24);
            checkBoxProxCaducidad.TabIndex = 10;
            checkBoxProxCaducidad.Text = "Casi caduca";
            checkBoxProxCaducidad.UseVisualStyleBackColor = true;
            // 
            // checkBoxStockBajo
            // 
            checkBoxStockBajo.AutoSize = true;
            checkBoxStockBajo.Location = new Point(1339, 17);
            checkBoxStockBajo.Name = "checkBoxStockBajo";
            checkBoxStockBajo.Size = new Size(101, 24);
            checkBoxStockBajo.TabIndex = 9;
            checkBoxStockBajo.Text = "Stock bajo";
            checkBoxStockBajo.UseVisualStyleBackColor = true;
            // 
            // numericPrecioMax
            // 
            numericPrecioMax.Location = new Point(1220, 31);
            numericPrecioMax.Name = "numericPrecioMax";
            numericPrecioMax.Size = new Size(98, 27);
            numericPrecioMax.TabIndex = 8;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(1113, 35);
            label5.Name = "label5";
            label5.Size = new Size(100, 20);
            label5.TabIndex = 7;
            label5.Text = "Mayor precio:";
            // 
            // numericPrecioMin
            // 
            numericPrecioMin.Location = new Point(1002, 30);
            numericPrecioMin.Name = "numericPrecioMin";
            numericPrecioMin.Size = new Size(98, 27);
            numericPrecioMin.TabIndex = 6;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(633, 34);
            label4.Name = "label4";
            label4.Size = new Size(77, 20);
            label4.TabIndex = 4;
            label4.Text = "Categoria:";
            // 
            // comboBoxCategoria
            // 
            comboBoxCategoria.FormattingEnabled = true;
            comboBoxCategoria.Items.AddRange(new object[] { "" });
            comboBoxCategoria.Location = new Point(716, 30);
            comboBoxCategoria.Name = "comboBoxCategoria";
            comboBoxCategoria.Size = new Size(173, 28);
            comboBoxCategoria.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(895, 34);
            label3.Name = "label3";
            label3.Size = new Size(101, 20);
            label3.TabIndex = 2;
            label3.Text = "Menor precio:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(376, 34);
            label2.Name = "label2";
            label2.Size = new Size(72, 20);
            label2.TabIndex = 1;
            label2.Text = "Provedor:";
            // 
            // comboBoxProveedor
            // 
            comboBoxProveedor.FormattingEnabled = true;
            comboBoxProveedor.Items.AddRange(new object[] { "" });
            comboBoxProveedor.Location = new Point(454, 30);
            comboBoxProveedor.Name = "comboBoxProveedor";
            comboBoxProveedor.Size = new Size(173, 28);
            comboBoxProveedor.TabIndex = 1;
            // 
            // textBoxBuscar
            // 
            textBoxBuscar.Location = new Point(144, 31);
            textBoxBuscar.Name = "textBoxBuscar";
            textBoxBuscar.Size = new Size(229, 27);
            textBoxBuscar.TabIndex = 1;
            textBoxBuscar.TextChanged += textBoxBuscar_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(18, 38);
            label1.Name = "label1";
            label1.Size = new Size(120, 20);
            label1.TabIndex = 0;
            label1.Text = "Buscar producto:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(18, 61);
            label6.Name = "label6";
            label6.Size = new Size(277, 20);
            label6.TabIndex = 11;
            label6.Text = "(Aplica para nombre, descripcion o lote)";
            // 
            // Inventario
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1550, 820);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Name = "Inventario";
            Text = "Inventario";
            Load += Inventario_Load;
            groupBox3.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridViewProductos).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericPrecioMax).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericPrecioMin).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox3;
        private Button buttonCerrar;
        private Button buttonEliminarUs;
        private Button buttonEditUs;
        private Button buttonAgregarProducto;
        private GroupBox groupBox2;
        private GroupBox groupBox1;
        private Label label3;
        private Label label2;
        private ComboBox comboBoxProveedor;
        private TextBox textBoxBuscar;
        private Label label1;
        private DataGridView dataGridViewProductos;
        private Label label4;
        private ComboBox comboBoxCategoria;
        private CheckBox checkBoxProxCaducidad;
        private CheckBox checkBoxStockBajo;
        private NumericUpDown numericPrecioMax;
        private Label label5;
        private NumericUpDown numericPrecioMin;
        private Button buttonEliminar;
        private Button buttonBuscar;
        private Label label6;
    }
}