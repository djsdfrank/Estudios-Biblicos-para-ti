using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Acr.UserDialogs;
using EstudiosBiblicos.Modelos;
using Xamarin.Forms;

namespace EstudiosBiblicos.ViewModels
{
    public class VMMisCursos : VMBase
    {
        public VMMisCursos(INavigation navService) : base(navService)
        {
        }

        public async Task Load()
        {
            UserDialogs.Instance.ShowLoading("");
                
            //OnPropertyChanged("IPBBDD");
            //OnPropertyChanged("NombreBBDD");
            //OnPropertyChanged("IDEmpresaAct");
            //OnPropertyChanged("NombreEmpleado");

            var listado = App.Database.GetMyCursos();
            if (listado != null)
                this.Cursos = new ObservableCollection<MisCursos>(listado);
            UserDialogs.Instance.HideLoading();
        }
        private ObservableCollection<MisCursos> _Cursos;
        public ObservableCollection<MisCursos> Cursos
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