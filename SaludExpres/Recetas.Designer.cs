namespace SaludExpres
{
    partial class Recetas
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
            dataGridRecetas = new DataGridView();
            buttonCerrar = new Button();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridRecetas).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(dataGridRecetas);
            groupBox1.Location = new Point(29, 45);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1334, 597);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Recetas registradas";
            // 
            // dataGridRecetas
            // 
            dataGridRecetas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridRecetas.Location = new Point(6, 26);
            dataGridRecetas.Name = "dataGridRecetas";
            dataGridRecetas.RowHeadersWidth = 51;
            dataGridRecetas.Size = new Size(1322, 565);
            dataGridRecetas.TabIndex = 0;
            // 
            // buttonCerrar
            // 
            buttonCerrar.Location = new Point(637, 668);
            buttonCerrar.Name = "buttonCerrar";
            buttonCerrar.Size = new Size(118, 29);
            buttonCerrar.TabIndex = 1;
            buttonCerrar.Text = "Cerrar";
            buttonCerrar.UseVisualStyleBackColor = true;
            buttonCerrar.Click += buttonCerrar_Click;
            // 
            // Recetas
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1392, 735);
            Controls.Add(buttonCerrar);
            Controls.Add(groupBox1);
            Name = "Recetas";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Recetas";
            groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridRecetas).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private DataGridView dataGridRecetas;
        private Button buttonCerrar;
    }
}