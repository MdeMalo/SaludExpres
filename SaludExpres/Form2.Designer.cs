namespace SaludExpres
{
    partial class Form2
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
            dataGridMetricas = new DataGridView();
            labelBienvenida = new Label();
            groupBox2 = new GroupBox();
            button1 = new Button();
            buttonAuditoria = new Button();
            buttonVerRecetas = new Button();
            buttonMovsInventario = new Button();
            buttonFactura = new Button();
            buttonRegistrarProveedor = new Button();
            buttonAdminResp = new Button();
            buttonClose = new Button();
            buttonRegVisita = new Button();
            buttonSucursales = new Button();
            button3 = new Button();
            buttonUsuarios = new Button();
            buttonRegistrarProducto = new Button();
            buttonRegistrarVentas = new Button();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridMetricas).BeginInit();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Top;
            groupBox1.Controls.Add(dataGridMetricas);
            groupBox1.Location = new Point(416, 87);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(566, 463);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Metricas del dia";
            // 
            // dataGridMetricas
            // 
            dataGridMetricas.BackgroundColor = SystemColors.ButtonHighlight;
            dataGridMetricas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridMetricas.GridColor = SystemColors.HighlightText;
            dataGridMetricas.Location = new Point(6, 26);
            dataGridMetricas.Name = "dataGridMetricas";
            dataGridMetricas.RowHeadersWidth = 51;
            dataGridMetricas.Size = new Size(554, 431);
            dataGridMetricas.TabIndex = 0;
            dataGridMetricas.CellContentClick += dataGridMetricas_CellContentClick;
            // 
            // labelBienvenida
            // 
            labelBienvenida.Anchor = AnchorStyles.Top;
            labelBienvenida.AutoSize = true;
            labelBienvenida.Font = new Font("Segoe UI Black", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelBienvenida.Location = new Point(416, 31);
            labelBienvenida.Name = "labelBienvenida";
            labelBienvenida.Size = new Size(194, 38);
            labelBienvenida.TabIndex = 1;
            labelBienvenida.Text = "BIENVENIDO";
            // 
            // groupBox2
            // 
            groupBox2.Anchor = AnchorStyles.Top;
            groupBox2.Controls.Add(button1);
            groupBox2.Controls.Add(buttonAuditoria);
            groupBox2.Controls.Add(buttonVerRecetas);
            groupBox2.Controls.Add(buttonMovsInventario);
            groupBox2.Controls.Add(buttonFactura);
            groupBox2.Controls.Add(buttonRegistrarProveedor);
            groupBox2.Controls.Add(buttonAdminResp);
            groupBox2.Controls.Add(buttonClose);
            groupBox2.Controls.Add(buttonRegVisita);
            groupBox2.Controls.Add(buttonSucursales);
            groupBox2.Controls.Add(button3);
            groupBox2.Controls.Add(buttonUsuarios);
            groupBox2.Controls.Add(buttonRegistrarProducto);
            groupBox2.Controls.Add(buttonRegistrarVentas);
            groupBox2.Location = new Point(416, 556);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(566, 339);
            groupBox2.TabIndex = 2;
            groupBox2.TabStop = false;
            groupBox2.Text = "Administración";
            // 
            // button1
            // 
            button1.Location = new Point(6, 304);
            button1.Name = "button1";
            button1.Size = new Size(136, 29);
            button1.TabIndex = 17;
            button1.Text = "Cerrar sesión";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // buttonAuditoria
            // 
            buttonAuditoria.Location = new Point(302, 256);
            buttonAuditoria.Name = "buttonAuditoria";
            buttonAuditoria.Size = new Size(196, 29);
            buttonAuditoria.TabIndex = 16;
            buttonAuditoria.Text = "Auditoria";
            buttonAuditoria.UseVisualStyleBackColor = true;
            buttonAuditoria.Click += buttonAuditoria_Click;
            // 
            // buttonVerRecetas
            // 
            buttonVerRecetas.Location = new Point(69, 256);
            buttonVerRecetas.Name = "buttonVerRecetas";
            buttonVerRecetas.Size = new Size(196, 29);
            buttonVerRecetas.TabIndex = 15;
            buttonVerRecetas.Text = "Recetas";
            buttonVerRecetas.UseVisualStyleBackColor = true;
            buttonVerRecetas.Click += buttonVerRecetas_Click;
            // 
            // buttonMovsInventario
            // 
            buttonMovsInventario.Location = new Point(302, 212);
            buttonMovsInventario.Name = "buttonMovsInventario";
            buttonMovsInventario.Size = new Size(196, 29);
            buttonMovsInventario.TabIndex = 14;
            buttonMovsInventario.Text = "Movimientos Inventario";
            buttonMovsInventario.UseVisualStyleBackColor = true;
            buttonMovsInventario.Click += buttonMovsInventario_Click;
            // 
            // buttonFactura
            // 
            buttonFactura.Location = new Point(69, 212);
            buttonFactura.Name = "buttonFactura";
            buttonFactura.Size = new Size(196, 29);
            buttonFactura.TabIndex = 13;
            buttonFactura.Text = "Generar factura";
            buttonFactura.UseVisualStyleBackColor = true;
            buttonFactura.Click += buttonFactura_Click;
            // 
            // buttonRegistrarProveedor
            // 
            buttonRegistrarProveedor.Location = new Point(69, 168);
            buttonRegistrarProveedor.Name = "buttonRegistrarProveedor";
            buttonRegistrarProveedor.Size = new Size(196, 29);
            buttonRegistrarProveedor.TabIndex = 12;
            buttonRegistrarProveedor.Text = "Administrar proveedor";
            buttonRegistrarProveedor.UseVisualStyleBackColor = true;
            buttonRegistrarProveedor.Click += buttonRegistrarProveedor_Click;
            // 
            // buttonAdminResp
            // 
            buttonAdminResp.Location = new Point(302, 127);
            buttonAdminResp.Name = "buttonAdminResp";
            buttonAdminResp.Size = new Size(196, 29);
            buttonAdminResp.TabIndex = 11;
            buttonAdminResp.Text = "Administrar responsables";
            buttonAdminResp.UseVisualStyleBackColor = true;
            buttonAdminResp.Click += buttonAdminResp_Click;
            // 
            // buttonClose
            // 
            buttonClose.Location = new Point(424, 304);
            buttonClose.Name = "buttonClose";
            buttonClose.Size = new Size(136, 29);
            buttonClose.TabIndex = 10;
            buttonClose.Text = "Cerrar";
            buttonClose.UseVisualStyleBackColor = true;
            buttonClose.Click += buttonClose_Click;
            // 
            // buttonRegVisita
            // 
            buttonRegVisita.Location = new Point(302, 168);
            buttonRegVisita.Name = "buttonRegVisita";
            buttonRegVisita.Size = new Size(196, 29);
            buttonRegVisita.TabIndex = 9;
            buttonRegVisita.Text = "Registrar visita sanitaria";
            buttonRegVisita.UseVisualStyleBackColor = true;
            buttonRegVisita.Click += buttonRegVisita_Click;
            // 
            // buttonSucursales
            // 
            buttonSucursales.Location = new Point(69, 127);
            buttonSucursales.Name = "buttonSucursales";
            buttonSucursales.Size = new Size(196, 29);
            buttonSucursales.TabIndex = 7;
            buttonSucursales.Text = "Sucursales";
            buttonSucursales.UseVisualStyleBackColor = true;
            buttonSucursales.Click += buttonSucursales_Click;
            // 
            // button3
            // 
            button3.Location = new Point(302, 86);
            button3.Name = "button3";
            button3.Size = new Size(196, 29);
            button3.TabIndex = 6;
            button3.Text = "Reportes";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // buttonUsuarios
            // 
            buttonUsuarios.Location = new Point(302, 45);
            buttonUsuarios.Name = "buttonUsuarios";
            buttonUsuarios.Size = new Size(196, 29);
            buttonUsuarios.TabIndex = 5;
            buttonUsuarios.Text = "Usuarios";
            buttonUsuarios.UseVisualStyleBackColor = true;
            buttonUsuarios.Click += buttonUsuarios_Click;
            // 
            // buttonRegistrarProducto
            // 
            buttonRegistrarProducto.Location = new Point(69, 86);
            buttonRegistrarProducto.Name = "buttonRegistrarProducto";
            buttonRegistrarProducto.Size = new Size(196, 29);
            buttonRegistrarProducto.TabIndex = 4;
            buttonRegistrarProducto.Text = "Inventario";
            buttonRegistrarProducto.UseVisualStyleBackColor = true;
            buttonRegistrarProducto.Click += buttonRegistrarProducto_Click;
            // 
            // buttonRegistrarVentas
            // 
            buttonRegistrarVentas.Location = new Point(69, 45);
            buttonRegistrarVentas.Name = "buttonRegistrarVentas";
            buttonRegistrarVentas.Size = new Size(196, 29);
            buttonRegistrarVentas.TabIndex = 3;
            buttonRegistrarVentas.Text = "Registrar ventas";
            buttonRegistrarVentas.UseVisualStyleBackColor = true;
            buttonRegistrarVentas.Click += buttonRegistrarVentas_Click;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1398, 907);
            Controls.Add(groupBox2);
            Controls.Add(labelBienvenida);
            Controls.Add(groupBox1);
            Name = "Form2";
            Text = "Form2";
            Load += Form2_Load;
            groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridMetricas).EndInit();
            groupBox2.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox groupBox1;
        private Label labelBienvenida;
        private GroupBox groupBox2;
        private Button button3;
        private Button buttonUsuarios;
        private Button buttonRegistrarProducto;
        private Button buttonRegistrarVentas;
        private Button buttonSucursales;
        private Button buttonRegVisita;
        private Button buttonClose;
        private Button buttonAdminResp;
        private Button buttonRegistrarProveedor;
        private Button buttonFactura;
        private Button buttonMovsInventario;
        private Button buttonVerRecetas;
        private DataGridView dataGridMetricas;
        private Button buttonAuditoria;
        private Button button1;
    }
}