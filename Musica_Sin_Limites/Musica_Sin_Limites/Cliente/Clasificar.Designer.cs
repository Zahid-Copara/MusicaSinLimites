
namespace Cliente
{
    partial class Clasificar
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.cbCalificacion = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnCancelarClasificacion = new System.Windows.Forms.Button();
            this.btnClasificar = new System.Windows.Forms.Button();
            this.lblNombre = new System.Windows.Forms.Label();
            this.lblAlbum = new System.Windows.Forms.Label();
            this.lblPosicion = new System.Windows.Forms.Label();
            this.lblAutor = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblID = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel1.Controls.Add(this.lblID);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.lblAutor);
            this.panel1.Controls.Add(this.lblPosicion);
            this.panel1.Controls.Add(this.lblAlbum);
            this.panel1.Controls.Add(this.lblNombre);
            this.panel1.Controls.Add(this.cbCalificacion);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Location = new System.Drawing.Point(69, 11);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(663, 302);
            this.panel1.TabIndex = 18;
            // 
            // cbCalificacion
            // 
            this.cbCalificacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCalificacion.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.cbCalificacion.Location = new System.Drawing.Point(180, 267);
            this.cbCalificacion.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbCalificacion.Name = "cbCalificacion";
            this.cbCalificacion.Size = new System.Drawing.Size(361, 24);
            this.cbCalificacion.TabIndex = 14;
            this.cbCalificacion.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("SansSerif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(39)))), ((int)(((byte)(86)))));
            this.label1.Location = new System.Drawing.Point(89, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "Nombre:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("SansSerif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(39)))), ((int)(((byte)(86)))));
            this.label2.Location = new System.Drawing.Point(100, 123);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "Album:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("SansSerif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(39)))), ((int)(((byte)(86)))));
            this.label3.Location = new System.Drawing.Point(83, 174);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 20);
            this.label3.TabIndex = 7;
            this.label3.Text = "Posición:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("SansSerif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(39)))), ((int)(((byte)(86)))));
            this.label5.Location = new System.Drawing.Point(46, 271);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(118, 20);
            this.label5.TabIndex = 9;
            this.label5.Text = "Clasificación:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("SansSerif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(39)))), ((int)(((byte)(86)))));
            this.label4.Location = new System.Drawing.Point(107, 222);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 20);
            this.label4.TabIndex = 8;
            this.label4.Text = "Autor:";
            // 
            // btnCancelarClasificacion
            // 
            this.btnCancelarClasificacion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelarClasificacion.AutoSize = true;
            this.btnCancelarClasificacion.BackColor = System.Drawing.Color.Transparent;
            this.btnCancelarClasificacion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelarClasificacion.Font = new System.Drawing.Font("SansSerif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.btnCancelarClasificacion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(39)))), ((int)(((byte)(86)))));
            this.btnCancelarClasificacion.Location = new System.Drawing.Point(624, 342);
            this.btnCancelarClasificacion.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCancelarClasificacion.Name = "btnCancelarClasificacion";
            this.btnCancelarClasificacion.Size = new System.Drawing.Size(107, 34);
            this.btnCancelarClasificacion.TabIndex = 17;
            this.btnCancelarClasificacion.Text = "Cancelar";
            this.btnCancelarClasificacion.UseVisualStyleBackColor = false;
            this.btnCancelarClasificacion.Click += new System.EventHandler(this.btnCancelarClasificacion_Click);
            // 
            // btnClasificar
            // 
            this.btnClasificar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClasificar.AutoSize = true;
            this.btnClasificar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClasificar.Font = new System.Drawing.Font("SansSerif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.btnClasificar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(39)))), ((int)(((byte)(86)))));
            this.btnClasificar.Location = new System.Drawing.Point(482, 342);
            this.btnClasificar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnClasificar.Name = "btnClasificar";
            this.btnClasificar.Size = new System.Drawing.Size(117, 34);
            this.btnClasificar.TabIndex = 16;
            this.btnClasificar.Text = "Clasificar";
            this.btnClasificar.UseVisualStyleBackColor = true;
            this.btnClasificar.Click += new System.EventHandler(this.btnClasificar_Click);
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Font = new System.Drawing.Font("SansSerif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.lblNombre.ForeColor = System.Drawing.Color.White;
            this.lblNombre.Location = new System.Drawing.Point(176, 72);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(0, 20);
            this.lblNombre.TabIndex = 15;
            // 
            // lblAlbum
            // 
            this.lblAlbum.AutoSize = true;
            this.lblAlbum.Font = new System.Drawing.Font("SansSerif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.lblAlbum.ForeColor = System.Drawing.Color.White;
            this.lblAlbum.Location = new System.Drawing.Point(179, 123);
            this.lblAlbum.Name = "lblAlbum";
            this.lblAlbum.Size = new System.Drawing.Size(0, 20);
            this.lblAlbum.TabIndex = 16;
            // 
            // lblPosicion
            // 
            this.lblPosicion.AutoSize = true;
            this.lblPosicion.Font = new System.Drawing.Font("SansSerif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.lblPosicion.ForeColor = System.Drawing.Color.White;
            this.lblPosicion.Location = new System.Drawing.Point(179, 174);
            this.lblPosicion.Name = "lblPosicion";
            this.lblPosicion.Size = new System.Drawing.Size(0, 20);
            this.lblPosicion.TabIndex = 17;
            // 
            // lblAutor
            // 
            this.lblAutor.AutoSize = true;
            this.lblAutor.Font = new System.Drawing.Font("SansSerif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.lblAutor.ForeColor = System.Drawing.Color.White;
            this.lblAutor.Location = new System.Drawing.Point(179, 222);
            this.lblAutor.Name = "lblAutor";
            this.lblAutor.Size = new System.Drawing.Size(0, 20);
            this.lblAutor.TabIndex = 18;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("SansSerif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(39)))), ((int)(((byte)(86)))));
            this.label6.Location = new System.Drawing.Point(132, 36);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(32, 20);
            this.label6.TabIndex = 19;
            this.label6.Text = "ID:";
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Font = new System.Drawing.Font("SansSerif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.lblID.ForeColor = System.Drawing.Color.White;
            this.lblID.Location = new System.Drawing.Point(176, 36);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(0, 20);
            this.lblID.TabIndex = 20;
            // 
            // Clasificar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(31)))), ((int)(((byte)(46)))));
            this.ClientSize = new System.Drawing.Size(801, 405);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnCancelarClasificacion);
            this.Controls.Add(this.btnClasificar);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Clasificar";
            this.Text = "Clasificar";
            this.Load += new System.EventHandler(this.Clasificar_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cbCalificacion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnCancelarClasificacion;
        private System.Windows.Forms.Button btnClasificar;
        private System.Windows.Forms.Label lblAutor;
        private System.Windows.Forms.Label lblPosicion;
        private System.Windows.Forms.Label lblAlbum;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.Label label6;
    }
}