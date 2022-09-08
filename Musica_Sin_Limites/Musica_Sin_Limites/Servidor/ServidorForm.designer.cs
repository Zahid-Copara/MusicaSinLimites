
namespace Servidor
{
    partial class ServidorForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblClienteConectado = new System.Windows.Forms.Label();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.dgServidor = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgServidor)).BeginInit();
            this.SuspendLayout();
            // 
            // lblClienteConectado
            // 
            this.lblClienteConectado.AutoSize = true;
            this.lblClienteConectado.Font = new System.Drawing.Font("SansSerif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.lblClienteConectado.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.lblClienteConectado.Location = new System.Drawing.Point(29, 122);
            this.lblClienteConectado.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblClienteConectado.Name = "lblClienteConectado";
            this.lblClienteConectado.Size = new System.Drawing.Size(292, 31);
            this.lblClienteConectado.TabIndex = 2;
            this.lblClienteConectado.Text = "Clientes conectados: ";
            // 
            // btnActualizar
            // 
            this.btnActualizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnActualizar.Font = new System.Drawing.Font("SansSerif", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.btnActualizar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(39)))), ((int)(((byte)(86)))));
            this.btnActualizar.Location = new System.Drawing.Point(867, 144);
            this.btnActualizar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(127, 32);
            this.btnActualizar.TabIndex = 3;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.UseVisualStyleBackColor = true;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // dgServidor
            // 
            this.dgServidor.AllowUserToAddRows = false;
            this.dgServidor.AllowUserToDeleteRows = false;
            this.dgServidor.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgServidor.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgServidor.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.dgServidor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgServidor.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.InfoText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgServidor.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgServidor.Location = new System.Drawing.Point(36, 183);
            this.dgServidor.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgServidor.Name = "dgServidor";
            this.dgServidor.ReadOnly = true;
            this.dgServidor.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            this.dgServidor.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgServidor.Size = new System.Drawing.Size(983, 247);
            this.dgServidor.TabIndex = 4;
            // 
            // ServidorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(31)))), ((int)(((byte)(46)))));
            this.ClientSize = new System.Drawing.Size(1067, 486);
            this.Controls.Add(this.dgServidor);
            this.Controls.Add(this.btnActualizar);
            this.Controls.Add(this.lblClienteConectado);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ServidorForm";
            this.Text = "SERVIDOR";
            this.Load += new System.EventHandler(this.ServidorForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgServidor)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblClienteConectado;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.DataGridView dgServidor;
    }
}

