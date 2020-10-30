
namespace NasaAPIProject.Common
{
   public interface IApplicationSettings
    {
        string NasaAPIBaseApiUrl { get; set; }
        string NasaAPIApiKey { get; set; }
        string LocalStorageRootPath { get; set; }
        string NasaAPIWebApi { get; set; }
    }
}
