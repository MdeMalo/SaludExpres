using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using QRCoder;

namespace SaludExpres
{
    public partial class GenerarFactura : Form
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["SaludExpresConnection"].ConnectionString;

        // Variables para almacenar las selecciones
        public int IdVenta { get; set; } = -1;
        public int IdReceptor { get; set; } = -1;
        public int IdEmisor { get; set; } = -1; // Si se permite seleccionar emisores

        public GenerarFactura()
        {
            InitializeComponent();
            CargarGridVentas();
            CargarGridReceptor();
            CargarGridEmisor();
            CargarComboBoxPagos();
            CalcularTotales();
            CalcularSubtotal();
            CargarComboBoxCFDI();
        }

        private DataTable ObtenerDetallesVenta(int idVenta)
        {
            DataTable dt = new DataTable();
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"
                SELECT 
                    dv.idProducto,
                    p.descripcion AS descripcion,
                    dv.cantidad,
                    dv.precioUnitario,
                    dv.subtotal AS importe
                FROM detalleventa dv
                INNER JOIN producto p ON dv.idProducto = p.idProducto
                WHERE dv.idVenta = @idVenta";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@idVenta", idVenta);
                        MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                        adapter.Fill(dt);
                        // Depuración: Mostrar cuántas filas se encontraron
                        MessageBox.Show($"Detalles encontrados para idVenta {idVenta}: {dt.Rows.Count}", "Depuración");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener los detalles de la venta: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return dt;
        }

        private void CargarComboBoxCFDI()
        {
            comboBoxCFDI.Items.Clear();
            comboBoxCFDI.Items.Add("D01: Honorarios médicos, dentales y gastos hospitalarios");
            comboBoxCFDI.Items.Add("G03: Gastos en general");
            comboBoxCFDI.Items.Add("P01: Por definir");
            comboBoxCFDI.SelectedIndex = 0;
        }
        private void CargarGridVentas()
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                // Ajusta la consulta según tus necesidades
                string query = "SELECT idVenta, fecha, total FROM venta WHERE /* condiciones, p.ej. pendiente de facturación */ 1";
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                gridVentas.DataSource = dt;
                gridVentas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
        }

        private (Bitmap qrCodeImage, string qrData) GenerarCodigoQR(int idFactura, int idVenta, int idEmisor, int idReceptor, decimal total)
        {
            try
            {
                // Crear la cadena numérica con los datos de la factura
                string qrData = $"{idFactura}{idVenta}{idEmisor}{idReceptor}{(int)total}";

                // Crear el generador de QR
                QRCodeGenerator qrGenerator = new QRCodeGenerator();
                QRCodeData qrCodeData = qrGenerator.CreateQrCode(qrData, QRCodeGenerator.ECCLevel.Q);

                // Generar la imagen del QR
                QRCode qrCode = new QRCode(qrCodeData);
                Bitmap qrCodeImage = qrCode.GetGraphic(20); // Tamaño estándar, puedes ajustarlo

                return (qrCodeImage, qrData); // Devuelve la imagen y la cadena numérica
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar el código QR: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return (null, null);
            }
        }

        private void GuardarCodigoNumerico(int idFactura, string codigoNumerico)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "UPDATE factura SET codigoBarras = @codigoBarras WHERE idFactura = @idFactura";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@codigoBarras", codigoNumerico);
                        cmd.Parameters.AddWithValue("@idFactura", idFactura);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar el código numérico: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarGridReceptor()
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    // Consulta para obtener receptores desde la tabla `receptor`
                    string query = "SELECT idReceptor, nombre AS receptor FROM receptor";
                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    gridReceptor.DataSource = dt;
                    gridReceptor.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar receptores: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarGridEmisor()
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    // Consulta para emisores
                    string query = "SELECT idEmisor, nombre FROM emisor";
                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    gridEmisor.DataSource = dt;
                    gridEmisor.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar emisores: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarComboBoxPagos()
        {
            comboBoxMetodoPago.Items.Clear();
            comboBoxMetodoPago.Items.Add("Efectivo");
            comboBoxMetodoPago.Items.Add("Tarjeta de Crédito");
            comboBoxMetodoPago.Items.Add("Transferencia");
            comboBoxMetodoPago.SelectedIndex = 0;
        }

        private void gridVentas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void gridEmisor_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void GenerarFactura_Load(object sender, EventArgs e)
        {

        }

        private void buttonGenerarFactura_Click(object sender, EventArgs e)
        {
            try
            {
                if (IdVenta == -1 || IdReceptor == -1 || IdEmisor == -1)
                {
                    MessageBox.Show("Seleccione una venta, receptor y emisor.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (comboBoxCFDI.SelectedItem == null)
                {
                    MessageBox.Show("Seleccione un uso CFDI.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DataTable detallesVenta = ObtenerDetallesVenta(IdVenta);
                if (detallesVenta.Rows.Count == 0)
                {
                    DialogResult result = MessageBox.Show("No se encontraron detalles para la venta seleccionada. ¿Desea continuar sin detalles?",
                        "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (result == DialogResult.No)
                    {
                        return;
                    }
                }

                decimal subtotal = CalcularSubtotal();
                decimal impuestos = subtotal * 0.16m;
                decimal total = subtotal + impuestos;

                string numeroFactura = "FAC" + DateTime.Now.ToString("yyyyMMddHHmmss");
                int idFactura = InsertarFactura(numeroFactura, subtotal, impuestos, total, detallesVenta);

                if (idFactura > 0)
                {
                    MessageBox.Show("Factura generada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    var (qrCode, qrData) = GenerarCodigoQR(idFactura, IdVenta, IdEmisor, IdReceptor, total);
                    if (qrCode != null)
                    {
                        pictureBoxQR.SizeMode = PictureBoxSizeMode.Zoom;
                        pictureBoxQR.Image = qrCode;
                        qrCode.Save("factura_" + idFactura + ".png", System.Drawing.Imaging.ImageFormat.Png);
                        GuardarCodigoNumerico(idFactura, qrData);
                    }
                    else
                    {
                        MessageBox.Show("No se pudo generar el código QR.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Error al generar la factura.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}\nDetalles: IdVenta={IdVenta}, IdReceptor={IdReceptor}, IdEmisor={IdEmisor}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private decimal CalcularSubtotal()
        {
            decimal totalVenta = ObtenerTotalVenta(IdVenta);
            decimal subtotal = totalVenta / 1.16m;
            return subtotal;
        }
        private void CalcularTotales()
        {
            decimal totalVenta = ObtenerTotalVenta(IdVenta);
            decimal subtotal = totalVenta / 1.16m;
            decimal iva = totalVenta - subtotal;
        }
        private decimal ObtenerTotalVenta(int idVenta)
        {
            decimal totalVenta = 0;
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT total FROM venta WHERE idVenta = @idVenta";
                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@idVenta", idVenta);
                        var result = cmd.ExecuteScalar();
                        if (result != null)
                        {
                            totalVenta = Convert.ToDecimal(result);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener el total de la venta: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return totalVenta;
        }


        // Método para insertar la factura en la BD y retornar el idFactura generado
        private int InsertarFactura(string numeroFactura, decimal subtotal, decimal impuestos, decimal total, DataTable detallesVenta)
        {
            int idFactura = 0;
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                using (MySqlTransaction transaction = conn.BeginTransaction())
                {
                    try
                    {
                        string queryFactura = @"
                    INSERT INTO factura 
                    (numeroFactura, fechaEmision, idEmisor, idReceptor, subtotal, impuestos, total, metodoPago, idVenta, usoCFDI)
                    VALUES 
                    (@numeroFactura, NOW(), @idEmisor, @idReceptor, @subtotal, @impuestos, @total, @metodoPago, @idVenta, @usoCFDI);
                    SELECT LAST_INSERT_ID();";
                        using (MySqlCommand cmd = new MySqlCommand(queryFactura, conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("@numeroFactura", numeroFactura);
                            cmd.Parameters.AddWithValue("@idEmisor", IdEmisor);
                            cmd.Parameters.AddWithValue("@idReceptor", IdReceptor);
                            cmd.Parameters.AddWithValue("@subtotal", subtotal);
                            cmd.Parameters.AddWithValue("@impuestos", impuestos);
                            cmd.Parameters.AddWithValue("@total", total);
                            cmd.Parameters.AddWithValue("@metodoPago", comboBoxMetodoPago.SelectedItem.ToString());
                            cmd.Parameters.AddWithValue("@idVenta", IdVenta);
                            cmd.Parameters.AddWithValue("@usoCFDI", comboBoxCFDI.SelectedItem.ToString());
                            idFactura = Convert.ToInt32(cmd.ExecuteScalar());
                        }

                        foreach (DataRow row in detallesVenta.Rows)
                        {
                            string queryDetalle = @"
                        INSERT INTO detallefactura 
                        (idFactura, descripcion, cantidad, unidadMedida, precioUnitario, importe, idproducto)
                        VALUES 
                        (@idFactura, @descripcion, @cantidad, @unidadMedida, @precioUnitario, @importe, @idproducto)";
                            using (MySqlCommand cmd = new MySqlCommand(queryDetalle, conn, transaction))
                            {
                                cmd.Parameters.AddWithValue("@idFactura", idFactura);
                                cmd.Parameters.AddWithValue("@descripcion", row["descripcion"] != DBNull.Value ? row["descripcion"] : "Producto sin descripción");
                                cmd.Parameters.AddWithValue("@cantidad", Convert.ToDecimal(row["cantidad"] != DBNull.Value ? row["cantidad"] : 1));
                                cmd.Parameters.AddWithValue("@unidadMedida", "Pieza");
                                cmd.Parameters.AddWithValue("@precioUnitario", row["precioUnitario"] != DBNull.Value ? row["precioUnitario"] : 0m);
                                cmd.Parameters.AddWithValue("@importe", row["importe"] != DBNull.Value ? row["importe"] : 0m);
                                cmd.Parameters.AddWithValue("@idproducto", row["idProducto"]);
                                cmd.ExecuteNonQuery();
                            }
                            // Depuración: Confirma que se insertó cada fila
                            MessageBox.Show($"Producto insertado: {row["idProducto"]}", "Depuración");
                        }

                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        MessageBox.Show("Error al insertar la factura o sus detalles: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return 0;
                    }
                }
            }
            return idFactura;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            AdministrarEmisores formAdminEmisores = new AdministrarEmisores();
            formAdminEmisores.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AdministrarReceptores formAdminReceptores = new AdministrarReceptores();
            formAdminReceptores.ShowDialog();
        }

        private void gridVentas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


        private void gridVentas_CellDoubleClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                IdVenta = Convert.ToInt32(gridVentas.Rows[e.RowIndex].Cells["idVenta"].Value);
                lblVentaSeleccionada.Text = $"Venta: {IdVenta}";

                MessageBox.Show($"Venta seleccionada: {IdVenta}");
            }
        }

        private void gridReceptor_CellDoubleClick_1(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0)
            {
                IdReceptor = Convert.ToInt32(gridReceptor.Rows[e.RowIndex].Cells["idReceptor"].Value);
                lblReceptorSeleccionado.Text = $"Receptor: {gridReceptor.Rows[e.RowIndex].Cells["receptor"].Value.ToString()}";
                MessageBox.Show($"Receptor seleccionado: {IdReceptor}");
            }
        }

        private void gridEmisor_CellDoubleClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                IdEmisor = Convert.ToInt32(gridEmisor.Rows[e.RowIndex].Cells["idEmisor"].Value);
                lblEmisorSeleccionado.Text = $"Emisor: {gridEmisor.Rows[e.RowIndex].Cells["nombre"].Value.ToString()}";


                MessageBox.Show($"Venta seleccionada: {IdEmisor}");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Los tipos de CFDI son:\n D01: Honorarios médicos, dentales y gastos hospitalarios" +
                "(ideal para medicamentos recetados que califican como gasto médico\n)" +
                "G03: Gastos en general (útil para productos de uso cotidiano que no califican como gasto médico, " +
                "como artículos de cuidado personal o higiene).\n" +
                "P01: Por definir (si el cliente no especifica el uso en el momento de la emisión).",
                "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void buttonCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
