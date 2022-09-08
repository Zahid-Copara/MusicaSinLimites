using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servidor
{
    public class PaqueteServidor
    {
        //Estructura de la propiedad comando del tipo string.
        public string Comando { get; set; }
        //Estructura de la propiedad contenido del tipo contenido.
        public string Contenido { get; set; }

        //Constructor vacio del Paquete Servidor (En caso de necesitarse)
        public PaqueteServidor()
        {

        }

        //Constructor con las dos estructuras de comando y datos
        public PaqueteServidor(string comando, string contenido)
        {
            Comando = comando;
            Contenido = contenido;
        }
        //Constructor de datos: Con el fin de servir para cuando se requiera pasar un bloque de informacion 
        //o los valores individuales. El string que se le ingrese lo ingresara en las propiedades respectivas
        // ej: crear:nombre,album,posicion,autor,clasificacion...
        //Separa: el dato del comando = crear y el contenido que puede ser, nombre, album, posicion...
        public PaqueteServidor(string datos) 
        {
            //Se determina cual va a ser la posicion del separador dos puntos (:).
            //Se utiliza ordinal para evaluar caracter por caracter
            int sepIndex = datos.IndexOf(":", StringComparison.Ordinal);
            //Extraemos la porcion del dato utilizando substring y obtener el comando
            Comando = datos.Substring(0, sepIndex);
            //Se extrae el contenido despues partiendo a la ubicacion despues de los dos puntos
            Contenido = datos.Substring(Comando.Length + 1);
        }

        //Metodo Serializa: El cual es un metodo que devuelve un string de acuerdo al contenido que se tenga en las propiedades
        public string Serializar()
        {
            return string.Format("{0}:{1}", Comando, Contenido);
        }

        //Metodo accesible sin necesidad de instanciar el objeto paquete servidor, implicito ya que esta definido de manera de usuario, operador
        //que es un convertidor de dato (permite que cuando se invoque no importe el valor que se de, este va a convertir al valor string), entonces
        //convierte en string al paquete
        public static implicit operator string(PaqueteServidor paquete)
        {
            //Regresa el paquete serializado 
            return paquete.Serializar();
        }
    }
}