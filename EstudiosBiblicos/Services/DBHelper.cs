using System;
using EstudiosBiblicos.Modelos;
using System.Linq;
using PCLStorage;
using SQLite;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Plugin.Connectivity;
using Xamarin.Forms;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using Acr.UserDialogs;

namespace EstudiosBiblicos.Services
{
    public class SqlHelper
    {
        static object locker = new object();
        SQLiteConnection database;
        public SqlHelper()
        {
            database = GetConnection();
            database.CreateTable<Curso>();
            database.CreateTable <MisCursos>();
            database.CreateTable<Leccion>();
            database.CreateTable<Usuario>();
            database.CreateTable<Leccion1Sel>();
            database.CreateTable<Leccion2Sel>();
            database.CreateTable<Leccion3Sel>();
            database.CreateTable<Leccion4Sel>();
            database.CreateTable<Leccion5Sel>();
            database.CreateTable<Leccion6Sel>();
            database.CreateTable<Leccion7Sel>();
            database.CreateTable<Leccion8Sel>();
            database.CreateTable<Leccion9Sel>();
            database.CreateTable<TextoBiblico>();
            database.CreateTable<Letras>();
            database.CreateTable<Letra>();
            database.CreateTable<Palabra>();
        }
        public SQLite.SQLiteConnection GetConnection()
        {
            SQLiteConnection sqliteConnection;
            var sqliteFilename = "Estudios.db3";
            //IFolder folder = FileSystem.Current.LocalStorage;
            //string path = PortablePath.Combine(folder.Path.ToString(), sqliteFilename);
            string path = PortablePath.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), sqliteFilename);
            sqliteConnection = new SQLite.SQLiteConnection(path);
            return sqliteConnection;
        }
        public bool GetCursoExists(int ID)
        {
            bool result = false;
            lock (locker)
            {
                if (database.Table<Curso>().FirstOrDefault(x => x.IdCurso == ID) != null)
                    result = true;
            }
            return result;
        }
        public int InsertarCurso(Curso item)
        {
            lock (locker)
            {
                if (GetCursoExists(item.IdCurso) == true)
                {
                    //Update Item  
                    database.Update(item);
                    return item.IdCurso;
                }
                else
                {
                    //Insert item  
                    return database.Insert(item);
                }
            }
        }
        public List<Curso> GetAllCursos()
        {
            lock (locker)
            {
                //return database.Table<LineUp>().ToList();
                return database.Query<Curso>($"SELECT * FROM Curso").ToList();
            }
        }
        public List<PrimerCurso> GetPrimerCursos()
        {
            lock (locker)
            {
                List<PrimerCurso> Cursos = new List<PrimerCurso>();
                //return database.Table<LineUp>().ToList();
                var listado = database.Query<Curso>($"SELECT * FROM Curso").ToList();
                foreach (var curso in listado)
                {
                    PrimerCurso c1 = new PrimerCurso() { IdCurso = curso.IdCurso, Nombre = curso.Nombre
                        , Descripcion = curso.Descripcion, Duracion = curso.Duracion, Estatus = 1
                        , Lecciones = curso.Lecciones, Imagen = curso.Imagen, Seleccionado = false };
                    Cursos.Add(c1);
                }
                return Cursos;
            }
        }

        public bool GetMiCursoExists(int ID)
        {
            bool result = false;
            lock (locker)
            {
                if (database.Table<MisCursos>().FirstOrDefault(x => x.IdCurso == ID) != null)
                    result = true;
            }
            return result;
        }
        public int InsertarMisCursos(MisCursos item)
        {
            lock (locker)
            {
                if (GetMiCursoExists(item.IdCurso) == true)
                {
                    //Update Item  
                    database.Delete(item);
                    return item.IdCurso;
                }
                else
                {
                    //Insert item  
                    return database.Insert(item);
                }
            }
        }

        public bool GetLeccionExists(int ID)
        {
            bool result = false;
            lock (locker)
            {
                if (database.Table<Leccion>().FirstOrDefault(x => x.IdLeccion == ID) != null)
                    result = true;
            }
            return result;
        }
        public int InsertarLeccion(Leccion item)
        {
            lock (locker)
            {
                if (GetLeccionExists(item.IdLeccion) == true)
                {
                    //Update Item  
                    database.Update(item);
                    return item.IdLeccion;
                }
                else
                {
                    //Insert item  
                    return database.Insert(item);
                }
            }
        }
        public List<Leccion> GetLeccionesById(int IdCurso)
        {
            lock (locker)
            {                
              return database.Query<Leccion>($"SELECT * FROM Leccion WHERE IdCurso = { IdCurso }").ToList();                
            }
        }

        public List<MisCursos> GetMyCursos()
        {
            lock (locker)
            {
                return database.Query<MisCursos>($"SELECT * FROM MisCursos").ToList();
            }
        }
        public bool GetusuarioExists(int ID)
        {
            bool result = false;
            lock (locker)
            {
                if (database.Table<Usuario>().FirstOrDefault(x => x.id_usuario == ID) != null)
                    result = true;
            }
            return result;
        }
        public int InsertarUsuario(Usuario item)
        {
            lock (locker)
            {
                if (GetusuarioExists(item.id_usuario) == true)
                {
                    //Update Item  
                    database.Update(item);
                    return item.id_usuario;
                }
                else
                {
                    //Insert item  
                    return database.Insert(item);
                }
            }
        }
        public Usuario GetLoggedUser()
        {
            bool result = false;
            lock (locker)
            {
                if (database.Table<Usuario>().FirstOrDefault(x => x.id_usuario != null) != null)
                    result = true;
            }
            if (result)
                return database.Table<Usuario>().FirstOrDefault();
            else
                return null;
        }
        public bool UpdateDateLoggedUser(DateTime fechanac)
        {
            bool result = false;
            lock (locker)
            {
                if (database.Table<Usuario>().FirstOrDefault(x => x.id_usuario != null) != null)
                    result = true;
            }
            if (result)
            {
                var usuario = database.Table<Usuario>().FirstOrDefault();
                usuario.fecha_nacimiento = fechanac;
                database.Update(usuario);
                return true;
            }
            else
                return false;
        }
        public void CerrarSesion()
        {
            database.DropTable<Usuario>();
            database.CreateTable<Usuario>();
        }
        public bool GetL1Exists(int ID)
        {
            bool result = false;
            lock (locker)
            {
                if (database.Table<Leccion1Sel>().FirstOrDefault(x => x.IdLeccion == ID) != null)
                    result = true;
            }
            return result;
        }
        public int InsertarL1(Leccion1Sel item)
        {
            lock (locker)
            {
                if (GetL1Exists(item.IdLeccion) == true)
                {
                    //Update Item  
                    database.Update(item);
                    return item.IdLeccion;
                }
                else
                {
                    //Insert item  
                    return database.Insert(item);
                }
            }
        }
        public Leccion1Sel GetL1()
        {
            lock (locker)
            {
                return database.Table<Leccion1Sel>().FirstOrDefault();
            }
        }
        public bool GetL2Exists(int ID)
        {
            bool result = false;
            lock (locker)
            {
                if (database.Table<Leccion2Sel>().FirstOrDefault(x => x.IdLeccion == ID) != null)
                    result = true;
            }
            return result;
        }
        public int InsertarL2(Leccion2Sel item)
        {
            lock (locker)
            {
                if (GetL2Exists(item.IdLeccion) == true)
                {
                    //Update Item  
                    database.Update(item);
                    return item.IdLeccion;
                }
                else
                {
                    //Insert item  
                    return database.Insert(item);
                }
            }
        }
        public Leccion2Sel GetL2()
        {
            lock (locker)
            {
                return database.Table<Leccion2Sel>().FirstOrDefault();
            }
        }
        public bool GetL3Exists(int ID)
        {
            bool result = false;
            lock (locker)
            {
                if (database.Table<Leccion3Sel>().FirstOrDefault(x => x.IdLeccion == ID) != null)
                    result = true;
            }
            return result;
        }
        public int InsertarL3(Leccion3Sel item)
        {
            lock (locker)
            {
                if (GetL3Exists(item.IdLeccion) == true)
                {
                    //Update Item  
                    database.Update(item);
                    return item.IdLeccion;
                }
                else
                {
                    //Insert item  
                    return database.Insert(item);
                }
            }
        }
        public Leccion3Sel GetL3()
        {
            lock (locker)
            {
                return database.Table<Leccion3Sel>().FirstOrDefault();
            }
        }
        public bool GetL4Exists(int ID)
        {
            bool result = false;
            lock (locker)
            {
                if (database.Table<Leccion4Sel>().FirstOrDefault(x => x.IdLeccion == ID) != null)
                    result = true;
            }
            return result;
        }
        public int InsertarL4(Leccion4Sel item)
        {
            lock (locker)
            {
                if (GetL4Exists(item.IdLeccion) == true)
                {
                    //Update Item  
                    database.Update(item);
                    return item.IdLeccion;
                }
                else
                {
                    //Insert item  
                    return database.Insert(item);
                }
            }
        }
        public Leccion4Sel GetL4()
        {
            lock (locker)
            {
                return database.Table<Leccion4Sel>().FirstOrDefault();
            }
        }
        public bool GetL5Exists(int ID)
        {
            bool result = false;
            lock (locker)
            {
                if (database.Table<Leccion5Sel>().FirstOrDefault(x => x.IdLeccion == ID) != null)
                    result = true;
            }
            return result;
        }
        public int InsertarL5(Leccion5Sel item)
        {
            lock (locker)
            {
                if (GetL5Exists(item.IdLeccion) == true)
                {
                    //Update Item  
                    database.Update(item);
                    return item.IdLeccion;
                }
                else
                {
                    //Insert item  
                    return database.Insert(item);
                }
            }
        }
        public Leccion5Sel GetL5()
        {
            lock (locker)
            {
                return database.Table<Leccion5Sel>().FirstOrDefault();
            }
        }
        public bool GetL6Exists(int ID)
        {
            bool result = false;
            lock (locker)
            {
                if (database.Table<Leccion6Sel>().FirstOrDefault(x => x.IdLeccion == ID) != null)
                    result = true;
            }
            return result;
        }
        public int InsertarL6(Leccion6Sel item)
        {
            lock (locker)
            {
                if (GetL6Exists(item.IdLeccion) == true)
                {
                    //Update Item  
                    database.Update(item);
                    return item.IdLeccion;
                }
                else
                {
                    //Insert item  
                    return database.Insert(item);
                }
            }
        }
        public Leccion6Sel GetL6()
        {
            lock (locker)
            {
                return database.Table<Leccion6Sel>().FirstOrDefault();
            }
        }
        public bool GetL7Exists(int ID)
        {
            bool result = false;
            lock (locker)
            {
                if (database.Table<Leccion7Sel>().FirstOrDefault(x => x.IdLeccion == ID) != null)
                    result = true;
            }
            return result;
        }
        public int InsertarL7(Leccion7Sel item)
        {
            lock (locker)
            {
                if (GetL7Exists(item.IdLeccion) == true)
                {
                    //Update Item  
                    database.Update(item);
                    return item.IdLeccion;
                }
                else
                {
                    //Insert item  
                    return database.Insert(item);
                }
            }
        }
        public Leccion7Sel GetL7()
        {
            lock (locker)
            {
                return database.Table<Leccion7Sel>().FirstOrDefault();
            }
        }
        public bool GetL8Exists(int ID)
        {
            bool result = false;
            lock (locker)
            {
                if (database.Table<Leccion8Sel>().FirstOrDefault(x => x.IdLeccion == ID) != null)
                    result = true;
            }
            return result;
        }
        public int InsertarL8(Leccion8Sel item)
        {
            lock (locker)
            {
                if (GetL8Exists(item.IdLeccion) == true)
                {
                    //Update Item  
                    database.Update(item);
                    return item.IdLeccion;
                }
                else
                {
                    //Insert item  
                    return database.Insert(item);
                }
            }
        }
        public Leccion8Sel GetL8()
        {
            lock (locker)
            {
                return database.Table<Leccion8Sel>().FirstOrDefault();
            }
        }



        public bool GetL9Exists(int ID)
        {
            bool result = false;
            lock (locker)
            {
                if (database.Table<Leccion9Sel>().FirstOrDefault(x => x.IdLeccion == ID) != null)
                    result = true;
            }
            return result;
        }
        public int InsertarL9(Leccion9Sel item)
        {
            lock (locker)
            {
                if (GetL9Exists(item.IdLeccion) == true)
                {
                    //Update Item  
                    database.Update(item);
                    return item.IdLeccion;
                }
                else
                {
                    //Insert item  
                    return database.Insert(item);
                }
            }
        }
        public Leccion9Sel GetL9(int ID)
        {
            lock (locker)
            {
                return database.Table<Leccion9Sel>().FirstOrDefault(x => x.IdLeccion == ID);
            }
        }


        public bool GetLBExists(int ID)
        {
            bool result = false;
            lock (locker)
            {
                if (database.Table<TextoBiblico>().FirstOrDefault(x => x.Id_Texto == ID) != null)
                    result = true;
            }
            return result;
        }
        public int InsertarTB(TextoBiblico item)
        {
            lock (locker)
            {
                if (GetLBExists(item.Id_Texto) == true)
                {
                    //Update Item  
                    database.Update(item);
                    return item.Id_Texto;
                }
                else
                {
                    //Insert item  
                    return database.Insert(item);
                }
            }
        }
        public TextoBiblico GetTB(int ID)
        {
            lock (locker)
            {
                if (database.Table<TextoBiblico>().FirstOrDefault(x => x.Id_Texto == ID) != null)
                    return database.Table<TextoBiblico>().FirstOrDefault(x => x.Id_Texto == ID);
                else
                    return null;
            }
        }
        public int UpdateLeccion(int id, int estado)
        {
            lock (locker)
            {
                if (GetLeccionExists(id) == true)
                {
                    //Update Item
                    var lc = database.Table<Leccion>().FirstOrDefault(x => x.IdLeccion == id);
                    lc.Estatus = estado;
                    database.Update(lc);
                    return lc.IdLeccion;
                }
                else
                {
                    //Insert item  
                    return 0;
                }
            }
        }



        public bool GetLetrasExists(int ID)
        {
            bool result = false;
            lock (locker)
            {
                if (database.Table<Letras>().FirstOrDefault(x => x.IdLeccion == ID) != null)
                    result = true;
            }
            return result;
        }
        public int InsertarLetras(Letras item)
        {
            lock (locker)
            {
                if (GetLetrasExists(item.IdLeccion) == true)
                {
                    //Update Item  
                    database.Update(item);
                    return item.IdLeccion;
                }
                else
                {
                    //Insert item  
                    return database.Insert(item);
                }
            }
        }
        public Letras GetLetras(int ID)
        {
            lock (locker)
            {
                return database.Table<Letras>().FirstOrDefault(x => x.IdLeccion == ID);
            }
        }

        public bool GetLetrasPExists(int ID, int numero)
        {
            bool result = false;
            lock (locker)
            {
                if (database.Table<Letra>().FirstOrDefault(x => x.IdLeccion == ID && x.Numero == numero) != null)
                    result = true;
            }
            return result;
        }
        public int InsertarLetrasP(Letra item)
        {
            lock (locker)
            {
                if (GetLetrasPExists(item.IdLeccion, item.Numero) == true)
                {
                    //Update Item  
                    database.Update(item);
                    return item.IdLeccion;
                }
                else
                {
                    //Insert item  
                    return database.Insert(item);
                }
            }
        }
        public List<Letra> GetLetrasP(int ID)
        {
            lock (locker)
            {
                return database.Query<Letra>($"SELECT * FROM Letra WHERE IdLeccion = { ID }").ToList();
            }
        }

        public bool GetPalabrasExists(int ID)
        {
            bool result = false;
            lock (locker)
            {
                if (database.Table<Palabra>().FirstOrDefault(x => x.IdLeccion == ID) != null)
                    result = true;
            }
            return result;
        }
        public int InsertarPalabras(Palabra item)
        {
            lock (locker)
            {
                if (GetPalabrasExists(item.IdLeccion) == true)
                {
                    //Update Item  
                    database.Update(item);
                    return item.IdLeccion;
                }
                else
                {
                    //Insert item  
                    return database.Insert(item);
                }
            }
        }
        public List<Palabra> GetPalabras(int ID)
        {
            lock (locker)
            {
                return database.Query<Palabra>($"SELECT * FROM Palabra WHERE IdLeccion = { ID }").ToList();
            }
        }
        public Palabra GetPalabra(int ID)
        {
            lock (locker)
            {
                return database.Table<Palabra>().FirstOrDefault(x => x.IdLeccion == ID);
            }
        }




        HttpClient _client = new HttpClient(new System.Net.Http.HttpClientHandler());
        private const string UrlConsultaUsuario = "buscarusuario.php";
        private const string UrlInsertarUsuario = "insertar_participante.php";
        private const string UrlActUsuario = "update_participante.php";
        public async Task<bool> LoguearUsuario(string Correo, string clave)
        {
            if (!CrossConnectivity.Current.IsConnected)
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    try
                    {
                        Acr.UserDialogs.UserDialogs.Instance.Toast("No tienes conexion al internet!", new TimeSpan(0, 0, 5));
                    }
                    catch (Exception ex)
                    {

                    }
                });
                return false;
            }
            try
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    try
                    {
                        UserDialogs.Instance.ShowLoading("");
                    }
                    catch (Exception ex)
                    {

                    }
                });

                HttpClientHandler clientHandler = new HttpClientHandler();
                clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
                HttpClient client = new HttpClient(clientHandler);


                var content = await client.GetStringAsync(Configurations.api +
                    UrlConsultaUsuario + "?correo=" + Correo + "&contrasena=" + clave);
                var tr = JsonConvert.DeserializeObject<List<Usuario>>(content);
                ObservableCollection<Usuario> trends = new ObservableCollection<Usuario>(tr);

                int i = trends.Count;
                if (i == 0)
                {
                    UserDialogs.Instance.HideLoading();
                    //UserDialogs.Instance.Toast("Correo o contrasena incorrecta!", new TimeSpan(0, 0, 5));
                    Acr.UserDialogs.UserDialogs.Instance.Alert("Correo o contrasena incorrecta!", "Alerta", null);
                    return false;
                }
                foreach (Usuario link in trends)
                {
                    if (link.id_usuario == 0)
                    {
                        UserDialogs.Instance.HideLoading();
                        UserDialogs.Instance.Toast("Correo o contrasena incorrecta!", new TimeSpan(0, 0, 5));
                        Acr.UserDialogs.UserDialogs.Instance.Alert("Correo o contrasena incorrecta!", "Alerta", null);
                        return false;
                    }
                    else
                    {
                        InsertarUsuario(link);
                    }
                }
                UserDialogs.Instance.HideLoading();
                return true;
            }
            catch (Exception ex)
            {
                UserDialogs.Instance.HideLoading();
                return false;
            }
        }
        public async Task<bool> InsertarUsuario(string nombre, string apellido, string Correo, string clave, string telefono, DateTime fechanac)
        {
            if (!CrossConnectivity.Current.IsConnected)
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    try
                    {
                        Acr.UserDialogs.UserDialogs.Instance.Toast("No tienes conexion al internet!", new TimeSpan(0, 0, 5));
                    }
                    catch (Exception ex)
                    {

                    }
                });
                return false;
            }
            try
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    try
                    {
                        UserDialogs.Instance.ShowLoading("");
                    }
                    catch (Exception ex)
                    {

                    }
                });

                HttpClientHandler clientHandler = new HttpClientHandler();
                clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
                HttpClient client = new HttpClient(clientHandler);

                string dia, mes, ano;
                dia = fechanac.ToString("dd");
                mes = fechanac.ToString("MM");
                ano = fechanac.ToString("yyyy");
                var content = await client.GetStringAsync(Configurations.api +
                    UrlInsertarUsuario + "?nombre=" + nombre + "&apellido=" + apellido + "&correo=" + Correo + "&contrasena=" + clave + "&telefono=" + telefono + "&fecha_nacimiento="+dia+"/"+mes+"/"+ano);

                if (content.Contains("Error"))
                {
                    UserDialogs.Instance.HideLoading();
                    //UserDialogs.Instance.Toast("Ha ocurrido un error insertando el participante!", new TimeSpan(0, 0, 5));
                    Acr.UserDialogs.UserDialogs.Instance.Alert("Ha ocurrido un error insertando el participante!", "Alerta", null);
                    return false;
                }
                UserDialogs.Instance.HideLoading();
                return true;
            }
            catch (Exception ex)
            {
                UserDialogs.Instance.HideLoading();
                return false;
            }
        }
        public async Task<bool> UpdtUsuario(int _id,string nombre, string apellido, string Correo, string clave, string telefono, DateTime fechanac)
        {
            if (!CrossConnectivity.Current.IsConnected)
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    try
                    {
                        Acr.UserDialogs.UserDialogs.Instance.Toast("No tienes conexion al internet!", new TimeSpan(0, 0, 5));
                    }
                    catch (Exception ex)
                    {

                    }
                });
                return false;
            }
            try
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    try
                    {
                        UserDialogs.Instance.ShowLoading("");
                    }
                    catch (Exception ex)
                    {

                    }
                });
                string dia, mes, ano;
                dia = fechanac.ToString("dd");
                mes = fechanac.ToString("MM");
                ano = fechanac.ToString("yyyy");
                HttpClientHandler clientHandler = new HttpClientHandler();
                clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
                HttpClient client = new HttpClient(clientHandler);


                var content = await client.GetStringAsync(Configurations.api +
                    UrlActUsuario + "?id="+_id.ToString()+"&nombre=" + nombre + "&apellido=" + apellido + "&correo=" + Correo + "&contrasena=" + clave + "&telefono=" + telefono + "&fecha_nacimiento=" + dia + "/" + mes + "/" + ano);

                if (content.Contains("Error"))
                {
                    UserDialogs.Instance.HideLoading();
                    //UserDialogs.Instance.Toast("Ha ocurrido un error insertando el participante!", new TimeSpan(0, 0, 5));
                    Acr.UserDialogs.UserDialogs.Instance.Alert("Ha ocurrido un error insertando el participante!", "Alerta", null);
                    return false;
                }
                //int _id,string nombre, string apellido, string Correo, string clave, string telefono, DateTime fechanac
                var usuario = GetLoggedUser();
                usuario.nombre = nombre;
                usuario.apellido = apellido;
                usuario.correo = Correo;
                usuario.contrasena = clave;
                usuario.telefono = telefono;                
                InsertarUsuario(usuario);
                UserDialogs.Instance.HideLoading();
                return true;
            }
            catch (Exception ex)
            {
                UserDialogs.Instance.HideLoading();
                return false;
            }
        }
    }
}