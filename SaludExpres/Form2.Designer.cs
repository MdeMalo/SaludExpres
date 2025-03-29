namespace SaludExpres
{
    partial class Form2
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
            listView1 = new ListView();
            label1 = new Label();
            groupBox2 = new GroupBox();
            button3 = new Button();
            buttonUsuarios = new Button();
            button2 = new Button();
            button1 = new Button();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(listView1);
            groupBox1.Location = new Point(158, 90);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(566, 463);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Metricas";
            // 
            // listView1
            // 
            listView1.Location = new Point(6, 26);
            listView1.Name = "listView1";
            listView1.Size = new Size(554, 431);
            listView1.TabIndex = 0;
            listView1.UseCompatibleStateImageBehavior = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Black", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(158, 34);
            label1.Name = "label1";
            label1.Size = new Size(194, 38);
            label1.TabIndex = 1;
            label1.Text = "BIENVENIDO";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(button3);
            groupBox2.Controls.Add(buttonUsuarios);
            groupBox2.Controls.Add(button2);
            groupBox2.Controls.Add(button1);
            groupBox2.Location = new Point(158, 559);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(566, 125);
            groupBox2.TabIndex = 2;
            groupBox2.TabStop = false;
            groupBox2.Text = "Administración";
            // 
            // button3
            // 
            button3.Location = new Point(324, 70);
            button3.Name = "button3";
            button3.Size = new Size(160, 29);
            button3.TabIndex = 6;
            button3.Text = "Reportes";
            button3.UseVisualStyleBackColor = true;
            // 
            // buttonUsuarios
            // 
            buttonUsuarios.Location = new Point(324, 25);
            buttonUsuarios.Name = "buttonUsuarios";
            buttonUsuarios.Size = new Size(160, 29);
            buttonUsuarios.TabIndex = 5;
            buttonUsuarios.Text = "Usuarios";
            buttonUsuarios.UseVisualStyleBackColor = true;
            buttonUsuarios.Click += buttonUsuarios_Click;
            // 
            // button2
            // 
            button2.Location = new Point(82, 70);
            button2.Name = "button2";
            button2.Size = new Size(160, 29);
            button2.TabIndex = 4;
            button2.Text = "Registrar productos";
            button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            button1.Location = new Point(82, 25);
            button1.Name = "button1";
            button1.Size = new Size(160, 29);
            button1.TabIndex = 3;
            button1.Text = "Registrar ventas";
            button1.UseVisualStyleBackColor = true;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1398, 716);
            Controls.Add(groupBox2);
            Controls.Add(label1);
            Controls.Add(groupBox1);
            Name = "Form2";
            Text = "Form2";
            Load += Form2_Load;
            groupBox1.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox groupBox1;
        private ListView listView1;
        private Label label1;
        private GroupBox groupBox2;
        private Button button3;
        private Button buttonUsuarios;
        private Button button2;
        private Button button1;
    }
}