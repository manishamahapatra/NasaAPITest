using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using NasaAPIProject.NASAAPI.Service;
using NasaAPIProject.NASAAPI.Model;
namespace NASAAPITest
{
    class GetNASAImageControllerServiceTest : IGetNASAImage
    {
        private readonly string[] _dates;

        private Photo _photo = new Photo();
        private Photos _photos = new Photos();
        private Rover _rover = new Rover();
        private Camera _camera = new Camera();

        ServiceResponse<Photos> serviceResponse = new ServiceResponse<Photos>();

        private void PopulateData()
        {
            _rover.id = "5";
            _rover.name = "Curiosity";
            _rover.landing_date = "2012-08-06";
            _rover.launch_date = "2011-11-26";
            _rover.status = "active";

            _camera.id = "20";
            _camera.name = "FHAZ";
            _camera.full_name = "Front Hazard Avoidance Camera";
            _camera.rover_id = "5";

            _photo.id = "102685";
            _photo.img_src = "http://mars.jpl.nasa.gov/msl-raw-images/proj/msl/redops/ods/surface/sol/01004/opgs/edr/fcam/FLB_486615455EDR_F0481570FHAZ00323M_.JPG";
            _photo.rover = _rover;
            _photo.sol = "1004";
            _photo.earth_date = "2015-06-03";
            _photo.camera = _camera;

            List<Photo> _photo1 = new List<Photo>();

            _photo1.Add(_photo);

            _photos.photos = _photo1;

        }

        public GetNASAImageControllerServiceTest()
        {
            PopulateData();
        }


        public async Task<ServiceResponse<Photos>> GetNASAImageByAllDate()
        {
            serviceResponse.Data = _photos;
            return serviceResponse;
        }
        public async Task<ServiceResponse<Photos>> GetNASAImageByDate(DateTime inputDate)
        {
            serviceResponse.Data = _photos;
            return serviceResponse;
        }
    }
}