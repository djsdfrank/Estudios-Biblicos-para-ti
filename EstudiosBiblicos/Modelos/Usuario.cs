using System;
using SQLite;

namespace EstudiosBiblicos.Modelos
{
    public class Usuario
    {
        [PrimaryKey]
        public int id_usuario { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string correo { get; set; }
        public string contrasena { get; set; }
        public string telefono { get; set; }
        public DateTime fecha_nacimiento { get; set; }
        public string estado { get; set; }
        public string Uid { get; set; }
    }
}
