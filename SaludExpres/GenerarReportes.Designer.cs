namespace SaludExpres
{
    partial class GenerarReportes
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
            comboTipoReporte = new ComboBox();
            label1 = new Label();
            buttonGenerar = new Button();
            dateInicio = new DateTimePicker();
            label2 = new Label();
            label3 = new Label();
            dateFin = new DateTimePicker();
            dataGridReportes = new DataGridView();
            buttonCancelar = new Button();
            label4 = new Label();
            groupBox1 = new GroupBox();
            groupBox2 = new GroupBox();
            ((System.ComponentModel.ISupportInitialize)dataGridReportes).BeginInit();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // comboTipoReporte
            // 
            comboTipoReporte.FormattingEnabled = true;
            comboTipoReporte.Items.AddRange(new object[] { "" });
            comboTipoReporte.Location = new Point(816, 104);
            comboTipoReporte.Name = "comboTipoReporte";
            comboTipoReporte.Size = new Size(151, 28);
            comboTipoReporte.TabIndex = 0;
            comboTipoReporte.SelectedIndexChanged += comboTipoReporte_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(609, 112);
            label1.Name = "label1";
            label1.Size = new Size(201, 20);
            label1.TabIndex = 1;
            label1.Text = "Seleccione el tipo de reporte";
            // 
            // buttonGenerar
            // 
            buttonGenerar.Location = new Point(605, 180);
            buttonGenerar.Name = "buttonGenerar";
            buttonGenerar.Size = new Size(166, 29);
            buttonGenerar.TabIndex = 2;
            buttonGenerar.Text = "Generar reporte";
            buttonGenerar.UseVisualStyleBackColor = true;
            buttonGenerar.Click += buttonGenerar_Click;
            // 
            // dateInicio
            // 
            dateInicio.Location = new Point(501, 47);
            dateInicio.Name = "dateInicio";
            dateInicio.Size = new Size(283, 27);
            dateInicio.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(405, 54);
            label2.Name = "label2";
            label2.Size = new Size(90, 20);
            label2.TabIndex = 4;
            label2.Text = "Fecha inicio:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(811, 54);
            label3.Name = "label3";
            label3.Size = new Size(71, 20);
            label3.TabIndex = 6;
            label3.Text = "Fecha fin:";
            // 
            // dateFin
            // 
            dateFin.Location = new Point(888, 47);
            dateFin.Name = "dateFin";
            dateFin.Size = new Size(283, 27);
            dateFin.TabIndex = 5;
            // 
            // dataGridReportes
            // 
            dataGridReportes.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            dataGridReportes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridReportes.Location = new Point(6, 26);
            dataGridReportes.Name = "dataGridReportes";
            dataGridReportes.RowHeadersWidth = 51;
            dataGridReportes.Size = new Size(1571, 364);
            dataGridReportes.TabIndex = 7;
            // 
            // buttonCancelar
            // 
            buttonCancelar.Location = new Point(805, 180);
            buttonCancelar.Name = "buttonCancelar";
            buttonCancelar.Size = new Size(166, 29);
            buttonCancelar.TabIndex = 10;
            buttonCancelar.Text = "Cancelar";
            buttonCancelar.UseVisualStyleBackColor = true;
            buttonCancelar.Click += buttonCancelar_Click;
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Top;
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Black", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(12, 29);
            label4.Name = "label4";
            label4.Size = new Size(158, 38);
            label4.TabIndex = 11;
            label4.Text = "REPORTES";
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            groupBox1.Controls.Add(dataGridReportes);
            groupBox1.Location = new Point(12, 70);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1583, 396);
            groupBox1.TabIndex = 12;
            groupBox1.TabStop = false;
            groupBox1.Text = "Reportes";
            // 
            // groupBox2
            // 
            groupBox2.Anchor = AnchorStyles.Bottom;
            groupBox2.Controls.Add(buttonCancelar);
            groupBox2.Controls.Add(label3);
            groupBox2.Controls.Add(dateFin);
            groupBox2.Controls.Add(label2);
            groupBox2.Controls.Add(dateInicio);
            groupBox2.Controls.Add(buttonGenerar);
            groupBox2.Controls.Add(label1);
            groupBox2.Controls.Add(comboTipoReporte);
            groupBox2.Location = new Point(18, 472);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(1577, 224);
            groupBox2.TabIndex = 13;
            groupBox2.TabStop = false;
            groupBox2.Text = "Filtros de busqueda";
            // 
            // GenerarReportes
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1607, 708);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(label4);
            Name = "GenerarReportes";
            Text = "GenerarReportes";
            Load += GenerarReportes_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridReportes).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox comboTipoReporte;
        private Label label1;
        private Button buttonGenerar;
        private DateTimePicker dateInicio;
        private Label label2;
        private Label label3;
        private DateTimePicker dateFin;
        private DataGridView dataGridReportes;
        private Button buttonCancelar;
        private Label label4;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
    }
}