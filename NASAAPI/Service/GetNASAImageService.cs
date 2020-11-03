using System.Collections.Generic;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using NasaAPIProject.NASAAPI.Model;
using Newtonsoft.Json;
namespace NasaAPIProject.NASAAPI.Service
{
    public class GetNASAImageService : IGetNASAImage
    {
        private string apiUrl = "https://api.nasa.gov/mars-photos/api/v1/rovers/curiosity/photos?api_key=DEMO_KEY&earth_date=";

        public async Task<ServiceResponse<Photos>> GetNASAImageByAllDate()
        {

            ServiceResponse<Photos> serviceResponse = new ServiceResponse<Photos>();
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
                    serviceResponse.Data = photos;
                }
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<Photos>> GetNASAImageByDate(string inputDate)
        {
            ServiceResponse<Photos> serviceResponse = new ServiceResponse<Photos>();
            Photos photos = new Photos();
            string earthDate = "";
            using (var httpClient = new HttpClient())
            {
                earthDate = Utility.ParseDateTime(inputDate);
                apiUrl += earthDate;
                using (var response = await httpClient.GetAsync(apiUrl))
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
