using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace redmax
{
    public partial class NuevoProductoForm : Form
    {
        public NuevoProductoForm()
        {
            InitializeComponent();
            ConfigurarFormulario();
        }

        private void ConfigurarFormulario()
        {
            // Tamaño y título
            this.Text = "Agregar Nuevo Producto";
            this.Size = new Size(400, 350);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;

            // Labels
            Label lblNombre = new Label { Text = "Nombre:", Location = new Point(20, 20), AutoSize = true };
            Label lblCategoria = new Label { Text = "Categoría:", Location = new Point(20, 70), AutoSize = true };
            Label lblPrecio = new Label { Text = "Precio:", Location = new Point(20, 120), AutoSize = true };
            Label lblStock = new Label { Text = "Stock:", Location = new Point(20, 170), AutoSize = true };

            // TextBoxes y ComboBox
            TextBox txtNombre = new TextBox { Name = "txtNombre", Location = new Point(120, 20), Width = 200 };
            ComboBox cmbCategoria = new ComboBox
            {
                Name = "cmbCategoria",
                Location = new Point(120, 70),
                Width = 200,
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            cmbCategoria.Items.Add("Software");
            cmbCategoria.Items.Add("Hardware");

            TextBox txtPrecio = new TextBox { Name = "txtPrecio", Location = new Point(120, 120), Width = 200 };
            TextBox txtStock = new TextBox { Name = "txtStock", Location = new Point(120, 170), Width = 200 };

            // Botón Guardar
            Button btnGuardar = new Button { Text = "Guardar", Location = new Point(120, 220), Width = 100 };
            btnGuardar.Click += (s, e) =>
            {
                if (!ValidarCampos(txtNombre, cmbCategoria, txtPrecio, txtStock)) return;
                GuardarProducto(txtNombre.Text, cmbCategoria.SelectedItem.ToString(),
                    Convert.ToDecimal(txtPrecio.Text), Convert.ToInt32(txtStock.Text));
            };

            // Añadir controles al Form
            this.Controls.Add(lblNombre);
            this.Controls.Add(lblCategoria);
            this.Controls.Add(lblPrecio);
            this.Controls.Add(lblStock);
            this.Controls.Add(txtNombre);
            this.Controls.Add(cmbCategoria);
            this.Controls.Add(txtPrecio);
            this.Controls.Add(txtStock);
            this.Controls.Add(btnGuardar);
        }

        private bool ValidarCampos(TextBox nombre, ComboBox categoria, TextBox precio, TextBox stock)
        {
            if (string.IsNullOrWhiteSpace(nombre.Text))
            {
                MessageBox.Show("Ingrese el nombre del producto.");
                return false;
            }
            if (categoria.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione una categoría.");
                return false;
            }
            if (!decimal.TryParse(precio.Text, out _))
            {
                MessageBox.Show("Precio inválido.");
                return false;
            }
            if (!int.TryParse(stock.Text, out _))
            {
                MessageBox.Show("Stock inválido.");
                return false;
            }
            return true;
        }

        private void GuardarProducto(string nombre, string categoria, decimal precio, int stock)
        {
            try
            {
                using (SqlConnection cn = Conexion.Conectar())
                {
                    cn.Open();
                    string insertar = "INSERT INTO Productos (Nombre, Categoria, Precio, Stock) VALUES (@nombre, @categoria, @precio, @stock)";
                    SqlCommand cmd = new SqlCommand(insertar, cn);
                    cmd.Parameters.AddWithValue("@nombre", nombre);
                    cmd.Parameters.AddWithValue("@categoria", categoria);
                    cmd.Parameters.AddWithValue("@precio", precio);
                    cmd.Parameters.AddWithValue("@stock", stock);
                    cmd.ExecuteNonQuery();
                }
                MessageBox.Show("Producto agregado correctamente.");
                this.Close(); // Cierra el form y vuelve al inventario
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar el producto: " + ex.Message);
            }
        }
    }
}
