using Business.Abstract;
using Business.Constants;
using Core.Utilities.FileOperations;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarImagesController : ControllerBase
    {
        ICarImageService _carImageService;
        IConfiguration _configuration;
        public CarImagesController(ICarImageService carImageService, IConfiguration configuration)
        {
            _carImageService = carImageService;
            _configuration = configuration;
        }

        [HttpPost("addcarimage")]
        public IActionResult AddCarImage([FromForm] IFormFile imageFile, [FromForm] CarImage carImage)
        {
            if (!FileOperations.CheckImageFile(imageFile))
            {
                return BadRequest(new { Message = Messages.InvalidImageFileFormat });
            }
            carImage.ImagePath = Guid.NewGuid() + Path.GetExtension(imageFile.FileName);
            var result = _carImageService.AddCarImage(carImage);            
            if (result.Success) {                
                FileOperations.WriteImageFile(imageFile, _configuration.GetSection("ImageRootPath").Value, carImage.ImagePath);
                return Ok(result); 
            }
            return BadRequest(result);
        }

        [HttpPost("updatecarimage")]
        public IActionResult UpdateCarImage([FromForm] IFormFile imageFile, [FromForm] CarImage carImage)
        {            
            if (!FileOperations.CheckImageFile(imageFile))
            {
                return BadRequest(new { Message = Messages.InvalidImageFileFormat });
            }
            carImage.ImagePath = Guid.NewGuid() + Path.GetExtension(imageFile.FileName);
            var result = _carImageService.UpdateCarImage(carImage);
            if (result.Success)
            {
                FileOperations.WriteImageFile(imageFile, _configuration.GetSection("ImageRootPath").Value, carImage.ImagePath);
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("deletecarimage")]
        public IActionResult DeleteCarImage([FromForm] CarImage carImage)
        {
            var result = _carImageService.GetById(carImage.Id);            
            if (result.Success)
            {
                FileOperations.DeleteImageFile(_configuration.GetSection("ImageRootPath").Value, result.Data.ImagePath);                
                var deleted = _carImageService.DeleteCarImage(carImage);
                if (deleted.Success) return Ok(deleted);
            }
            return BadRequest();
        }

        [HttpGet("listcarimage")]
        public IActionResult ListCarImage(int carId)
        {
            var result = _carImageService.GetImagesByCarId(carId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }
    }
}
