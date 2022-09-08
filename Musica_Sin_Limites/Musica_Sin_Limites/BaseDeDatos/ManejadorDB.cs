//******************************************************************************************************************************************************************
// Realizado por: 
//  - Ibeth Bastidas
//  - Zahid Copara
//
// Resultados:
// -----------------------------------------------------------------------------------------------------------------------------------------------------------------
// BaseDeDatos
// -----------------------------------------------------------------------------------------------------------------------------------------------------------------
//  *El código en ManejadorDB del proyecto BaseDeDatos realiza la conexiones a la base de datos y los métodos de búsquedas y validaciones
//   necesarios para el desarrollo correcto del proyecto. Esta biblioteca se usa como referencia en el Servidor.
// -----------------------------------------------------------------------------------------------------------------------------------------------------------------
// Entidad
// -----------------------------------------------------------------------------------------------------------------------------------------------------------------
//  *El código de Canción en el proyecto Entidad es una Clase con los atributos de la canción, los métodos Get y Set, y los constructores
//   necesarios o los requeridos por ManejadorDB para realizar los distintos procesos. Esta biblioteca se usa como referencia en ManejadorDB y en el Servidor.
// ------------------------------------------------------------------------------------------------------------------------------------------------------------------
// Cliente
// -----------------------------------------------------------------------------------------------------------------------------------------------------------------
//  *El cliente consta de las clases: PaqueteCliente, MapaCliente y ConexionTCPCliente. Consta de los formularios: Editar, Búsqueda, Menú_Principal e Ingresar_Canción
//    *En PaqueteCliente se elabora un paquete que será el que se enviará, se definen los constructores con distintos parámetros de entrada y la serialización para
//     separar el paquete en comando y contenido. El comando permitirá tanto a cliente y servidor interpretar el contenido del mensaje y realizar lo más adecuado.
//    *En MapaCliente se serializa y deserializa el paquete, es decir, de un conjunto de strings separados por comas se lo hace una lista y viceversa.
//     Mapa y Paquete funcionan de la misma forma tanto en Cliente como Servidor
//    *ConexionTCPCliente se definen los métodos que permiten que se realice la conexión TCP entre cliente y servidor.
//    *Busqueda es el formulario para realizar búsquedas por parámetros, contiene los métodos para interpretar los comandos de LISTAR_POR
//     y eliminar canciones.
//    *Editar es el formulario que permite editar una canción a partir de seleccionarla desde Búsqueda, contiene los métodos para interpretar
//     el comando Actualizar que NOOK y OK que recibe desde el servidor.
//    *Ingresar_Canción es el formulario para el ingreso de canciones y contiene los métodos para interpretar los comandos CREAR, NOOK y OK del servidor
//    *Menú_Principal es el formulario que contiene a todos los demás, contiene la conexión TCP 
// -----------------------------------------------------------------------------------------------------------------------------------------------------------------
// Servidor
// ----------------------------------------------------------------------------------------------------------------------------------------------------------------
//  *El servidor consta de las clases: PaqueteServidor, MapaServidor y ConexionTCPServidor. Consta del formulario: ServidorForm
//    *Mapa, Paquete y Conexión resultan en lo mismo que en lo explicado para el cliente.
//    *SevidorForm es el formulario que contiene la conexión TCP, y los métodos para interpretar los comandos de los paquetes enviados por el Cliente
//     Envía respuestas al cliente de acuerdo a lo solicitado, envía OK y el detalle de lo sucedido cuando se ejecuta correctamente y NOOK cuando ha ocurrido
//     algún error, envía los paquetes necesarios para listar los elementos solicitados por el cliente.Y procesa las solicitudes del cliente modificando la base datos
//*************************************************************************************************************************************



using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidad;

namespace BaseDeDatos
{
    public class ManejadorDB
    {

        //Conexión a la base de datos
        //SqlConnection sqlConexion = new SqlConnection(@"Data Source=LAPTOP-MB7L5OOR;Initial Catalog=dbMusicaSinLimites;Integrated Security=True");

        SqlConnection sqlConexion = new SqlConnection(@"Data Source=ZAHID;Initial Catalog=dbMusicaSinLimites;Integrated Security=True");
        //Metodo para ABRIR conexión
        public SqlConnection AbrirConexion()
        {

            if (sqlConexion.State == ConnectionState.Closed)
            {
                sqlConexion.Open();
                Console.WriteLine("Estado de la conexion con la BD: " + sqlConexion.State.ToString());
            }
            return sqlConexion;
        }

        //Metodo para CERRAR la conexión
        public void CerrarConexion()
        {
            if (sqlConexion.State == ConnectionState.Open)
            {
                sqlConexion.Close();
                Console.WriteLine("Estado de la conexion con la BD: " + sqlConexion.State.ToString());
            }
        }


        //CREATE
        public bool CrearCancion(Cancion c)
        {
            //Como se genera automáticamente el ID hay que especificar los campos que se van a insertar para que no de errores.
            bool retorno = true;
            string nquery = "INSERT INTO tblRegistroCanciones ( cancion, album, posicion_en_album, autor, clasificacion) values ('" + c.NCancion + "','" + c.Album + "'," + c.Posicion_en_album + ",'" + c.Autor + "'," + c.Clasificacion + ")";
            Console.WriteLine(nquery);
            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.InsertCommand = new SqlCommand(nquery, sqlConexion);
                AbrirConexion();
                adapter.InsertCommand.ExecuteNonQuery();
                CerrarConexion();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                retorno = false;
            }
            return retorno;
        }


        //READ
        public DataTable ListarCancion()
        {
            DataTable dt = new DataTable();
            string nquery = "SELECT idCancion AS N, cancion AS CANCION, album AS ALBUM, posicion_en_album AS POSICION,autor AS AUTOR,clasificacion AS CLASIFICACION FROM tblRegistroCanciones";
            Console.WriteLine(nquery);
            SqlDataAdapter adapter = new SqlDataAdapter();
            try
            {
                AbrirConexion();
                adapter.SelectCommand = new SqlCommand(nquery, sqlConexion);
                adapter.InsertCommand = new SqlCommand(nquery, sqlConexion);
                adapter.Fill(dt);
                CerrarConexion();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            return dt;
        }

        //DELETE
        //Metodo que acepta el query de la base de datos y elimina una fila de la base de datos
        //aceptando el id de la cancion para poder eliminarla.
        public bool EliminarCancion(int id_lista)
        {
            bool retorno = true;
            string nquery = string.Format("DELETE FROM tblRegistroCanciones WHERE idCancion={0}", id_lista);
            Console.WriteLine(nquery);
            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.InsertCommand = new SqlCommand(nquery, sqlConexion);
                AbrirConexion();
                adapter.InsertCommand.ExecuteNonQuery();
                CerrarConexion();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                retorno = false;
            }
            return retorno;
        }

        //VALIDACIÓN BÚSQUEDA POR CANCIÓN
        //Devuelve un true si la canción a buscarse sí existe en la base de datos, o alguna coincidencia
        public bool ValidarBusquedaPorCancion(string c)
        {
            bool resultado = false;
            string cRead;
            SqlCommand comando1;
            String sqlstr1 = "SELECT * FROM tblRegistroCanciones where cancion LIKE '%" + c + "%'";
            try
            {
                using (SqlConnection conexion = new SqlConnection())
                {
                    AbrirConexion();
                    comando1 = new SqlCommand(sqlstr1, sqlConexion);
                    SqlDataReader reader1 = comando1.ExecuteReader();
                    while (reader1.Read())
                    {
                        cRead = reader1["cancion"].ToString();
                        resultado = true;
                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                resultado = false;
            }

            CerrarConexion();
            return resultado;
        }
        //VALIDACIÓN BÚSQUEDA POR ALBUM
        //Devuelve un true si el album a buscarse sí existe en la base de datos, o alguna coincidencia
        public bool ValidarBusquedaPorAlbum(string a)
        {
            bool resultado = false;
            string aRead;
            SqlCommand comando1;
            String sqlstr1 = "SELECT * FROM tblRegistroCanciones where album LIKE '%" + a + "%'";
            try
            {
                using (SqlConnection conexion = new SqlConnection())
                {
                    AbrirConexion();
                    comando1 = new SqlCommand(sqlstr1, sqlConexion);
                    SqlDataReader reader1 = comando1.ExecuteReader();
                    while (reader1.Read())
                    {
                        aRead = reader1["album"].ToString();
                        resultado = true;


                    }

                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                resultado = false;
            }

            CerrarConexion();
            return resultado;
        }
        //VALIDACIÓN BÚSQUEDA POR AUTOR
        //Devuelve un true si el autor a buscarse sí existe en la base de datos, o alguna coincidencia
        public bool ValidarBusquedaPorAutor(string au)
        {
            bool resultado = false;
            string auRead;
            SqlCommand comando1;
            String sqlstr1 = "SELECT * FROM tblRegistroCanciones where autor LIKE '%" + au + "%'";
            try
            {
                using (SqlConnection conexion = new SqlConnection())
                {
                    AbrirConexion();
                    comando1 = new SqlCommand(sqlstr1, sqlConexion);
                    SqlDataReader reader1 = comando1.ExecuteReader();
                    while (reader1.Read())
                    {
                        auRead = reader1["autor"].ToString();
                        resultado = true;


                    }

                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                resultado = false;
            }

            CerrarConexion();
            return resultado;
        }
        //VALIDACIÓN BÚSQUEDA POR CLASIFICACION
        //Devuelve un true si la clasificación a buscarse sí existe en la base de datos
        public bool ValidarBusquedaPorClasificacion(int cl)
        {
            bool resultado = false;
            string clRead;
            SqlCommand comando1;
            String sqlstr1 = "SELECT * FROM tblRegistroCanciones where clasificacion ="+ cl + "";
            try
            {
                using (SqlConnection conexion = new SqlConnection())
                {
                    AbrirConexion();
                    comando1 = new SqlCommand(sqlstr1, sqlConexion);
                    SqlDataReader reader1 = comando1.ExecuteReader();
                    while (reader1.Read())
                    {
                        clRead = reader1["clasificacion"].ToString();
                        resultado = true;


                    }

                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                resultado = false;
            }

            CerrarConexion();
            return resultado;
        }

        //VALIDACIÓN INGRESO DE CANCIONES REPETIDAS
        //Se lee la base de datos y si se encuentra similitud con el parámetro ingresado significa que se está repitiendo 
        //el nombre de la canción, el álbum, el autor o la posición, el método de validación para cada uno está descrito en
        //las siguientes funciones.
        public bool CancionRepetida(string c)
        {
            bool resultado = false;
            string cRead;
            SqlCommand comando1;
            String sqlstr1 = "SELECT * FROM tblRegistroCanciones where cancion= '" + c + "'";
            try
            {
                using (SqlConnection conexion = new SqlConnection())
                {
                    AbrirConexion();
                    comando1 = new SqlCommand(sqlstr1, sqlConexion);
                    SqlDataReader reader1 = comando1.ExecuteReader();
                    while (reader1.Read())
                    {
                        cRead = reader1["cancion"].ToString();
                        resultado = true;
                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                resultado = false;
            }

            CerrarConexion();
            return resultado;
        }
        //VALIDACIÓN INGRESO DE ÁLBUM REPETIDO
        public bool AlbumRepetido(string a)
        {
            bool resultado = false;
            string aRead;
            SqlCommand comando1;
            String sqlstr1 = "SELECT * FROM tblRegistroCanciones where album ='" + a + "'";
            try
            {
                using (SqlConnection conexion = new SqlConnection())
                {
                    AbrirConexion();
                    comando1 = new SqlCommand(sqlstr1, sqlConexion);
                    SqlDataReader reader1 = comando1.ExecuteReader();
                    while (reader1.Read())
                    {
                        aRead = reader1["album"].ToString();
                        resultado = true;


                    }

                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                resultado = false;
            }

            CerrarConexion();
            return resultado;
        }
        //VALIDACIÓN AUTOR REPETIDO
        public bool AutorRepetido(string au)
        {
            bool resultado = false;
            string auRead;
            SqlCommand comando1;
            String sqlstr1 = "SELECT * FROM tblRegistroCanciones where autor= '" + au + "'";
            try
            {
                using (SqlConnection conexion = new SqlConnection())
                {
                    AbrirConexion();
                    comando1 = new SqlCommand(sqlstr1, sqlConexion);
                    SqlDataReader reader1 = comando1.ExecuteReader();
                    while (reader1.Read())
                    {
                        auRead = reader1["autor"].ToString();
                        resultado = true;


                    }

                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                resultado = false;
            }

            CerrarConexion();
            return resultado;
        }

        //VALIDACIÓN PARA QUE NO SE REPITA UNA POSICIÓN DENTRO DEL ÁLBUM DE UN MISMO AUTOR EN CANCIONES DIFERENTES
        public bool PosicionEnAlbumOcupada(int pos)
        {
            bool resultado = false;
            string posRead;
            SqlCommand comando1;
            String sqlstr1 = "SELECT * FROM tblRegistroCanciones where posicion_en_album = " + pos + "";
            try
            {
                using (SqlConnection conexion = new SqlConnection())
                {
                    AbrirConexion();
                    comando1 = new SqlCommand(sqlstr1, sqlConexion);
                    SqlDataReader reader1 = comando1.ExecuteReader();
                    while (reader1.Read())
                    {
                        posRead = reader1["autor"].ToString();
                        resultado = true;
                    }

                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                resultado = false;
            }

            CerrarConexion();
            return resultado;
        }
    }
}

