using System;
using SQLite;

namespace EstudiosBiblicos.Modelos
{
    public class TextoBiblico
    {        
        [PrimaryKey]
        public int Id_Texto { get; set; }        
        public string Descripcion { get; set; }
    }
}
