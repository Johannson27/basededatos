using System;
using System.Windows.Forms;

namespace redmax
{
    partial class catalogoclientes
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button6 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.panellogo = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.cnombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.capellido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cnrc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cncedula = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cfechaNacimiento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cdireccion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cdepartamento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnRefrescar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.dtpFechaNacimiento = new System.Windows.Forms.DateTimePicker();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtApellido = new System.Windows.Forms.TextBox();
            this.txtNRC = new System.Windows.Forms.TextBox();
            this.txtNCedula = new System.Windows.Forms.TextBox();
            this.txtDireccion = new System.Windows.Forms.TextBox();
            this.txtDepartamento = new System.Windows.Forms.TextBox();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(219, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(768, 80);
            this.panel2.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Modern No. 20", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(355, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "REDMAX";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.panel1.Controls.Add(this.button6);
            this.panel1.Controls.Add(this.button5);
            this.panel1.Controls.Add(this.button4);
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.panellogo);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(219, 507);
            this.panel1.TabIndex = 2;
            // 
            // button6
            // 
            this.button6.Dock = System.Windows.Forms.DockStyle.Top;
            this.button6.FlatAppearance.BorderSize = 0;
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button6.ForeColor = System.Drawing.Color.Gainsboro;
            this.button6.Image = global::redmax.Properties.Resources.download__11_;
            this.button6.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button6.Location = new System.Drawing.Point(0, 375);
            this.button6.Name = "button6";
            this.button6.Padding = new System.Windows.Forms.Padding(11, 0, 0, 0);
            this.button6.Size = new System.Drawing.Size(219, 59);
            this.button6.TabIndex = 7;
            this.button6.Text = "   Salir";
            this.button6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button6.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button6.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.Dock = System.Windows.Forms.DockStyle.Top;
            this.button5.FlatAppearance.BorderSize = 0;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.ForeColor = System.Drawing.Color.Gainsboro;
            this.button5.Image = global::redmax.Properties.Resources.download__10_;
            this.button5.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button5.Location = new System.Drawing.Point(0, 316);
            this.button5.Name = "button5";
            this.button5.Padding = new System.Windows.Forms.Padding(11, 0, 0, 0);
            this.button5.Size = new System.Drawing.Size(219, 59);
            this.button5.TabIndex = 6;
            this.button5.Text = "   Facturacion";
            this.button5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button5.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button4
            // 
            this.button4.Dock = System.Windows.Forms.DockStyle.Top;
            this.button4.FlatAppearance.BorderSize = 0;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.ForeColor = System.Drawing.Color.Gainsboro;
            this.button4.Image = global::redmax.Properties.Resources.download__2_;
            this.button4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button4.Location = new System.Drawing.Point(0, 257);
            this.button4.Name = "button4";
            this.button4.Padding = new System.Windows.Forms.Padding(11, 0, 0, 0);
            this.button4.Size = new System.Drawing.Size(219, 59);
            this.button4.TabIndex = 5;
            this.button4.Text = "   Inventario";
            this.button4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button4.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.Dock = System.Windows.Forms.DockStyle.Top;
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.ForeColor = System.Drawing.Color.Gainsboro;
            this.button3.Image = global::redmax.Properties.Resources.download__3_;
            this.button3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button3.Location = new System.Drawing.Point(0, 198);
            this.button3.Name = "button3";
            this.button3.Padding = new System.Windows.Forms.Padding(11, 0, 0, 0);
            this.button3.Size = new System.Drawing.Size(219, 59);
            this.button3.TabIndex = 4;
            this.button3.Text = "   Ingreso de productos";
            this.button3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Dock = System.Windows.Forms.DockStyle.Top;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.ForeColor = System.Drawing.Color.Gainsboro;
            this.button2.Image = global::redmax.Properties.Resources.basket_cart_icon_32x32;
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.Location = new System.Drawing.Point(0, 139);
            this.button2.Name = "button2";
            this.button2.Padding = new System.Windows.Forms.Padding(11, 0, 0, 0);
            this.button2.Size = new System.Drawing.Size(219, 59);
            this.button2.TabIndex = 3;
            this.button2.Text = "   Catalogo de productos";
            this.button2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Top;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.Color.Gainsboro;
            this.button1.Image = global::redmax.Properties.Resources.Sin_título_1;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(0, 80);
            this.button1.Name = "button1";
            this.button1.Padding = new System.Windows.Forms.Padding(11, 0, 0, 0);
            this.button1.Size = new System.Drawing.Size(219, 59);
            this.button1.TabIndex = 2;
            this.button1.Text = "   Catalogo de clientes";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panellogo
            // 
            this.panellogo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(58)))));
            this.panellogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panellogo.Location = new System.Drawing.Point(0, 0);
            this.panellogo.Name = "panellogo";
            this.panellogo.Size = new System.Drawing.Size(219, 80);
            this.panellogo.TabIndex = 1;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cnombre,
            this.capellido,
            this.cnrc,
            this.cncedula,
            this.cfechaNacimiento,
            this.cdireccion,
            this.cdepartamento});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataGridView1.Location = new System.Drawing.Point(219, 263);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(768, 244);
            this.dataGridView1.TabIndex = 4;
            // 
            // cnombre
            // 
            this.cnombre.DataPropertyName = "nombre";
            this.cnombre.HeaderText = "NOMBRE";
            this.cnombre.MinimumWidth = 6;
            this.cnombre.Name = "cnombre";
            this.cnombre.ReadOnly = true;
            this.cnombre.Width = 125;
            // 
            // capellido
            // 
            this.capellido.DataPropertyName = "apellido";
            this.capellido.HeaderText = "APELLIDO";
            this.capellido.MinimumWidth = 6;
            this.capellido.Name = "capellido";
            this.capellido.ReadOnly = true;
            this.capellido.Width = 125;
            // 
            // cnrc
            // 
            this.cnrc.DataPropertyName = "nrc";
            this.cnrc.HeaderText = "NRC";
            this.cnrc.MinimumWidth = 6;
            this.cnrc.Name = "cnrc";
            this.cnrc.ReadOnly = true;
            this.cnrc.Width = 125;
            // 
            // cncedula
            // 
            this.cncedula.DataPropertyName = "ncedula";
            this.cncedula.HeaderText = "CEDULA";
            this.cncedula.MinimumWidth = 6;
            this.cncedula.Name = "cncedula";
            this.cncedula.ReadOnly = true;
            this.cncedula.Width = 125;
            // 
            // cfechaNacimiento
            // 
            this.cfechaNacimiento.DataPropertyName = "fechaNacimiento";
            this.cfechaNacimiento.HeaderText = "FECHA DE NACIMIENTO";
            this.cfechaNacimiento.MinimumWidth = 6;
            this.cfechaNacimiento.Name = "cfechaNacimiento";
            this.cfechaNacimiento.ReadOnly = true;
            this.cfechaNacimiento.Width = 125;
            // 
            // cdireccion
            // 
            this.cdireccion.DataPropertyName = "direccion";
            this.cdireccion.HeaderText = "DIRECCION";
            this.cdireccion.MinimumWidth = 6;
            this.cdireccion.Name = "cdireccion";
            this.cdireccion.ReadOnly = true;
            this.cdireccion.Width = 125;
            // 
            // cdepartamento
            // 
            this.cdepartamento.DataPropertyName = "departamento";
            this.cdepartamento.HeaderText = "DEPARTAMENTO";
            this.cdepartamento.MinimumWidth = 6;
            this.cdepartamento.Name = "cdepartamento";
            this.cdepartamento.ReadOnly = true;
            this.cdepartamento.Width = 125;
            // 
            // btnRefrescar
            // 
            this.btnRefrescar.Location = new System.Drawing.Point(831, 175);
            this.btnRefrescar.Name = "btnRefrescar";
            this.btnRefrescar.Size = new System.Drawing.Size(75, 23);
            this.btnRefrescar.TabIndex = 16;
            this.btnRefrescar.Text = "Refrescar";
            this.btnRefrescar.UseVisualStyleBackColor = true;
            this.btnRefrescar.Click += new System.EventHandler(this.btnRefrescar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(721, 175);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(75, 23);
            this.btnEliminar.TabIndex = 15;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.Location = new System.Drawing.Point(831, 99);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(75, 23);
            this.btnEditar.TabIndex = 14;
            this.btnEditar.Text = "Editar";
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnNuevo
            // 
            this.btnNuevo.Location = new System.Drawing.Point(721, 99);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(75, 23);
            this.btnNuevo.TabIndex = 13;
            this.btnNuevo.Text = "Agregar";
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // dtpFechaNacimiento
            // 
            this.dtpFechaNacimiento.Location = new System.Drawing.Point(507, 117);
            this.dtpFechaNacimiento.Name = "dtpFechaNacimiento";
            this.dtpFechaNacimiento.Size = new System.Drawing.Size(200, 22);
            this.dtpFechaNacimiento.TabIndex = 17;
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(265, 99);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(100, 22);
            this.txtNombre.TabIndex = 18;
            // 
            // txtApellido
            // 
            this.txtApellido.Location = new System.Drawing.Point(265, 139);
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.Size = new System.Drawing.Size(100, 22);
            this.txtApellido.TabIndex = 19;
            // 
            // txtNRC
            // 
            this.txtNRC.Location = new System.Drawing.Point(265, 186);
            this.txtNRC.Name = "txtNRC";
            this.txtNRC.Size = new System.Drawing.Size(100, 22);
            this.txtNRC.TabIndex = 20;
            // 
            // txtNCedula
            // 
            this.txtNCedula.Location = new System.Drawing.Point(390, 100);
            this.txtNCedula.Name = "txtNCedula";
            this.txtNCedula.Size = new System.Drawing.Size(100, 22);
            this.txtNCedula.TabIndex = 21;
            // 
            // txtDireccion
            // 
            this.txtDireccion.Location = new System.Drawing.Point(390, 139);
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(100, 22);
            this.txtDireccion.TabIndex = 22;
            // 
            // txtDepartamento
            // 
            this.txtDepartamento.Location = new System.Drawing.Point(390, 186);
            this.txtDepartamento.Name = "txtDepartamento";
            this.txtDepartamento.Size = new System.Drawing.Size(100, 22);
            this.txtDepartamento.TabIndex = 23;
            // 
            // catalogoclientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(987, 507);
            this.Controls.Add(this.txtDepartamento);
            this.Controls.Add(this.txtDireccion);
            this.Controls.Add(this.txtNCedula);
            this.Controls.Add(this.txtNRC);
            this.Controls.Add(this.txtApellido);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.dtpFechaNacimiento);
            this.Controls.Add(this.btnRefrescar);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "catalogoclientes";
            this.Text = "catalogoclientes";
            this.Load += new System.EventHandler(this.catalogoclientes_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        
        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panellogo;
        private System.Windows.Forms.DataGridView dataGridView1;
        private DataGridViewCellEventHandler dataGridView1_CellContentClick;
        private Button btnRefrescar;
        private Button btnEliminar;
        private Button btnEditar;
        private Button btnNuevo;
        private DateTimePicker dtpFechaNacimiento;
        private TextBox txtNombre;
        private TextBox txtApellido;
        private TextBox txtNRC;
        private TextBox txtNCedula;
        private TextBox txtDireccion;
        private TextBox txtDepartamento;
        private DataGridViewTextBoxColumn cnombre;
        private DataGridViewTextBoxColumn capellido;
        private DataGridViewTextBoxColumn cnrc;
        private DataGridViewTextBoxColumn cncedula;
        private DataGridViewTextBoxColumn cfechaNacimiento;
        private DataGridViewTextBoxColumn cdireccion;
        private DataGridViewTextBoxColumn cdepartamento;
    }
}