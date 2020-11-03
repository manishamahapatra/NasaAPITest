using System.Threading.Tasks;
using NasaAPIProject.NASAAPI.Model;
namespace NasaAPIProject.NASAAPI.Service
{
    public interface IDownloadImageservice
    {
      Task DownloadFileAsync(Photo photo);
     Task ArchiveImages();
    }
}