using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class Cancion
    {
        //ATRIBUTOS
        private int idCancion;
        private string Ncancion;
        private string album;
        private int posicion_en_album;
        private string autor;
        private int clasificacion;


        //CONSTRUCTORES
        //Constructor vacío
        public Cancion()
        {

        }
        //Constructores con varios parámetros
        public Cancion(string cancion, string album, int posicion_en_album, string autor, int clasificacion)
        {
            this.NCancion = cancion;
            this.Album = album;
            this.Posicion_en_album = posicion_en_album;
            this.Autor = autor;
            this.Clasificacion = clasificacion;
        }
        //Constructor con todos los parámetros
        public Cancion(int idCancion, string ncancion, string album, int posicion_en_album, string autor, int clasificacion)
        {
            this.idCancion = idCancion;
            Ncancion = ncancion;
            this.album = album;
            this.posicion_en_album = posicion_en_album;
            this.autor = autor;
            this.clasificacion = clasificacion;
        }

        //GETTERS Y SETTERS
        public int IdCancion { get => idCancion; set => idCancion = value; }
        public string NCancion { get => Ncancion; set => Ncancion = value; }
        public string Album { get => album; set => album = value; }
        public int Posicion_en_album { get => posicion_en_album; set => posicion_en_album = value; }
        public string Autor { get => autor; set => autor = value; }
        public int Clasificacion { get => clasificacion; set => clasificacion = value; }
    }
}

