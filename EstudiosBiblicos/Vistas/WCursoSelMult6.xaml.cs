using System;
using System.Collections.Generic;
using EstudiosBiblicos.Services;
using EstudiosBiblicos.ViewModels;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;

namespace EstudiosBiblicos.Vistas
{
    public partial class WCursoSelMult6 : ContentPage
    {
        ViewCell lastCell;
        public WCursoSelMult6()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            this.BindingContext = new VML6(Navigation);
            var usuario = App.LeccionSeleccionada;
            if (usuario != null)
            {
                //_id = usuario.id_usuario;
                TbCurso.Text = usuario.Nombre;
                //tbApellido.Text = usuario.apellido;
                //tbCorreo.Text = usuario.correo;
                //tbcontrasena.Text = usuario.contrasena;
                //tbtelefono.Text = usuario.telefono;
                //tbfechanacimiento.Text = usuario.fecha_nacimiento.ToShortDateString();
            }

        }
        protected async override void OnAppearing()
        {
            await ((VML6)this.BindingContext).Load();
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
            try
            {
                //App.ParteSelected = (Cursos)LvMesas.SelectedItem;
                var historyBehavior = false
                ? HistoryBehavior.ClearHistory : HistoryBehavior.Default;

                App.NavigationService.NavigateTo("ViewDetalle", "", historyBehavior);
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

                App.NavigationService.NavigateTo("VMMisCursos", "", historyBehavior);
            }
            catch (Exception ex)
            {

            }
        }
        async void OnTapGuardar(object sender, EventArgs args)
        {
            Textobiblico(1);
        }
        void btn1_Clicked(System.Object sender, System.EventArgs e)
        {
            Textobiblico(1);
        }
        async void OnTapTB1(object sender, EventArgs args)
        {
            Textobiblico(1);
        }


        void btn2_Clicked(System.Object sender, System.EventArgs e)
        {
            Textobiblico(2);
        }
        async void OnTapTB2(object sender, EventArgs args)
        {
            Textobiblico(2);
        }

        void btn3_Clicked(System.Object sender, System.EventArgs e)
        {
            Textobiblico(3);
        }
        async void OnTapTB3(object sender, EventArgs args)
        {
            Textobiblico(3);
        }

        void btn4_Clicked(System.Object sender, System.EventArgs e)
        {
            Textobiblico(4);
        }
        async void OnTapTB4(object sender, EventArgs args)
        {
            Textobiblico(4);
        }

        void btn5_Clicked(System.Object sender, System.EventArgs e)
        {
            Textobiblico(5);
        }
        async void OnTapTB5(object sender, EventArgs args)
        {
            Textobiblico(5);
        }

        void btn6_Clicked(System.Object sender, System.EventArgs e)
        {
            Textobiblico(6);
        }
        async void OnTapTB6(object sender, EventArgs args)
        {
            Textobiblico(6);
        }

        void btn7_Clicked(System.Object sender, System.EventArgs e)
        {
            Textobiblico(7);
        }
        async void OnTapTB7(object sender, EventArgs args)
        {
            Textobiblico(7);
        }

        void btn8_Clicked(System.Object sender, System.EventArgs e)
        {
            Textobiblico(8);
        }
        async void OnTapTB8(object sender, EventArgs args)
        {
            Textobiblico(8);
        }

        void btn9_Clicked(System.Object sender, System.EventArgs e)
        {
            Textobiblico(9);
        }
        async void OnTapTB9(object sender, EventArgs args)
        {
            Textobiblico(9);
        }

        void btn10_Clicked(System.Object sender, System.EventArgs e)
        {
            Textobiblico(10);
        }
        async void OnTapTB10(object sender, EventArgs args)
        {
            Textobiblico(10);
        }
        void Textobiblico(int Id)
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                try
                {
                    PopupNavigation.Instance.PushAsync(new Vistas.PopUpTextoBiblico(Id));
                }
                catch (Exception ex)
                {
                    //Debug.WriteLine(ex.ToString());
                }
            });
        }
        void btnfinalizar_Clicked(System.Object sender, System.EventArgs e)
        {
            if (PB1.Percentage < 1)
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    try
                    {
                        //Acr.UserDialogs.UserDialogs.Instance.Toast("El campo del correo electronico es obligatorio.", new TimeSpan(0, 0, 5));
                        Acr.UserDialogs.UserDialogs.Instance.Alert("Debe completar el curso para poder finalizar!", "Alerta", null);
                    }
                    catch (Exception ex)
                    {
                        //Debug.WriteLine(ex.ToString());
                    }
                });
                return;
            }
            Device.BeginInvokeOnMainThread(() =>
            {
                try
                {
                    ((VML6)this.BindingContext).Finalizar();
                    PopupNavigation.Instance.PushAsync(new Vistas.PopUpFinalizado());
                }
                catch (Exception ex)
                {
                    //Debug.WriteLine(ex.ToString());
                }
            });
        }
        async void OnTapGuardar2(object sender, EventArgs args)
        {
            if (PB1.Percentage < 1)
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    try
                    {
                        //Acr.UserDialogs.UserDialogs.Instance.Toast("El campo del correo electronico es obligatorio.", new TimeSpan(0, 0, 5));
                        Acr.UserDialogs.UserDialogs.Instance.Alert("Debe completar el curso para poder finalizar!", "Alerta", null);
                    }
                    catch (Exception ex)
                    {
                        //Debug.WriteLine(ex.ToString());
                    }
                });
                return;
            }
            Device.BeginInvokeOnMainThread(() =>
            {
                try
                {
                    ((VML6)this.BindingContext).Finalizar();
                    PopupNavigation.Instance.PushAsync(new Vistas.PopUpFinalizado());
                }
                catch (Exception ex)
                {
                    //Debug.WriteLine(ex.ToString());
                }
            });
        }
    }
}
