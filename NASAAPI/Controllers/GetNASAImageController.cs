using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NasaAPIProject.NASAAPI.Service;
namespace NasaAPIProject.NASAAPI.Controllers
{
 
    [Route("api/[controller]")]
    public class GetNASAImageController:ControllerBase
    {
        private readonly IGetNASAImage _nasaImageService;
        private readonly IDownloadImageservice _downloadImageService;
        public GetNASAImageController(IGetNASAImage nasaImageService,IDownloadImageservice downloadImageService )
        {
             _nasaImageService=nasaImageService;
             _downloadImageService=downloadImageService;
        }

       [Route("api/GetNASAImageByDateAll")]
        [HttpGet("GetNASAImageByDateAll")]
        public async Task<IActionResult> GetNASAImageByAllDate()
        {
            return Ok(await _nasaImageService.GetNASAImageByAllDate());
        }

        [Route("api/GetNASAImageByDate/{inputdate}")]
        [HttpGet("GetNASAImageByDate/{inputdate}")]
        public async Task<IActionResult> GetNASAImageByDate(string inputdate)
        {
            return Ok(await _nasaImageService.GetNASAImageByDate(Utility.ParseDateTime(inputdate)));
            
        }
        [Route("api/DownloadImage")]
        [HttpGet("DownloadImage")]
        public  async Task DownloadImage()
        {
            await _downloadImageService.ArchiveImages();
        }
    }
}
