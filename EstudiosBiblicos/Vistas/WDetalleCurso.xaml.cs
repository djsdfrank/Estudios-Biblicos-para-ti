using System;
using System.Collections.Generic;
using EstudiosBiblicos.Modelos;
using EstudiosBiblicos.Services;
using EstudiosBiblicos.ViewModels;
using Xamarin.Forms;

namespace EstudiosBiblicos.Vistas
{
    public partial class WDetalleCurso : ContentPage
    {
        ViewCell lastCell;
        public WDetalleCurso()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            this.BindingContext = new VMDetCurso(Navigation);
        }
        protected async override void OnAppearing()
        {
            await ((VMDetCurso)this.BindingContext).Load();
        }
        private void ViewCell_Tapped(object sender, System.EventArgs e)
        {
            //if (lastCell != null)
            //    lastCell.View.BackgroundColor = Color.Transparent;
            var viewCell = (ViewCell)sender;
            if (viewCell.View != null)
            {
                //viewCell.View.BackgroundColor = Color.White;
                lastCell = viewCell;
            }
            //LvMesas.SelectedItem = null;
            //LvMesas.SelectedItem = viewCell.BindingContext;

            Leccion contex = (Leccion)viewCell.BindingContext;

            try
            {
                App.LeccionSeleccionada = contex;
                //App.ParteSelected = (Cursos)LvMesas.SelectedItem;
                var historyBehavior = false
                ? HistoryBehavior.ClearHistory : HistoryBehavior.Default;

                App.NavigationService.NavigateTo("WDetalleCurso2", "", historyBehavior);
            }
            catch (Exception ex)
            {

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