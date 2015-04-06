using System.Configuration;
using System.Globalization;
using System.Threading;

namespace Shrew.Web
{
    public class CultureConfig
    {
        static CultureInfo defaultCulture;
        public static CultureInfo DefaultCulture
        {
            get
            {
                if (defaultCulture == null)
                    defaultCulture = new CultureInfo(ConfigurationManager.AppSettings["DefaultCulture"]);
                return defaultCulture;
            }
        }
        public static void SetCulture()
        {
            Thread.CurrentThread.CurrentUICulture = DefaultCulture;
            Thread.CurrentThread.CurrentCulture = DefaultCulture;
        }
    }
}