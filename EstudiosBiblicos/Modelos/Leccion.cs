using System;
using SQLite;

namespace EstudiosBiblicos.Modelos
{
    public class Leccion
    {
        public int IdCurso { get; set; }
        [PrimaryKey]
        public int IdLeccion { get; set; }
        public int Estatus { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int Preguntas { get; set; }
        public int Duracion { get; set; }
        public string Imagen { get; set; }
        public string CntPreguntas { get { return Preguntas.ToString() + " Preguntas"; } }
        public string CntDuracion { get { return Duracion.ToString() + " Horas"; } }
        public int TiempoDurado { get; set; }
        public int Puntos { get; set; }
        public int Correctas { get; set; }
        public int Incorrectas { get; set; }
        public int Omitidas { get; set; }
        public bool Terminado { get {
                if (Estatus == 2)
                    return true;
                else
                    return false;
                    } }
    }
}
