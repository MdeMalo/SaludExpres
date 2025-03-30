using System;
using System.Configuration;
using System.Data;
using System.Globalization;
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
                    p.precioConIva, 
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

                    // Opcional: Renombrar columnas para mayor claridad en el DataGridView
                    dt.Columns["idProducto"].ColumnName = "ID";
                    dt.Columns["nombre"].ColumnName = "Nombre";
                    dt.Columns["descripcion"].ColumnName = "Descripción";
                    dt.Columns["precioCompra"].ColumnName = "Precio Compra";
                    dt.Columns["precioSinIva"].ColumnName = "Precio Sin IVA";
                    dt.Columns["precioConIva"].ColumnName = "Precio Con IVA";
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

                // 🟢 Filtro por texto en Nombre, Descripción o Lote
                if (!string.IsNullOrEmpty(busqueda))
                {
                    filtros.Add($"(Nombre LIKE '%{busqueda}%' OR Descripción LIKE '%{busqueda}%' OR Lote LIKE '%{busqueda}%')");
                }

                // 🟢 Filtro por Proveedor
                if (comboBoxProveedor.SelectedIndex > 0)
                {
                    filtros.Add($"Proveedor = '{comboBoxProveedor.Text}'");
                }

                // 🟢 Filtro por Categoría
                if (comboBoxCategoria.SelectedIndex > 0)
                {
                    filtros.Add($"Categoría = '{comboBoxCategoria.Text}'");
                }

                // 🟢 Filtro por Rango de Precios
                if (numericPrecioMin.Value > 0 || numericPrecioMax.Value > 0)
                {
                    filtros.Add($"([Precio Sin IVA] >= {numericPrecioMin.Value} AND [Precio Sin IVA] <= {numericPrecioMax.Value})");
                }

                // 🟢 Filtro por Stock Bajo
                if (checkBoxStockBajo.Checked)
                {
                    filtros.Add("Stock < 10");
                }

                // 🟢 Filtro por Fecha de Caducidad
                if (checkBoxProxCaducidad.Checked)
                {
                    filtros.Add($"[Fecha Caducidad] <= #{DateTime.Now.AddMonths(3):yyyy-MM-dd}#");
                }

                // 🔹 Aplica el filtro
                dt.DefaultView.RowFilter = string.Join(" AND ", filtros);

                // 🔄 Refresca la vista
                dataGridViewProductos.Refresh();
                dataGridViewProductos.Update();
                MessageBox.Show("Filtro aplicado: " + string.Join(" AND ", filtros));
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

                    // Agregar opción "Todos" al inicio
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
                MessageBox.Show("Error al cargar proveedores para filtro: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                    // Agregar opción "Todos" al inicio
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
                MessageBox.Show("Error al cargar categorías para filtro: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AplicarFiltroNombre()
        {
            try
            {
                if (dataGridViewProductos.DataSource is DataTable dt)
                {
                    string busqueda = textBoxBuscar.Text.Trim();
                    if (!string.IsNullOrEmpty(busqueda))
                    {
                        dt.DefaultView.RowFilter = $"Nombre LIKE '%{busqueda}%'";
                    }
                    else
                    {
                        dt.DefaultView.RowFilter = ""; // Quita el filtro si está vacío
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al aplicar el filtro por nombre: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonEliminar_Click(object sender, EventArgs e)
        {
            if (dataGridViewProductos.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un producto para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Obtener el ID del producto desde la columna renombrada
            int idProducto = Convert.ToInt32(dataGridViewProductos.SelectedRows[0].Cells["ID"].Value);

            DialogResult result = MessageBox.Show("¿Está seguro de que desea eliminar este producto?",
                                                  "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    using (MySqlConnection connection = new MySqlConnection(connectionString))
                    {
                        connection.Open();
                        string query = "DELETE FROM producto WHERE idProducto = @idProducto";

                        using (MySqlCommand cmd = new MySqlCommand(query, connection))
                        {
                            cmd.Parameters.AddWithValue("@idProducto", idProducto);
                            cmd.ExecuteNonQuery();
                        }
                    }

                    MessageBox.Show("Producto eliminado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarProductos(); // Recargar la tabla después de eliminar
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al eliminar el producto: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            // Verificar si hay alguna fila seleccionada
            if (dataGridViewProductos.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un producto para editar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Obtener el ID del producto seleccionado desde la columna "ID" renombrada
            int idProducto = Convert.ToInt32(dataGridViewProductos.SelectedRows[0].Cells["ID"].Value);

            // Crear una nueva instancia del formulario de edición y pasarle el ID del producto
            EditarProducto editarProductoForm = new EditarProducto(idProducto);

            // Mostrar el formulario de edición
            editarProductoForm.ShowDialog();

            // Recargar los productos después de editar
            CargarProductos();
        }

        private void buttonBuscar_Click(object sender, EventArgs e)
        {
            AplicarFiltro();
        }

        private void textBoxBuscar_TextChanged(object sender, EventArgs e)
        {
            AplicarFiltroNombre();
        }
    }
}
