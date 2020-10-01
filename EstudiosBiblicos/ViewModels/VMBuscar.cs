using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Acr.UserDialogs;
using EstudiosBiblicos.Modelos;
using Xamarin.Forms;

namespace EstudiosBiblicos.ViewModels
{
    public class VMBuscar : VMBase
    {
        public VMBuscar(INavigation navService) : base(navService)
        {
        }
        
        public async Task Load()
        {            
            UserDialogs.Instance.ShowLoading("");
                
            //OnPropertyChanged("IPBBDD");
            //OnPropertyChanged("NombreBBDD");
            //OnPropertyChanged("IDEmpresaAct");
            //OnPropertyChanged("NombreEmpleado");

            var listado = App.Database.GetAllCursos();
            if (listado != null)
                this.Cursos = new ObservableCollection<Curso>(listado);
            UserDialogs.Instance.HideLoading();
        }
        private ObservableCollection<Curso> _Cursos;
        public ObservableCollection<Curso> Cursos
        {
            get { return _Cursos; }
            set
            {
                _Cursos = value;
                OnPropertyChanged();
            }
        }
    }
}