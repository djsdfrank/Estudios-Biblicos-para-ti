using System;
using SQLite;
using Xamarin.Forms;

namespace EstudiosBiblicos.Modelos
{
    public class Palabra
    {
        [PrimaryKey]
        public int IdLeccion { get; set; }
        public string Palabras { get; set; }
        public string Texto1 { get; set; }
        public string Texto2 { get; set; }
    }
}
