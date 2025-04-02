using System;
using System.Configuration;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace SaludExpres
{
    public partial class Inventario : Form
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["SaludExpresConnection"].ConnectionString;

        public Inventario()
        {
            InitializeComponent();
            CargarProductos();
        }

        private void CargarProductos()
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = @"
                        SELECT 
                            p.idProducto, 
                            p.nombre, 
                            p.descripcion, 
                            p.precioCompra, 
                            p.precioSinIva, 
                            p.stock, 
                            p.tipo, 
                            p.lote, 
                            p.fechaFabricacion, 
                            p.fechaCaducidad, 
                            p.registroSanitario, 
                            p.condicionesAlmacenamiento, 
                            pr.nombre AS proveedor, 
                            c.nombre AS categoria, 
                            s.nombre AS sucursal
                        FROM producto p
                        LEFT JOIN proveedor pr ON p.idProveedor = pr.idProveedor
                        LEFT JOIN categoria c ON p.idCategoria = c.idCategoria
                        LEFT JOIN sucursal s ON p.idSucursal = s.idSucursal";

                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    dataGridViewProductos.DataSource = dt;
                    dataGridViewProductos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    dataGridViewProductos.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

                    // Renombrar columnas
                    dt.Columns["idProducto"].ColumnName = "ID";
                    dt.Columns["nombre"].ColumnName = "Nombre";
                    dt.Columns["descripcion"].ColumnName = "Descripción";
                    dt.Columns["precioCompra"].ColumnName = "Precio Compra";
                    dt.Columns["precioSinIva"].ColumnName = "Precio Sin IVA";
                    dt.Columns["stock"].ColumnName = "Stock";
                    dt.Columns["tipo"].ColumnName = "Tipo";
                    dt.Columns["lote"].ColumnName = "Lote";
                    dt.Columns["fechaFabricacion"].ColumnName = "Fecha Fabricación";
                    dt.Columns["fechaCaducidad"].ColumnName = "Fecha Caducidad";
                    dt.Columns["registroSanitario"].ColumnName = "Registro Sanitario";
                    dt.Columns["condicionesAlmacenamiento"].ColumnName = "Condiciones Almacenamiento";
                    dt.Columns["proveedor"].ColumnName = "Proveedor";
                    dt.Columns["categoria"].ColumnName = "Categoría";
                    dt.Columns["sucursal"].ColumnName = "Sucursal";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar productos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Inventario_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            CargarFiltrosProveedores();
            CargarFiltrosCategorias();
        }

        private void buttonCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AplicarFiltro()
        {
            if (dataGridViewProductos.DataSource is DataTable dt)
            {
                List<string> filtros = new List<string>();
                string busqueda = textBoxBuscar.Text.Trim();

                if (!string.IsNullOrEmpty(busqueda))
                {
                    filtros.Add($"(Nombre LIKE '%{busqueda}%' OR Descripción LIKE '%{busqueda}%' OR Lote LIKE '%{busqueda}%')");
                }

                if (comboBoxProveedor.SelectedIndex > 0)
                {
                    filtros.Add($"Proveedor = '{comboBoxProveedor.Text}'");
                }

                if (comboBoxCategoria.SelectedIndex > 0)
                {
                    filtros.Add($"Categoría = '{comboBoxCategoria.Text}'");
                }

                if (numericPrecioMin.Value > 0 || numericPrecioMax.Value > 0)
                {
                    filtros.Add($"([Precio Sin IVA] >= {numericPrecioMin.Value} AND [Precio Sin IVA] <= {numericPrecioMax.Value})");
                }

                if (checkBoxStockBajo.Checked)
                {
                    filtros.Add("Stock < 10");
                }

                if (checkBoxProxCaducidad.Checked)
                {
                    filtros.Add($"[Fecha Caducidad] <= '{DateTime.Now.AddMonths(3):yyyy-MM-dd}'");
                }

                dt.DefaultView.RowFilter = filtros.Count > 0 ? string.Join(" AND ", filtros) : "";
                dataGridViewProductos.Refresh();
            }
        }

        private void CargarFiltrosProveedores()
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT idProveedor, nombre FROM proveedor";
                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    DataRow dr = dt.NewRow();
                    dr["idProveedor"] = 0;
                    dr["nombre"] = "Todos";
                    dt.Rows.InsertAt(dr, 0);

                    comboBoxProveedor.DataSource = dt;
                    comboBoxProveedor.DisplayMember = "nombre";
                    comboBoxProveedor.ValueMember = "idProveedor";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar proveedores: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarFiltrosCategorias()
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT idCategoria, nombre FROM categoria";
                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    DataRow dr = dt.NewRow();
                    dr["idCategoria"] = 0;
                    dr["nombre"] = "Todos";
                    dt.Rows.InsertAt(dr, 0);

                    comboBoxCategoria.DataSource = dt;
                    comboBoxCategoria.DisplayMember = "nombre";
                    comboBoxCategoria.ValueMember = "idCategoria";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar categorías: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonEliminar_Click(object sender, EventArgs e)
        {
            if (dataGridViewProductos.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un producto para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int idProducto = Convert.ToInt32(dataGridViewProductos.SelectedRows[0].Cells["ID"].Value);
            DialogResult resultado = MessageBox.Show("¿Está seguro de eliminar este producto?",
                                                   "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (resultado == DialogResult.Yes)
            {
                try
                {
                    using (MySqlConnection connection = new MySqlConnection(connectionString))
                    {
                        connection.Open();
                        using (MySqlTransaction transaction = connection.BeginTransaction())
                        {
                            try
                            {
                                // Eliminar registros dependientes (ajusta según tus tablas)
                                string[] tablasDependientes = { "movimientoinventario" /*, "detalle_venta", "otra_tabla" */ };
                                foreach (string tabla in tablasDependientes)
                                {
                                    string queryDependiente = $"DELETE FROM {tabla} WHERE idProducto = @idProducto";
                                    using (MySqlCommand cmdDependiente = new MySqlCommand(queryDependiente, connection, transaction))
                                    {
                                        cmdDependiente.Parameters.AddWithValue("@idProducto", idProducto);
                                        cmdDependiente.ExecuteNonQuery();
                                    }
                                }

                                // Eliminar el producto
                                string queryProducto = "DELETE FROM producto WHERE idProducto = @idProducto";
                                using (MySqlCommand cmdProducto = new MySqlCommand(queryProducto, connection, transaction))
                                {
                                    cmdProducto.Parameters.AddWithValue("@idProducto", idProducto);
                                    cmdProducto.ExecuteNonQuery();
                                }

                                transaction.Commit();
                                MessageBox.Show("Producto eliminado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                CargarProductos(); // Recargar la lista en lugar de cerrar el formulario
                            }
                            catch (Exception ex)
                            {
                                transaction.Rollback();
                                MessageBox.Show("Error al eliminar el producto: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al conectar con la base de datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void buttonAgregarProducto_Click(object sender, EventArgs e)
        {
            RegistrarProducto registrarProducto = new RegistrarProducto();
            registrarProducto.ShowDialog();
            CargarProductos();
        }

        private void buttonEditUs_Click(object sender, EventArgs e)
        {
            if (dataGridViewProductos.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un producto para editar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int idProducto = Convert.ToInt32(dataGridViewProductos.SelectedRows[0].Cells["ID"].Value);
            EditarProducto editarProductoForm = new EditarProducto(idProducto);
            editarProductoForm.ShowDialog();
            CargarProductos();
        }

        private void buttonBuscar_Click(object sender, EventArgs e)
        {
            AplicarFiltro();
        }

        private void textBoxBuscar_TextChanged(object sender, EventArgs e)
        {
            AplicarFiltro(); // Usar el filtro completo en lugar de solo por nombre
        }
    }
}