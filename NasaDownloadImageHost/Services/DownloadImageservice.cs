using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.IO;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using NasaAPIProject.Common;
using NasaAPIProject.NASAAPI.Model;
namespace NasaAPIProject.NasaDownloadImageHost.Services
{
    public class DownloadImageservice:IDownloadImageservice
    {
        private readonly IApplicationSettings _applicationSettings;

        public DownloadImageservice(IApplicationSettings applicationSettings)
        {
            _applicationSettings = applicationSettings;
        }

        public async Task DownloadFileAsync(Photo photo)
        {
            try
            {
                using (var webClient = new WebClient())
                {
                    var downloadToDirectory = _applicationSettings.LocalStorageRootPath;
                    await webClient.DownloadFileTaskAsync(new Uri(photo.img_src), @downloadToDirectory);
                }
            }
            catch (Exception ex)
            {
                
            }
        }
        public async Task ArchiveImages(string fileLocation)
        {
             var alldates = GetDatesFromFile(fileLocation);
           
            var tasklist = alldates.Select(GetAllImageUrls).ToList();
            var allUrls = (await Task.WhenAll(tasklist)).SelectMany(d => d).ToList();
            
            await DownloadMultipleFilesAsync(allUrls);
           
        }
        public async Task DownloadMultipleFilesAsync(List<Photos> Photo)
        {
            System.IO.Directory.CreateDirectory(_applicationSettings.LocalStorageRootPath);
          
           //await Task.WhenAll(Photo.Select(DownloadFileAsync));
        }
        public async Task<List<Photos>> GetAllImageUrls(DateTime inputDate)
        {
            List<Photos> photos = new List<Photos>();
            using (var client = new HttpClient())
            {
                client.BaseAddress =
                    new Uri(_applicationSettings.NasaAPIWebApi);
              
                using (var response = await client.GetAsync($"api/GetNASAImageByDate/{inputDate:yyyy-MM-dd}"))
                {
                    string apiRespone = await response.Content.ReadAsStringAsync();
                    photos = JsonConvert.DeserializeObject<List<Photos>>(apiRespone);
                }
            }
            return photos;
        }

        private IList<DateTime> GetDatesFromFile(string fileLocation)
        {
            var fileContents = File.ReadAllLines(fileLocation);
            return fileContents.Select(ParseDateTime).Where(x => x != DateTime.MinValue).ToList();
        }

        public static DateTime ParseDateTime(string date)
        {
            return !DateTime.TryParse(date, out var result) ? DateTime.MinValue : result;
        }
    }
}
