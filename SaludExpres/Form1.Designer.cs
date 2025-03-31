namespace SaludExpres
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            textBoxCorreo = new TextBox();
            textBoxContrasenia = new TextBox();
            label2 = new Label();
            buttonIngresar = new Button();
            buttonRecContra = new Button();
            buttonCerrar = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(211, 129);
            label1.Name = "label1";
            label1.Size = new Size(125, 20);
            label1.TabIndex = 0;
            label1.Text = "Ingrese su correo:";
            // 
            // textBoxCorreo
            // 
            textBoxCorreo.Location = new Point(342, 122);
            textBoxCorreo.Name = "textBoxCorreo";
            textBoxCorreo.Size = new Size(248, 27);
            textBoxCorreo.TabIndex = 1;
            // 
            // textBoxContrasenia
            // 
            textBoxContrasenia.Location = new Point(342, 173);
            textBoxContrasenia.Name = "textBoxContrasenia";
            textBoxContrasenia.PasswordChar = '*';
            textBoxContrasenia.Size = new Size(248, 27);
            textBoxContrasenia.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(250, 180);
            label2.Name = "label2";
            label2.Size = new Size(86, 20);
            label2.TabIndex = 2;
            label2.Text = "Contraseña:";
            // 
            // buttonIngresar
            // 
            buttonIngresar.Location = new Point(310, 246);
            buttonIngresar.Name = "buttonIngresar";
            buttonIngresar.Size = new Size(180, 29);
            buttonIngresar.TabIndex = 4;
            buttonIngresar.Text = "Ingresar";
            buttonIngresar.UseVisualStyleBackColor = true;
            buttonIngresar.Click += buttonIngresar_Click;
            // 
            // buttonRecContra
            // 
            buttonRecContra.Location = new Point(310, 281);
            buttonRecContra.Name = "buttonRecContra";
            buttonRecContra.Size = new Size(180, 29);
            buttonRecContra.TabIndex = 5;
            buttonRecContra.Text = "Recuperar contraseña";
            buttonRecContra.UseVisualStyleBackColor = true;
            buttonRecContra.Click += buttonRecContra_Click;
            // 
            // buttonCerrar
            // 
            buttonCerrar.Location = new Point(694, 409);
            buttonCerrar.Name = "buttonCerrar";
            buttonCerrar.Size = new Size(94, 29);
            buttonCerrar.TabIndex = 9;
            buttonCerrar.Text = "Cerrar";
            buttonCerrar.UseVisualStyleBackColor = true;
            buttonCerrar.Click += buttonCerrar_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(buttonCerrar);
            Controls.Add(buttonRecContra);
            Controls.Add(buttonIngresar);
            Controls.Add(textBoxContrasenia);
            Controls.Add(label2);
            Controls.Add(textBoxCorreo);
            Controls.Add(label1);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox textBoxCorreo;
        private TextBox textBoxContrasenia;
        private Label label2;
        private Button buttonIngresar;
        private Button buttonRecContra;
        private Button buttonCerrar;
    }
}
