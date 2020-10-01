using System;
using System.Collections.Generic;
using EstudiosBiblicos.Modelos;
using EstudiosBiblicos.Services;
using EstudiosBiblicos.ViewModels;
using Xamarin.Forms;

namespace EstudiosBiblicos.Vistas
{
    public partial class WBuscar : ContentPage
    {
        ViewCell lastCell;
        public WBuscar()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            this.BindingContext = new VMBuscar(Navigation);
        }
        protected async override void OnAppearing()
        {
            await ((VMBuscar)this.BindingContext).Load();
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
            
            Curso contex = (Curso)viewCell.BindingContext;
            
            try
            {
                App.CursoSeleccionado = contex;
                MisCursos c1 = new MisCursos()
                {
                    IdCurso = contex.IdCurso,
                    Nombre = contex.Nombre
                        ,
                    Descripcion = contex.Descripcion,
                    Duracion = contex.Duracion,
                    Estatus = 1
                        ,
                    Lecciones = contex.Lecciones,
                    Imagen = contex.Imagen
                };
                App.Database.InsertarMisCursos(c1);
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

            Curso contex = (Curso)viewCell.BindingContext;

            try
            {
                App.CursoSeleccionado = contex;
                //App.ParteSelected = (Cursos)LvMesas.SelectedItem;
                MisCursos c1 = new MisCursos()
                {
                    IdCurso = contex.IdCurso,
                    Nombre = contex.Nombre
                        ,
                    Descripcion = contex.Descripcion,
                    Duracion = contex.Duracion,
                    Estatus = 1
                        ,
                    Lecciones = contex.Lecciones,
                    Imagen = contex.Imagen
                };
                App.Database.InsertarMisCursos(c1);
                var historyBehavior = false
                ? HistoryBehavior.ClearHistory : HistoryBehavior.Default;

                App.NavigationService.NavigateTo("WDetalleCurso", "", historyBehavior);
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
    }
}
