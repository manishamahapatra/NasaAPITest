using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NasaAPIProject.NASAAPI.Service;
namespace NasaAPIProject.NASAAPI.Controllers
{
 
    [Route("api/[controller]")]
    public class GetNASAImageController:ControllerBase
    {
        private readonly IGetNASAImage _nasaImageService;
        public GetNASAImageController(IGetNASAImage nasaImageService)
        {
             _nasaImageService=nasaImageService;
        }

        [Route("api/GetNASAImageByDateAll")]
        [HttpGet("GetNASAImageByDateAll")]
        public async Task<IActionResult> GetNASAImageByAllDate()
        {
            return Ok(await _nasaImageService.GetNASAImageByAllDate());
        }

        [Route("api/GetNASAImageByDate/{inputdate}")]
        [HttpGet]
        public async Task<IActionResult> GetNASAImageByDate(string inputdate)
        {
            return Ok(await _nasaImageService.GetNASAImageByDate(Utility.ParseDateTime(inputdate)));
            
        }
    }
}
