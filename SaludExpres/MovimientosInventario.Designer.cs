namespace SaludExpres
{
    partial class MovimientosInventario
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
            dataGridViewMovimientos = new DataGridView();
            buttonCerrar = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewMovimientos).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewMovimientos
            // 
            dataGridViewMovimientos.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewMovimientos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewMovimientos.Location = new Point(42, 25);
            dataGridViewMovimientos.Name = "dataGridViewMovimientos";
            dataGridViewMovimientos.RowHeadersWidth = 51;
            dataGridViewMovimientos.Size = new Size(1233, 347);
            dataGridViewMovimientos.TabIndex = 0;
            // 
            // buttonCerrar
            // 
            buttonCerrar.Location = new Point(611, 394);
            buttonCerrar.Name = "buttonCerrar";
            buttonCerrar.Size = new Size(94, 29);
            buttonCerrar.TabIndex = 1;
            buttonCerrar.Text = "Cerrar";
            buttonCerrar.UseVisualStyleBackColor = true;
            buttonCerrar.Click += buttonCerrar_Click;
            // 
            // MovimientosInventario
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1316, 450);
            Controls.Add(buttonCerrar);
            Controls.Add(dataGridViewMovimientos);
            Name = "MovimientosInventario";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "MovimientosInventario";
            Load += MovimientosInventario_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewMovimientos).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridViewMovimientos;
        private Button buttonCerrar;
    }
}