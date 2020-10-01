using System;
using SQLite;

namespace EstudiosBiblicos.Modelos
{
    public class Leccion9Sel
    {
        bool _S1, _S2, _S3;
        DateTime _FechaInicio;
        DateTime _FechaFin;
        TimeSpan _HorasTrabajadas;
        [PrimaryKey]
        public int IdLeccion { get; set; }
        public decimal Progreso
        {
            get
            {
                if (Seleccionadas == 0)
                    return 0;
                else
                    return Seleccionadas / 9;
            }
        }
        public int Seleccionadas { get; set; }
        public int Correctas { get; set; }
        public bool S1 { get; set; }
        public bool S2 { get; set; }
        public bool S3 { get; set; }
        public bool S4 { get; set; }
        public bool S5 { get; set; }
        public bool S6 { get; set; }
        public bool S7 { get; set; }
        public bool S8 { get; set; }
        public bool S9 { get; set; }
        public bool S10 { get; set; }
        public bool S11 { get; set; }
        public bool S12 { get; set; }
        public bool S13 { get; set; }
        public bool S14 { get; set; }
        public bool S15 { get; set; }
        public bool S16 { get; set; }
        public bool S17 { get; set; }
        public bool S18 { get; set; }
        public bool S19 { get; set; }
        public bool S20 { get; set; }
        public bool S21 { get; set; }
        public bool S22 { get; set; }
        public bool S23 { get; set; }
        public bool S24 { get; set; }
        public bool S25 { get; set; }
        public bool S26 { get; set; }
        public bool S27 { get; set; }

        public string T1 { get; set; }
        public string T2 { get; set; }
        public string T3 { get; set; }
        public string T4 { get; set; }
        public string T5 { get; set; }
        public string T6 { get; set; }
        public string T7 { get; set; }
        public string T8 { get; set; }
        public string T9 { get; set; }
        public string T10 { get; set; }
        public string T11 { get; set; }
        public string T12 { get; set; }
        public string T13 { get; set; }
        public string T14 { get; set; }
        public string T15 { get; set; }
        public string T16 { get; set; }
        public string T17 { get; set; }
        public string T18 { get; set; }
        public string T19 { get; set; }
        public string T20 { get; set; }
        public string T21 { get; set; }
        public string T22 { get; set; }
        public string T23 { get; set; }
        public string T24 { get; set; }
        public string T25 { get; set; }
        public string T26 { get; set; }
        public string T27 { get; set; }

        public string P1 { get; set; }
        public string P2 { get; set; }
        public string P3 { get; set; }
        public string P4 { get; set; }
        public string P5 { get; set; }
        public string P6 { get; set; }
        public string P7 { get; set; }
        public string P8 { get; set; }
        public string P9 { get; set; }
        public string P10 { get; set; }

        public string TB1 { get; set; }
        public string TB2 { get; set; }
        public string TB3 { get; set; }
        public string TB4 { get; set; }
        public string TB5 { get; set; }
        public string TB6 { get; set; }
        public string TB7 { get; set; }
        public string TB8 { get; set; }
        public string TB9 { get; set; }
        public string TB10 { get; set; }

        public DateTime FechaInicio
        {
            get { return _FechaInicio; }
            set
            {
                _FechaInicio = value;
            }
        }
        public DateTime FechaFin
        {
            get { return _FechaFin; }
            set
            {
                _FechaFin = value;
            }
        }
        public TimeSpan HorasTrabajadas
        {
            get
            {
                //var diffInSeconds = (_FechaFin - _FechaInicio).TotalSeconds;
                //double cnt = Math.Abs(diffInSeconds);
                //DifEnSegundos = cnt;
                //TimeSpan HorasTrabajadas2 = TimeSpan.FromSeconds(cnt);
                //_HorasTrabajadas = HorasTrabajadas2;
                ////double horaini = _FechaInicio.TotalHours;                
                return _HorasTrabajadas;
            }
            set { _HorasTrabajadas = value; }
        }
        public double DifEnSegundos
        {
            get;
            set;
        }
    }
}
