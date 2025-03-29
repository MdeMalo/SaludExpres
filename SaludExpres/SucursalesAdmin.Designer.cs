namespace SaludExpres
{
    partial class SucursalesAdmin
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
            label1 = new Label();
            groupBox1 = new GroupBox();
            dataGridSucursales = new DataGridView();
            groupBox2 = new GroupBox();
            buttonEditSucursal = new Button();
            buttonDeleteSucursal = new Button();
            buttonAddSucursal = new Button();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridSucursales).BeginInit();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Black", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(42, 9);
            label1.Name = "label1";
            label1.Size = new Size(195, 38);
            label1.TabIndex = 2;
            label1.Text = "SUCURSALES";
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Top;
            groupBox1.Controls.Add(dataGridSucursales);
            groupBox1.Location = new Point(36, 60);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1372, 479);
            groupBox1.TabIndex = 3;
            groupBox1.TabStop = false;
            groupBox1.Text = "Sucursales";
            // 
            // dataGridSucursales
            // 
            dataGridSucursales.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridSucursales.Location = new Point(6, 26);
            dataGridSucursales.Name = "dataGridSucursales";
            dataGridSucursales.RowHeadersWidth = 51;
            dataGridSucursales.Size = new Size(1360, 447);
            dataGridSucursales.TabIndex = 0;
            // 
            // groupBox2
            // 
            groupBox2.Anchor = AnchorStyles.Top;
            groupBox2.Controls.Add(buttonEditSucursal);
            groupBox2.Controls.Add(buttonDeleteSucursal);
            groupBox2.Controls.Add(buttonAddSucursal);
            groupBox2.Location = new Point(36, 545);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(1372, 105);
            groupBox2.TabIndex = 4;
            groupBox2.TabStop = false;
            groupBox2.Text = "Gestion";
            // 
            // buttonEditSucursal
            // 
            buttonEditSucursal.Location = new Point(769, 38);
            buttonEditSucursal.Name = "buttonEditSucursal";
            buttonEditSucursal.Size = new Size(140, 29);
            buttonEditSucursal.TabIndex = 7;
            buttonEditSucursal.Text = "Editar sucursal";
            buttonEditSucursal.UseVisualStyleBackColor = true;
            buttonEditSucursal.Click += buttonEditSucursal_Click;
            // 
            // buttonDeleteSucursal
            // 
            buttonDeleteSucursal.Location = new Point(616, 38);
            buttonDeleteSucursal.Name = "buttonDeleteSucursal";
            buttonDeleteSucursal.Size = new Size(140, 29);
            buttonDeleteSucursal.TabIndex = 6;
            buttonDeleteSucursal.Text = "Eliminar sucursal";
            buttonDeleteSucursal.UseVisualStyleBackColor = true;
            buttonDeleteSucursal.Click += buttonDeleteSucursal_Click_1;
            // 
            // buttonAddSucursal
            // 
            buttonAddSucursal.Location = new Point(463, 38);
            buttonAddSucursal.Name = "buttonAddSucursal";
            buttonAddSucursal.Size = new Size(140, 29);
            buttonAddSucursal.TabIndex = 5;
            buttonAddSucursal.Text = "Agregar sucursal";
            buttonAddSucursal.UseVisualStyleBackColor = true;
            buttonAddSucursal.Click += buttonAddSucursal_Click_1;
            // 
            // SucursalesAdmin
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1445, 674);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(label1);
            Name = "SucursalesAdmin";
            Text = "SucursalesAdmin";
            Load += SucursalesAdmin_Load;
            groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridSucursales).EndInit();
            groupBox2.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private GroupBox groupBox1;
        private DataGridView dataGridSucursales;
        private GroupBox groupBox2;
        private Button buttonEditSucursal;
        private Button buttonDeleteSucursal;
        private Button buttonAddSucursal;
    }
}