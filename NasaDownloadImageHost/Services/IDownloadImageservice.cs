using System.Collections.Generic;
using System.Threading.Tasks;
using NasaAPIProject.NASAAPI.Model;
using NasaAPIProject.Common;

namespace NasaAPIProject.NasaDownloadImageHost.Services
{
    public interface IDownloadImageservice: ISingletonDependency
    {
       Task DownloadFileAsync(Photo photo);
       Task ArchiveImages(string fileLocation);
    }
}
