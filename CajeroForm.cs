using System;
using System.Windows.Forms;

namespace redmax
{
    public partial class CajeroForm : Form
    {
        private string nombreCompleto;

        public CajeroForm(string nombre)
        {
            InitializeComponent();
            nombreCompleto = nombre;
        }

        private void CajeroForm_Load(object sender, EventArgs e)
        {
            Label lbl = new Label();
            lbl.Text = $"Bienvenido, {nombreCompleto} (Cajero)";
            lbl.AutoSize = true;
            lbl.Location = new System.Drawing.Point(20, 20);
            this.Controls.Add(lbl);

            this.Text = "Cajero";
        }
    }
}
