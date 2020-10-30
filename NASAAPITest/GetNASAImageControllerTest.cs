using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NasaAPIProject.NASAAPI.Service;
using NasaAPIProject.NASAAPI.Model;
using NasaAPIProject.NASAAPI.Controllers;
using Xunit;

namespace NASAAPITest
{
    public class GetNASAImageControllerTest
    {
        GetNASAImageController _controller;
        IGetNASAImage _service;

        public GetNASAImageControllerTest()
        {
            _service = new GetNASAImageControllerServiceTest();
            _controller = new GetNASAImageController(_service);

        }
        [Fact]
        public void Get_WhenCalled_ReturnsOkResult()
        {
            var okResult = _controller.GetNASAImageByAllDate();
            Assert.IsType<OkObjectResult>(okResult.Result);
        }
        [Fact]
        public void Get_WhenCalled_ReturnsAllPhotos()
        {
            var okResult = _controller.GetNASAImageByAllDate().Result as OkObjectResult;
            var photos = Assert.IsType<ServiceResponse<Photos>>(okResult.Value);
            Assert.True(photos.Success);
        }
    }
}
