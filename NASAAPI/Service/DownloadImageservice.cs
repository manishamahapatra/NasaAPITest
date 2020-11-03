using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Resources;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using NasaAPIProject.NASAAPI.Model;
namespace NasaAPIProject.NASAAPI.Service
{
    public class DownloadImageservice : IDownloadImageservice
    {
        private string apiUrl = "https://api.nasa.gov/mars-photos/api/v1/rovers/curiosity/photos?api_key=DEMO_KEY&earth_date=";

        public async Task ArchiveImages()
        {

            Photos photos = new Photos();
            string earthDate = "";
            using (var httpClient = new HttpClient())
            {
                foreach (string date in Utility.GetAllDates())
                {
                    earthDate = Utility.ParseDateTime(date);
                    apiUrl += earthDate;
                    using (var response = await httpClient.GetAsync(apiUrl))
                    {
                        string apiRespone = await response.Content.ReadAsStringAsync();
                        photos = JsonConvert.DeserializeObject<Photos>(apiRespone);
                    }
                }
            }

            await DownloadMultipleFilesAsync(photos);
        }

        public async Task DownloadMultipleFilesAsync(Photos Photos)
        {
            await Task.WhenAll(Photos.photos.Select(DownloadFileAsync));
        }

        public async Task DownloadFileAsync(Photo photo)
        {
            try
            {
                using (var webClient = new WebClient())
                {
                    var downloadToDirectory = "Images/" + Utility.GetImageFileName(photo.img_src);
                    webClient.Credentials = System.Net.CredentialCache.DefaultNetworkCredentials;
                    await webClient.DownloadFileTaskAsync(new Uri(photo.img_src), @downloadToDirectory);

                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}