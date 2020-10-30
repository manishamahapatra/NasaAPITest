using System.Collections.Generic;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using NasaAPIProject.NASAAPI.Model;
using Newtonsoft.Json;
using NasaAPIProject.Common;

namespace NasaAPIProject.NASAAPI.Service
{
    public class GetNASAImageService : IGetNASAImage
    {
        private string apiUrl = "https://api.nasa.gov/mars-photos/api/v1/rovers/curiosity/photos?";

        /*private readonly IApplicationSettings _applicationSettings;
        public GetNASAImageService(IApplicationSettings applicationSettings)
        {
            _applicationSettings = applicationSettings;
        }*/

        public async Task<ServiceResponse<Photos>> GetNASAImageByAllDate()
        {

            ServiceResponse<Photos> serviceResponse = new ServiceResponse<Photos>();
            Photos photos = new Photos();
            DateTime earthDate ;
            using (var httpClient = new HttpClient())
            {
                foreach (string date in Utility.GetAllDates())
                {
                    httpClient.BaseAddress = new Uri(apiUrl);
                    earthDate = Utility.ParseDateTime(date);
                    using (var response = await httpClient.GetAsync($"api_key=cxIDqtWdnATkuqWH0tt0ZeoWnEQTTgV01HYLjMcO&earth_date={earthDate:yyyy-MM-dd}"))
                    {
                        string apiRespone = await response.Content.ReadAsStringAsync();
                        photos = JsonConvert.DeserializeObject<Photos>(apiRespone);
                    }
                    serviceResponse.Data = photos;
                }
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<Photos>> GetNASAImageByDate(DateTime inputDate)
        {
            ServiceResponse<Photos> serviceResponse = new ServiceResponse<Photos>();
            Photos photos = new Photos();
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(apiUrl);
                //  apiUrl += inputDate;
                using (var response = await httpClient.GetAsync($"&earth_date={inputDate:yyyy-MM-dd}"))
                {
                    string apiRespone = await response.Content.ReadAsStringAsync();
                    photos = JsonConvert.DeserializeObject<Photos>(apiRespone);
                }
                serviceResponse.Data = photos;

            }
            return serviceResponse;
        }
    }
}
