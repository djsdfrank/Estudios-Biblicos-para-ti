using System;
using SQLite;
using Xamarin.Forms;

namespace EstudiosBiblicos.Modelos
{
    public class Letras
    {
        [PrimaryKey]
        public int IdLeccion { get; set; }
        public string Palabras { get; set; }
    }
}
