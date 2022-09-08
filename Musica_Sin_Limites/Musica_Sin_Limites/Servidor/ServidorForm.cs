using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using BaseDeDatos;
using Entidad;
namespace Servidor

{
   
    public partial class ServidorForm : Form
    {
        //manejador de base de datos
        ManejadorDB d = new ManejadorDB();
        //Delegado que al detectar que un cliente se conectó o desconectó llama al método
        //ClientCarrier pasándole la conexión de dicho cliente
        public delegate void ClientCarrier(ConexionTcpServidor conexionTcp);
        public event ClientCarrier OnClientConnected;
        public event ClientCarrier OnClientDisconnected;
        //Cuando el evento de recibir datos ocurra se pasará la conexión y datos al método DataRecieved
        public delegate void DataRecieved(ConexionTcpServidor conexionTcp, string data);
        public event DataRecieved OnDataRecieved;
        
        private TcpListener _tcpListener;
        private Thread _acceptThread;
        //Lista de clientes conectados
        private List<ConexionTcpServidor> connectedClients = new List<ConexionTcpServidor>();

        public ServidorForm()
        {
            InitializeComponent();
            //Se llena el datagrid con el registro de canciones en la base de datos
            dgServidor.DataSource = d.ListarCancion();
        }

        private void ServidorForm_Load(object sender, EventArgs e)
        {
            //Cuando se reciben datos se concatena al método mensaje recibido desde el cliente
            //Cuando se conecta o desconecta un cliente se aumenta en 1, permitiendo asi llevar un registro 
            OnDataRecieved += MensajeRecibidoDesdeElCliente;
            OnClientConnected += ConexionRecibida;
            OnClientDisconnected += ConexionCerrada;
            //Metodo escuchar clientes recibe el puerto e IP con la que se realizará la conexión
            EscucharClientes("127.0.0.1", 1997);
        }
        //Metodo para interpretar los mensajes que llegan desde el cliente y responderlos respectivamente
        private void MensajeRecibidoDesdeElCliente(ConexionTcpServidor conexionTcp, string datos)
        {
            var paquete = new PaqueteServidor(datos);
            //Se obtiene el comando a interpretar del paquete recibido
            string comando = paquete.Comando;
            //CREAR: Se almacenan los datos recibidos del cliente en un objeto de tipo Cancion para luego guardarlo en la base de datos
            if (comando == "crear")
            {
                string contenido = paquete.Contenido;
                List<string> valores = MapaServidor.Deserializar(contenido);
                Cancion c = new Cancion(valores[0], valores[1], Int32.Parse(valores[2]), valores[3], Int32.Parse(valores[4]));
                //VALIDACIONES:
                //No se permite crear canciones con nombre, album y autor repetido
                //No se permite crear una cancion que tenga la misma posición, album y autor
                if (d.CancionRepetida(valores[0]) && d.AlbumRepetido(valores[1]) && d.AutorRepetido(valores[3]))
                {
                    var msgPackNOOK = new PaqueteServidor("NOOK_CREAR", "La canción que intenta añadir ya existe");
                    conexionTcp.EnviarPaquete(msgPackNOOK);
                }else if (d.AlbumRepetido(valores[1]) && d.AutorRepetido(valores[3]) && d.PosicionEnAlbumOcupada(Int32.Parse(valores[2])))
                {
                    var msgPackNOOK2 = new PaqueteServidor("NOOK_CREAR_2", "Ya existe una canción de este álbum y este autor en la posición especificada.");
                    conexionTcp.EnviarPaquete(msgPackNOOK2);

                }
                //Si no es una canción repetida se añade a la base de datos
                else
                {
                    try
                    {
                        d.CrearCancion(c);
                        //OK: se envía información al cliente del resultado de su pedido
                        var msgPackOK = new PaqueteServidor("OK_CREAR", "Se ha añadido correctamente una nueva canción");
                        conexionTcp.EnviarPaquete(msgPackOK);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);
                    }
                }

            }
            //ELIMINAR: 
            //Con el id recibido del cliente, se realiza la búsqueda de esta canción en la base de datos y se la elimina
            if (comando == "eliminar_cancion")
            {
                string contenido = paquete.Contenido;
                List<string> valores = MapaServidor.Deserializar(contenido);
                int ID = Int32.Parse(valores[0]);
                try
                {
                    d.EliminarCancion(ID);
                    //OK: Envía la confirmación de la realización de la petición en caso de no ocurrir errores
                    var msgPack = new PaqueteServidor("OK_ELIMINAR","Se ha eliminado exitosamente la canción");
                    conexionTcp.EnviarPaquete(msgPack);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    //NOOK: Envía la información del error ocurrido en la eliminación de la canción
                    var msgPack = new PaqueteServidor("NOOK_ELIMINAR", "No se ha podido eliminar la canción seleccionada");
                    conexionTcp.EnviarPaquete(msgPack);
                }

            }
            //ACTUALIZAR:
            /*
             * Para actualizar se hace uso del procedimiento almacenado que esta implementado en la base de datos
             * ya que se utiliza el comando LIKE en actualizar para poder actualizar dependiendo del parametro que se envia 
             * desde el cliente.
             * Se implementa el NOOK para mostrar un mensaje de que no se logro realizar la actualizacion. Y tambien un OK que permita mostrar 
             * un mensaje de que la actualizacion se realizó correctamente
             */
            if (comando == "actualizar")
            {
                string contenido = paquete.Contenido;
                //Se almacena el contenido en una lista
                List<string> valores = MapaServidor.Deserializar(contenido);
                if (d.CancionRepetida(valores[0]) && d.AlbumRepetido(valores[1]) && d.AutorRepetido(valores[3]))
                {
                    var msgPackNOOK = new PaqueteServidor("NOOK_ACTUALIZAR", "No se ha actualizado la canción puesto que los nuevos datos coinciden con una canción existente");
                    conexionTcp.EnviarPaquete(msgPackNOOK);
                }
                else
                {
                    string cadena = string.Format("exec dbo.ActualizarTabla '{0}','{1}',{2},'{3}',{4}", valores[0], valores[1], Int32.Parse(valores[2]), valores[3],
                        Int32.Parse(valores[4]));
                    var msgPackOK = new PaqueteServidor("OK_ACTUALIZAR", "La canción se ha actualizado exitosamente");
                    conexionTcp.EnviarPaquete(msgPackOK);
                    try
                    {
                        //Comando SQL
                        SqlCommand sqlCommand = new SqlCommand(cadena, d.AbrirConexion());
                        SqlDataReader lector = sqlCommand.ExecuteReader();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);
                    }
                    d.CerrarConexion();
                }

            }

            //Actualizar Clasificacion:
            //Con este metodo se actualiza la clasificacion de una cancion
            if (comando == "actualizar_clasificacion")
            {
                string contenido = paquete.Contenido;
                //Se almacena el contenido en una lista
                List<string> valores = MapaServidor.Deserializar(contenido);
                string cadena = string.Format("exec dbo.ActualizarClasificacion {0},{1}", Int32.Parse(valores[0]), Int32.Parse(valores[1]));
                var msgPackOK = new PaqueteServidor("OK_ACTUALIZAR_CANCION", "Se ha calificado la cancion correctamente");
                conexionTcp.EnviarPaquete(msgPackOK);
                try
                {
                    //Comando SQL
                    SqlCommand sqlCommand = new SqlCommand(cadena, d.AbrirConexion());
                    SqlDataReader lector = sqlCommand.ExecuteReader();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
                d.CerrarConexion();
            }

                //LISTAR POR:
                //Lista las canciones de acuerdo a los parámetros de búsqueda que envía el cliente
                if (comando == "LISTAR_POR_CANCION")
            {
                string contenido = paquete.Contenido;
                List<string> valores = MapaServidor.Deserializar(contenido);
                //Declaro un objeto canción para guardar las lecturas de la base de datos en sus atributos
                Cancion c = new Cancion();
                //VALIDACIONES:
                //Si el parámetro utilizado en la búsqueda de la canción  existe en la base de datos entonces
                //Se leen los datos con un while y se los guarda en los atributos del objeto canción creado para luego enviarlos
                // en un paquete al cliente. Esto se realiza con todos los comandos de tipo LISTAR_POR con el comando adecuado 
                //para cada uno de ellos acorde a los parámetros de búsqueda enviados por el cliente.
                if (d.ValidarBusquedaPorCancion(valores[0]))
                {
                    //comando SQL que se ejecutará
                    string nquery = "SELECT * FROM tblRegistroCanciones where cancion LIKE '%" + valores[0] + "%'";
                    try
                    {
                        SqlCommand sqlCommand = new SqlCommand(nquery, d.AbrirConexion());
                        SqlDataReader lector = sqlCommand.ExecuteReader();
                        while (lector.Read())
                        {
                            //Se almacenan los datos leidos de las diferentes columnas en las variables
                            c.IdCancion = Int32.Parse(lector["idCancion"].ToString());
                            c.NCancion = lector["cancion"].ToString();
                            c.Album = lector["album"].ToString();
                            c.Posicion_en_album = Int32.Parse(lector["posicion_en_album"].ToString());
                            c.Autor = lector["autor"].ToString();
                            c.Clasificacion = Int32.Parse(lector["clasificacion"].ToString());

                            System.Diagnostics.Debug.WriteLine(lector["cancion"].ToString());
                            //Se envían los paquetes respuesta al cliente con la información solicitada
                            var msgPack = new PaqueteServidor("RESPUESTA_LISTAR_POR_",
                                string.Format("{0},{1},{2},{3},{4},{5}",
                                c.IdCancion, c.NCancion, c.Album, c.Posicion_en_album, c.Autor, c.Clasificacion));
                            conexionTcp.EnviarPaquete(msgPack);
                        }
                        d.CerrarConexion();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error: " + ex.Message);
                    }
                }
                else if (d.ValidarBusquedaPorCancion(valores[0]) == false)
                {
                    //Si el valor a buscarse no existe en la base de datos se envía el NOOK con los detalles.
                    var msgPackNOOK = new PaqueteServidor("NOOK_LISTAR_POR_CANCION", "No se ha encontrado una canción con nombres similares");
                    conexionTcp.EnviarPaquete(msgPackNOOK);
                }
            }
          
            if (comando == "LISTAR_POR_ALBUM")
            {
                string contenido = paquete.Contenido;
                List<string> valores = MapaServidor.Deserializar(contenido);  
                Cancion c = new Cancion();
                if (d.ValidarBusquedaPorAlbum(valores[0]))
                {
                    string nquery = "SELECT * FROM tblRegistroCanciones where album LIKE '%" + valores[0] + "%'";
                    try
                    {
                        SqlCommand sqlCommand = new SqlCommand(nquery, d.AbrirConexion());
                        SqlDataReader lector = sqlCommand.ExecuteReader();
                        while (lector.Read())
                        {
                            c.IdCancion = Int32.Parse(lector["idCancion"].ToString());
                            c.NCancion = lector["cancion"].ToString();
                            c.Album = lector["album"].ToString();
                            c.Posicion_en_album = Int32.Parse(lector["posicion_en_album"].ToString());
                            c.Autor = lector["autor"].ToString();
                            c.Clasificacion = Int32.Parse(lector["clasificacion"].ToString());
                            //System.Diagnostics.Debug.WriteLine(lector["cancion"].ToString());
                            var msgPack = new PaqueteServidor("RESPUESTA_LISTAR_POR_",
                                string.Format("{0},{1},{2},{3},{4},{5}",
                                c.IdCancion, c.NCancion, c.Album, c.Posicion_en_album, c.Autor, c.Clasificacion));
                            conexionTcp.EnviarPaquete(msgPack);
                        }
                        d.CerrarConexion();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error: " + ex.Message);
                    }
                }
                else if (d.ValidarBusquedaPorAlbum(valores[0]) == false)
                {
                    var msgPackNOOK = new PaqueteServidor("NOOK_LISTAR_POR_ALBUM", "No se ha encontrado un álbum con nombres similares");
                    conexionTcp.EnviarPaquete(msgPackNOOK);
                }
            }
            if (comando == "LISTAR_POR_AUTOR")
            {             
                string contenido = paquete.Contenido;            
                List<string> valores = MapaServidor.Deserializar(contenido);             
                Cancion c = new Cancion();
                if (d.ValidarBusquedaPorAutor(valores[0]))
                {
                    string nquery = "SELECT * FROM tblRegistroCanciones where autor LIKE '%" + valores[0] + "%'";
                    try
                    {                     
                        SqlCommand sqlCommand = new SqlCommand(nquery, d.AbrirConexion());
                        SqlDataReader lector = sqlCommand.ExecuteReader();
                        while (lector.Read())
                        {
                            c.IdCancion = Int32.Parse(lector["idCancion"].ToString());
                            c.NCancion = lector["cancion"].ToString();
                            c.Album = lector["album"].ToString();
                            c.Posicion_en_album = Int32.Parse(lector["posicion_en_album"].ToString());
                            c.Autor = lector["autor"].ToString();
                            c.Clasificacion = Int32.Parse(lector["clasificacion"].ToString());
                            //System.Diagnostics.Debug.WriteLine(lector["cancion"].ToString());
                            var msgPack = new PaqueteServidor("RESPUESTA_LISTAR_POR_",
                                string.Format("{0},{1},{2},{3},{4},{5}",
                                c.IdCancion, c.NCancion, c.Album, c.Posicion_en_album, c.Autor, c.Clasificacion));
                            conexionTcp.EnviarPaquete(msgPack);
                        }
                        d.CerrarConexion();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error: " + ex.Message);
                    }
                }
                else if (d.ValidarBusquedaPorAutor(valores[0]) == false)
                {
                    var msgPackNOOK = new PaqueteServidor("NOOK_LISTAR_POR_AUTOR", "No se ha encontrado un autor con nombres similares");
                    conexionTcp.EnviarPaquete(msgPackNOOK);
                }
            }
            if (comando == "LISTAR_POR_CLASIFICACION")
            {
                string contenido = paquete.Contenido;
                List<string> valores = MapaServidor.Deserializar(contenido);
                Cancion c = new Cancion(); 
                int clasificacion = Int32.Parse(valores[0]);
                if (d.ValidarBusquedaPorClasificacion(clasificacion))
                {
                    string nquery = "SELECT * FROM tblRegistroCanciones where clasificacion =" + clasificacion + "";
                    try
                    {
                        SqlCommand sqlCommand = new SqlCommand(nquery, d.AbrirConexion());
                        SqlDataReader lector = sqlCommand.ExecuteReader();
                        while (lector.Read())
                        {
                            c.IdCancion = Int32.Parse(lector["idCancion"].ToString());
                            c.NCancion = lector["cancion"].ToString();
                            c.Album = lector["album"].ToString();
                            c.Posicion_en_album = Int32.Parse(lector["posicion_en_album"].ToString());
                            c.Autor = lector["autor"].ToString();
                            c.Clasificacion = Int32.Parse(lector["clasificacion"].ToString());
                            //System.Diagnostics.Debug.WriteLine(lector["cancion"].ToString());
                            var msgPack = new PaqueteServidor("RESPUESTA_LISTAR_POR_",
                                string.Format("{0},{1},{2},{3},{4},{5}",
                                c.IdCancion, c.NCancion, c.Album, c.Posicion_en_album, c.Autor, c.Clasificacion));
                            conexionTcp.EnviarPaquete(msgPack);
                        }
                        d.CerrarConexion();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error: " + ex.Message);
                    }

                }
                else if (d.ValidarBusquedaPorClasificacion(clasificacion) == false)
                {
                    var msgPackNOOK = new PaqueteServidor("NOOK_LISTAR_POR_CLASIFICACION", "No existen canciones con esa clasificación");
                    conexionTcp.EnviarPaquete(msgPackNOOK);
                }
            }

        }
        //Metodo ConexionRecibida:
        ///Muestra en el Label del servidor el número de clientes conectados, si el cliente no se encuentra en la lista
        ///de clientes conectados, es añadido.
        private void ConexionRecibida(ConexionTcpServidor conexionTcp)
        {
            //Se bloquea el acceso a clientes conectados para evitar bloquear hilos
            lock (connectedClients)
                if (!connectedClients.Contains(conexionTcp))
                    connectedClients.Add(conexionTcp);
            Invoke(new Action(() => lblClienteConectado.Text = string.Format("Clientes: {0}", connectedClients.Count)));
        }
        //Metodo conexion cerrada:
        ///Muestra en el Label del servidor el número de clientes conectados, elimina las conexiones de clientes que han salido
        ///para actualizar los valores en el label
        private void ConexionCerrada(ConexionTcpServidor conexionTcp)
        {
            //Se bloquea el acceso a clientes conectados para evitar bloquear hilos
            lock (connectedClients)
                if (connectedClients.Contains(conexionTcp))
                {
                    int cliIndex = connectedClients.IndexOf(conexionTcp);
                    connectedClients.RemoveAt(cliIndex);
                }
            Invoke(new Action(() => lblClienteConectado.Text = string.Format("Clientes: {0}", connectedClients.Count)));
        }
        ///EscucharClientes:
        ///Realiza el manejo de las conexiones recibiendo como parámetro la IP y el puerto
        ///crea un TcpListener e inicializa el hilo y creo un hilo para aceptar por clientes y lo inicializa también
        ///si existen errores se mostrará en un MessageBox, puesto que si no se lo muestra y se lo ignora la conexión se podría perder
        private void EscucharClientes(string ipAddress, int port)
        {
            try
            {
                //hilo del servidor
                _tcpListener = new TcpListener(IPAddress.Parse(ipAddress), port);
                _tcpListener.Start();
                //hilo para escuchar por conexiones de clientes
                _acceptThread = new Thread(AceptarClientes);
                _acceptThread.Start();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message.ToString());
            }
        }
        ///AceptarClientes:
        ///Método que estará escuchando conexiones de manera constante para aceptarlos
        private void AceptarClientes()
        {
            do
            {
                try
                {
                    //acepta al cliente
                    var conexion = _tcpListener.AcceptTcpClient();
                    //se crea la conexión
                    var srvClient = new ConexionTcpServidor(conexion)
                    {
                        //Se crea el hilo de lectura que referencia al método leer datos
                        ReadThread = new Thread(LeerDatos)
                    };
                    //inicia el hilo
                    srvClient.ReadThread.Start(srvClient);
                    //si hay clientes conectados  se llama a srvClient 
                    if (OnClientConnected != null)
                        OnClientConnected(srvClient);
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message.ToString());
                }

            } while (true);
        }
        ///Método LeerDatos:
        ///Lee los datos que llegan de los clientes almacenándolos en un búfer para luego convertir los datos del
        ///búfer en caracteres y obtener el mensale
        private void LeerDatos(object client)
        {
            var cli = client as ConexionTcpServidor;
            //búfer de recepción
            var charBuffer = new List<int>();

            do
            {
                try
                {
                    //condición: sin clientes se deja de leer
                    if (cli == null)
                        break;
                    //condición: fin del stream de datos
                    if (cli.StreamReader.EndOfStream)
                        break;
                    //almacena lo leido en charCode
                    int charCode = cli.StreamReader.Read();
                    //condición: variable vacía no se han leido datos ( no se están enviando datos)
                    //si  es diferente de cero se almacena lo leído en el búfer
                    if (charCode == -1)
                        break;
                    
                    if (charCode != 0)
                    {
                        charBuffer.Add(charCode);
                        continue;
                    }
                    //Cuando los datos recibidos no son nulos se convierten los datos a caracteres
                    if (OnDataRecieved != null)
                    {
                        var chars = new char[charBuffer.Count];
                        for (int i = 0; i < charBuffer.Count; i++)
                        {
                            chars[i] = Convert.ToChar(charBuffer[i]);
                        }
                        //se convierte el array de caracteres a string
                        var message = new string(chars);
                        //se llama al la recepción de mensajes
                        OnDataRecieved(cli, message);
                    }
                    //limpia el búfer
                    charBuffer.Clear();
                }
                catch (IOException)
                {
                    break;
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message.ToString());

                    break;
                }
            } while (true);

            if (OnClientDisconnected != null)
                OnClientDisconnected(cli);
        }
        //Se alctualiza la vista de los datos
        private void btnActualizar_Click(object sender, EventArgs e)
        {
            DataTable nuevo=d.ListarCancion();
            dgServidor.DataSource = nuevo.DefaultView;
        }
    }
}
