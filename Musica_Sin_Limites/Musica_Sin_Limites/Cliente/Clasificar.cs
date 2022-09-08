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
    public partial class Clasificar : Form
    {
        //Se declaran variables publicas para obtener los datos del formulario previo
        public int ID_cancion;
        public string Nombre;
        public string Album;
        public int Posicion;
        public string Autor;

        public Clasificar()
        {
            InitializeComponent();
        }
        public Clasificar(int id, string nombre, string album, int posicion, string autor)
        {
            InitializeComponent();
            //Se guardan los datos en las variables publicas
            this.ID_cancion = id;
            this.Nombre = nombre;
            this.Album = album;
            this.Posicion = posicion;
            this.Autor = autor;
            //Generacion de la lista del combobox
            List<string> ListaCalificacion = new List<string>();
            ListaCalificacion.Add("1");
            ListaCalificacion.Add("2");
            ListaCalificacion.Add("3");
            ListaCalificacion.Add("4");
            ListaCalificacion.Add("5");
            //Carga de la lista en el combobox
            cbCalificacion.DataSource = ListaCalificacion;
            //Carga de los label para saber la informacion de la cancion 
            lblID.Text = ID_cancion.ToString();
            lblNombre.Text = Nombre;
            lblAutor.Text = Autor;
            lblAlbum.Text = Album;
            lblPosicion.Text = Posicion.ToString();
        }

        private void Clasificar_Load(object sender, EventArgs e)
        {
            Menu_Principal.conexionTcp.OnDataRecieved += MensajeRecibidoDesdeElServidor;
        }

        private void btnCancelarClasificacion_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClasificar_Click(object sender, EventArgs e)
        {
            var msgPack = new PaqueteCliente("actualizar_clasificacion", string.Format("{0},{1}", cbCalificacion.SelectedValue.ToString(), ID_cancion));
            Menu_Principal.conexionTcp.EnviarPaquete(msgPack);
            //MessageBox.Show("Cancion Clasificada Exitosamente!!", "Aviso", MessageBoxButtons.OK);
            this.Close();
        }

        public void MensajeRecibidoDesdeElServidor(string datos)
        {
            //Se obtiene el comando del paquete recibido desde el servidor
            var paquete = new PaqueteCliente(datos);
            string comando = paquete.Comando;

            //COMANDO OK PARA LA CREACIÓN DE NUEVOS REGISTROS DE CANCIONES
            if (comando == "OK_ACTUALIZAR_CANCION")
            {
                string contenido = paquete.Contenido;
                MessageBox.Show(contenido);

            }
        }
    }
}
