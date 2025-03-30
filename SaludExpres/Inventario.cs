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

                // Filtro por texto en nombre, descripción o lote
                if (!string.IsNullOrEmpty(busqueda))
                {
                    filtros.Add($"(Nombre LIKE '%{busqueda}%' OR Descripción LIKE '%{busqueda}%' OR Lote LIKE '%{busqueda}%')");
                }

                // Filtro por proveedor
                if (comboBoxProveedor.SelectedIndex > 0)
                {
                    filtros.Add($"idProveedor = {comboBoxProveedor.SelectedValue}");
                }

                // Filtro por categoría
                if (comboBoxCategoria.SelectedIndex > 0)
                {
                    filtros.Add($"idCategoria = {comboBoxCategoria.SelectedValue}");
                }

                // Filtro por rango de precios
                if (numericPrecioMin.Value > 0 || numericPrecioMax.Value > 0)
                {
                    filtros.Add($"(precioSinIva >= {numericPrecioMin.Value} AND precioSinIva <= {numericPrecioMax.Value})");
                }

                // Filtro por stock
                if (checkBoxStockBajo.Checked)
                {
                    filtros.Add("stock < 10"); // Productos con menos de 10 unidades
                }

                // Filtro por fecha de caducidad
                if (checkBoxProxCaducidad.Checked)
                {
                    filtros.Add($"fechaCaducidad <= '{DateTime.Now.AddMonths(3).ToString("yyyy-MM-dd")}'");
                }

                // Aplica el filtro combinado
                dt.DefaultView.RowFilter = string.Join(" AND ", filtros);
            }
        }

        // Evento de búsqueda en tiempo real
        private void textBoxBuscar_TextChanged(object sender, EventArgs e)
        {
            AplicarFiltro();
        }

        // Evento para cuando se cambia una opción de filtro
        private void comboBoxProveedor_SelectedIndexChanged(object sender, EventArgs e)
        {
            AplicarFiltro();
        }

        private void comboBoxCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            AplicarFiltro();
        }

        private void numericPrecioMin_ValueChanged(object sender, EventArgs e)
        {
            AplicarFiltro();
        }

        private void numericPrecioMax_ValueChanged(object sender, EventArgs e)
        {
            AplicarFiltro();
        }

        private void checkBoxStockBajo_CheckedChanged(object sender, EventArgs e)
        {
            AplicarFiltro();
        }

        private void checkBoxProxCaducidad_CheckedChanged(object sender, EventArgs e)
        {
            AplicarFiltro();
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

    }
}
