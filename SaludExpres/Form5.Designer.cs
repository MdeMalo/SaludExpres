namespace SaludExpres
{
    partial class MenuRegularForm
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
            buttonVerRecetas = new Button();
            buttonClose = new Button();
            buttonRegistrarProducto = new Button();
            buttonRegistrarVentas = new Button();
            groupBox1 = new GroupBox();
            labelBienvenida = new Label();
            button1 = new Button();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // buttonVerRecetas
            // 
            buttonVerRecetas.Location = new Point(92, 145);
            buttonVerRecetas.Name = "buttonVerRecetas";
            buttonVerRecetas.Size = new Size(196, 29);
            buttonVerRecetas.TabIndex = 19;
            buttonVerRecetas.Text = "Recetas";
            buttonVerRecetas.UseVisualStyleBackColor = true;
            buttonVerRecetas.Click += buttonVerRecetas_Click;
            // 
            // buttonClose
            // 
            buttonClose.Location = new Point(471, 358);
            buttonClose.Name = "buttonClose";
            buttonClose.Size = new Size(119, 29);
            buttonClose.TabIndex = 18;
            buttonClose.Text = "Cerrar";
            buttonClose.UseVisualStyleBackColor = true;
            buttonClose.Click += buttonClose_Click;
            // 
            // buttonRegistrarProducto
            // 
            buttonRegistrarProducto.Location = new Point(92, 99);
            buttonRegistrarProducto.Name = "buttonRegistrarProducto";
            buttonRegistrarProducto.Size = new Size(196, 29);
            buttonRegistrarProducto.TabIndex = 17;
            buttonRegistrarProducto.Text = "Inventario";
            buttonRegistrarProducto.UseVisualStyleBackColor = true;
            buttonRegistrarProducto.Click += buttonRegistrarProducto_Click;
            // 
            // buttonRegistrarVentas
            // 
            buttonRegistrarVentas.Location = new Point(92, 53);
            buttonRegistrarVentas.Name = "buttonRegistrarVentas";
            buttonRegistrarVentas.Size = new Size(196, 29);
            buttonRegistrarVentas.TabIndex = 16;
            buttonRegistrarVentas.Text = "Registrar ventas";
            buttonRegistrarVentas.UseVisualStyleBackColor = true;
            buttonRegistrarVentas.Click += buttonRegistrarVentas_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(buttonVerRecetas);
            groupBox1.Controls.Add(buttonRegistrarProducto);
            groupBox1.Controls.Add(buttonRegistrarVentas);
            groupBox1.Location = new Point(210, 112);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(380, 227);
            groupBox1.TabIndex = 20;
            groupBox1.TabStop = false;
            groupBox1.Text = "Controles";
            // 
            // labelBienvenida
            // 
            labelBienvenida.AutoSize = true;
            labelBienvenida.Font = new Font("Segoe UI Black", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelBienvenida.Location = new Point(210, 49);
            labelBienvenida.Name = "labelBienvenida";
            labelBienvenida.Size = new Size(104, 41);
            labelBienvenida.TabIndex = 21;
            labelBienvenida.Text = "label1";
            labelBienvenida.Click += labelBienvenida_Click;
            // 
            // button1
            // 
            button1.Location = new Point(210, 358);
            button1.Name = "button1";
            button1.Size = new Size(119, 29);
            button1.TabIndex = 22;
            button1.Text = "Cerrar sesión";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // MenuRegularForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button1);
            Controls.Add(labelBienvenida);
            Controls.Add(groupBox1);
            Controls.Add(buttonClose);
            Name = "MenuRegularForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Usuario normal";
            Load += MenuRegularForm_Load;
            groupBox1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button buttonVerRecetas;
        private Button buttonClose;
        private Button buttonRegistrarProducto;
        private Button buttonRegistrarVentas;
        private GroupBox groupBox1;
        private Label labelBienvenida;
        private Button button1;
    }
}