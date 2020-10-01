using System;
using System.Collections.Generic;
using EstudiosBiblicos.Modelos;
using EstudiosBiblicos.Services;
using EstudiosBiblicos.ViewModels;
using Xamarin.Forms;

namespace EstudiosBiblicos.Vistas
{
    public partial class WDetalleCurso2 : ContentPage
    {
        ViewCell lastCell;
        public WDetalleCurso2()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            lblmultpreguntas.Text = App.LeccionSeleccionada.Preguntas.ToString() + " preguntas";
            lblmultTiempo.Text = App.LeccionSeleccionada.Duracion.ToString() + " min";
            lblTimesopa.Text = "30 min";
            if (App.LeccionSeleccionada.IdCurso == 2)
                Grid2.IsVisible = false;
        }
        
        
        async void OnTapPreguntas(object sender, EventArgs args)
        {
            try
            {
                var historyBehavior = false
              ? HistoryBehavior.ClearHistory : HistoryBehavior.Default;
               switch(App.LeccionSeleccionada.IdLeccion)
                {
                    case 1:
                        App.NavigationService.NavigateTo("WCursoSelMult", "", historyBehavior);
                        break;
                    case 2:
                        App.NavigationService.NavigateTo("WCursoSelMult2", "", historyBehavior);
                        break;
                    case 3:
                        App.NavigationService.NavigateTo("WCursoSelMult3", "", historyBehavior);
                        break;
                    case 4:
                        App.NavigationService.NavigateTo("WCursoSelMult4", "", historyBehavior);
                        break;
                    case 5:
                        App.NavigationService.NavigateTo("WCursoSelMult5", "", historyBehavior);
                        break;
                    case 6:
                        App.NavigationService.NavigateTo("WCursoSelMult6", "", historyBehavior);
                        break;
                    case 7:
                        App.NavigationService.NavigateTo("WCursoSelMult7", "", historyBehavior);
                        break;
                    case 8:
                        App.NavigationService.NavigateTo("WCursoSelMult9", "", historyBehavior);
                        break;
                    case 9:
                        App.NavigationService.NavigateTo("WCurso2SelMult1", "", historyBehavior);
                        break;
                    case 10:
                        App.NavigationService.NavigateTo("WCurso2SelMult1", "", historyBehavior);
                        break;
                    case 11:
                        App.NavigationService.NavigateTo("WCurso2SelMult1", "", historyBehavior);
                        break;
                    case 12:
                        App.NavigationService.NavigateTo("WCurso2SelMult1", "", historyBehavior);
                        break;
                    case 13:
                        App.NavigationService.NavigateTo("WCurso2SelMult1", "", historyBehavior);
                        break;
                    case 14:
                        App.NavigationService.NavigateTo("WCurso2SelMult1", "", historyBehavior);
                        break;
                    case 15:
                        App.NavigationService.NavigateTo("WCurso2SelMult1", "", historyBehavior);
                        break;
                    case 16:
                        App.NavigationService.NavigateTo("WCurso2SelMult1", "", historyBehavior);
                        break;
                    case 17:
                        App.NavigationService.NavigateTo("WCurso2SelMult1", "", historyBehavior);
                        break;
                    case 18:
                        App.NavigationService.NavigateTo("WCurso2SelMult1", "", historyBehavior);
                        break;
                    default:
                        break;
                }
               
            }
            catch (Exception ex)
            {

            }
        }
        async void OnTapZopa(object sender, EventArgs args)
        {
            try
            {
                var historyBehavior = false
              ? HistoryBehavior.ClearHistory : HistoryBehavior.Default;
                if(App.LeccionSeleccionada.IdCurso == 1)
                App.NavigationService.NavigateTo("WZopa2", "", historyBehavior);
            }
            catch (Exception ex)
            {

            }
        }
        protected override void OnSizeAllocated(double width, double height)
        {
            try
            {
                base.OnSizeAllocated(width, height); // must be called
                App._width = width;
                App._height = height;
            }
            catch (Exception ex)
            {
                //Logger.Instance.Error($"OnSizeAllocated exception, {ex.Message}");
            }
        }
        async void OnTapPerfil(object sender, EventArgs args)
        {
            try
            {
                var historyBehavior = false
                ? HistoryBehavior.ClearHistory : HistoryBehavior.Default;

                App.NavigationService.NavigateTo("WPerfil", "", historyBehavior);
            }
            catch (Exception ex)
            {

            }
        }
        async void OnTapMenuBuscar(object sender, EventArgs args)
        {
            try
            {
                var historyBehavior = false
                ? HistoryBehavior.ClearHistory : HistoryBehavior.Default;

                App.NavigationService.NavigateTo("WBuscar", "", historyBehavior);
            }
            catch (Exception ex)
            {

            }
        }
        async void OnTapMenuMisCursos(object sender, EventArgs args)
        {
            try
            {
                var historyBehavior = false
                ? HistoryBehavior.ClearHistory : HistoryBehavior.Default;

                App.NavigationService.NavigateTo("WMisCursos", "", historyBehavior);
            }
            catch (Exception ex)
            {

            }
        }
    }
}