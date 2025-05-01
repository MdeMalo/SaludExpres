namespace SaludExpres
{
    partial class DetalleFacturaForm
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
            labelNumeroFactura = new Label();
            labelFechaEmision = new Label();
            labelImpuestos = new Label();
            labelSubtotal = new Label();
            labelUsoCFDI = new Label();
            labelMetodoPago = new Label();
            labelTotal = new Label();
            gridDetallesFactura = new DataGridView();
            groupBox1 = new GroupBox();
            ((System.ComponentModel.ISupportInitialize)gridDetallesFactura).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // labelNumeroFactura
            // 
            labelNumeroFactura.AutoSize = true;
            labelNumeroFactura.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelNumeroFactura.Location = new Point(45, 33);
            labelNumeroFactura.Name = "labelNumeroFactura";
            labelNumeroFactura.Size = new Size(79, 31);
            labelNumeroFactura.TabIndex = 0;
            labelNumeroFactura.Text = "label1";
            // 
            // labelFechaEmision
            // 
            labelFechaEmision.AutoSize = true;
            labelFechaEmision.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelFechaEmision.Location = new Point(45, 75);
            labelFechaEmision.Name = "labelFechaEmision";
            labelFechaEmision.Size = new Size(79, 31);
            labelFechaEmision.TabIndex = 1;
            labelFechaEmision.Text = "label2";
            // 
            // labelImpuestos
            // 
            labelImpuestos.AutoSize = true;
            labelImpuestos.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelImpuestos.Location = new Point(45, 159);
            labelImpuestos.Name = "labelImpuestos";
            labelImpuestos.Size = new Size(79, 31);
            labelImpuestos.TabIndex = 3;
            labelImpuestos.Text = "label3";
            // 
            // labelSubtotal
            // 
            labelSubtotal.AutoSize = true;
            labelSubtotal.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelSubtotal.Location = new Point(45, 117);
            labelSubtotal.Name = "labelSubtotal";
            labelSubtotal.Size = new Size(79, 31);
            labelSubtotal.TabIndex = 2;
            labelSubtotal.Text = "label4";
            // 
            // labelUsoCFDI
            // 
            labelUsoCFDI.AutoSize = true;
            labelUsoCFDI.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelUsoCFDI.Location = new Point(45, 285);
            labelUsoCFDI.Name = "labelUsoCFDI";
            labelUsoCFDI.Size = new Size(79, 31);
            labelUsoCFDI.TabIndex = 6;
            labelUsoCFDI.Text = "label5";
            // 
            // labelMetodoPago
            // 
            labelMetodoPago.AutoSize = true;
            labelMetodoPago.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelMetodoPago.Location = new Point(45, 243);
            labelMetodoPago.Name = "labelMetodoPago";
            labelMetodoPago.Size = new Size(79, 31);
            labelMetodoPago.TabIndex = 5;
            labelMetodoPago.Text = "label6";
            // 
            // labelTotal
            // 
            labelTotal.AutoSize = true;
            labelTotal.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelTotal.Location = new Point(45, 201);
            labelTotal.Name = "labelTotal";
            labelTotal.Size = new Size(79, 31);
            labelTotal.TabIndex = 4;
            labelTotal.Text = "label7";
            // 
            // gridDetallesFactura
            // 
            gridDetallesFactura.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridDetallesFactura.Location = new Point(6, 340);
            gridDetallesFactura.Name = "gridDetallesFactura";
            gridDetallesFactura.RowHeadersWidth = 51;
            gridDetallesFactura.Size = new Size(1026, 147);
            gridDetallesFactura.TabIndex = 7;
            gridDetallesFactura.CellContentClick += gridDetallesFactura_CellContentClick;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(gridDetallesFactura);
            groupBox1.Controls.Add(labelUsoCFDI);
            groupBox1.Controls.Add(labelMetodoPago);
            groupBox1.Controls.Add(labelTotal);
            groupBox1.Controls.Add(labelImpuestos);
            groupBox1.Controls.Add(labelSubtotal);
            groupBox1.Controls.Add(labelFechaEmision);
            groupBox1.Controls.Add(labelNumeroFactura);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1038, 493);
            groupBox1.TabIndex = 8;
            groupBox1.TabStop = false;
            groupBox1.Text = "Detalles";
            // 
            // DetalleFacturaForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1062, 517);
            Controls.Add(groupBox1);
            Name = "DetalleFacturaForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "DetalleFacturaForm";
            Load += DetalleFacturaForm_Load;
            ((System.ComponentModel.ISupportInitialize)gridDetallesFactura).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label labelNumeroFactura;
        private Label labelFechaEmision;
        private Label labelImpuestos;
        private Label labelSubtotal;
        private Label labelUsoCFDI;
        private Label labelMetodoPago;
        private Label labelTotal;
        private DataGridView gridDetallesFactura;
        private GroupBox groupBox1;
    }
}