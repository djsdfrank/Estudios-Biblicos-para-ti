using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using EstudiosBiblicos.Modelos;
using Xamarin.Forms;

namespace EstudiosBiblicos.ViewModels
{
    public class VMPCurso : VMBase
    {
        public VMPCurso(INavigation navService) : base(navService)
        {
        }

        public async Task Load()
        {
            //var transac = new TransaccionesServices();
            //var listado = await transac.GetOsiPartes(Int32.Parse(Configurations.IDEmpresaActual));
            //var listado = App.Database.GetOsiPartes(Int32.Parse(Configurations.IDEmpresaActual), Int32.Parse(Configurations.IDUsuarioActual));
            //if (listado != null)
            //    this.OsiPartes = new ObservableCollection<OsiParte>(listado);
            //OnPropertyChanged("IPBBDD");
            //OnPropertyChanged("NombreBBDD");
            //OnPropertyChanged("IDEmpresaAct");
            //OnPropertyChanged("NombreEmpleado");
            var listado = App.Database.GetPrimerCursos();
            if (listado != null)
                this.Cursos = new ObservableCollection<PrimerCurso>(listado);


        }
        private ObservableCollection<PrimerCurso> _Cursos;
        public ObservableCollection<PrimerCurso> Cursos
        {
            get { return _Cursos; }
            set
            {
                _Cursos = value;
                OnPropertyChanged();
            }
        }
        public async Task ReLoad()
        {
            OnPropertyChanged("Cursos");
        }
    }
}