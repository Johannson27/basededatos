using System;
using System.Windows.Forms;

namespace redmax
{
    public partial class AdminForm : Form
    {
        private string nombreCompleto;

        public AdminForm(string nombre)
        {
            InitializeComponent();
            nombreCompleto = nombre;
        }

        private void AdminForm_Load(object sender, EventArgs e)
        {
            Label lbl = new Label();
            lbl.Text = $"Bienvenido, {nombreCompleto} (Administrador)";
            lbl.AutoSize = true;
            lbl.Location = new System.Drawing.Point(20, 20);
            this.Controls.Add(lbl);

            this.Text = "Administrador";
        }
    }
}
