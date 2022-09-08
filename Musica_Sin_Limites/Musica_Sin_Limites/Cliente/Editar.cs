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
    public partial class Editar : Form
    {
        //Se declaran variables publicas para obtener los datos del formulario previo
        public int ID_cancion;
        public string Nombre;
        public string Album;
        public int Posicion;
        public string Autor;


        public Editar(int id, string nombre, string album, int posicion, string autor)
        {
            InitializeComponent();
            this.ID_cancion = id;
            //Se guardan los datos en las variables publicas
            this.ID_cancion = id;
            this.Nombre = nombre;
            this.Album = album;
            this.Posicion = posicion;
            this.Autor = autor;
            //Se guarda al inicio a la cancion
            lblID.Text = ID_cancion.ToString();
            txtNombre.Text = Nombre;
            txtAlbum.Text = Album;
            txtPosicion.Text = Posicion.ToString();
            txtAutor.Text = Autor;            

        }


        public Editar()
        {
            InitializeComponent();

        }

        private void btnCancelarActualizacion_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnActualizarCancion_Click(object sender, EventArgs e)
        {
            string posicion_numero = txtPosicion.Text;
            bool resultado_posicion = int.TryParse(posicion_numero, out _);
            if (resultado_posicion == false && (string.IsNullOrWhiteSpace(txtNombre.Text)) && (string.IsNullOrWhiteSpace(txtAlbum.Text)) && (string.IsNullOrWhiteSpace(txtAutor.Text)))
            {
                MessageBox.Show("Por favor verifique que no exista elementos en blanco!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if ((Menu_Principal.conexionTcp.TcpClient.Connected) && (resultado_posicion == false))
            {
                MessageBox.Show("Porfavor Ingrese un valor valido para Posicion");
            }
            else if ((Menu_Principal.conexionTcp.TcpClient.Connected) && (resultado_posicion == true))
            {
                var msgPack = new PaqueteCliente("actualizar", string.Format("{0},{1},{2},{3},{4}", txtNombre.Text, txtAlbum.Text, txtPosicion.Text, txtAutor.Text, ID_cancion));
                Menu_Principal.conexionTcp.EnviarPaquete(msgPack);
                Console.WriteLine(msgPack);
                //MessageBox.Show("Cancion Actualizada Exitosamente!!", "Aviso", MessageBoxButtons.OK);
                this.Close();
              
            }
        }

        private void Editar_Load(object sender, EventArgs e)
        {
            Menu_Principal.conexionTcp.OnDataRecieved += MensajeRecibidoDesdeElServidor;
        }
        public void MensajeRecibidoDesdeElServidor(string datos)
        {
            //Se obtiene el comando del paquete recibido desde el servidor
            var paquete = new PaqueteCliente(datos);
            string comando = paquete.Comando;

            //COMANDO OK PARA LA CREACIÓN DE NUEVOS REGISTROS DE CANCIONES
            if (comando == "OK_ACTUALIZAR")
            {
                string contenido = paquete.Contenido;
                MessageBox.Show(contenido);

            }
            //COMANDO NOOK PARA LA CREACIÓN DE NUEVOS REGISTROS DE CANCIONES
            if (comando == "NOOK_ACTUALIZAR")
            {
                string contenido = paquete.Contenido;
                MessageBox.Show(contenido);

            }

        }
    }
}
