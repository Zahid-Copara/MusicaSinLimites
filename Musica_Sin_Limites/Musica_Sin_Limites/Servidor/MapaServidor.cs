using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servidor
{
    //Mapa Servidor sirve para al obtener los contenidos de cada comando y ponerlos en comas y visceversa
    //(Es decir se obtiene una lista, string, etc. y separarlos por coma)
    //El mapa que se encarga de serializar el contenido, ese contenido se va a almacenar en un objeto paquete como contenido, se le agrega su comando y asi el paquete 
    //se envia al servidor form.
    public class MapaServidor
    {
        //Metodo que serializa los contenidos por comas.
        //Se entrega una lista y esta lista se recorre, se procesa y devuelve un string separado por comas.
        public static string Serializar(List<string> lista)
        {
            //Validar si la lista viene vacia
            if (lista.Count == 0)
            {
                return null;
            }
            //Variable booleana que permitira conocer si es el primer valor
            bool esElPrimero = true;
            //Variable de salida que sera un constructor de string
            var salida = new StringBuilder();

            //Se procesa con un bucle for each se recorre la lista de strings 
            foreach (var linea in lista)
            {
                if (esElPrimero)
                {
                    //Al constructor de la salida se le agrega la linea o item 1.
                    salida.Append(linea);
                    //Se cambia el estado a false porque ya se registro el primer valor.
                    esElPrimero = false;
                }
                else
                {
                    //Se construye la lista con n valores, y se los separa con una coma.
                    salida.Append(string.Format(",{0}", linea));
                }
            }
            return salida.ToString();
        }
        //Metodo inverso Deserializar (devuelve una lista)
        public static List<string> Deserializar(string entrada)
        {
            //Se declara la variable string que sera la entrada que recibe el Metodo
            string str = entrada;
            //Se declara la variable tipo lista que sera la que se devuelva
            var lista = new List<string>();

            //Validamos que este string no este nulo
            if (string.IsNullOrEmpty(str))
            {
                //Se devuelve la lista tal y como esta para que no exista un error
                return lista;
            }

            try
            {
                //Se recorre el string, en entrada, el cual es un string separado por comas y por eso se utiliza el split para la delimitacion.
                //Entonces split nos entrega los valores que esten separados por comas.
                foreach (string linea in entrada.Split(','))
                {
                    //Se agrega el valor a la lista (ya sin comas)
                    lista.Add(linea);
                }
            }
            catch (Exception)
            {
                //Si ocurre una excepcion se retorna un null
                return null;
            }
            //Se regresa la lista ya deserializada
            return lista;
        }
    }
}
