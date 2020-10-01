using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using EstudiosBiblicos.Modelos;
using Xamarin.Forms;

namespace EstudiosBiblicos.ViewModels
{
    public class VMDetCurso : VMBase
    {
        public VMDetCurso(INavigation navService) : base(navService)
        {
        }
        public string NombreCurso { get; set; }
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
            int id;
            if (App.CursoSeleccionado != null)
            {
                id = App.CursoSeleccionado.IdCurso;
                NombreCurso = App.CursoSeleccionado.Nombre;
            }
            else
            { id = App.CursoSeleccionado2.IdCurso;
                NombreCurso = App.CursoSeleccionado2.Nombre;
            }
            var listado = App.Database.GetLeccionesById(id);
            if (listado != null)
                this.Lecciones = new ObservableCollection<Leccion>(listado);
     
            OnPropertyChanged("NombreCurso");

        }
        private ObservableCollection<Leccion> _Lecciones;
        public ObservableCollection<Leccion> Lecciones
        {
            get { return _Lecciones; }
            set
            {
                _Lecciones = value;
                OnPropertyChanged();
            }
        }
        public async Task ReLoad()
        {
            OnPropertyChanged("Cursos");
        }
    }
}