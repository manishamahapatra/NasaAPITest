using System.Threading.Tasks;
using System;

using NasaAPIProject.NASAAPI.Model;
namespace NasaAPIProject.NASAAPI.Service
{
    public interface IGetNASAImage
    {
         Task<ServiceResponse<Photos>> GetNASAImageByAllDate();
         Task<ServiceResponse<Photos>> GetNASAImageByDate(string inputDate);
    }
}