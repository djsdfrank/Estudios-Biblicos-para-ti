using System;
using System.Threading.Tasks;
using EstudiosBiblicos.Modelos;
using EstudiosBiblicos.Services;
using Xamarin.Forms;

namespace EstudiosBiblicos.ViewModels
{
    public class VML9 : VMBase
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

        string _T1, _T2, _T3;
        string _T4, _T5, _T6;
        string _T7, _T8, _T9;
        string _T10, _T11, _T12;
        string _T13, _T14, _T15;
        string _T16, _T17, _T18;
        string _T19, _T20, _T21;
        string _T22, _T23, _T24;
        string _T25, _T26, _T27;

        string _P1, _P2, _P3;
        string _P4, _P5, _P6;
        string _P7, _P8, _P9;
        string _P10;

        string _TB1, _TB2, _TB3;
        string _TB4, _TB5, _TB6;
        string _TB7, _TB8, _TB9;
        string _TB10;
        DateTime _FechaInicio, _fech;
        DateTime _FechaFin;
        TimeSpan _HorasTrabajadas;
        int _Correctas;
        int _cantidadpreguntas = 10;
        public VML9(INavigation navService) : base(navService)
        {
        }

        public async Task Load()
        {
            //OnPropertyChanged("IPBBDD");
            //OnPropertyChanged("NombreBBDD");
            //OnPropertyChanged("IDEmpresaAct");
            //OnPropertyChanged("NombreEmpleado");

            var listado = App.Database.GetL9(App.LeccionSeleccionada.IdLeccion);
            if (listado != null)
            {
                this.Cursos = listado;
                FechaInicio = _Cursos.FechaInicio;
                if (FechaInicio == _fech)
                {
                    FechaInicio = DateTime.Now;
                    Cursos.FechaInicio = DateTime.Now;
                    App.Database.InsertarL9(_Cursos);
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
                S24 = _Cursos.S24;
                S25 = _Cursos.S25;
                S26 = _Cursos.S26;
                S27 = _Cursos.S27;


                T1 = _Cursos.T1;
                T2 = _Cursos.T2;
                T3 = _Cursos.T3;
                T4 = _Cursos.T4;
                T5 = _Cursos.T5;
                T6 = _Cursos.T6;
                T7 = _Cursos.T7;
                T8 = _Cursos.T8;
                T9 = _Cursos.T9;
                T10 = _Cursos.T10;
                T11 = _Cursos.T11;
                T12 = _Cursos.T12;
                T13 = _Cursos.T13;
                T14 = _Cursos.T14;
                T15 = _Cursos.T15;
                T16 = _Cursos.T16;
                T17 = _Cursos.T17;
                T18 = _Cursos.T18;
                T19 = _Cursos.T19;
                T20 = _Cursos.T20;
                T21 = _Cursos.T21;
                T22 = _Cursos.T22;
                T23 = _Cursos.T23;
                T24 = _Cursos.T24;
                T25 = _Cursos.T25;
                T26 = _Cursos.T26;
                T27 = _Cursos.T27;

                _P1 = _Cursos.P1;
                _P2 = _Cursos.P2;
                _P3 = _Cursos.P3;
                _P4 = _Cursos.P4;
                _P5 = _Cursos.P5;
                _P6 = _Cursos.P6;
                _P7 = _Cursos.P7;
                _P8 = _Cursos.P8;
                _P9 = _Cursos.P9;
                _P10 = _Cursos.P10;
                OnPropertyChanged("P1");
                OnPropertyChanged("P2");
                OnPropertyChanged("P3");
                OnPropertyChanged("P4");
                OnPropertyChanged("P5");
                OnPropertyChanged("P6");
                OnPropertyChanged("P7");
                OnPropertyChanged("P8");
                OnPropertyChanged("P9");
                OnPropertyChanged("P10");


                _TB1 = _Cursos.TB1;
                _TB2 = _Cursos.TB2;
                _TB3 = _Cursos.TB3;
                _TB4 = _Cursos.TB4;
                _TB5 = _Cursos.TB5;
                _TB6 = _Cursos.TB6;
                _TB7 = _Cursos.TB7;
                _TB8 = _Cursos.TB8;
                _TB9 = _Cursos.TB9;
                _TB10 = _Cursos.TB10;
                OnPropertyChanged("TB1");
                OnPropertyChanged("TB2");
                OnPropertyChanged("TB3");
                OnPropertyChanged("TB4");
                OnPropertyChanged("TB5");
                OnPropertyChanged("TB6");
                OnPropertyChanged("TB7");
                OnPropertyChanged("TB8");
                OnPropertyChanged("TB9");
                OnPropertyChanged("TB10");
            }
            if (App.reloadleccion)
            { volverainentar(); }
        }

        public async Task Finalizar()
        {
            FechaFin = DateTime.Now;
            Cursos.FechaFin = DateTime.Now;
            App.Database.InsertarL9(_Cursos);
        }
        private Leccion9Sel _Cursos;
        public Leccion9Sel Cursos
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
                if (_S4 || _S5)
                    cant++;
                if (_S6 || _S7 || _S8)
                    cant++;
                if (_S9 || _S10)
                    cant++;
                if (_S11 || _S12 || _S13)
                    cant++;
                if (_S14 || _S15)
                    cant++;
                if (_S16 || _S17 || _S18)
                    cant++;
                if (_S19 || _S20 || _S21)
                    cant++;
                if (_S22 || _S23 || _S24)
                    cant++;
                if (_S25 || _S26 || _S27)
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
                        App.Database.InsertarL9(_Cursos);
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
                App.Database.InsertarL9(_Cursos);
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
                App.Database.InsertarL9(_Cursos);
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
                App.Database.InsertarL9(_Cursos);
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
                    OnPropertyChanged("S4");
                    OnPropertyChanged("S5");
                    OnPropertyChanged("Seleccionadas");
                    OnPropertyChanged("Progreso");
                }
                Cursos.S4 = _S4;
                App.Database.InsertarL9(_Cursos);
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
                    OnPropertyChanged("S4");
                    OnPropertyChanged("S5");
                    OnPropertyChanged("Seleccionadas");
                    OnPropertyChanged("Progreso");
                }
                Cursos.S5 = _S5;
                App.Database.InsertarL9(_Cursos);
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
                    _S7 = false;
                    _S8 = false;
                    OnPropertyChanged("S6");
                    OnPropertyChanged("S7");
                    OnPropertyChanged("S8");
                    OnPropertyChanged("Seleccionadas");
                    OnPropertyChanged("Progreso");
                }
                Cursos.S6 = _S6;
                App.Database.InsertarL9(_Cursos);
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
                    _S6 = false;
                    _S8 = false;
                    OnPropertyChanged("S6");
                    OnPropertyChanged("S7");
                    OnPropertyChanged("S8");
                    OnPropertyChanged("Seleccionadas");
                    OnPropertyChanged("Progreso");
                }
                Cursos.S7 = _S7;
                App.Database.InsertarL9(_Cursos);
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
                    _S6 = false;
                    _S7 = false;
                    OnPropertyChanged("S6");
                    OnPropertyChanged("S7");
                    OnPropertyChanged("S8");
                    OnPropertyChanged("Seleccionadas");
                    OnPropertyChanged("Progreso");
                }
                Cursos.S8 = _S8;
                App.Database.InsertarL9(_Cursos);
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
                    _S10 = false;
                    OnPropertyChanged("S9");
                    OnPropertyChanged("S10");
                    OnPropertyChanged("Seleccionadas");
                    OnPropertyChanged("Progreso");
                }
                Cursos.S9 = _S9;
                App.Database.InsertarL9(_Cursos);
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
                    _S9 = false;
                    OnPropertyChanged("S9");
                    OnPropertyChanged("S10");
                    OnPropertyChanged("Seleccionadas");
                    OnPropertyChanged("Progreso");
                }
                Cursos.S10 = _S10;
                App.Database.InsertarL9(_Cursos);
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
                    _S12 = false;
                    _S13 = false;
                    OnPropertyChanged("S11");
                    OnPropertyChanged("S12");
                    OnPropertyChanged("S13");
                    OnPropertyChanged("Seleccionadas");
                    OnPropertyChanged("Progreso");
                }
                Cursos.S11 = _S11;
                App.Database.InsertarL9(_Cursos);
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
                    _S11 = false;
                    _S13 = false;
                    OnPropertyChanged("S11");
                    OnPropertyChanged("S12");
                    OnPropertyChanged("S13");
                    OnPropertyChanged("Seleccionadas");
                    OnPropertyChanged("Progreso");
                }
                Cursos.S12 = _S12;
                App.Database.InsertarL9(_Cursos);
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
                    _S11 = false;
                    _S12 = false;
                    OnPropertyChanged("S11");
                    OnPropertyChanged("S12");
                    OnPropertyChanged("S13");
                    OnPropertyChanged("Seleccionadas");
                    OnPropertyChanged("Progreso");
                }
                Cursos.S13 = _S13;
                App.Database.InsertarL9(_Cursos);
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
                    _S15 = false;
                    OnPropertyChanged("S14");
                    OnPropertyChanged("S15");
                    OnPropertyChanged("Seleccionadas");
                    OnPropertyChanged("Progreso");
                }
                Cursos.S14 = _S14;
                App.Database.InsertarL9(_Cursos);
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
                    _S14 = false;
                    OnPropertyChanged("S14");
                    OnPropertyChanged("S15");
                    OnPropertyChanged("Seleccionadas");
                    OnPropertyChanged("Progreso");
                }
                Cursos.S15 = _S15;
                App.Database.InsertarL9(_Cursos);
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
                App.Database.InsertarL9(_Cursos);
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
                App.Database.InsertarL9(_Cursos);
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
                App.Database.InsertarL9(_Cursos);
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
                App.Database.InsertarL9(_Cursos);
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
                App.Database.InsertarL9(_Cursos);
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
                App.Database.InsertarL9(_Cursos);
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
                App.Database.InsertarL9(_Cursos);
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
                App.Database.InsertarL9(_Cursos);
            }
        }
        public bool S24
        {
            get { return _S24; }
            set
            {
                _S24 = value;
                if (_S24)
                {
                    _S22 = false;
                    _S24 = false;
                    OnPropertyChanged("S22");
                    OnPropertyChanged("S23");
                    OnPropertyChanged("S24");
                    OnPropertyChanged("Seleccionadas");
                    OnPropertyChanged("Progreso");
                }
                Cursos.S24 = _S24;
                App.Database.InsertarL9(_Cursos);
            }
        }

        public bool S25
        {
            get { return _S25; }
            set
            {
                _S25 = value;
                if (_S25)
                {
                    _S16 = false;
                    _S27 = false;
                    OnPropertyChanged("S15");
                    OnPropertyChanged("S26");
                    OnPropertyChanged("S27");
                    OnPropertyChanged("Seleccionadas");
                    OnPropertyChanged("Progreso");
                }
                Cursos.S25 = _S25;
                App.Database.InsertarL9(_Cursos);
            }
        }
        public bool S26
        {
            get { return _S26; }
            set
            {
                _S26 = value;
                if (_S26)
                {
                    _S25 = false;
                    _S27 = false;
                    OnPropertyChanged("S25");
                    OnPropertyChanged("S26");
                    OnPropertyChanged("S27");
                    OnPropertyChanged("Seleccionadas");
                    OnPropertyChanged("Progreso");
                }
                Cursos.S26 = _S26;
                App.Database.InsertarL9(_Cursos);
            }
        }
        public bool S27
        {
            get { return _S27; }
            set
            {
                _S27 = value;
                if (_S27)
                {
                    _S25 = false;
                    _S26 = false;
                    OnPropertyChanged("S25");
                    OnPropertyChanged("S26");
                    OnPropertyChanged("S27");
                    OnPropertyChanged("Seleccionadas");
                    OnPropertyChanged("Progreso");
                }
                Cursos.S27 = _S27;
                App.Database.InsertarL9(_Cursos);
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
                App.Database.InsertarL9(_Cursos);
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
                App.Database.InsertarL9(_Cursos);
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
                App.Database.InsertarL9(_Cursos);
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
                App.Database.InsertarL9(_Cursos);
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
                App.Database.InsertarL9(_Cursos);
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
                App.Database.InsertarL9(_Cursos);
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
                App.Database.InsertarL9(_Cursos);
            }
        }
        public string T8
        {
            get { return _T8; }
            set
            {
                _T8 = value;
                Cursos.T8 = _T8;
                OnPropertyChanged();
                App.Database.InsertarL9(_Cursos);
            }
        }
        public string T9
        {
            get { return _T9; }
            set
            {
                _T9 = value;
                Cursos.T9 = _T9;
                OnPropertyChanged();
                App.Database.InsertarL9(_Cursos);
            }
        }
        public string T10
        {
            get { return _T10; }
            set
            {
                _T10 = value;
                Cursos.T10 = _T10;
                OnPropertyChanged();
                App.Database.InsertarL9(_Cursos);
            }
        }
        public string T11
        {
            get { return _T11; }
            set
            {
                _T11 = value;
                Cursos.T11 = _T11;
                OnPropertyChanged();
                App.Database.InsertarL9(_Cursos);
            }
        }
        public string T12
        {
            get { return _T12; }
            set
            {
                _T12 = value;
                Cursos.T12 = _T12;
                OnPropertyChanged();
                App.Database.InsertarL9(_Cursos);
            }
        }
        public string T13
        {
            get { return _T13; }
            set
            {
                _T13 = value;
                Cursos.T13 = _T13;
                OnPropertyChanged();
                App.Database.InsertarL9(_Cursos);
            }
        }
        public string T14
        {
            get { return _T14; }
            set
            {
                _T14 = value;
                Cursos.T14 = _T14;
                OnPropertyChanged();
                App.Database.InsertarL9(_Cursos);
            }
        }
        public string T15
        {
            get { return _T15; }
            set
            {
                _T15 = value;
                Cursos.T15 = _T15;
                OnPropertyChanged();
                App.Database.InsertarL9(_Cursos);
            }
        }
        public string T16
        {
            get { return _T16; }
            set
            {
                _T16 = value;
                Cursos.T16 = _T16;
                OnPropertyChanged();
                App.Database.InsertarL9(_Cursos);
            }
        }
        public string T17
        {
            get { return _T17; }
            set
            {
                _T17 = value;
                Cursos.T17 = _T17;
                OnPropertyChanged();
                App.Database.InsertarL9(_Cursos);
            }
        }
        public string T18
        {
            get { return _T18; }
            set
            {
                _T18 = value;
                Cursos.T18 = _T18;
                OnPropertyChanged();
                App.Database.InsertarL9(_Cursos);
            }
        }
        public string T19
        {
            get { return _T19; }
            set
            {
                _T19 = value;
                Cursos.T19 = _T19;
                OnPropertyChanged();
                App.Database.InsertarL9(_Cursos);
            }
        }
        public string T20
        {
            get { return _T20; }
            set
            {
                _T20 = value;
                Cursos.T20 = _T20;
                OnPropertyChanged();
                App.Database.InsertarL9(_Cursos);
            }
        }
        public string T21
        {
            get { return _T21; }
            set
            {
                _T21 = value;
                Cursos.T21 = _T21;
                OnPropertyChanged();
                App.Database.InsertarL9(_Cursos);
            }
        }
        public string T22
        {
            get { return _T22; }
            set
            {
                _T22 = value;
                Cursos.T22 = _T22;
                OnPropertyChanged();
                App.Database.InsertarL9(_Cursos);
            }
        }
        public string T23
        {
            get { return _T23; }
            set
            {
                _T23 = value;
                Cursos.T23 = _T23;
                OnPropertyChanged();
                App.Database.InsertarL9(_Cursos);
            }
        }
        public string T24
        {
            get { return _T24; }
            set
            {
                _T24 = value;
                Cursos.T24 = _T24;
                OnPropertyChanged();
                App.Database.InsertarL9(_Cursos);
            }
        }
        public string T25
        {
            get { return _T25; }
            set
            {
                _T25 = value;
                Cursos.T25 = _T25;
                OnPropertyChanged();
                App.Database.InsertarL9(_Cursos);
            }
        }
        public string T26
        {
            get { return _T26; }
            set
            {
                _T26 = value;
                Cursos.T26 = _T26;
                OnPropertyChanged();
                App.Database.InsertarL9(_Cursos);
            }
        }
        public string T27
        {
            get { return _T27; }
            set
            {
                _T27 = value;
                Cursos.T27 = _T27;
                OnPropertyChanged();
                App.Database.InsertarL9(_Cursos);
            }
        }

        public string P1
        {
            get { return _P1; }            
        }
        public string P2
        {
            get { return _P2; }
        }
        public string P3
        {
            get { return _P3; }
        }
        public string P4
        {
            get { return _P4; }
        }
        public string P5
        {
            get { return _P5; }
        }
        public string P6
        {
            get { return _P6; }
        }
        public string P7
        {
            get { return _P7; }
        }
        public string P8
        {
            get { return _P8; }
        }
        public string P9
        {
            get { return _P9; }
        }
        public string P10
        {
            get { return _P10; }
        }


        public string TB1
        {
            get { return _TB1; }
        }
        public string TB2
        {
            get { return _TB2; }
        }
        public string TB3
        {
            get { return _TB3; }
        }
        public string TB4
        {
            get { return _TB4; }
        }
        public string TB5
        {
            get { return _TB5; }
        }
        public string TB6
        {
            get { return _TB6; }
        }
        public string TB7
        {
            get { return _TB7; }
        }
        public string TB8
        {
            get { return _TB8; }
        }
        public string TB9
        {
            get { return _TB9; }
        }
        public string TB10
        {
            get { return _TB10; }
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
                App.Database.InsertarL9(_Cursos);

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
                App.Database.InsertarL9(_Cursos);
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
            App.Database.InsertarL9(_Cursos);
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
