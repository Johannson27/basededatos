using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace redmax
{
    public partial class catalogoclientes : Form
    {
        private List<Cliente> clientes = new List<Cliente>();

        // Placeholder defaults
        private readonly Dictionary<TextBox, string> placeholders = new Dictionary<TextBox, string>();

        public catalogoclientes()
        {
            InitializeComponent();
        }

        private void catalogoclientes_Load(object sender, EventArgs e)
        {
            CargarClientes();
            ConfigurarDataGrid();

            // ===== Placeholders elegantes =====
            AgregarPlaceholder(txtNombre, "Ingrese el nombre");
            AgregarPlaceholder(txtApellido, "Ingrese el apellido");
            AgregarPlaceholder(txtNRC, "Ingrese NRC");
            AgregarPlaceholder(txtNCedula, "Ingrese Cédula");
            AgregarPlaceholder(txtDireccion, "Ingrese dirección");
            AgregarPlaceholder(txtDepartamento, "Ingrese departamento");
        }

        // =============================
        // Configuración del DataGrid
        // =============================
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
            dataGridView1.DataError += (s, e) => { e.ThrowException = false; };
            dataGridView1.SelectionChanged += DataGridView1_SelectionChanged;
        }

        // =============================
        // Cargar clientes desde SQL
        // =============================
        private void CargarClientes()
        {
            clientes.Clear();

            try
            {
                using (SqlConnection cn = Conexion.Conectar())
                {
                    cn.Open();
                    string consulta = "SELECT Codigo, Nombre, Apellido, NRC, NCedula, FechaNacimiento, Direccion, Departamento FROM Clientes";
                    SqlCommand cmd = new SqlCommand(consulta, cn);
                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        clientes.Add(new Cliente
                        {
                            Codigo = Convert.ToInt32(dr["Codigo"]),
                            Nombre = dr["Nombre"].ToString(),
                            Apellido = dr["Apellido"].ToString(),
                            NRC = dr["NRC"].ToString(),
                            NCedula = dr["NCedula"].ToString(),
                            FechaNacimiento = Convert.ToDateTime(dr["FechaNacimiento"]),
                            Direccion = dr["Direccion"].ToString(),
                            Departamento = dr["Departamento"].ToString()
                        });
                    }

                    dr.Close();
                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = clientes;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar clientes: " + ex.Message);
            }
        }

        // =============================
        // Selección de fila -> llenar TextBox
        // =============================
        private void DataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                Cliente c = (Cliente)dataGridView1.CurrentRow.DataBoundItem;

                // Solo asigna si no hay placeholder activo
                AsignarTextBox(txtNombre, c.Nombre);
                AsignarTextBox(txtApellido, c.Apellido);
                AsignarTextBox(txtNRC, c.NRC);
                AsignarTextBox(txtNCedula, c.NCedula);
                dtpFechaNacimiento.Value = c.FechaNacimiento;
                AsignarTextBox(txtDireccion, c.Direccion);
                AsignarTextBox(txtDepartamento, c.Departamento);
            }
        }

        private void AsignarTextBox(TextBox tb, string valor)
        {
            if (tb.ForeColor != Color.Gray) tb.Text = valor;
        }

        // =============================
        // Botones CRUD
        // =============================
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos()) return;
            EjecutarCRUD("INSERT INTO Clientes (Nombre, Apellido, NRC, NCedula, FechaNacimiento, Direccion, Departamento) " +
                         "VALUES (@nombre, @apellido, @nrc, @ncedula, @fecha, @direccion, @departamento)");
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null || !ValidarCampos()) return;

            int codigo = Convert.ToInt32(dataGridView1.CurrentRow.Cells["Codigo"].Value);
            EjecutarCRUD("UPDATE Clientes SET Nombre=@nombre, Apellido=@apellido, NRC=@nrc, NCedula=@ncedula, " +
                         "FechaNacimiento=@fecha, Direccion=@direccion, Departamento=@departamento WHERE Codigo=@codigo",
                         codigo);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null) return;

            int codigo = Convert.ToInt32(dataGridView1.CurrentRow.Cells["Codigo"].Value);
            if (MessageBox.Show("¿Eliminar este cliente?", "Confirmar", MessageBoxButtons.YesNo) != DialogResult.Yes) return;

            EjecutarCRUD("DELETE FROM Clientes WHERE Codigo=@codigo", codigo);
        }

        private void btnRefrescar_Click(object sender, EventArgs e) => CargarClientes();

        // =============================
        // Método para ejecutar INSERT/UPDATE/DELETE
        // =============================
        private void EjecutarCRUD(string sql, int codigo = -1)
        {
            try
            {
                using (SqlConnection cn = Conexion.Conectar())
                {
                    cn.Open();
                    SqlCommand cmd = new SqlCommand(sql, cn);

                    if (sql.Contains("@nombre")) cmd.Parameters.AddWithValue("@nombre", txtNombre.Text);
                    if (sql.Contains("@apellido")) cmd.Parameters.AddWithValue("@apellido", txtApellido.Text);
                    if (sql.Contains("@nrc")) cmd.Parameters.AddWithValue("@nrc", txtNRC.Text);
                    if (sql.Contains("@ncedula")) cmd.Parameters.AddWithValue("@ncedula", txtNCedula.Text);
                    if (sql.Contains("@fecha")) cmd.Parameters.AddWithValue("@fecha", dtpFechaNacimiento.Value);
                    if (sql.Contains("@direccion")) cmd.Parameters.AddWithValue("@direccion", txtDireccion.Text);
                    if (sql.Contains("@departamento")) cmd.Parameters.AddWithValue("@departamento", txtDepartamento.Text);
                    if (sql.Contains("@codigo")) cmd.Parameters.AddWithValue("@codigo", codigo);

                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Operación realizada correctamente.");
                LimpiarCampos();
                CargarClientes();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al ejecutar operación: " + ex.Message);
            }
        }

        // =============================
        // Placeholders elegantes
        // =============================
        private void AgregarPlaceholder(TextBox tb, string texto)
        {
            placeholders[tb] = texto;
            if (string.IsNullOrEmpty(tb.Text))
            {
                tb.Text = texto;
                tb.ForeColor = Color.Gray;
            }

            tb.GotFocus += (s, e) =>
            {
                if (tb.Text == placeholders[tb])
                {
                    tb.Text = "";
                    tb.ForeColor = Color.Black;
                }
            };

            tb.LostFocus += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(tb.Text))
                {
                    tb.Text = placeholders[tb];
                    tb.ForeColor = Color.Gray;
                }
            };
        }

        // =============================
        // Validaciones
        // =============================
        private bool ValidarCampos()
        {
            foreach (var tb in placeholders.Keys)
            {
                if (string.IsNullOrWhiteSpace(tb.Text) || tb.ForeColor == Color.Gray)
                {
                    MessageBox.Show($"El campo '{placeholders[tb]}' es obligatorio.");
                    return false;
                }
            }
            return true;
        }

        private void LimpiarCampos()
        {
            foreach (var tb in placeholders.Keys)
            {
                tb.Text = "";
                tb.ForeColor = Color.Black;
            }
            dtpFechaNacimiento.Value = DateTime.Today;
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

    public class Cliente
    {
        public int Codigo { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string NRC { get; set; }
        public string NCedula { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Direccion { get; set; }
        public string Departamento { get; set; }
    }
}
