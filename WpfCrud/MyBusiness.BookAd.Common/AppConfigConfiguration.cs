using System.Configuration;
using MyBusiness.BookAd.Common.Interfaces;

namespace MyBusiness.BookAd.Common
{
    /// <summary>
    /// Obtains the application configuration through App.Config
    /// </summary>
    public class AppConfigConfiguration : IConfiguration
    {
        public AppConfigConfiguration()
        {
            var dataProvider = ConfigurationManager.AppSettings["DataProvider"];
            DataProvider = dataProvider;
            if (string.IsNullOrWhiteSpace(DataProvider))
            {
                throw new ConfigurationErrorsException("Missing DataProvider in the App.Config");
            }
        }

        public string DataProvider { get; private set; }
    }
}
