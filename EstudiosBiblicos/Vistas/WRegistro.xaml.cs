using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Input;
using EstudiosBiblicos.Services;
using Xamarin.Forms;

namespace EstudiosBiblicos.Vistas
{
    public partial class WRegistro : ContentPage
    {
        private int _id;
        private DateTime _SelDate;
        public WRegistro()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            DPFecha.MinimumDate = new DateTime(1960, 1, 1);

            if (App.CargarUsuario)
            {
                var usuario = App.Database.GetLoggedUser();
                if (usuario != null)
                {
                    _id = usuario.id_usuario;
                    tbNombre.Text = usuario.nombre;
                    tbApellido.Text = usuario.apellido;
                    tbCorreo.Text = usuario.correo;
                    tbcontrasena.Text = usuario.contrasena;
                    tbtelefono.Text = usuario.telefono;
                    tbfechanacimiento.Text = usuario.fecha_nacimiento.ToShortDateString();
                }
            }
        }
        
        async void OnTapGuardar(object sender, EventArgs args)
        {


            var _Nombre = tbNombre.Text;
            var _Apellido = tbApellido.Text;
            var _Correo = tbCorreo.Text;
            var _Password = tbcontrasena.Text;
            var _Telefono = tbtelefono.Text;
            if (_Correo == "" || _Password == "" ||
                (_Correo == "" && _Password == ""))
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    try
                    {
                        //Acr.UserDialogs.UserDialogs.Instance.Toast("Todos los campos son obligatorios!", new TimeSpan(0, 0, 5));
                        Acr.UserDialogs.UserDialogs.Instance.Alert("Todos los campos son obligatorios!", "Alerta", null);
                    }
                    catch (Exception ex)
                    {
                        //Debug.WriteLine(ex.ToString());
                    }
                });
                return;
            }
            if (String.IsNullOrWhiteSpace(_Correo))
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    try
                    {
                        //Acr.UserDialogs.UserDialogs.Instance.Toast("El campo del correo electronico es obligatorio.", new TimeSpan(0, 0, 5));
                        Acr.UserDialogs.UserDialogs.Instance.Alert("El campo del correo electronico es obligatorio.", "Alerta", null);
                    }
                    catch (Exception ex)
                    {
                        //Debug.WriteLine(ex.ToString());
                    }
                });
                return;
            }
            else
            {
                //Valida que el formato del correo sea valido
                bool isEmail = Regex.IsMatch(_Correo, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase);
                if (!isEmail)
                {
                    Device.BeginInvokeOnMainThread(() =>
                    {
                        try
                        {
                            Acr.UserDialogs.UserDialogs.Instance.Toast("El formato del correo electrónico es incorrecto, intente de nuevo.", new TimeSpan(0, 0, 5));

                        }
                        catch (Exception ex)
                        {
                            //Debug.WriteLine(ex.ToString());
                        }
                    });
                    return;
                }
            }

            if (String.IsNullOrWhiteSpace(_Password))
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    try
                    {
                        //Acr.UserDialogs.UserDialogs.Instance.Toast("El campo del correo electronico es obligatorio.", new TimeSpan(0, 0, 5));
                        Acr.UserDialogs.UserDialogs.Instance.Alert("El campo contrasena es obligatoria.", "Alerta", null);
                    }
                    catch (Exception ex)
                    {
                        //Debug.WriteLine(ex.ToString());
                    }
                });
                return;
            }
            //if (String.IsNullOrWhiteSpace(_Nombre))
            //{
            //    Device.BeginInvokeOnMainThread(() =>
            //    {
            //        try
            //        {
            //            //Acr.UserDialogs.UserDialogs.Instance.Toast("El campo del correo electronico es obligatorio.", new TimeSpan(0, 0, 5));
            //            Acr.UserDialogs.UserDialogs.Instance.Alert("El campo nombre es obligatoria.", "Alerta", null);
            //        }
            //        catch (Exception ex)
            //        {
            //            //Debug.WriteLine(ex.ToString());
            //        }
            //    });
            //    return;
            //}

            //if (String.IsNullOrWhiteSpace(_Apellido))
            //{
            //    Device.BeginInvokeOnMainThread(() =>
            //    {
            //        try
            //        {
            //            //Acr.UserDialogs.UserDialogs.Instance.Toast("El campo del correo electronico es obligatorio.", new TimeSpan(0, 0, 5));
            //            Acr.UserDialogs.UserDialogs.Instance.Alert("El campo apellido es obligatoria.", "Alerta", null);
            //        }
            //        catch (Exception ex)
            //        {
            //            //Debug.WriteLine(ex.ToString());
            //        }
            //    });
            //    return;
            //}
            //if (String.IsNullOrWhiteSpace(_Telefono))
            //{
            //    Device.BeginInvokeOnMainThread(() =>
            //    {
            //        try
            //        {
            //            //Acr.UserDialogs.UserDialogs.Instance.Toast("El campo del correo electronico es obligatorio.", new TimeSpan(0, 0, 5));
            //            Acr.UserDialogs.UserDialogs.Instance.Alert("El campo telefono es obligatoria.", "Alerta", null);
            //        }
            //        catch (Exception ex)
            //        {
            //            //Debug.WriteLine(ex.ToString());
            //        }
            //    });
            //    return;
            //}

            bool usuario;
            if (App.CargarUsuario)
            {   usuario = await App.Database.UpdtUsuario(_id, _Nombre, _Apellido, _Correo, _Password, _Telefono, _SelDate);
                App.Database.UpdateDateLoggedUser(_SelDate);
            }
            else
            {
                usuario = await App.Database.InsertarUsuario(_Nombre, _Apellido, _Correo, _Password, _Telefono, _SelDate);
            }
            if (usuario)
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    try
                    {
                        //Acr.UserDialogs.UserDialogs.Instance.Toast("Ha sido resgistrado correctamente!", new TimeSpan(0, 0, 5));
                        Acr.UserDialogs.UserDialogs.Instance.Alert("Ha sido resgistrado correctamente!", "Alerta", null);
                    }
                    catch (Exception ex)
                    {
                        //Debug.WriteLine(ex.ToString());
                    }
                });
                //_Nombre = "";
                _Correo = "";
                _Password = "";


                var historyBehavior = false
              ? HistoryBehavior.ClearHistory : HistoryBehavior.Default;


                if (Configurations.EsPrimeraVez == "Si")
                {
                    App.NavigationService.NavigateTo("WPrimerCurso", "", historyBehavior);
                }
                else
                if (App.CargarUsuario)
                {
                    App.NavigationService.NavigateTo("WMisCursos", "", historyBehavior);
                }
                else
                {
                    App.NavigationService.NavigateTo("WLogin", "", historyBehavior);
                }
            }
        }

        void Button_Clicked(System.Object sender, System.EventArgs e)
        {
        }
        async void OnTapFecha(object sender, EventArgs args)
        {
            try
            {
                DPFecha.Date = Convert.ToDateTime(tbfechanacimiento.Text);
            }
            catch (Exception ex)
            {
                DPFecha.Date = DateTime.Now;
            }
            DPFecha.IsOpen = true;
        }

        void DPFecha_DateSelected(System.Object sender, Syncfusion.XForms.Pickers.DateChangedEventArgs e)
        {
            _SelDate = DPFecha.Date;
            tbfechanacimiento.Text = _SelDate.Date.ToShortDateString(); 
        }
    }
}
