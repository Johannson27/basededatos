using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace redmax
{
    public partial class ProductoForm : Form
    {
        private int idProducto = 0; // 0 = nuevo producto, >0 = editar

        public ProductoForm()
        {
            InitializeComponent();
            this.Text = "Agregar Producto";
        }

        public ProductoForm(int id)
        {
            InitializeComponent();
            this.Text = "Editar Producto";
            idProducto = id;
            CargarProducto();
        }

        private void CargarProducto()
        {
            try
            {
                using (SqlConnection cn = Conexion.Conectar())
                {
                    cn.Open();
                    string consulta = "SELECT Nombre, Categoria, Precio, Stock FROM Productos WHERE IdProducto=@id";
                    SqlCommand cmd = new SqlCommand(consulta, cn);
                    cmd.Parameters.AddWithValue("@id", idProducto);
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        txtNombre.Text = dr["Nombre"].ToString();
                        txtCategoria.Text = dr["Categoria"].ToString();
                        txtPrecio.Text = dr["Precio"].ToString();
                        txtStock.Text = dr["Stock"].ToString();
                    }
                    dr.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar el producto: " + ex.Message);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(txtCategoria.Text) ||
                string.IsNullOrWhiteSpace(txtPrecio.Text) ||
                string.IsNullOrWhiteSpace(txtStock.Text))
            {
                MessageBox.Show("Todos los campos son obligatorios.");
                return;
            }

            if (!decimal.TryParse(txtPrecio.Text, out decimal precio))
            {
                MessageBox.Show("Precio inválido.");
                return;
            }

            if (!int.TryParse(txtStock.Text, out int stock))
            {
                MessageBox.Show("Stock inválido.");
                return;
            }

            try
            {
                using (SqlConnection cn = Conexion.Conectar())
                {
                    cn.Open();
                    SqlCommand cmd;
                    if (idProducto == 0)
                    {
                        cmd = new SqlCommand(
                            "INSERT INTO Productos (Nombre, Categoria, Precio, Stock) VALUES (@nombre,@categoria,@precio,@stock)",
                            cn);
                    }
                    else
                    {
                        cmd = new SqlCommand(
                            "UPDATE Productos SET Nombre=@nombre, Categoria=@categoria, Precio=@precio, Stock=@stock WHERE IdProducto=@id",
                            cn);
                        cmd.Parameters.AddWithValue("@id", idProducto);
                    }

                    cmd.Parameters.AddWithValue("@nombre", txtNombre.Text);
                    cmd.Parameters.AddWithValue("@categoria", txtCategoria.Text);
                    cmd.Parameters.AddWithValue("@precio", precio);
                    cmd.Parameters.AddWithValue("@stock", stock);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Producto guardado correctamente.");
                    this.DialogResult = DialogResult.OK;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar el producto: " + ex.Message);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
