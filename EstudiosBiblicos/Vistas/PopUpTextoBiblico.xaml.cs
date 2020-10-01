using System;
using System.Collections.Generic;
using EstudiosBiblicos.Modelos;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;

namespace EstudiosBiblicos.Vistas
{
    public partial class PopUpTextoBiblico : PopupPage
    {
        
        public PopUpTextoBiblico(int id)
        {
            InitializeComponent();
            TextoBiblico tb =  App.Database.GetTB(id);
            tbtexto.Text = tb.Descripcion;
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

        void btnprograma_Clicked(System.Object sender, System.EventArgs e)
        {
            
        }
    }
}