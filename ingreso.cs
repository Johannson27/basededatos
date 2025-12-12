using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace redmax
{
    public partial class ingreso : Form
    {
        public ingreso()
        {
            InitializeComponent();
        }

        private void ingreso_Load(object sender, EventArgs e)
        {
            CargarCategorias();
            ConfigurarPlaceholders();
        }

        private void CargarCategorias()
        {
            cbCategoria.Items.Clear();

            using (SqlConnection cn = Conexion.Conectar())
            {
                cn.Open();
                string query = "SELECT DISTINCT Categoria FROM Productos ORDER BY Categoria";
                SqlCommand cmd = new SqlCommand(query, cn);
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    cbCategoria.Items.Add(dr["Categoria"].ToString());
                }

                dr.Close();
            }
            cbCategoria.Text = "Seleccionar categoría";
        }

        private void ConfigurarPlaceholders()
        {
            SetPlaceholder(txtNombre, "Nombre");
            SetPlaceholder(txtPrecio, "Precio");
            SetPlaceholder(txtStock, "Stock");
            SetPlaceholder(cbCategoria, "Categoría");
        }

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

        private void btnAgregarProducto_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text.Trim();
            string categoria = cbCategoria.Text.Trim();
            if (!decimal.TryParse(txtPrecio.Text.Trim(), out decimal precio))
            {
                MessageBox.Show("Precio inválido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!int.TryParse(txtStock.Text.Trim(), out int stock))
            {
                MessageBox.Show("Stock inválido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrEmpty(nombre) || categoria == "Categoría" || string.IsNullOrEmpty(categoria))
            {
                MessageBox.Show("Todos los campos son obligatorios.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection cn = Conexion.Conectar())
            {
                cn.Open();
                string query = @"
                    INSERT INTO Productos (Nombre, Categoria, Precio, Stock)
                    VALUES (@n, @c, @p, @s)";
                SqlCommand cmd = new SqlCommand(query, cn);
                cmd.Parameters.AddWithValue("@n", nombre);
                cmd.Parameters.AddWithValue("@c", categoria);
                cmd.Parameters.AddWithValue("@p", precio);
                cmd.Parameters.AddWithValue("@s", stock);
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show($"Producto {nombre} agregado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LimpiarCampos();
        }

        private void LimpiarCampos()
        {
            txtNombre.Text = "Nombre";
            txtPrecio.Text = "Precio";
            txtStock.Text = "Stock";
            cbCategoria.Text = "Categoría";
        }

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
