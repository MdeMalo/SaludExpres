using System;
using System.Configuration;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace SaludExpres
{
    public partial class AuditoriaEmpleadosForm : Form
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["SaludExpresConnection"].ConnectionString;

        public AuditoriaEmpleadosForm()
        {
            InitializeComponent();
            InitializeControls();
        }

        private void InitializeControls()
        {
            this.Text = "Auditoría de Empleados";
            this.Size = new System.Drawing.Size(900, 600);
            this.StartPosition = FormStartPosition.CenterScreen;

            // Label y TextBox para idUsuario
            Label lblIdUsuario = new Label { Text = "ID de Usuario:", Location = new Point(10, 10), AutoSize = true };
            TextBox txtIdUsuario = new TextBox { Name = "txtIdUsuario", Location = new Point(150, 10), Width = 200 };
            this.Controls.Add(lblIdUsuario);
            this.Controls.Add(txtIdUsuario);

            // Label y TextBox para tablaAfectada
            Label lblTablaAfectada = new Label { Text = "Tabla Afectada:", Location = new Point(10, 40), AutoSize = true };
            TextBox txtTablaAfectada = new TextBox { Name = "txtTablaAfectada", Location = new Point(150, 40), Width = 200 };
            this.Controls.Add(lblTablaAfectada);
            this.Controls.Add(txtTablaAfectada);

            // Label y TextBox para idRegistro
            Label lblIdRegistro = new Label { Text = "ID Registro:", Location = new Point(10, 70), AutoSize = true };
            TextBox txtIdRegistro = new TextBox { Name = "txtIdRegistro", Location = new Point(150, 70), Width = 200 };
            this.Controls.Add(lblIdRegistro);
            this.Controls.Add(txtIdRegistro);

            // Label y ComboBox para accion
            Label lblAccion = new Label { Text = "Acción:", Location = new Point(10, 100), AutoSize = true };
            ComboBox comboAccion = new ComboBox
            {
                Name = "comboAccion",
                Location = new Point(150, 100),
                Width = 200,
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            comboAccion.Items.AddRange(new string[] { "INSERT", "UPDATE", "DELETE", "OTHER" });
            comboAccion.SelectedIndex = 0;
            this.Controls.Add(lblAccion);
            this.Controls.Add(comboAccion);

            // Label y TextBox para descripcion
            Label lblDescripcion = new Label { Text = "Descripción:", Location = new Point(10, 130), AutoSize = true };
            TextBox txtDescripcion = new TextBox
            {
                Name = "txtDescripcion",
                Location = new Point(150, 130),
                Width = 400,
                Height = 100,
                Multiline = true,
                ScrollBars = ScrollBars.Vertical
            };
            this.Controls.Add(lblDescripcion);
            this.Controls.Add(txtDescripcion);

            // Botón Guardar
            Button btnGuardar = new Button
            {
                Text = "Guardar Auditoría",
                Location = new Point(150, 250),
                Size = new Size(150, 30)
            };
            btnGuardar.Click += BtnGuardar_Click;
            this.Controls.Add(btnGuardar);

            // Botón Ver Auditorías
            Button btnVerAuditorias = new Button
            {
                Text = "Ver Auditorías",
                Location = new Point(310, 250),
                Size = new Size(150, 30)
            };
            btnVerAuditorias.Click += BtnVerAuditorias_Click;
            this.Controls.Add(btnVerAuditorias);

            // Botón Cancelar
            Button btnCancelar = new Button
            {
                Text = "Cancelar",
                Location = new Point(470, 250),
                Size = new Size(150, 30)
            };
            btnCancelar.Click += (s, e) => this.Close();
            this.Controls.Add(btnCancelar);

            // DataGridView para mostrar auditorías
            DataGridView dataGridAuditoria = new DataGridView
            {
                Name = "dataGridAuditoria",
                Location = new Point(10, 290),
                Size = new Size(this.ClientSize.Width - 20, this.ClientSize.Height - 310),
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                ReadOnly = true,
                AllowUserToAddRows = false
            };
            this.Controls.Add(dataGridAuditoria);
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            TextBox txtIdUsuario = this.Controls["txtIdUsuario"] as TextBox;
            TextBox txtTablaAfectada = this.Controls["txtTablaAfectada"] as TextBox;
            TextBox txtIdRegistro = this.Controls["txtIdRegistro"] as TextBox;
            ComboBox comboAccion = this.Controls["comboAccion"] as ComboBox;
            TextBox txtDescripcion = this.Controls["txtDescripcion"] as TextBox;

            if (!int.TryParse(txtIdUsuario.Text.Trim(), out int idUsuario) || idUsuario <= 0)
            {
                MessageBox.Show("Por favor, ingrese un ID de usuario válido.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(txtTablaAfectada.Text.Trim()))
            {
                MessageBox.Show("Por favor, especifique la tabla afectada.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int? idRegistro = null;
            if (!string.IsNullOrEmpty(txtIdRegistro.Text.Trim()))
            {
                if (!int.TryParse(txtIdRegistro.Text.Trim(), out int idReg) || idReg < 0)
                {
                    MessageBox.Show("Por favor, ingrese un ID de registro válido o déjelo en blanco.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                idRegistro = idReg;
            }

            string accion = comboAccion.SelectedItem.ToString();
            string descripcion = txtDescripcion.Text.Trim();

            if (!UsuarioExiste(idUsuario))
            {
                MessageBox.Show("El ID de usuario especificado no existe.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = @"
                        INSERT INTO auditoria (tablaAfectada, idRegistro, accion, fecha, idUsuario, descripcion)
                        VALUES (@tablaAfectada, @idRegistro, @accion, NOW(), @idUsuario, @descripcion)";
                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@tablaAfectada", txtTablaAfectada.Text.Trim());
                        cmd.Parameters.AddWithValue("@idRegistro", idRegistro.HasValue ? (object)idRegistro.Value : DBNull.Value);
                        cmd.Parameters.AddWithValue("@accion", accion);
                        cmd.Parameters.AddWithValue("@idUsuario", idUsuario);
                        cmd.Parameters.AddWithValue("@descripcion", string.IsNullOrEmpty(descripcion) ? DBNull.Value : descripcion);

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Auditoría registrada con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LimpiarCampos();
                        CargarAuditorias(idUsuario); // Actualizar el DataGridView tras guardar
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar la auditoría: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnVerAuditorias_Click(object sender, EventArgs e)
        {
            TextBox txtIdUsuario = this.Controls["txtIdUsuario"] as TextBox;
            if (!int.TryParse(txtIdUsuario.Text.Trim(), out int idUsuario) || idUsuario <= 0)
            {
                MessageBox.Show("Por favor, ingrese un ID de usuario válido.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            CargarAuditorias(idUsuario);
        }

        private void CargarAuditorias(int idUsuario)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = @"
                        SELECT 
                            a.idAuditoria AS 'ID Auditoría',
                            a.tablaAfectada AS 'Tabla Afectada',
                            a.idRegistro AS 'ID Registro',
                            a.accion AS 'Acción',
                            a.fecha AS 'Fecha',
                            a.idUsuario AS 'ID Usuario',
                            CONCAT(e.nombre, ' ', e.apellidoPaterno) AS 'Nombre Empleado',
                            a.descripcion AS 'Descripción'
                        FROM auditoria a
                        LEFT JOIN usuario u ON a.idUsuario = u.idUsuario
                        LEFT JOIN empleado e ON u.idEmpleado = e.idEmpleado
                        WHERE a.idUsuario = @idUsuario
                        ORDER BY a.fecha DESC";
                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@idUsuario", idUsuario);
                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);
                            DataGridView dataGridAuditoria = this.Controls["dataGridAuditoria"] as DataGridView;
                            dataGridAuditoria.DataSource = dt;

                            if (dt.Rows.Count == 0)
                            {
                                MessageBox.Show("No se encontraron auditorías para este usuario.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar las auditorías: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool UsuarioExiste(int idUsuario)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT COUNT(*) FROM usuario WHERE idUsuario = @idUsuario";
                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@idUsuario", idUsuario);
                        int count = Convert.ToInt32(cmd.ExecuteScalar());
                        return count > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al verificar el usuario: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void LimpiarCampos()
        {
            TextBox txtIdUsuario = this.Controls["txtIdUsuario"] as TextBox;
            TextBox txtTablaAfectada = this.Controls["txtTablaAfectada"] as TextBox;
            TextBox txtIdRegistro = this.Controls["txtIdRegistro"] as TextBox;
            ComboBox comboAccion = this.Controls["comboAccion"] as ComboBox;
            TextBox txtDescripcion = this.Controls["txtDescripcion"] as TextBox;

            txtTablaAfectada.Clear();
            txtIdRegistro.Clear();
            comboAccion.SelectedIndex = 0;
            txtDescripcion.Clear();
            // No limpiamos txtIdUsuario para mantener el contexto del usuario auditado
        }
    }
}