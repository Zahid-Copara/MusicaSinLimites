
namespace Cliente
{
    partial class Busqueda
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.lblBuscarPor = new System.Windows.Forms.Label();
            this.txtParametro = new System.Windows.Forms.TextBox();
            this.rdbNombreCancion = new System.Windows.Forms.RadioButton();
            this.rdbClasificacion = new System.Windows.Forms.RadioButton();
            this.rdbNombreAlbum = new System.Windows.Forms.RadioButton();
            this.rdbAutor = new System.Windows.Forms.RadioButton();
            this.lblParametroBuscar = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnClasificar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSalir
            // 
            this.btnSalir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSalir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalir.Font = new System.Drawing.Font("SansSerif", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.btnSalir.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(39)))), ((int)(((byte)(86)))));
            this.btnSalir.Location = new System.Drawing.Point(13, 490);
            this.btnSalir.Margin = new System.Windows.Forms.Padding(4);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(100, 28);
            this.btnSalir.TabIndex = 17;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnEliminar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminar.Font = new System.Drawing.Font("SansSerif", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.btnEliminar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(39)))), ((int)(((byte)(86)))));
            this.btnEliminar.Location = new System.Drawing.Point(13, 454);
            this.btnEliminar.Margin = new System.Windows.Forms.Padding(4);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(100, 28);
            this.btnEliminar.TabIndex = 15;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnEditar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEditar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditar.Font = new System.Drawing.Font("SansSerif", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.btnEditar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(39)))), ((int)(((byte)(86)))));
            this.btnEditar.Location = new System.Drawing.Point(13, 382);
            this.btnEditar.Margin = new System.Windows.Forms.Padding(4);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(100, 28);
            this.btnEditar.TabIndex = 14;
            this.btnEditar.Text = "Editar";
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Coral;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.GridColor = System.Drawing.SystemColors.ActiveCaption;
            this.dataGridView1.Location = new System.Drawing.Point(121, 235);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dataGridView1.Size = new System.Drawing.Size(640, 283);
            this.dataGridView1.TabIndex = 13;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBuscar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscar.Font = new System.Drawing.Font("SansSerif", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.btnBuscar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(39)))), ((int)(((byte)(86)))));
            this.btnBuscar.Location = new System.Drawing.Point(661, 199);
            this.btnBuscar.Margin = new System.Windows.Forms.Padding(4);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(100, 28);
            this.btnBuscar.TabIndex = 12;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // lblBuscarPor
            // 
            this.lblBuscarPor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblBuscarPor.AutoSize = true;
            this.lblBuscarPor.Font = new System.Drawing.Font("SansSerif", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.lblBuscarPor.ForeColor = System.Drawing.Color.Snow;
            this.lblBuscarPor.Location = new System.Drawing.Point(13, 165);
            this.lblBuscarPor.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBuscarPor.Name = "lblBuscarPor";
            this.lblBuscarPor.Size = new System.Drawing.Size(131, 20);
            this.lblBuscarPor.TabIndex = 11;
            this.lblBuscarPor.Text = "Búsqueda por: ";
            // 
            // txtParametro
            // 
            this.txtParametro.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtParametro.Location = new System.Drawing.Point(339, 133);
            this.txtParametro.Margin = new System.Windows.Forms.Padding(4);
            this.txtParametro.Name = "txtParametro";
            this.txtParametro.Size = new System.Drawing.Size(423, 22);
            this.txtParametro.TabIndex = 9;
            this.txtParametro.TextChanged += new System.EventHandler(this.txtParametro_TextChanged);
            this.txtParametro.MouseUp += new System.Windows.Forms.MouseEventHandler(this.txtParametro_MouseUp);
            // 
            // rdbNombreCancion
            // 
            this.rdbNombreCancion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rdbNombreCancion.AutoSize = true;
            this.rdbNombreCancion.Font = new System.Drawing.Font("SansSerif", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.rdbNombreCancion.ForeColor = System.Drawing.Color.Snow;
            this.rdbNombreCancion.Location = new System.Drawing.Point(155, 164);
            this.rdbNombreCancion.Margin = new System.Windows.Forms.Padding(4);
            this.rdbNombreCancion.Name = "rdbNombreCancion";
            this.rdbNombreCancion.Size = new System.Drawing.Size(187, 24);
            this.rdbNombreCancion.TabIndex = 18;
            this.rdbNombreCancion.TabStop = true;
            this.rdbNombreCancion.Text = "Nombre de Canción";
            this.rdbNombreCancion.UseVisualStyleBackColor = true;
            this.rdbNombreCancion.CheckedChanged += new System.EventHandler(this.rdbNombreCancion_CheckedChanged);
            // 
            // rdbClasificacion
            // 
            this.rdbClasificacion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rdbClasificacion.AutoSize = true;
            this.rdbClasificacion.Font = new System.Drawing.Font("SansSerif", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.rdbClasificacion.ForeColor = System.Drawing.Color.MistyRose;
            this.rdbClasificacion.Location = new System.Drawing.Point(355, 165);
            this.rdbClasificacion.Margin = new System.Windows.Forms.Padding(4);
            this.rdbClasificacion.Name = "rdbClasificacion";
            this.rdbClasificacion.Size = new System.Drawing.Size(133, 24);
            this.rdbClasificacion.TabIndex = 19;
            this.rdbClasificacion.TabStop = true;
            this.rdbClasificacion.Text = "Clasificación";
            this.rdbClasificacion.UseVisualStyleBackColor = true;
            this.rdbClasificacion.CheckedChanged += new System.EventHandler(this.rdbClasificacion_CheckedChanged);
            // 
            // rdbNombreAlbum
            // 
            this.rdbNombreAlbum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rdbNombreAlbum.AutoSize = true;
            this.rdbNombreAlbum.Font = new System.Drawing.Font("SansSerif", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.rdbNombreAlbum.ForeColor = System.Drawing.Color.MistyRose;
            this.rdbNombreAlbum.Location = new System.Drawing.Point(506, 166);
            this.rdbNombreAlbum.Margin = new System.Windows.Forms.Padding(4);
            this.rdbNombreAlbum.Name = "rdbNombreAlbum";
            this.rdbNombreAlbum.Size = new System.Drawing.Size(171, 24);
            this.rdbNombreAlbum.TabIndex = 20;
            this.rdbNombreAlbum.TabStop = true;
            this.rdbNombreAlbum.Text = "Nombre de álbum";
            this.rdbNombreAlbum.UseVisualStyleBackColor = true;
            this.rdbNombreAlbum.CheckedChanged += new System.EventHandler(this.rdbNombreAlbum_CheckedChanged);
            // 
            // rdbAutor
            // 
            this.rdbAutor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rdbAutor.AutoSize = true;
            this.rdbAutor.Font = new System.Drawing.Font("SansSerif", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.rdbAutor.ForeColor = System.Drawing.Color.MistyRose;
            this.rdbAutor.Location = new System.Drawing.Point(689, 166);
            this.rdbAutor.Margin = new System.Windows.Forms.Padding(4);
            this.rdbAutor.Name = "rdbAutor";
            this.rdbAutor.Size = new System.Drawing.Size(75, 24);
            this.rdbAutor.TabIndex = 21;
            this.rdbAutor.TabStop = true;
            this.rdbAutor.Text = "Autor";
            this.rdbAutor.UseVisualStyleBackColor = true;
            this.rdbAutor.CheckedChanged += new System.EventHandler(this.rdbAutor_CheckedChanged);
            // 
            // lblParametroBuscar
            // 
            this.lblParametroBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblParametroBuscar.AutoSize = true;
            this.lblParametroBuscar.Font = new System.Drawing.Font("SansSerif", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.lblParametroBuscar.ForeColor = System.Drawing.Color.Snow;
            this.lblParametroBuscar.Location = new System.Drawing.Point(95, 134);
            this.lblParametroBuscar.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblParametroBuscar.Name = "lblParametroBuscar";
            this.lblParametroBuscar.Size = new System.Drawing.Size(0, 20);
            this.lblParametroBuscar.TabIndex = 22;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(813, 123);
            this.panel1.TabIndex = 23;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(192, 31);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(551, 69);
            this.label1.TabIndex = 0;
            this.label1.Text = "Música sin Límites ";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnClasificar
            // 
            this.btnClasificar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnClasificar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClasificar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClasificar.Font = new System.Drawing.Font("SansSerif", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.btnClasificar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(39)))), ((int)(((byte)(86)))));
            this.btnClasificar.Location = new System.Drawing.Point(13, 418);
            this.btnClasificar.Margin = new System.Windows.Forms.Padding(4);
            this.btnClasificar.Name = "btnClasificar";
            this.btnClasificar.Size = new System.Drawing.Size(100, 28);
            this.btnClasificar.TabIndex = 24;
            this.btnClasificar.Text = "Clasificar";
            this.btnClasificar.UseVisualStyleBackColor = true;
            this.btnClasificar.Click += new System.EventHandler(this.btnClasificar_Click);
            // 
            // Busqueda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(31)))), ((int)(((byte)(46)))));
            this.ClientSize = new System.Drawing.Size(813, 610);
            this.Controls.Add(this.btnClasificar);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblParametroBuscar);
            this.Controls.Add(this.rdbAutor);
            this.Controls.Add(this.rdbNombreAlbum);
            this.Controls.Add(this.rdbClasificacion);
            this.Controls.Add(this.rdbNombreCancion);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.lblBuscarPor);
            this.Controls.Add(this.txtParametro);
            this.ForeColor = System.Drawing.Color.Coral;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Busqueda";
            this.Text = "BÚSQUEDA";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ClienteForm2_FormClosing);
            this.Load += new System.EventHandler(this.ClienteForm2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Label lblBuscarPor;
        private System.Windows.Forms.TextBox txtParametro;
        private System.Windows.Forms.RadioButton rdbNombreCancion;
        private System.Windows.Forms.RadioButton rdbClasificacion;
        private System.Windows.Forms.RadioButton rdbNombreAlbum;
        private System.Windows.Forms.RadioButton rdbAutor;
        private System.Windows.Forms.Label lblParametroBuscar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnClasificar;
    }
}

