namespace SaludExpres
{
    partial class AdministrarProveedores
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
            buttonCerrar = new Button();
            groupBox1 = new GroupBox();
            dataGridProveedores = new DataGridView();
            buttonEliminar = new Button();
            buttonEditar = new Button();
            buttonAgregar = new Button();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridProveedores).BeginInit();
            SuspendLayout();
            // 
            // buttonCerrar
            // 
            buttonCerrar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonCerrar.Location = new Point(1769, 481);
            buttonCerrar.Name = "buttonCerrar";
            buttonCerrar.Size = new Size(94, 29);
            buttonCerrar.TabIndex = 10;
            buttonCerrar.Text = "Cerrar";
            buttonCerrar.UseVisualStyleBackColor = true;
            buttonCerrar.Click += buttonCerrar_Click;
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            groupBox1.Controls.Add(dataGridProveedores);
            groupBox1.Location = new Point(12, 23);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1851, 400);
            groupBox1.TabIndex = 9;
            groupBox1.TabStop = false;
            groupBox1.Text = "Responsables sanitarios";
            // 
            // dataGridProveedores
            // 
            dataGridProveedores.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            dataGridProveedores.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridProveedores.Location = new Point(6, 26);
            dataGridProveedores.Name = "dataGridProveedores";
            dataGridProveedores.RowHeadersWidth = 51;
            dataGridProveedores.Size = new Size(1839, 368);
            dataGridProveedores.TabIndex = 0;
            // 
            // buttonEliminar
            // 
            buttonEliminar.Anchor = AnchorStyles.Bottom;
            buttonEliminar.Location = new Point(1026, 450);
            buttonEliminar.Name = "buttonEliminar";
            buttonEliminar.Size = new Size(94, 29);
            buttonEliminar.TabIndex = 8;
            buttonEliminar.Text = "Eliminar";
            buttonEliminar.UseVisualStyleBackColor = true;
            buttonEliminar.Click += buttonEliminar_Click;
            // 
            // buttonEditar
            // 
            buttonEditar.Anchor = AnchorStyles.Bottom;
            buttonEditar.Location = new Point(890, 450);
            buttonEditar.Name = "buttonEditar";
            buttonEditar.Size = new Size(94, 29);
            buttonEditar.TabIndex = 7;
            buttonEditar.Text = "Editar";
            buttonEditar.UseVisualStyleBackColor = true;
            buttonEditar.Click += buttonEditar_Click;
            // 
            // buttonAgregar
            // 
            buttonAgregar.Anchor = AnchorStyles.Bottom;
            buttonAgregar.Location = new Point(754, 450);
            buttonAgregar.Name = "buttonAgregar";
            buttonAgregar.Size = new Size(94, 29);
            buttonAgregar.TabIndex = 6;
            buttonAgregar.Text = "Agregar";
            buttonAgregar.UseVisualStyleBackColor = true;
            buttonAgregar.Click += buttonAgregar_Click;
            // 
            // AdministrarProveedores
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1875, 532);
            Controls.Add(buttonCerrar);
            Controls.Add(groupBox1);
            Controls.Add(buttonEliminar);
            Controls.Add(buttonEditar);
            Controls.Add(buttonAgregar);
            Name = "AdministrarProveedores";
            Text = "AdministrarProveedores";
            Load += AdministrarProveedores_Load;
            groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridProveedores).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button buttonCerrar;
        private GroupBox groupBox1;
        private Button buttonEliminar;
        private Button buttonEditar;
        private Button buttonAgregar;
        private DataGridView dataGridProveedores;
    }
}