namespace SaludExpres
{
    partial class AdministrarResponsablesSanitarios
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
            dataGridResponsables = new DataGridView();
            buttonAgregar = new Button();
            buttonEditar = new Button();
            buttonEliminar = new Button();
            groupBox1 = new GroupBox();
            buttonCerrar = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridResponsables).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridResponsables
            // 
            dataGridResponsables.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            dataGridResponsables.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridResponsables.Location = new Point(6, 26);
            dataGridResponsables.Name = "dataGridResponsables";
            dataGridResponsables.RowHeadersWidth = 51;
            dataGridResponsables.Size = new Size(1839, 368);
            dataGridResponsables.TabIndex = 0;
            // 
            // buttonAgregar
            // 
            buttonAgregar.Anchor = AnchorStyles.Bottom;
            buttonAgregar.Location = new Point(754, 460);
            buttonAgregar.Name = "buttonAgregar";
            buttonAgregar.Size = new Size(94, 29);
            buttonAgregar.TabIndex = 1;
            buttonAgregar.Text = "Agregar";
            buttonAgregar.UseVisualStyleBackColor = true;
            buttonAgregar.Click += buttonAgregar_Click;
            // 
            // buttonEditar
            // 
            buttonEditar.Anchor = AnchorStyles.Bottom;
            buttonEditar.Location = new Point(890, 460);
            buttonEditar.Name = "buttonEditar";
            buttonEditar.Size = new Size(94, 29);
            buttonEditar.TabIndex = 2;
            buttonEditar.Text = "Editar";
            buttonEditar.UseVisualStyleBackColor = true;
            buttonEditar.Click += buttonEditar_Click;
            // 
            // buttonEliminar
            // 
            buttonEliminar.Anchor = AnchorStyles.Bottom;
            buttonEliminar.Location = new Point(1026, 460);
            buttonEliminar.Name = "buttonEliminar";
            buttonEliminar.Size = new Size(94, 29);
            buttonEliminar.TabIndex = 3;
            buttonEliminar.Text = "Eliminar";
            buttonEliminar.UseVisualStyleBackColor = true;
            buttonEliminar.Click += buttonEliminar_Click;
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            groupBox1.Controls.Add(dataGridResponsables);
            groupBox1.Location = new Point(12, 33);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1851, 400);
            groupBox1.TabIndex = 4;
            groupBox1.TabStop = false;
            groupBox1.Text = "Responsables sanitarios";
            // 
            // buttonCerrar
            // 
            buttonCerrar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonCerrar.Location = new Point(1769, 491);
            buttonCerrar.Name = "buttonCerrar";
            buttonCerrar.Size = new Size(94, 29);
            buttonCerrar.TabIndex = 5;
            buttonCerrar.Text = "Cerrar";
            buttonCerrar.UseVisualStyleBackColor = true;
            buttonCerrar.Click += buttonCerrar_Click;
            // 
            // AdministrarResponsablesSanitarios
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1875, 532);
            Controls.Add(buttonCerrar);
            Controls.Add(groupBox1);
            Controls.Add(buttonEliminar);
            Controls.Add(buttonEditar);
            Controls.Add(buttonAgregar);
            Name = "AdministrarResponsablesSanitarios";
            Text = "AdministrarResponsablesSanitarios";
            Load += AdministrarResponsablesSanitarios_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridResponsables).EndInit();
            groupBox1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridResponsables;
        private Button buttonAgregar;
        private Button buttonEditar;
        private Button buttonEliminar;
        private GroupBox groupBox1;
        private Button buttonCerrar;
    }
}