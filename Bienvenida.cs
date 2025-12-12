using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace redmax
{
    public partial class Bienvenida : Form
    {
        public Bienvenida()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            catalogoclientes clientes = new catalogoclientes();
            clientes.FormClosed += (s, args) => this.Show();
            clientes.Show();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            catalogoproductos productos = new catalogoproductos();
            productos.FormClosed += (s, args) => this.Show();
            productos.Show();

        }



        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            inventario inv = new inventario();
            inv.FormClosed += (s, args) => this.Show();
            inv.Show();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            facturacion fac = new facturacion();
            fac.FormClosed += (s, args) => this.Show();
            fac.Show();

        }

        private void button6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            ingreso ing = new ingreso();
            ing.FormClosed += (s, args) => this.Show();
            ing.Show();


        }
    }
}
