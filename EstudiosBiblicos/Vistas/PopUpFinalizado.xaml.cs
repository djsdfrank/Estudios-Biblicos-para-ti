using System;
using System.Collections.Generic;
using EstudiosBiblicos.Services;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;

namespace EstudiosBiblicos.Vistas
{
    public partial class PopUpFinalizado : PopupPage
    {

        public PopUpFinalizado()
        {
            InitializeComponent();
        }
        
        void Button_Clicked(System.Object sender, System.EventArgs e)
        {

        }

        void Button_Clicked_1(System.Object sender, System.EventArgs e)
        {

        }

        async void Button_Clicked_2(System.Object sender, System.EventArgs e)
        {

            Device.BeginInvokeOnMainThread(() =>
            {
                try
                {
                    Acr.UserDialogs.UserDialogs.Instance.Toast($"No tienes conexion al servidor!", new TimeSpan(0, 0, 10));
                }
                catch (Exception ex)
                {
                //Debug.WriteLine(ex.ToString());
            }
            });

            //await PopupNavigation.Instance.PopAllAsync();
            //App.Current.MainPage = new ViewTickets();
        }
        async void OnTapClose(object sender, EventArgs args)
        {
            try
            {
                await PopupNavigation.Instance.PopAllAsync();
            }
            catch (Exception ex)
            {

            }


        }
        async void OnNext(object sender, EventArgs args)
        {
            try
            {
                await PopupNavigation.Instance.PopAllAsync();
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
                await PopupNavigation.Instance.PopAllAsync();
                var historyBehavior = false
              ? HistoryBehavior.ClearHistory : HistoryBehavior.Default;
                App.NavigationService.NavigateTo("WDetalleCurso", "", historyBehavior);
            }
            catch (Exception ex)
            {

            }
        }
    }
}