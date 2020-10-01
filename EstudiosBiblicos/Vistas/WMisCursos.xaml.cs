using System;
using System.Collections.Generic;
using EstudiosBiblicos.Modelos;
using EstudiosBiblicos.Services;
using EstudiosBiblicos.ViewModels;
using Xamarin.Forms;

namespace EstudiosBiblicos.Vistas
{
    public partial class WMisCursos : ContentPage
    {
        ViewCell lastCell;
        public WMisCursos()
        {
            InitializeComponent();

            NavigationPage.SetHasNavigationBar(this, false);
            this.BindingContext = new VMMisCursos(Navigation);
        }
        protected async override void OnAppearing()
        {
            await ((VMMisCursos)this.BindingContext).Load();
        }
        void LvCursos_ItemSelected(System.Object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null) return;
            try
            {
                //App.ParteSelected = (OsiParte)e.SelectedItem;
                //var historyBehavior = false
                //? HistoryBehavior.ClearHistory : HistoryBehavior.Default;

                //App.NavigationService.NavigateTo("ViewDetalle", "", historyBehavior);

            }
            catch (Exception ex)
            {

            }
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

            MisCursos contex = (MisCursos)viewCell.BindingContext;

            try
            {
                App.CursoSeleccionado2 = contex;
                App.CursoSeleccionado = null;
                //App.ParteSelected = (Cursos)LvMesas.SelectedItem;
                var historyBehavior = false
                ? HistoryBehavior.ClearHistory : HistoryBehavior.Default;

                App.NavigationService.NavigateTo("WDetalleCurso", "", historyBehavior);
            }
            catch (Exception ex)
            {

            }
        }

        void btnIniciar_Clicked(System.Object sender, System.EventArgs e)
        {
            //if (lastCell != null)
            //    lastCell.View.BackgroundColor = Color.Transparent;
            var viewCell = (Button)sender;

            //LvMesas.SelectedItem = null;
            //LvMesas.SelectedItem = viewCell.BindingContext;

            MisCursos contex = (MisCursos)viewCell.BindingContext;

            try
            {
                App.CursoSeleccionado2 = contex;
                App.CursoSeleccionado = null;
                //App.ParteSelected = (Cursos)LvMesas.SelectedItem;
                var historyBehavior = false
                ? HistoryBehavior.ClearHistory : HistoryBehavior.Default;

                App.NavigationService.NavigateTo("WDetalleCurso", "", historyBehavior);
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
    }
}