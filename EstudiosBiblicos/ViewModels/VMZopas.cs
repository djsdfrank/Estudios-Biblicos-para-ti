using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using EstudiosBiblicos.Modelos;
using Xamarin.Forms;

namespace EstudiosBiblicos.ViewModels
{
    public class VMZopas : VMBase
    {
        public VMZopas(INavigation navService) : base(navService)
        {
        }

        public async Task Load()
        {
            //OnPropertyChanged("IPBBDD");
            //OnPropertyChanged("NombreBBDD");
            //OnPropertyChanged("IDEmpresaAct");
            //OnPropertyChanged("NombreEmpleado");

            var listado = App.Database.GetLetras(1);
            if (listado != null)
            {
                //this.Cursos = new ObservableCollection<Letras>(listado);
                this.Letras = listado.Palabras.Split(',');
            }
            var listado2 = App.Database.GetLetrasP(1);
            if (listado2 != null)
            {
                this.LetrasP = new ObservableCollection<Letra>(listado2);
            }            
        }
        private ObservableCollection<Letras> _Cursos;
        public ObservableCollection<Letras> Cursos
        {
            get { return _Cursos; }
            set
            {
                _Cursos = value;
                OnPropertyChanged();
            }
        }
        private ObservableCollection<Letra> _letrasP;
        public ObservableCollection<Letra> LetrasP
        {
            get { return _letrasP; }
            set
            {
                _letrasP = value;
                OnPropertyChanged();
            }
        }
        private string[] _Letras;
        public string[] Letras
        {
            get { return _Letras; }
            set
            {
                _Letras = value;
                OnPropertyChanged();
            }
        }
        Command _Marcar;
        public Command Marcar
        {
            get
            {
                return _Marcar ?? (_Marcar = new Command<string> (async (x) =>
                {
                    int i = Int32.Parse(x);
                    LetrasP[i].Temporal = !LetrasP[i].Temporal;
                    App.Database.InsertarLetrasP(LetrasP[i]);
                    OnPropertyChanged("LetrasP");
                }));
            }
        }
    }
}