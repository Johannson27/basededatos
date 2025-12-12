using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace redmax
{
    public partial class inventario : Form
    {
        private List<Producto> productos = new List<Producto>();

        public inventario()
        {
            InitializeComponent();
        }

        private void inventario_Load(object sender, EventArgs e)
        {
            CargarProductos();
            ConfigurarDataGrid();
            ConfigurarFiltros();
        }

        private void ConfigurarDataGrid()
        {
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
            dataGridView1.ReadOnly = true;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.DefaultCellStyle.BackColor = Color.White;
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;
        }

        private void ConfigurarFiltros()
        {
            // ComboBox Categoría
            cmbCategoriaFiltro.Items.Clear();
            cmbCategoriaFiltro.Items.Add("Todas");
            foreach (var cat in productos.Select(p => p.Categoria).Distinct())
            {
                cmbCategoriaFiltro.Items.Add(cat);
            }
            cmbCategoriaFiltro.SelectedIndex = 0;
            cmbCategoriaFiltro.SelectedIndexChanged += (s, e) => AplicarFiltros();

            // TextBox Buscar
            txtBuscar.ForeColor = Color.Gray;
            txtBuscar.Text = "Buscar producto...";
            txtBuscar.GotFocus += (s, e) =>
            {
                if (txtBuscar.Text == "Buscar producto...") { txtBuscar.Text = ""; txtBuscar.ForeColor = Color.Black; }
            };
            txtBuscar.LostFocus += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(txtBuscar.Text)) { txtBuscar.Text = "Buscar producto..."; txtBuscar.ForeColor = Color.Gray; }
            };
            txtBuscar.TextChanged += (s, e) => AplicarFiltros();
        }

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
                }
                AplicarFiltros();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar productos: " + ex.Message);
            }
        }

        private void AplicarFiltros()
        {
            if (productos.Count == 0) return;

            var listaFiltrada = productos.AsEnumerable();

            // Filtrar por categoría
            if (cmbCategoriaFiltro.SelectedIndex > 0)
            {
                listaFiltrada = listaFiltrada.Where(p => p.Categoria == cmbCategoriaFiltro.SelectedItem.ToString());
            }

            // Filtrar por búsqueda
            if (!string.IsNullOrWhiteSpace(txtBuscar.Text) && txtBuscar.Text != "Buscar producto...")
            {
                listaFiltrada = listaFiltrada.Where(p => p.Nombre.IndexOf(txtBuscar.Text, StringComparison.OrdinalIgnoreCase) >= 0);
            }

            dataGridView1.DataSource = listaFiltrada.Select(p => new
            {
                p.IdProducto,
                p.Nombre,
                p.Categoria,
                p.Precio,
                p.Stock
            }).ToList();
        }

        private void button1_Click(object sender, EventArgs e) // Clientes
        {
            this.Hide();
            catalogoclientes frm = new catalogoclientes();
            frm.FormClosed += (s, args) => this.Show();
            frm.Show();
        }

        private void button2_Click(object sender, EventArgs e) // Productos
        {
            this.Hide();
            catalogoproductos frm = new catalogoproductos();
            frm.FormClosed += (s, args) => this.Show();
            frm.Show();
        }

        private void button3_Click(object sender, EventArgs e) // Ingreso
        {
            this.Hide();
            ingreso frm = new ingreso();
            frm.FormClosed += (s, args) => this.Show();
            frm.Show();
        }

        private void button4_Click(object sender, EventArgs e) // Inventario
        {
            AplicarFiltros();
        }

        private void button5_Click(object sender, EventArgs e) // Facturación
        {
            this.Hide();
            facturacion frm = new facturacion();
            frm.FormClosed += (s, args) => this.Show();
            frm.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
