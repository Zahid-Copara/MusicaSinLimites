using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cliente
{
    public partial class Menu_Principal : Form
    {
        
        public static ConexionTcpCliente conexionTcp = new ConexionTcpCliente();
        public static string IPADDRESS = "127.0.0.1";
        public const int PORT = 1997;
        public Menu_Principal()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            conexionTcp.OnDataRecieved += MensajeRecibidoDesdeElServidor;

            if (conexionTcp.Connectar(IPADDRESS, PORT) == false)
            {
                MessageBox.Show("Error conectando con el servidor!");
                return;
            }
        }

        private Form formularioActivo = null;
        private void abrirFormularioHijo(Form formularioHijo)
        {
            if (formularioActivo != null)
            {
                formularioActivo.Close();
            }
            formularioActivo = formularioHijo;
            formularioHijo.TopLevel = false;
            formularioHijo.FormBorderStyle = FormBorderStyle.None;
            formularioHijo.Dock = DockStyle.Fill;
            panelFormularioHijo.Controls.Add(formularioHijo);
            panelFormularioHijo.Tag = formularioHijo;
            formularioHijo.BringToFront();
            formularioHijo.Show();
        }

        private void panelFormularioHijo_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnIngresarCancion_Click(object sender, EventArgs e)
        {
            abrirFormularioHijo(new Ingresar_Cancion());
        }
        private void MensajeRecibidoDesdeElServidor(string datos)
        {
            var paquete = new PaqueteCliente(datos);
            string comando = paquete.Comando;
            if (comando == "resultado")
            {
                string contenido = paquete.Contenido;

                // Invoke(new Action(() => label1.Text = string.Format("Respuesta: {0}", contenido)));
            }
        }

        private void btnModificarCancion_Click(object sender, EventArgs e)
        {
            abrirFormularioHijo(new Busqueda());
        }

        private void Menu_Principal_FormClosing(object sender, FormClosingEventArgs e)
        {

            Environment.Exit(0);


        }
    }
}
