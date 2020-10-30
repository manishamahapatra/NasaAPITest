using System.Configuration;
namespace NasaAPIProject.Common
{
    public class ApplicationSettings:IApplicationSettings
    {
        public ApplicationSettings()
        {
            NasaAPIBaseApiUrl = ConfigurationManager.AppSettings["NasaAPIBaseApiUrl"];
            NasaAPIApiKey = ConfigurationManager.AppSettings["NasaAPIApiKey"];
            LocalStorageRootPath = ConfigurationManager.AppSettings["LocalStorageRootPath"];
            NasaAPIWebApi = ConfigurationManager.AppSettings["NasaAPIWebApi"];
        }


        public string NasaAPIBaseApiUrl { get; set; }
        public string NasaAPIApiKey { get; set; }
        public string LocalStorageRootPath { get; set; }
        public string NasaAPIWebApi { get; set; }
    }
}
