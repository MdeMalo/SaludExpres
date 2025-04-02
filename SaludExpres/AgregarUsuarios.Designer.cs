namespace SaludExpres
{
    partial class AgregarUsuarios
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
            label10 = new Label();
            comboBoxSucursal = new ComboBox();
            label8 = new Label();
            label9 = new Label();
            textSalario = new TextBox();
            textCargo = new TextBox();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            textApellidoMaterno = new TextBox();
            textApellidoPaterno = new TextBox();
            textNombre = new TextBox();
            buttonCancelar = new Button();
            buttonGuardar = new Button();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            checkBox1 = new CheckBox();
            comboBox1 = new ComboBox();
            textCorreo = new TextBox();
            textContrasenia = new TextBox();
            textUsuario = new TextBox();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Top;
            groupBox1.Controls.Add(label10);
            groupBox1.Controls.Add(comboBoxSucursal);
            groupBox1.Controls.Add(label8);
            groupBox1.Controls.Add(label9);
            groupBox1.Controls.Add(textSalario);
            groupBox1.Controls.Add(textCargo);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(textApellidoMaterno);
            groupBox1.Controls.Add(textApellidoPaterno);
            groupBox1.Controls.Add(textNombre);
            groupBox1.Controls.Add(buttonCancelar);
            groupBox1.Controls.Add(buttonGuardar);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(checkBox1);
            groupBox1.Controls.Add(comboBox1);
            groupBox1.Controls.Add(textCorreo);
            groupBox1.Controls.Add(textContrasenia);
            groupBox1.Controls.Add(textUsuario);
            groupBox1.Location = new Point(208, 48);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(781, 371);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Agregar usuarios";
            groupBox1.Enter += groupBox1_Enter;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(120, 237);
            label10.Name = "label10";
            label10.Size = new Size(66, 20);
            label10.TabIndex = 21;
            label10.Text = "Sucursal:";
            // 
            // comboBoxSucursal
            // 
            comboBoxSucursal.FormattingEnabled = true;
            comboBoxSucursal.Items.AddRange(new object[] { "Administrador", "Cajero", "Encargado de Inventario", "Farmacéutico", "Supervisor" });
            comboBoxSucursal.Location = new Point(192, 234);
            comboBoxSucursal.Name = "comboBoxSucursal";
            comboBoxSucursal.Size = new Size(172, 28);
            comboBoxSucursal.TabIndex = 20;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(453, 241);
            label8.Name = "label8";
            label8.Size = new Size(58, 20);
            label8.TabIndex = 18;
            label8.Text = "Salario:";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(459, 197);
            label9.Name = "label9";
            label9.Size = new Size(52, 20);
            label9.TabIndex = 19;
            label9.Text = "Cargo:";
            // 
            // textSalario
            // 
            textSalario.Location = new Point(517, 234);
            textSalario.Name = "textSalario";
            textSalario.Size = new Size(172, 27);
            textSalario.TabIndex = 17;
            // 
            // textCargo
            // 
            textCargo.Location = new Point(517, 190);
            textCargo.Name = "textCargo";
            textCargo.Size = new Size(172, 27);
            textCargo.TabIndex = 16;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(382, 153);
            label5.Name = "label5";
            label5.Size = new Size(129, 20);
            label5.TabIndex = 14;
            label5.Text = "Apellido Materno:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(388, 109);
            label6.Name = "label6";
            label6.Size = new Size(123, 20);
            label6.TabIndex = 15;
            label6.Text = "Apellido Paterno:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(444, 61);
            label7.Name = "label7";
            label7.Size = new Size(67, 20);
            label7.TabIndex = 13;
            label7.Text = "Nombre:";
            // 
            // textApellidoMaterno
            // 
            textApellidoMaterno.Location = new Point(517, 146);
            textApellidoMaterno.Name = "textApellidoMaterno";
            textApellidoMaterno.Size = new Size(172, 27);
            textApellidoMaterno.TabIndex = 12;
            // 
            // textApellidoPaterno
            // 
            textApellidoPaterno.Location = new Point(517, 102);
            textApellidoPaterno.Name = "textApellidoPaterno";
            textApellidoPaterno.Size = new Size(172, 27);
            textApellidoPaterno.TabIndex = 11;
            // 
            // textNombre
            // 
            textNombre.Location = new Point(517, 58);
            textNombre.Name = "textNombre";
            textNombre.Size = new Size(172, 27);
            textNombre.TabIndex = 10;
            // 
            // buttonCancelar
            // 
            buttonCancelar.Location = new Point(417, 312);
            buttonCancelar.Name = "buttonCancelar";
            buttonCancelar.Size = new Size(125, 29);
            buttonCancelar.TabIndex = 9;
            buttonCancelar.Text = "Cancelar";
            buttonCancelar.UseVisualStyleBackColor = true;
            buttonCancelar.Click += buttonCancelar_Click;
            // 
            // buttonGuardar
            // 
            buttonGuardar.Location = new Point(239, 312);
            buttonGuardar.Name = "buttonGuardar";
            buttonGuardar.Size = new Size(125, 29);
            buttonGuardar.TabIndex = 8;
            buttonGuardar.Text = "Guardar";
            buttonGuardar.UseVisualStyleBackColor = true;
            buttonGuardar.Click += buttonGuardar_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(152, 200);
            label4.Name = "label4";
            label4.Size = new Size(34, 20);
            label4.TabIndex = 7;
            label4.Text = "Rol:";
            label4.Click += label2_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(129, 155);
            label3.Name = "label3";
            label3.Size = new Size(57, 20);
            label3.TabIndex = 7;
            label3.Text = "Correo:";
            label3.Click += label2_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(100, 110);
            label2.Name = "label2";
            label2.Size = new Size(86, 20);
            label2.TabIndex = 7;
            label2.Text = "Contraseña:";
            label2.Click += label2_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(124, 65);
            label1.Name = "label1";
            label1.Size = new Size(62, 20);
            label1.TabIndex = 6;
            label1.Text = "Usuario:";
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(332, 275);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(116, 24);
            checkBox1.TabIndex = 5;
            checkBox1.Text = "¿Esta activo?";
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "Administrador", "Cajero", "Encargado de Inventario", "Farmacéutico", "Supervisor" });
            comboBox1.Location = new Point(192, 192);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(172, 28);
            comboBox1.TabIndex = 4;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // textCorreo
            // 
            textCorreo.Location = new Point(192, 148);
            textCorreo.Name = "textCorreo";
            textCorreo.Size = new Size(172, 27);
            textCorreo.TabIndex = 2;
            textCorreo.TextChanged += textCorreo_TextChanged;
            // 
            // textContrasenia
            // 
            textContrasenia.Location = new Point(192, 103);
            textContrasenia.Name = "textContrasenia";
            textContrasenia.Size = new Size(172, 27);
            textContrasenia.TabIndex = 1;
            textContrasenia.TextChanged += textContrasenia_TextChanged;
            // 
            // textUsuario
            // 
            textUsuario.Location = new Point(192, 58);
            textUsuario.Name = "textUsuario";
            textUsuario.Size = new Size(172, 27);
            textUsuario.TabIndex = 0;
            textUsuario.TextChanged += textUsuario_TextChanged;
            // 
            // AgregarUsuarios
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1196, 450);
            Controls.Add(groupBox1);
            Name = "AgregarUsuarios";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Agregar Usuarios";
            Load += AgregarUsuarios_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private CheckBox checkBox1;
        private ComboBox comboBox1;
        private TextBox textCorreo;
        private TextBox textContrasenia;
        private TextBox textUsuario;
        private Label label2;
        private Label label1;
        private Label label4;
        private Label label3;
        private Button buttonCancelar;
        private Button buttonGuardar;
        private Label label8;
        private Label label9;
        private TextBox textSalario;
        private TextBox textCargo;
        private Label label5;
        private Label label6;
        private Label label7;
        private TextBox textApellidoMaterno;
        private TextBox textApellidoPaterno;
        private TextBox textNombre;
        private Label label10;
        private ComboBox comboBoxSucursal;
    }
}