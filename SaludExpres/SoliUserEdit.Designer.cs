namespace SaludExpres
{
    partial class SoliUserEdit
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
            textUser = new TextBox();
            label1 = new Label();
            buttonEnviar = new Button();
            SuspendLayout();
            // 
            // textUser
            // 
            textUser.Location = new Point(315, 139);
            textUser.Name = "textUser";
            textUser.Size = new Size(175, 27);
            textUser.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(181, 146);
            label1.Name = "label1";
            label1.Size = new Size(128, 20);
            label1.TabIndex = 1;
            label1.Text = "Ingrese el usuario:";
            // 
            // buttonEnviar
            // 
            buttonEnviar.Location = new Point(269, 210);
            buttonEnviar.Name = "buttonEnviar";
            buttonEnviar.Size = new Size(138, 29);
            buttonEnviar.TabIndex = 2;
            buttonEnviar.Text = "Enviar";
            buttonEnviar.UseVisualStyleBackColor = true;
            buttonEnviar.Click += buttonEnviar_Click;
            // 
            // SoliUserEdit
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(670, 378);
            Controls.Add(buttonEnviar);
            Controls.Add(label1);
            Controls.Add(textUser);
            Name = "SoliUserEdit";
            Text = "SoliUserEdit";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textUser;
        private Label label1;
        private Button buttonEnviar;
    }
}