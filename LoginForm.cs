using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace redmax
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            SetPlaceholder(txtUsuario, "Usuario");
            SetPlaceholder(txtContrasena, "Contraseña");
            txtContrasena.UseSystemPasswordChar = false;
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
                    if (txt == txtContrasena) txt.UseSystemPasswordChar = true;
                }
            };

            txt.Leave += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(txt.Text))
                {
                    txt.Text = mensaje;
                    txt.ForeColor = Color.Gray;
                    if (txt == txtContrasena) txt.UseSystemPasswordChar = false;
                }
            };
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text.Trim();
            string contrasena = txtContrasena.Text.Trim();

            if (string.IsNullOrEmpty(usuario) || usuario == "Usuario" ||
                string.IsNullOrEmpty(contrasena) || contrasena == "Contraseña")
            {
                MessageBox.Show("Ingrese usuario y contraseña.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection cn = Conexion.Conectar())
                {
                    cn.Open();
                    string query = @"
                        SELECT U.NombreCompleto, R.Nombre AS RolNombre
                        FROM Usuarios U
                        INNER JOIN Roles R ON U.IdRol = R.IdRol
                        WHERE LTRIM(RTRIM(U.Usuario)) = @usuario AND LTRIM(RTRIM(U.Contrasena)) = @contrasena";

                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@usuario", usuario);
                    cmd.Parameters.AddWithValue("@contrasena", contrasena);

                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.Read())
                    {
                        string nombreCompleto = dr["NombreCompleto"].ToString();
                        string rolNombre = dr["RolNombre"].ToString();
                        dr.Close();

                        this.Hide();

                        // Abrir Bienvenida
                        Bienvenida bienvenida = new Bienvenida();
                        bienvenida.FormClosed += (s, args) => this.Show();

                        Label lbl = new Label();
                        lbl.Text = $"Bienvenido, {nombreCompleto} ({rolNombre})";
                        lbl.AutoSize = true;
                        lbl.Location = new Point(20, 20);
                        bienvenida.Controls.Add(lbl);

                        bienvenida.Show();
                    }
                    else
                    {
                        MessageBox.Show("Usuario o contraseña incorrectos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al conectarse a la base de datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
