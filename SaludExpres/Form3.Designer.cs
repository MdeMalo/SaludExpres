namespace SaludExpres
{
    partial class Form3
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
            label3 = new Label();
            comboFiltroEstado = new ComboBox();
            label2 = new Label();
            comboFiltroRol = new ComboBox();
            textBusUser = new TextBox();
            label1 = new Label();
            dataGridUsuarios = new DataGridView();
            groupBox2 = new GroupBox();
            groupBox3 = new GroupBox();
            buttonEliminarUs = new Button();
            buttonEditUs = new Button();
            buttonAgregarUsuario = new Button();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridUsuarios).BeginInit();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Top;
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(comboFiltroEstado);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(comboFiltroRol);
            groupBox1.Controls.Add(textBusUser);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(12, 36);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1462, 89);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Filtros";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(895, 39);
            label3.Name = "label3";
            label3.Size = new Size(126, 20);
            label3.TabIndex = 2;
            label3.Text = "Filtrar por estado:";
            label3.Click += label3_Click;
            // 
            // comboFiltroEstado
            // 
            comboFiltroEstado.FormattingEnabled = true;
            comboFiltroEstado.Items.AddRange(new object[] { "", "Contratado", "Despedido" });
            comboFiltroEstado.Location = new Point(1027, 32);
            comboFiltroEstado.Name = "comboFiltroEstado";
            comboFiltroEstado.Size = new Size(173, 28);
            comboFiltroEstado.TabIndex = 3;
            comboFiltroEstado.SelectedIndexChanged += comboFiltroEstado_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(611, 39);
            label2.Name = "label2";
            label2.Size = new Size(99, 20);
            label2.TabIndex = 1;
            label2.Text = "Filtrar por rol:";
            // 
            // comboFiltroRol
            // 
            comboFiltroRol.FormattingEnabled = true;
            comboFiltroRol.Items.AddRange(new object[] { "", "Administrador", "Cajero", "Encargado de Inventario", "Farmacéutico", "Supervisor" });
            comboFiltroRol.Location = new Point(716, 31);
            comboFiltroRol.Name = "comboFiltroRol";
            comboFiltroRol.Size = new Size(173, 28);
            comboFiltroRol.TabIndex = 1;
            comboFiltroRol.SelectedIndexChanged += comboFiltroRol_SelectedIndexChanged;
            // 
            // textBusUser
            // 
            textBusUser.Location = new Point(376, 32);
            textBusUser.Name = "textBusUser";
            textBusUser.Size = new Size(229, 27);
            textBusUser.TabIndex = 1;
            textBusUser.TextChanged += textBusUser_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(263, 39);
            label1.Name = "label1";
            label1.Size = new Size(107, 20);
            label1.TabIndex = 0;
            label1.Text = "Buscar usuario:";
            // 
            // dataGridUsuarios
            // 
            dataGridUsuarios.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            dataGridUsuarios.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridUsuarios.Location = new Point(6, 26);
            dataGridUsuarios.Name = "dataGridUsuarios";
            dataGridUsuarios.RowHeadersWidth = 51;
            dataGridUsuarios.Size = new Size(1450, 498);
            dataGridUsuarios.TabIndex = 1;
            dataGridUsuarios.CellContentClick += dataGridUsuarios_CellContentClick;
            // 
            // groupBox2
            // 
            groupBox2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            groupBox2.Controls.Add(dataGridUsuarios);
            groupBox2.Location = new Point(12, 131);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(1462, 530);
            groupBox2.TabIndex = 2;
            groupBox2.TabStop = false;
            groupBox2.Text = "Usuarios";
            // 
            // groupBox3
            // 
            groupBox3.Anchor = AnchorStyles.Bottom;
            groupBox3.Controls.Add(buttonEliminarUs);
            groupBox3.Controls.Add(buttonEditUs);
            groupBox3.Controls.Add(buttonAgregarUsuario);
            groupBox3.Location = new Point(18, 667);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(1456, 79);
            groupBox3.TabIndex = 3;
            groupBox3.TabStop = false;
            groupBox3.Text = "Gestión";
            // 
            // buttonEliminarUs
            // 
            buttonEliminarUs.Anchor = AnchorStyles.Top;
            buttonEliminarUs.Location = new Point(909, 25);
            buttonEliminarUs.Name = "buttonEliminarUs";
            buttonEliminarUs.Size = new Size(180, 29);
            buttonEliminarUs.TabIndex = 2;
            buttonEliminarUs.Text = "Eliminar Usuario";
            buttonEliminarUs.UseVisualStyleBackColor = true;
            buttonEliminarUs.Click += buttonEliminarUs_Click;
            // 
            // buttonEditUs
            // 
            buttonEditUs.Anchor = AnchorStyles.Top;
            buttonEditUs.Location = new Point(634, 25);
            buttonEditUs.Name = "buttonEditUs";
            buttonEditUs.Size = new Size(180, 29);
            buttonEditUs.TabIndex = 1;
            buttonEditUs.Text = "Editar Usuario";
            buttonEditUs.UseVisualStyleBackColor = true;
            buttonEditUs.Click += buttonEditUs_Click;
            // 
            // buttonAgregarUsuario
            // 
            buttonAgregarUsuario.Anchor = AnchorStyles.Top;
            buttonAgregarUsuario.Location = new Point(367, 25);
            buttonAgregarUsuario.Name = "buttonAgregarUsuario";
            buttonAgregarUsuario.Size = new Size(180, 29);
            buttonAgregarUsuario.TabIndex = 0;
            buttonAgregarUsuario.Text = "Agregar Usuario";
            buttonAgregarUsuario.UseVisualStyleBackColor = true;
            buttonAgregarUsuario.Click += buttonAgregarUsuario_Click;
            // 
            // Form3
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1486, 758);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Name = "Form3";
            Text = "Form3";
            Load += Form3_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridUsuarios).EndInit();
            groupBox2.ResumeLayout(false);
            groupBox3.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private Label label3;
        private ComboBox comboFiltroEstado;
        private Label label2;
        private ComboBox comboFiltroRol;
        private TextBox textBusUser;
        private Label label1;
        private DataGridView dataGridUsuarios;
        private GroupBox groupBox2;
        private GroupBox groupBox3;
        private Button buttonEliminarUs;
        private Button buttonEditUs;
        private Button buttonAgregarUsuario;
    }
}