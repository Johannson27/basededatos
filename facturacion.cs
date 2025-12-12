using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace redmax
{
    public partial class facturacion : Form
    {
        public facturacion()
        {
            InitializeComponent();
        }

        private void facturacion_Load(object sender, EventArgs e)
        {
            // Cargar categorías desde SQL
            cbCategorias.Items.Clear();
            CargarCategoriasDesdeSQL();
            cbProductos.Enabled = false;

            // Placeholders
            SetPlaceholder(txtCantidad, "Cantidad");
            SetPlaceholder(txtPrecio, "Precio");
            SetPlaceholder(txtIVA, "IVA (%)");
            SetPlaceholder(txtSubtotal, "Subtotal");
            SetPlaceholder(txtTotal, "Total");
            SetPlaceholder(cbCategorias, "Categorias");
            SetPlaceholder(cbProductos, "Producto");
        }

        // ================================
        // Cargar categorías desde SQL
        // ================================
        private void CargarCategoriasDesdeSQL()
        {
            using (SqlConnection cn = Conexion.Conectar())
            {
                cn.Open();
                string query = "SELECT DISTINCT Categoria FROM Productos ORDER BY Categoria";
                SqlCommand cmd = new SqlCommand(query, cn);
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                    cbCategorias.Items.Add(dr["Categoria"].ToString());

                dr.Close();
            }
        }

        // ================================
        // Cambiar categoría -> cargar productos
        // ================================
        private void cbCategorias_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbProductos.Items.Clear();
            cbProductos.Enabled = true;

            using (SqlConnection cn = Conexion.Conectar())
            {
                cn.Open();
                string query = "SELECT Nombre FROM Productos WHERE Categoria=@cat AND Stock > 0 ORDER BY Nombre";
                SqlCommand cmd = new SqlCommand(query, cn);
                cmd.Parameters.AddWithValue("@cat", cbCategorias.Text);

                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                    cbProductos.Items.Add(dr["Nombre"].ToString());

                dr.Close();
            }
        }

        // ================================
        // Botón Facturar
        // ================================
        private void btnFacturar_Click(object sender, EventArgs e)
        {
            if (cbProductos.Text == "Producto" || string.IsNullOrWhiteSpace(cbProductos.Text))
            {
                MessageBox.Show("Seleccione un producto.");
                return;
            }

            string producto = cbProductos.Text;

            // Cantidad desde txtCantidad
            if (!int.TryParse(txtCantidad.Text, out int cantidad) || cantidad <= 0)
            {
                MessageBox.Show("Ingrese una cantidad válida.");
                return;
            }

            decimal precio = ObtenerPrecio(producto);
            if (precio <= 0)
            {
                MessageBox.Show("Precio inválido.");
                return;
            }

            int stock = ObtenerStock(producto);
            if (cantidad > stock)
            {
                MessageBox.Show("Stock insuficiente.");
                return;
            }

            // Calcular totales
            decimal subtotal = precio * cantidad;
            decimal iva = subtotal * 0.15m;
            decimal total = subtotal + iva;

            // Mostrar en TextBox
            txtPrecio.Text = precio.ToString("0.00");
            txtSubtotal.Text = subtotal.ToString("0.00");
            txtIVA.Text = iva.ToString("0.00");
            txtTotal.Text = total.ToString("0.00");

            // Guardar en SQL
            int idFactura = GuardarFactura(subtotal, iva, total);
            GuardarDetalles(idFactura, producto, cantidad, precio, subtotal);

            // Actualizar stock
            DescontarStock(producto, cantidad);

            MessageBox.Show($"Factura registrada!\nID: {idFactura}\nTotal: ${total:0.00}");
        }

        // ================================
        // Obtener precio desde SQL
        // ================================
        private decimal ObtenerPrecio(string producto)
        {
            using (SqlConnection cn = Conexion.Conectar())
            {
                cn.Open();
                string query = "SELECT Precio FROM Productos WHERE Nombre=@n";
                SqlCommand cmd = new SqlCommand(query, cn);
                cmd.Parameters.AddWithValue("@n", producto);
                object result = cmd.ExecuteScalar();
                return result == null ? 0 : Convert.ToDecimal(result);
            }
        }

        // ================================
        // Obtener stock desde SQL
        // ================================
        private int ObtenerStock(string producto)
        {
            using (SqlConnection cn = Conexion.Conectar())
            {
                cn.Open();
                string query = "SELECT Stock FROM Productos WHERE Nombre=@n";
                SqlCommand cmd = new SqlCommand(query, cn);
                cmd.Parameters.AddWithValue("@n", producto);
                object result = cmd.ExecuteScalar();
                return result == null ? 0 : Convert.ToInt32(result);
            }
        }

        // ================================
        // Descontar stock
        // ================================
        private void DescontarStock(string producto, int cantidad)
        {
            using (SqlConnection cn = Conexion.Conectar())
            {
                cn.Open();
                string query = "UPDATE Productos SET Stock = Stock - @c WHERE Nombre=@n";
                SqlCommand cmd = new SqlCommand(query, cn);
                cmd.Parameters.AddWithValue("@c", cantidad);
                cmd.Parameters.AddWithValue("@n", producto);
                cmd.ExecuteNonQuery();
            }
        }

        // ================================
        // Guardar factura
        // ================================
        private int GuardarFactura(decimal subtotal, decimal iva, decimal total)
        {
            using (SqlConnection cn = Conexion.Conectar())
            {
                cn.Open();
                string query = @"
                    INSERT INTO Factura (Subtotal, IVA, Total)
                    VALUES (@s, @i, @t);
                    SELECT SCOPE_IDENTITY();";

                SqlCommand cmd = new SqlCommand(query, cn);
                cmd.Parameters.AddWithValue("@s", subtotal);
                cmd.Parameters.AddWithValue("@i", iva);
                cmd.Parameters.AddWithValue("@t", total);

                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        // ================================
        // Guardar detalle de factura
        // ================================
        private void GuardarDetalles(int idFactura, string producto, int cantidad, decimal precio, decimal subtotal)
        {
            using (SqlConnection cn = Conexion.Conectar())
            {
                cn.Open();
                string query = @"
                    INSERT INTO FacturaDetalle (IdFactura, Producto, Cantidad, Precio, Subtotal)
                    VALUES (@f, @p, @c, @pr, @s)";
                SqlCommand cmd = new SqlCommand(query, cn);
                cmd.Parameters.AddWithValue("@f", idFactura);
                cmd.Parameters.AddWithValue("@p", producto);
                cmd.Parameters.AddWithValue("@c", cantidad);
                cmd.Parameters.AddWithValue("@pr", precio);
                cmd.Parameters.AddWithValue("@s", subtotal);
                cmd.ExecuteNonQuery();
            }
        }

        // ================================
        // Placeholders para TextBox
        // ================================
        private void SetPlaceholder(TextBox txt, string mensaje)
        {
            txt.ForeColor = Color.Gray;
            txt.Text = mensaje;

            txt.Enter += (s, e) =>
            {
                if (txt.Text == mensaje)
                {
                    txt.Text = "";
                    txt.ForeColor = Color.Black;
                }
            };

            txt.Leave += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(txt.Text))
                {
                    txt.Text = mensaje;
                    txt.ForeColor = Color.Gray;
                }
            };
        }

        // ================================
        // Placeholders para ComboBox
        // ================================
        private void SetPlaceholder(ComboBox cmb, string mensaje)
        {
            cmb.ForeColor = Color.Gray;
            cmb.Text = mensaje;

            cmb.Enter += (s, e) =>
            {
                if (cmb.Text == mensaje)
                {
                    cmb.Text = "";
                    cmb.ForeColor = Color.Black;
                }
            };

            cmb.Leave += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(cmb.Text))
                {
                    cmb.Text = mensaje;
                    cmb.ForeColor = Color.Gray;
                }
            };
        }

        // ================================
        // Botones de navegación
        // ================================
        private void button1_Click(object sender, EventArgs e) { AbrirForm(new catalogoclientes()); }
        private void button2_Click(object sender, EventArgs e) { AbrirForm(new catalogoproductos()); }
        private void button3_Click(object sender, EventArgs e) { AbrirForm(new ingreso()); }
        private void button4_Click(object sender, EventArgs e) { AbrirForm(new inventario()); }
        private void button5_Click(object sender, EventArgs e) { AbrirForm(new facturacion()); }
        private void button6_Click(object sender, EventArgs e) { Application.Exit(); }

        private void AbrirForm(Form frm)
        {
            this.Hide();
            frm.FormClosed += (s, args) => this.Show();
            frm.Show();
        }

    }
}

