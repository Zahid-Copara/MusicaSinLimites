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

    public partial class Ingresar_Cancion : Form
    {

        public Ingresar_Cancion()
        {
            InitializeComponent();
            //Inicializacion del combobox
            List<string> ListaCalificacion = new List<string>();
            ListaCalificacion.Add("1");
            ListaCalificacion.Add("2");
            ListaCalificacion.Add("3");
            ListaCalificacion.Add("4");
            ListaCalificacion.Add("5");
            //Carga de la lista en el combobox
            cbCalificacion.DataSource = ListaCalificacion;
            Console.WriteLine(cbCalificacion.SelectedValue.ToString());
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void btnCancelarIngreso_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Ingresar_Cancion_Load(object sender, EventArgs e)
        {
            Menu_Principal.conexionTcp.OnDataRecieved += MensajeRecibidoDesdeElServidor;
        }

        private void btnGuardarCancion_Click(object sender, EventArgs e)
        {
            string posicion_numero = txtPosicion.Text;
            bool resultado_posicion = int.TryParse(posicion_numero, out _);
            if (resultado_posicion == false && (string.IsNullOrWhiteSpace(txtNombre.Text)) && (string.IsNullOrWhiteSpace(txtAlbum.Text)) && (string.IsNullOrWhiteSpace(txtAutor.Text)))
            {
                MessageBox.Show("Por favor verifique que no exista elementos en blanco!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if ((Menu_Principal.conexionTcp.TcpClient.Connected) && (resultado_posicion == false))
            {
                MessageBox.Show("Porfavor Ingrese un valor válido para Posicion");
            }
            else if ((Menu_Principal.conexionTcp.TcpClient.Connected) && (resultado_posicion == true))
            {
                var msgPack = new PaqueteCliente("crear", string.Format("{0},{1},{2},{3},{4}", txtNombre.Text, txtAlbum.Text, txtPosicion.Text, txtAutor.Text, cbCalificacion.SelectedValue.ToString()));
                Menu_Principal.conexionTcp.EnviarPaquete(msgPack);
                //MessageBox.Show("Cancion Creada Exitosamente!!", "Aviso", MessageBoxButtons.OK);
                this.Close();
            }
        }
        public void MensajeRecibidoDesdeElServidor(string datos)
        {
            //Se obtiene el comando del paquete recibido desde el servidor
            var paquete = new PaqueteCliente(datos);
            string comando = paquete.Comando;

            //COMANDO OK PARA LA CREACIÓN DE NUEVOS REGISTROS DE CANCIONES
            if (comando == "OK_CREAR")
            {
                string contenido = paquete.Contenido;
                MessageBox.Show(contenido);

            }
            //COMANDO NOOK PARA LA CREACIÓN DE NUEVOS REGISTROS DE CANCIONES
            if (comando == "NOOK_CREAR")
            {
                string contenido = paquete.Contenido;
                MessageBox.Show(contenido);

            }
            if (comando == "NOOK_CREAR_2")
            {
                string contenido = paquete.Contenido;
                MessageBox.Show(contenido);

            }

        }
    }
}
