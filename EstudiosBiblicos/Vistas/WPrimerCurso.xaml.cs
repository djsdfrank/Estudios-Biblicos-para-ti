using System;
using System.Collections.Generic;
using EstudiosBiblicos.Modelos;
using EstudiosBiblicos.Services;
using EstudiosBiblicos.ViewModels;
using Xamarin.Forms;

namespace EstudiosBiblicos.Vistas
{
    public class MenuItemsa
    {
        public int Cod { get; set; }
        public string Imagen { get; set; }
        public string Titulo { get; set; }
        public string Texto { get; set; }

        
    }
    public partial class WPrimerCurso : ContentPage
    {
        public WPrimerCurso()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);            
            this.BindingContext = new VMPCurso(Navigation);
        }
        protected async override void OnAppearing()
        {
            await ((VMPCurso)this.BindingContext).Load();
        }
        void Button_Clicked(System.Object sender, System.EventArgs e)
        {
            try
            {
                Configurations.EsPrimeraVez = "No";
                var historyBehavior = false
                ? HistoryBehavior.ClearHistory : HistoryBehavior.Default;

                App.NavigationService.NavigateTo("WMisCursos", "", historyBehavior);
            }
            catch (Exception ex)
            {

            }
        }
        async void OnTapSelected(object sender, EventArgs args)
        {
            

            try
            {
                var grd = (Grid)sender;
                PrimerCurso contex = (PrimerCurso)grd.BindingContext;
                if (contex.Seleccionado == false)
                {
                    Label stack = grd.FindByName<Label>("lblselected");
                    stack.IsVisible = true;
                    contex.Seleccionado = true;                    
                }
                else
                {
                    Label stack = grd.FindByName<Label>("lblselected");
                    stack.IsVisible = false;
                    contex.Seleccionado = false;
                }
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
                    Imagen = contex.Imagen,
                    LeccionesTerminadas = 0
                };
                App.Database.InsertarMisCursos(c1);
            }
            catch (Exception ex)
            {

            }
        }

        async void OnTapMasAdelante(object sender, EventArgs args)
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
