
namespace Cliente
{
    partial class Menu_Principal
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Menu_Principal));
            this.panelMenuLateral = new System.Windows.Forms.Panel();
            this.btnModificarCancion = new System.Windows.Forms.Button();
            this.btnIngresarCancion = new System.Windows.Forms.Button();
            this.panelLogo = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.panelFormularioHijo = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panelMenuLateral.SuspendLayout();
            this.panelLogo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panelFormularioHijo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelMenuLateral
            // 
            this.panelMenuLateral.AutoScroll = true;
            this.panelMenuLateral.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(7)))), ((int)(((byte)(11)))));
            this.panelMenuLateral.Controls.Add(this.btnModificarCancion);
            this.panelMenuLateral.Controls.Add(this.btnIngresarCancion);
            this.panelMenuLateral.Controls.Add(this.panelLogo);
            this.panelMenuLateral.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelMenuLateral.Location = new System.Drawing.Point(0, 0);
            this.panelMenuLateral.Name = "panelMenuLateral";
            this.panelMenuLateral.Size = new System.Drawing.Size(250, 610);
            this.panelMenuLateral.TabIndex = 0;
            // 
            // btnModificarCancion
            // 
            this.btnModificarCancion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(7)))), ((int)(((byte)(11)))));
            this.btnModificarCancion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnModificarCancion.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnModificarCancion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnModificarCancion.Font = new System.Drawing.Font("SansSerif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.btnModificarCancion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(39)))), ((int)(((byte)(86)))));
            this.btnModificarCancion.Location = new System.Drawing.Point(0, 145);
            this.btnModificarCancion.Name = "btnModificarCancion";
            this.btnModificarCancion.Size = new System.Drawing.Size(250, 45);
            this.btnModificarCancion.TabIndex = 2;
            this.btnModificarCancion.Text = "Búsqueda de Canciones";
            this.btnModificarCancion.UseVisualStyleBackColor = false;
            this.btnModificarCancion.Click += new System.EventHandler(this.btnModificarCancion_Click);
            // 
            // btnIngresarCancion
            // 
            this.btnIngresarCancion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(7)))), ((int)(((byte)(11)))));
            this.btnIngresarCancion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnIngresarCancion.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnIngresarCancion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIngresarCancion.Font = new System.Drawing.Font("SansSerif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.btnIngresarCancion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(39)))), ((int)(((byte)(86)))));
            this.btnIngresarCancion.Location = new System.Drawing.Point(0, 100);
            this.btnIngresarCancion.Name = "btnIngresarCancion";
            this.btnIngresarCancion.Size = new System.Drawing.Size(250, 45);
            this.btnIngresarCancion.TabIndex = 1;
            this.btnIngresarCancion.Text = "Ingresar Canción";
            this.btnIngresarCancion.UseVisualStyleBackColor = false;
            this.btnIngresarCancion.Click += new System.EventHandler(this.btnIngresarCancion_Click);
            // 
            // panelLogo
            // 
            this.panelLogo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(31)))), ((int)(((byte)(46)))));
            this.panelLogo.Controls.Add(this.pictureBox2);
            this.panelLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelLogo.Location = new System.Drawing.Point(0, 0);
            this.panelLogo.Name = "panelLogo";
            this.panelLogo.Size = new System.Drawing.Size(250, 100);
            this.panelLogo.TabIndex = 0;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(72, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(100, 100);
            this.pictureBox2.TabIndex = 0;
            this.pictureBox2.TabStop = false;
            // 
            // panelFormularioHijo
            // 
            this.panelFormularioHijo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelFormularioHijo.Controls.Add(this.pictureBox1);
            this.panelFormularioHijo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelFormularioHijo.Location = new System.Drawing.Point(250, 0);
            this.panelFormularioHijo.Name = "panelFormularioHijo";
            this.panelFormularioHijo.Size = new System.Drawing.Size(814, 610);
            this.panelFormularioHijo.TabIndex = 1;
            this.panelFormularioHijo.Paint += new System.Windows.Forms.PaintEventHandler(this.panelFormularioHijo_Paint);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(211, 118);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(396, 386);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // Menu_Principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(31)))), ((int)(((byte)(46)))));
            this.ClientSize = new System.Drawing.Size(1064, 610);
            this.Controls.Add(this.panelFormularioHijo);
            this.Controls.Add(this.panelMenuLateral);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Menu_Principal";
            this.Text = "MENÚ PRINCIPAL";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Menu_Principal_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panelMenuLateral.ResumeLayout(false);
            this.panelLogo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panelFormularioHijo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMenuLateral;
        private System.Windows.Forms.Button btnModificarCancion;
        private System.Windows.Forms.Button btnIngresarCancion;
        private System.Windows.Forms.Panel panelLogo;
        private System.Windows.Forms.Panel panelFormularioHijo;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}

