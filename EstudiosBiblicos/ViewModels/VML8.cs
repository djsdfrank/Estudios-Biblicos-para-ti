using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using EstudiosBiblicos.Modelos;
using EstudiosBiblicos.Services;
using Xamarin.Forms;

namespace EstudiosBiblicos.ViewModels
{
    public class VML8 : VMBase
    {
        bool _S1, _S2, _S3;
        bool _S4, _S5, _S6;
        bool _S7, _S8, _S9;
        bool _S10, _S11, _S12;
        bool _S13, _S14, _S15;
        bool _S16, _S17, _S18;
        bool _S19, _S20, _S21;
        bool _S22, _S23, _S24;
        bool _S25, _S26, _S27;
        bool _S28, _S29, _S30;

        string _T1, _T2, _T3;
        string _T4, _T5, _T6;
        string _T7, _T8, _T9;
        string _T10;
        DateTime _FechaInicio, _fech;
        DateTime _FechaFin;
        TimeSpan _HorasTrabajadas;
        int _Correctas;
        int _cantidadpreguntas = 10;
        public VML8(INavigation navService) : base(navService)
        {
        }

        public async Task Load()
        {
            //OnPropertyChanged("IPBBDD");
            //OnPropertyChanged("NombreBBDD");
            //OnPropertyChanged("IDEmpresaAct");
            //OnPropertyChanged("NombreEmpleado");

            var listado = App.Database.GetL8();
            if (listado != null)
            {
                this.Cursos = listado;
                FechaInicio = _Cursos.FechaInicio;
                if (FechaInicio == _fech)
                {
                    FechaInicio = DateTime.Now;
                    Cursos.FechaInicio = DateTime.Now;
                    App.Database.InsertarL8(_Cursos);
                }
                FechaFin = _Cursos.FechaFin;
                S1 = _Cursos.S1;
                S2 = _Cursos.S2;
                S3 = _Cursos.S3;
                S4 = _Cursos.S4;
                S5 = _Cursos.S5;
                S6 = _Cursos.S6;
                S7 = _Cursos.S7;
                S8 = _Cursos.S8;
                S9 = _Cursos.S9;
                S10 = _Cursos.S10;
                S11 = _Cursos.S11;
                S12 = _Cursos.S12;
                S13 = _Cursos.S13;
                S14 = _Cursos.S14;
                S15 = _Cursos.S15;
                S16 = _Cursos.S16;
                S17 = _Cursos.S17;
                S18 = _Cursos.S18;
                S19 = _Cursos.S19;
                S20 = _Cursos.S20;
                S21 = _Cursos.S21;
                S22 = _Cursos.S22;
                S23 = _Cursos.S23;


                T1 = _Cursos.T1;
                T2 = _Cursos.T2;
                T3 = _Cursos.T3;
                T4 = _Cursos.T4;
                T5 = _Cursos.T5;
                T6 = _Cursos.T6;
                T7 = _Cursos.T7;
            }
            if (App.reloadleccion)
            { volverainentar(); }
        }

        public async Task Finalizar()
        {
            FechaFin = DateTime.Now;
            Cursos.FechaFin = DateTime.Now;
            App.Database.InsertarL8(_Cursos);
        }
        private Leccion8Sel _Cursos;
        public Leccion8Sel Cursos
        {
            get { return _Cursos; }
            set
            {
                _Cursos = value;
                OnPropertyChanged();
            }
        }
        public int Seleccionadas
        {
            get
            {
                int cant = 0;
                if (_S1 || _S2 || _S3)
                    cant++;
                if (_S4 || _S5 || _S6)
                    cant++;
                if (_S7 || _S8 || _S9)
                    cant++;
                if (_S10 || _S11 || _S12)
                    cant++;
                if (_S13 || _S14 || _S15)
                    cant++;
                if (_S16 || _S17 || _S18)
                    cant++;
                if (_S19 || _S20 || _S21)
                    cant++;
                if (_S22 || _S23 || _S24)
                    cant++;
                    cant++;
                return cant;
            }
        }
        public decimal Progreso
        {
            get
            {
                var pct = (decimal)Seleccionadas / _cantidadpreguntas;
                if (pct == 1)
                {
                    if (FechaFin == _fech)
                    {
                        FechaFin = DateTime.Now;
                        Cursos.FechaFin = DateTime.Now;
                        App.Database.InsertarL8(_Cursos);
                    }
                    var inc = _cantidadpreguntas - Correctas;
                    var _pct = Decimal.ToInt32(((decimal)Correctas / _cantidadpreguntas) * 100);
                    App.Tiempo = HorasTrabajadas;
                    App.Puntos = Correctas.ToString() + "/" + _cantidadpreguntas.ToString();
                    App.Preguntas = _cantidadpreguntas.ToString();
                    App.Correcto = Correctas.ToString();
                    App.Incorrectas = inc.ToString();
                    App.LoadPCT = _pct.ToString() + "%";
                    App.Database.UpdateLeccion(_Cursos.IdLeccion, 2);
                    if (!App.reloadleccion)
                    {
                        var historyBehavior = false
                    ? HistoryBehavior.ClearHistory : HistoryBehavior.Default;
                        App.NavigationService.NavigateTo("WResumenLeccionFinalizada", "", historyBehavior);
                    }
                    return 0;
                }
                if (Seleccionadas == 0)
                    return 0;
                else
                    return (decimal)Seleccionadas / _cantidadpreguntas;
            }
        }
        public bool S1
        {
            get { return _S1; }
            set
            {
                _S1 = value;
                if (_S1)
                {
                    _S2 = false;
                    _S3 = false;
                    OnPropertyChanged("S1");
                    OnPropertyChanged("S2");
                    OnPropertyChanged("S3");
                    OnPropertyChanged("Seleccionadas");
                    OnPropertyChanged("Progreso");
                }
                Cursos.S1 = _S1;
                App.Database.InsertarL8(_Cursos);
            }
        }
        public bool S2
        {
            get { return _S2; }
            set
            {
                _S2 = value;
                if (_S2)
                {
                    _S1 = false;
                    _S3 = false;
                    OnPropertyChanged("S1");
                    OnPropertyChanged("S2");
                    OnPropertyChanged("S3");
                    OnPropertyChanged("Seleccionadas");
                    OnPropertyChanged("Progreso");
                }
                Cursos.S2 = _S2;
                App.Database.InsertarL8(_Cursos);
            }
        }
        public bool S3
        {
            get { return _S3; }
            set
            {
                _S3 = value;
                if (_S3)
                {
                    _S1 = false;
                    _S2 = false;
                    OnPropertyChanged("S1");
                    OnPropertyChanged("S2");
                    OnPropertyChanged("S3");
                    OnPropertyChanged("Seleccionadas");
                    OnPropertyChanged("Progreso");
                }
                Cursos.S3 = _S3;
                App.Database.InsertarL8(_Cursos);
            }
        }


        public bool S4
        {
            get { return _S4; }
            set
            {
                _S4 = value;
                if (_S4)
                {
                    _S5 = false;
                    _S6 = false;
                    OnPropertyChanged("S4");
                    OnPropertyChanged("S5");
                    OnPropertyChanged("S6");
                    OnPropertyChanged("Seleccionadas");
                    OnPropertyChanged("Progreso");
                }
                Cursos.S4 = _S4;
                App.Database.InsertarL8(_Cursos);
            }
        }
        public bool S5
        {
            get { return _S5; }
            set
            {
                _S5 = value;
                if (_S5)
                {
                    _S4 = false;
                    _S6 = false;
                    OnPropertyChanged("S4");
                    OnPropertyChanged("S5");
                    OnPropertyChanged("S6");
                    OnPropertyChanged("Seleccionadas");
                    OnPropertyChanged("Progreso");
                }
                Cursos.S5 = _S5;
                App.Database.InsertarL8(_Cursos);
            }
        }
        public bool S6
        {
            get { return _S6; }
            set
            {
                _S6 = value;
                if (_S6)
                {
                    _S4 = false;
                    _S5 = false;
                    OnPropertyChanged("S4");
                    OnPropertyChanged("S5");
                    OnPropertyChanged("S6");
                    OnPropertyChanged("Seleccionadas");
                    OnPropertyChanged("Progreso");
                }
                Cursos.S6 = _S6;
                App.Database.InsertarL8(_Cursos);
            }
        }

        public bool S7
        {
            get { return _S7; }
            set
            {
                _S7 = value;
                if (_S7)
                {
                    _S8 = false;
                    _S9 = false;
                    OnPropertyChanged("S7");
                    OnPropertyChanged("S8");
                    OnPropertyChanged("S9");
                    OnPropertyChanged("Seleccionadas");
                    OnPropertyChanged("Progreso");
                }
                Cursos.S7 = _S7;
                App.Database.InsertarL8(_Cursos);
            }
        }
        public bool S8
        {
            get { return _S8; }
            set
            {
                _S8 = value;
                if (_S8)
                {
                    _S7 = false;
                    _S9 = false;
                    OnPropertyChanged("S7");
                    OnPropertyChanged("S8");
                    OnPropertyChanged("S9");
                    OnPropertyChanged("Seleccionadas");
                    OnPropertyChanged("Progreso");
                }
                Cursos.S8 = _S8;
                App.Database.InsertarL8(_Cursos);
            }
        }
        public bool S9
        {
            get { return _S9; }
            set
            {
                _S9 = value;
                if (_S9)
                {
                    _S7 = false;
                    _S8 = false;
                    OnPropertyChanged("S7");
                    OnPropertyChanged("S8");
                    OnPropertyChanged("S9");
                    OnPropertyChanged("Seleccionadas");
                    OnPropertyChanged("Progreso");
                }
                Cursos.S9 = _S9;
                App.Database.InsertarL8(_Cursos);
            }
        }

        public bool S10
        {
            get { return _S10; }
            set
            {
                _S10 = value;
                if (_S10)
                {
                    _S11 = false;
                    _S12 = false;
                    OnPropertyChanged("S10");
                    OnPropertyChanged("S11");
                    OnPropertyChanged("S12");
                    OnPropertyChanged("Seleccionadas");
                    OnPropertyChanged("Progreso");
                }
                Cursos.S10 = _S10;
                App.Database.InsertarL8(_Cursos);
            }
        }
        public bool S11
        {
            get { return _S11; }
            set
            {
                _S11 = value;
                if (_S11)
                {
                    _S10 = false;
                    _S12 = false;
                    OnPropertyChanged("S10");
                    OnPropertyChanged("S11");
                    OnPropertyChanged("S12");
                    OnPropertyChanged("Seleccionadas");
                    OnPropertyChanged("Progreso");
                }
                Cursos.S11 = _S11;
                App.Database.InsertarL8(_Cursos);
            }
        }
        public bool S12
        {
            get { return _S12; }
            set
            {
                _S12 = value;
                if (_S12)
                {
                    _S10 = false;
                    _S11 = false;
                    OnPropertyChanged("S10");
                    OnPropertyChanged("S11");
                    OnPropertyChanged("S12");
                    OnPropertyChanged("Seleccionadas");
                    OnPropertyChanged("Progreso");
                }
                Cursos.S12 = _S12;
                App.Database.InsertarL8(_Cursos);
            }
        }

        public bool S13
        {
            get { return _S13; }
            set
            {
                _S13 = value;
                if (_S13)
                {
                    _S14 = false;
                    _S15 = false;
                    OnPropertyChanged("S13");
                    OnPropertyChanged("S14");
                    OnPropertyChanged("S15");
                    OnPropertyChanged("Seleccionadas");
                    OnPropertyChanged("Progreso");
                }
                Cursos.S13 = _S13;
                App.Database.InsertarL8(_Cursos);
            }
        }
        public bool S14
        {
            get { return _S14; }
            set
            {
                _S14 = value;
                if (_S14)
                {
                    _S13 = false;
                    _S15 = false;
                    OnPropertyChanged("S13");
                    OnPropertyChanged("S14");
                    OnPropertyChanged("S15");
                    OnPropertyChanged("Seleccionadas");
                    OnPropertyChanged("Progreso");
                }
                Cursos.S14 = _S14;
                App.Database.InsertarL8(_Cursos);
            }
        }
        public bool S15
        {
            get { return _S15; }
            set
            {
                _S15 = value;
                if (_S15)
                {
                    _S13 = false;
                    _S14 = false;
                    OnPropertyChanged("S13");
                    OnPropertyChanged("S14");
                    OnPropertyChanged("S15");
                    OnPropertyChanged("Seleccionadas");
                    OnPropertyChanged("Progreso");
                }
                Cursos.S15 = _S15;
                App.Database.InsertarL8(_Cursos);
            }
        }

        public bool S16
        {
            get { return _S16; }
            set
            {
                _S16 = value;
                if (_S16)
                {
                    _S17 = false;
                    _S18 = false;
                    OnPropertyChanged("S16");
                    OnPropertyChanged("S17");
                    OnPropertyChanged("S18");
                    OnPropertyChanged("Seleccionadas");
                    OnPropertyChanged("Progreso");
                }
                Cursos.S16 = _S16;
                App.Database.InsertarL8(_Cursos);
            }
        }
        public bool S17
        {
            get { return _S17; }
            set
            {
                _S17 = value;
                if (_S17)
                {
                    _S16 = false;
                    _S18 = false;
                    OnPropertyChanged("S16");
                    OnPropertyChanged("S17");
                    OnPropertyChanged("S18");
                    OnPropertyChanged("Seleccionadas");
                    OnPropertyChanged("Progreso");
                }
                Cursos.S17 = _S17;
                App.Database.InsertarL8(_Cursos);
            }
        }
        public bool S18
        {
            get { return _S18; }
            set
            {
                _S18 = value;
                if (_S18)
                {
                    _S16 = false;
                    _S17 = false;
                    OnPropertyChanged("S16");
                    OnPropertyChanged("S17");
                    OnPropertyChanged("S18");
                    OnPropertyChanged("Seleccionadas");
                    OnPropertyChanged("Progreso");
                }
                Cursos.S18 = _S18;
                App.Database.InsertarL8(_Cursos);
            }
        }

        public bool S19
        {
            get { return _S19; }
            set
            {
                _S19 = value;
                if (_S19)
                {
                    _S20 = false;
                    _S21 = false;
                    OnPropertyChanged("S19");
                    OnPropertyChanged("S20");
                    OnPropertyChanged("S21");
                    OnPropertyChanged("Seleccionadas");
                    OnPropertyChanged("Progreso");
                }
                Cursos.S19 = _S19;
                App.Database.InsertarL8(_Cursos);
            }
        }
        public bool S20
        {
            get { return _S20; }
            set
            {
                _S20 = value;
                if (_S20)
                {
                    _S19 = false;
                    _S21 = false;
                    OnPropertyChanged("S19");
                    OnPropertyChanged("S20");
                    OnPropertyChanged("S21");
                    OnPropertyChanged("Seleccionadas");
                    OnPropertyChanged("Progreso");
                }
                Cursos.S20 = _S20;
                App.Database.InsertarL8(_Cursos);
            }
        }
        public bool S21
        {
            get { return _S21; }
            set
            {
                _S21 = value;
                if (_S21)
                {
                    _S19 = false;
                    _S20 = false;
                    OnPropertyChanged("S19");
                    OnPropertyChanged("S20");
                    OnPropertyChanged("S21");
                    OnPropertyChanged("Seleccionadas");
                    OnPropertyChanged("Progreso");
                }
                Cursos.S21 = _S21;
                App.Database.InsertarL8(_Cursos);
            }
        }

        public bool S22
        {
            get { return _S22; }
            set
            {
                _S22 = value;
                if (_S22)
                {
                    _S23 = false;
                    _S24 = false;
                    OnPropertyChanged("S22");
                    OnPropertyChanged("S23");
                    OnPropertyChanged("S24");
                    OnPropertyChanged("Seleccionadas");
                    OnPropertyChanged("Progreso");
                }
                Cursos.S22 = _S22;
                App.Database.InsertarL8(_Cursos);
            }
        }
        public bool S23
        {
            get { return _S23; }
            set
            {
                _S23 = value;
                if (_S23)
                {
                    _S22 = false;
                    _S24 = false;
                    OnPropertyChanged("S22");
                    OnPropertyChanged("S23");
                    OnPropertyChanged("S24");
                    OnPropertyChanged("Seleccionadas");
                    OnPropertyChanged("Progreso");
                }
                Cursos.S23 = _S23;
                App.Database.InsertarL8(_Cursos);
            }
        }        

        public string T1
        {
            get { return _T1; }
            set
            {
                _T1 = value;
                Cursos.T1 = _T1;
                OnPropertyChanged();
                App.Database.InsertarL8(_Cursos);
            }
        }
        public string T2
        {
            get { return _T2; }
            set
            {
                _T2 = value;
                Cursos.T2 = _T2;
                OnPropertyChanged();
                App.Database.InsertarL8(_Cursos);
            }
        }
        public string T3
        {
            get { return _T3; }
            set
            {
                _T3 = value;
                Cursos.T3 = _T3;
                OnPropertyChanged();
                App.Database.InsertarL8(_Cursos);
            }
        }
        public string T4
        {
            get { return _T4; }
            set
            {
                _T4 = value;
                Cursos.T4 = _T4;
                OnPropertyChanged();
                App.Database.InsertarL8(_Cursos);
            }
        }
        public string T5
        {
            get { return _T5; }
            set
            {
                _T5 = value;
                Cursos.T5 = _T5;
                OnPropertyChanged();
                App.Database.InsertarL8(_Cursos);
            }
        }
        public string T6
        {
            get { return _T6; }
            set
            {
                _T6 = value;
                Cursos.T6 = _T6;
                OnPropertyChanged();
                App.Database.InsertarL8(_Cursos);
            }
        }
        public string T7
        {
            get { return _T7; }
            set
            {
                _T7 = value;
                Cursos.T7 = _T7;
                OnPropertyChanged();
                App.Database.InsertarL8(_Cursos);
            }
        }
        

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
                var diffInSeconds = (_FechaFin - _FechaInicio).TotalSeconds;
                double cnt = Math.Abs(diffInSeconds);
                //DifEnSegundos = cnt;
                TimeSpan HorasTrabajadas2 = TimeSpan.FromSeconds(cnt);
                _HorasTrabajadas = HorasTrabajadas2;
                //double horaini = _FechaInicio.TotalHours;
                OnPropertyChanged("HorasTrabajadas");

                Cursos.HorasTrabajadas = _HorasTrabajadas;
                App.Database.InsertarL8(_Cursos);

                return _HorasTrabajadas;
            }
        }
        public int Correctas
        {
            get
            {
                int contador = 0;
                if (_S1)
                    contador++;
                if (_S5)
                    contador++;
                if (_S7)
                    contador++;
                if (_S10)
                    contador++;
                if (_S15)
                    contador++;
                if (_S17)
                    contador++;
                if (_S19)
                    contador++;
                _Cursos.Correctas = contador;
                App.Database.InsertarL8(_Cursos);
                return contador;
            }
            set
            {
                _Correctas = value;
                OnPropertyChanged();
                Cursos.Correctas = _Correctas;
            }
        }
        void volverainentar()
        {
            if (!_S1)
            {
                S2 = false;
                S3 = false;
            }
            if (!_S5)
            {
                S4 = false;
                S6 = false;
            }
            if (!_S7)
            {
                S8 = false;
                S9 = false;
            }
            if (!_S10)
            {
                S11 = false;
                S12 = false;
            }
            if (!_S15)
            {
                S13 = false;
                S14 = false;
            }
            if (!_S17)
            {
                S16 = false;
                S18 = false;
            }
            if (!_S19)
            {
                S20 = false;
                S21 = false;
            }
            _Cursos.S1 = S1;
            _Cursos.S2 = S2;
            _Cursos.S3 = S3;
            _Cursos.S4 = S4;
            _Cursos.S5 = S5;
            _Cursos.S6 = S6;
            _Cursos.S7 = S7;
            _Cursos.S8 = S8;
            _Cursos.S9 = S9;
            _Cursos.S10 = S10;
            _Cursos.S11 = S11;
            _Cursos.S12 = S12;
            _Cursos.S13 = S13;
            _Cursos.S14 = S14;
            _Cursos.S15 = S15;
            _Cursos.S16 = S16;
            _Cursos.S17 = S17;
            _Cursos.S18 = S18;
            _Cursos.S19 = S19;
            _Cursos.S20 = S20;
            _Cursos.S21 = S21;
            App.Database.InsertarL8(_Cursos);
            OnPropertyChanged("S1");
            OnPropertyChanged("S2");
            OnPropertyChanged("S3");
            OnPropertyChanged("S4");
            OnPropertyChanged("S5");
            OnPropertyChanged("S6");
            OnPropertyChanged("S7");
            OnPropertyChanged("S8");
            OnPropertyChanged("S9");
            OnPropertyChanged("S10");
            OnPropertyChanged("S11");
            OnPropertyChanged("S12");
            OnPropertyChanged("S13");
            OnPropertyChanged("S14");
            OnPropertyChanged("S15");
            OnPropertyChanged("S16");
            OnPropertyChanged("S17");
            OnPropertyChanged("S18");
            OnPropertyChanged("S19");
            OnPropertyChanged("S20");
            OnPropertyChanged("S21");
        }
    }
}