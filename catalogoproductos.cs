using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace redmax
{
    public partial class catalogoproductos : Form
    {
        private List<Producto> productos = new List<Producto>();

        public catalogoproductos()
        {
            InitializeComponent();
        }

        private void catalogoproductos_Load(object sender, EventArgs e)
        {
            ConfigurarDataGrid(); // Configuramos columnas antes de cargar
            SetPlaceholders();
            ConfigurarCategoriaComboBox();
            CargarProductos();
        }

        // =========================
        // Placeholders en TextBox
        // =========================
        private void SetPlaceholders()
        {
            txtNombre.ForeColor = Color.Gray;
            txtNombre.Text = "Nombre del producto";
            txtNombre.GotFocus += (s, e) => {
                if (txtNombre.Text == "Nombre del producto") { txtNombre.Text = ""; txtNombre.ForeColor = Color.Black; }
            };
            txtNombre.LostFocus += (s, e) => {
                if (string.IsNullOrWhiteSpace(txtNombre.Text)) { txtNombre.Text = "Nombre del producto"; txtNombre.ForeColor = Color.Gray; }
            };

            txtPrecio.ForeColor = Color.Gray;
            txtPrecio.Text = "Precio";
            txtPrecio.GotFocus += (s, e) => {
                if (txtPrecio.Text == "Precio") { txtPrecio.Text = ""; txtPrecio.ForeColor = Color.Black; }
            };
            txtPrecio.LostFocus += (s, e) => {
                if (string.IsNullOrWhiteSpace(txtPrecio.Text)) { txtPrecio.Text = "Precio"; txtPrecio.ForeColor = Color.Gray; }
            };

            txtStock.ForeColor = Color.Gray;
            txtStock.Text = "Stock";
            txtStock.GotFocus += (s, e) => {
                if (txtStock.Text == "Stock") { txtStock.Text = ""; txtStock.ForeColor = Color.Black; }
            };
            txtStock.LostFocus += (s, e) => {
                if (string.IsNullOrWhiteSpace(txtStock.Text)) { txtStock.Text = "Stock"; txtStock.ForeColor = Color.Gray; }
            };
        }

        // =========================
        // ComboBox Categoría
        // =========================
        private void ConfigurarCategoriaComboBox()
        {
            cmbCategoria.Items.Clear();
            cmbCategoria.Items.Add("Software");
            cmbCategoria.Items.Add("Hardware");
            cmbCategoria.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        // =========================
        // Configuración DataGrid
        // =========================
        private void ConfigurarDataGrid()
        {
            dataGridProductos.AutoGenerateColumns = false;
            dataGridProductos.Columns.Clear();

            // Definir columnas manualmente para evitar index out of range
            dataGridProductos.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "ID", DataPropertyName = "IdProducto" });
            dataGridProductos.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Nombre", DataPropertyName = "Nombre" });
            dataGridProductos.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Categoría", DataPropertyName = "Categoria" });
            dataGridProductos.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Precio", DataPropertyName = "Precio" });
            dataGridProductos.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Stock", DataPropertyName = "Stock" });

            dataGridProductos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridProductos.MultiSelect = false;
            dataGridProductos.ReadOnly = true;
            dataGridProductos.AllowUserToAddRows = false;
            dataGridProductos.AllowUserToDeleteRows = false;
            dataGridProductos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridProductos.RowHeadersVisible = false;

            dataGridProductos.SelectionChanged += DataGridProductos_SelectionChanged;
            dataGridProductos.DataError += (s, e) => { e.ThrowException = false; };
        }

        // =========================
        // Cargar productos
        // =========================
        private void CargarProductos()
        {
            productos.Clear();
            try
            {
                using (SqlConnection cn = Conexion.Conectar())
                {
                    cn.Open();
                    string consulta = "SELECT IdProducto, Nombre, Categoria, Precio, Stock FROM Productos";
                    SqlCommand cmd = new SqlCommand(consulta, cn);
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        productos.Add(new Producto
                        {
                            IdProducto = Convert.ToInt32(dr["IdProducto"]),
                            Nombre = dr["Nombre"].ToString(),
                            Categoria = dr["Categoria"].ToString(),
                            Precio = Convert.ToDecimal(dr["Precio"]),
                            Stock = Convert.ToInt32(dr["Stock"])
                        });
                    }
                    dr.Close();

                    dataGridProductos.DataSource = null;
                    dataGridProductos.DataSource = productos;

                    // Resetear selección para evitar problemas de CurrentRow
                    if (dataGridProductos.Rows.Count > 0)
                        dataGridProductos.Rows[0].Selected = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar productos: " + ex.Message);
            }
        }

        // =========================
        // Selección de fila
        // =========================
        private void DataGridProductos_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridProductos.CurrentRow != null && dataGridProductos.CurrentRow.DataBoundItem != null)
            {
                Producto p = dataGridProductos.CurrentRow.DataBoundItem as Producto;
                if (p != null)
                {
                    txtNombre.Text = p.Nombre;
                    cmbCategoria.SelectedItem = p.Categoria;
                    txtPrecio.Text = p.Precio.ToString();
                    txtStock.Text = p.Stock.ToString();
                }
            }
            else
            {
                LimpiarCampos();
            }
        }

        // =========================
        // CRUD
        // =========================
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos()) return;

            try
            {
                using (SqlConnection cn = Conexion.Conectar())
                {
                    cn.Open();
                    string insertar = "INSERT INTO Productos (Nombre, Categoria, Precio, Stock) VALUES (@nombre, @categoria, @precio, @stock)";
                    SqlCommand cmd = new SqlCommand(insertar, cn);
                    cmd.Parameters.AddWithValue("@nombre", txtNombre.Text);
                    cmd.Parameters.AddWithValue("@categoria", cmbCategoria.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@precio", Convert.ToDecimal(txtPrecio.Text));
                    cmd.Parameters.AddWithValue("@stock", Convert.ToInt32(txtStock.Text));
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Producto agregado.");
                    LimpiarCampos();
                    CargarProductos();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dataGridProductos.CurrentRow == null || dataGridProductos.CurrentRow.DataBoundItem == null) return;
            if (!ValidarCampos()) return;

            Producto p = dataGridProductos.CurrentRow.DataBoundItem as Producto;
            if (p == null) return;

            try
            {
                using (SqlConnection cn = Conexion.Conectar())
                {
                    cn.Open();
                    string actualizar = "UPDATE Productos SET Nombre=@nombre, Categoria=@categoria, Precio=@precio, Stock=@stock WHERE IdProducto=@id";
                    SqlCommand cmd = new SqlCommand(actualizar, cn);
                    cmd.Parameters.AddWithValue("@nombre", txtNombre.Text);
                    cmd.Parameters.AddWithValue("@categoria", cmbCategoria.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@precio", Convert.ToDecimal(txtPrecio.Text));
                    cmd.Parameters.AddWithValue("@stock", Convert.ToInt32(txtStock.Text));
                    cmd.Parameters.AddWithValue("@id", p.IdProducto);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Producto actualizado.");
                    LimpiarCampos();
                    CargarProductos();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dataGridProductos.CurrentRow == null || dataGridProductos.CurrentRow.DataBoundItem == null) return;

            Producto p = dataGridProductos.CurrentRow.DataBoundItem as Producto;
            if (p == null) return;

            if (MessageBox.Show("¿Eliminar este producto?", "Confirmar", MessageBoxButtons.YesNo) != DialogResult.Yes) return;

            try
            {
                using (SqlConnection cn = Conexion.Conectar())
                {
                    cn.Open();
                    string eliminar = "DELETE FROM Productos WHERE IdProducto=@id";
                    SqlCommand cmd = new SqlCommand(eliminar, cn);
                    cmd.Parameters.AddWithValue("@id", p.IdProducto);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Producto eliminado.");
                    LimpiarCampos();
                    CargarProductos();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnRefrescar_Click(object sender, EventArgs e)
        {
            CargarProductos();
        }

        // =========================
        // Limpiar campos
        // =========================
        private void LimpiarCampos()
        {
            txtNombre.Text = "Nombre del producto";
            txtNombre.ForeColor = Color.Gray;
            cmbCategoria.SelectedIndex = -1;
            txtPrecio.Text = "Precio";
            txtPrecio.ForeColor = Color.Gray;
            txtStock.Text = "Stock";
            txtStock.ForeColor = Color.Gray;
        }

        // =========================
        // Validar campos
        // =========================
        private bool ValidarCampos()
        {
            if (txtNombre.Text == "Nombre del producto" || string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("Ingrese el nombre del producto.");
                return false;
            }
            if (cmbCategoria.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione una categoría válida.");
                return false;
            }
            if (!decimal.TryParse(txtPrecio.Text, out _))
            {
                MessageBox.Show("Precio inválido.");
                return false;
            }
            if (!int.TryParse(txtStock.Text, out _))
            {
                MessageBox.Show("Stock inválido.");
                return false;
            }
            return true;
        }

        // =========================
        // Navegación entre forms
        // =========================
        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            catalogoclientes clientes = new catalogoclientes();
            clientes.ShowDialog();
            this.Show();
        }

        private void button2_Click(object sender, EventArgs e) { }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            ingreso ingreso = new ingreso();
            ingreso.ShowDialog();
            this.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            inventario inventario = new inventario();
            inventario.ShowDialog();
            this.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            facturacion facturacion = new facturacion();
            facturacion.ShowDialog();
            this.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
