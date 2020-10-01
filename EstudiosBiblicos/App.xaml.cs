using System;
using Xamarin.Forms;
using EstudiosBiblicos.Services;
using EstudiosBiblicos.Vistas;
using EstudiosBiblicos.Modelos;

namespace EstudiosBiblicos
{
    public partial class App : Application
    {
        static SqlHelper database;
        public static NavigationService NavigationService { get; }
            = new NavigationService();
        public static Curso CursoSeleccionado { get; set; }
        public static MisCursos CursoSeleccionado2 { get; set; }
        public static Leccion LeccionSeleccionada { get; set; }
        public static bool CargarUsuario = false;

        public static TimeSpan Tiempo;
        public static string Puntos;
        public static string Preguntas;
        public static string Correcto;
        public static string Incorrectas;
        public static string LoadPCT;
        public static bool reloadleccion = false;

        //public static string TAG = "Super Word Search";
        // maximum attempts to find a random value that fits constraints 
        public const int MAX_RANDOM_TRIES = 100;
        // game difficulty enum
        //public enum GameDifficulty { easy, medium, hard };
        // word direction enum
        public enum WordDirection { LeftToRight, TopToBottom, RightToLeft, BottomToTop, TopLeftToBottomRight, TopRightToBottomLeft, BottomLeftToTopRight, BottomRightToTopLeft };
        // Header html page height
        public const int HEADER_HTML_HEIGHT = 100;
        // Minus points for hard level penalty
        public const int PENALTY_POINTS = 25;

        public static double _width = 1024;
        public static double _height = 768;

        public App()
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MzExNzMzQDMxMzgyZTMyMmUzME92Skx4UGRhM3FGQ21oT3V2aE9BTVdoaXJmTkkxY25CdzJVdUZ3K2RlQzA9");
            InitializeComponent();
            NavigationService.Configure("WLogin", typeof(Vistas.WLogin));
            NavigationService.Configure("WRegistro", typeof(Vistas.WRegistro));
            NavigationService.Configure("WPrimerCurso", typeof(Vistas.WPrimerCurso));
            NavigationService.Configure("WMainMenu", typeof(Vistas.WMainMenu));
            NavigationService.Configure("WPerfil", typeof(Vistas.WPerfil));
            NavigationService.Configure("WBuscar", typeof(Vistas.WBuscar));
            NavigationService.Configure("WCursoSelMult", typeof(Vistas.WCursoSelMult));
            NavigationService.Configure("WDetalleCurso", typeof(Vistas.WDetalleCurso));
            NavigationService.Configure("WDetalleCurso2", typeof(Vistas.WDetalleCurso2));
            NavigationService.Configure("WMisCursos", typeof(Vistas.WMisCursos));
            NavigationService.Configure("WResumenLeccionFinalizada", typeof(Vistas.WResumenLeccionFinalizada));
            NavigationService.Configure("WCursoSelMult2", typeof(Vistas.WCursoSelMult2));
            NavigationService.Configure("WCursoSelMult3", typeof(Vistas.WCursoSelMult3));
            NavigationService.Configure("WCursoSelMult4", typeof(Vistas.WCursoSelMult4));
            NavigationService.Configure("WCursoSelMult5", typeof(Vistas.WCursoSelMult5));
            NavigationService.Configure("WCursoSelMult6", typeof(Vistas.WCursoSelMult6));
            NavigationService.Configure("WCursoSelMult7", typeof(Vistas.WCursoSelMult7));
            NavigationService.Configure("WCursoSelMult9", typeof(Vistas.WCursoSelMult9));
            NavigationService.Configure("WZopa", typeof(Vistas.WZopa));
            NavigationService.Configure("WZopa2", typeof(Vistas.WZopa2));
            NavigationService.Configure("WCurso2SelMult1", typeof(Vistas.WCurso2SelMult1)); 


            var usuario = App.Database.GetLoggedUser();
            if(usuario == null)
                MainPage = new NavigationPage(new WLogin());
            else
                MainPage = new NavigationPage(new WMisCursos());
        }
        
        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
        public static SqlHelper Database
        {
            get
            {
                if (database == null)
                {
                    database = new SqlHelper();
                }
                return database;
            }
        }
    }
}
