using System;
using System.Collections.Generic;
using EstudiosBiblicos.Services;
using Xamarin.Forms;

namespace EstudiosBiblicos.Vistas
{
    public partial class WPerfil : ContentPage
    {
        public WPerfil()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            var usuario = App.Database.GetLoggedUser();
            if (usuario != null)
            {
                tbNombreCompleto.Text = usuario.nombre + " " + usuario.apellido;
                tbCorreo.Text = usuario.correo;
                tbtelefono.Text = usuario.telefono;
                tbfechanacimiento.Text = usuario.fecha_nacimiento.ToShortDateString();
            }
        }
        async void OnTapGuardar(object sender, EventArgs args)
        {
            App.CargarUsuario = true;
            try
            {
                var historyBehavior = false
                ? HistoryBehavior.ClearHistory : HistoryBehavior.Default;

                App.NavigationService.NavigateTo("WRegistro", "", historyBehavior);
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
        
        async void OnTapCerrarsesion(object sender, EventArgs args)
        {
            Acr.UserDialogs.UserDialogs.Instance.Confirm(new Acr.UserDialogs.ConfirmConfig
            {
                CancelText = "No",
                Message = $"Esta seguro que desea cerrar la sesion?",
                OkText = "Si",
                OnAction = async (r) =>
                {
                    if (r)
                    {
                        App.Database.CerrarSesion();
                        try
                        {
                            var historyBehavior = false
                            ? HistoryBehavior.ClearHistory : HistoryBehavior.Default;

                            App.NavigationService.NavigateTo("WLogin", "", historyBehavior);
                        }
                        catch (Exception ex)
                        {

                        }
                    }
                },
                Title = "Cerrar Sesion"
            });            
        }
        void btncerrarcesion_Clicked(System.Object sender, System.EventArgs e)
        {
            Acr.UserDialogs.UserDialogs.Instance.Confirm(new Acr.UserDialogs.ConfirmConfig
            {
                CancelText = "No",
                Message = $"Esta seguro que desea cerrar la sesion?",
                OkText = "Si",
                OnAction = async (r) =>
                {
                    if (r)
                    {
                        App.Database.CerrarSesion();
                        try
                        {
                            var historyBehavior = false
                            ? HistoryBehavior.ClearHistory : HistoryBehavior.Default;

                            App.NavigationService.NavigateTo("WLogin", "", historyBehavior);
                        }
                        catch (Exception ex)
                        {

                        }
                    }
                },
                Title = "Cerrar Sesion"
            });
        }

        void btneditar_Clicked(System.Object sender, System.EventArgs e)
        {
            App.CargarUsuario = true;
            try
            {
                var historyBehavior = false
                ? HistoryBehavior.ClearHistory : HistoryBehavior.Default;

                App.NavigationService.NavigateTo("WRegistro", "", historyBehavior);
            }
            catch (Exception ex)
            {

            }
        }
    }
}
