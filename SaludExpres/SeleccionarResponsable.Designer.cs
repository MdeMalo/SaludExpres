namespace SaludExpres
{
    partial class SeleccionarResponsable
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
            comboBox1 = new ComboBox();
            label1 = new Label();
            buttonAceptar = new Button();
            buttonCancelar = new Button();
            SuspendLayout();
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(332, 168);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(200, 28);
            comboBox1.TabIndex = 0;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(159, 176);
            label1.Name = "label1";
            label1.Size = new Size(167, 20);
            label1.TabIndex = 1;
            label1.Text = "Selecciona responsable:";
            // 
            // buttonAceptar
            // 
            buttonAceptar.Location = new Point(234, 257);
            buttonAceptar.Name = "buttonAceptar";
            buttonAceptar.Size = new Size(94, 29);
            buttonAceptar.TabIndex = 2;
            buttonAceptar.Text = "Aceptar";
            buttonAceptar.UseVisualStyleBackColor = true;
            buttonAceptar.Click += buttonAceptar_Click;
            // 
            // buttonCancelar
            // 
            buttonCancelar.Location = new Point(362, 257);
            buttonCancelar.Name = "buttonCancelar";
            buttonCancelar.Size = new Size(94, 29);
            buttonCancelar.TabIndex = 3;
            buttonCancelar.Text = "Cancelar";
            buttonCancelar.UseVisualStyleBackColor = true;
            buttonCancelar.Click += buttonCancelar_Click;
            // 
            // SeleccionarResponsable
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(690, 364);
            Controls.Add(buttonCancelar);
            Controls.Add(buttonAceptar);
            Controls.Add(label1);
            Controls.Add(comboBox1);
            Name = "SeleccionarResponsable";
            Text = "SeleccionarResponsable";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox comboBox1;
        private Label label1;
        private Button buttonAceptar;
        private Button buttonCancelar;
    }
}