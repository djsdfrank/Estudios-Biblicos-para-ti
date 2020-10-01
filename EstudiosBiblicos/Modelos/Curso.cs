using System;
using SQLite;

namespace EstudiosBiblicos.Modelos
{
    public class Curso
    {
        [PrimaryKey] 
        public int IdCurso { get; set; }
        public int Estatus { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int Lecciones { get; set; }
        public int Duracion { get; set; }
        public string Imagen { get; set; }
        public string CntLecciones { get { return Lecciones.ToString() + " Lecciónes"; } }
        public string CntDuracion { get { return Duracion.ToString() + " Horas"; } }
    }
}
