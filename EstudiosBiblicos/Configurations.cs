using Plugin.Settings;
using Plugin.Settings.Abstractions;
namespace EstudiosBiblicos
{
    public static class Configurations
    {        
        private const string PrimeraVezKey = "PrimeraVez";
        private const string LinkKey = "Link";

        private static ISettings AppSettings
        {
            get
            {
                return CrossSettings.Current;
            }
        }
        public static string EsPrimeraVez
        {
            get
            {
                return AppSettings.GetValueOrDefault(PrimeraVezKey, "Si");
            }
            set
            {
                AppSettings.AddOrUpdateValue(PrimeraVezKey, value);
            }
        }
        public static string api
        {
            get
            {
                return AppSettings.GetValueOrDefault(LinkKey, "http://167.86.98.218/CursoBiblico/");
            }
            set
            {
                AppSettings.AddOrUpdateValue(LinkKey, value);
            }
        }
    }
}
