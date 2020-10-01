using System;
using SQLite;
using Xamarin.Forms;

namespace EstudiosBiblicos.Modelos
{
    public class Letra
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public int IdLeccion { get; set; }
        public int Numero { get; set; }
        public bool Fijo { get; set; }
        public bool Temporal { get; set; }
        public Color MybackColor
        {
            get
            {
                if (Fijo || Temporal)
                    return Color.Green;
                else
                    return Color.Transparent;//return Color.FromHex("#008577");
            }
        }
        public Color MyTextColor
        {
            get
            {
                if (Fijo || Temporal)
                    return Color.White;
                else
                    return Color.Black;
            }
        }
    }
}
