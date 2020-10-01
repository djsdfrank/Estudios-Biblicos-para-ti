using System;
using System.Collections.Generic;
using EstudiosBiblicos.Modelos;
using EstudiosBiblicos.Services;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;

namespace EstudiosBiblicos.Vistas
{
    public partial class WResumenLeccionFinalizada : ContentPage
    {
        public WResumenLeccionFinalizada()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            try
            {
                string str = App.Tiempo.ToString();
                var strs = str.Split('.');
                LBTiempo.Text = strs[0];
            }
            catch (Exception ex)
            {
                LBTiempo.Text = "";
            }
            LBPuntos.Text = App.Puntos;
            LBPreguntas.Text = App.Preguntas;
            LBCorrecto.Text = App.Correcto;
            LBIncorrecto.Text = App.Incorrectas;
            lbPct.Text = App.LoadPCT;
            LbNombre.Text = App.LeccionSeleccionada.Nombre;
        }
        async void OnNext(object sender, EventArgs args)
        {
            try
            {
                var historyBehavior = false
              ? HistoryBehavior.ClearHistory : HistoryBehavior.Default;
                App.NavigationService.NavigateTo("WDetalleCurso", "", historyBehavior);
            }
            catch (Exception ex)
            {

            }
        }

        async void btn_Clicked(System.Object sender, System.EventArgs e)
        {
            try
            {
                var historyBehavior = false
              ? HistoryBehavior.ClearHistory : HistoryBehavior.Default;
                App.NavigationService.NavigateTo("WDetalleCurso", "", historyBehavior);
            }
            catch (Exception ex)
            {

            }
        }
        
        async void OnReload(object sender, EventArgs args)
        {
            try
            {
                App.reloadleccion = true;
                var historyBehavior = false
              ? HistoryBehavior.ClearHistory : HistoryBehavior.Default;
                App.NavigationService.NavigateTo("WCursoSelMult", "", historyBehavior);
            }
            catch (Exception ex)
            {

            }
        }
        
        async void btnreload_Clicked(System.Object sender, System.EventArgs e)
        {
            try
            {
                App.reloadleccion = true;
                var historyBehavior = false
              ? HistoryBehavior.ClearHistory : HistoryBehavior.Default;
                App.NavigationService.NavigateTo("WCursoSelMult", "", historyBehavior);
            }
            catch (Exception ex)
            {

            }
        }
    }
}
