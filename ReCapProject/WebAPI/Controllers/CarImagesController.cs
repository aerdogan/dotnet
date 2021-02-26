using Business.Abstract;
using Core.Utilities.FileOperations;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarImagesController : ControllerBase
    {
        ICarImageService _carImageService;

        public CarImagesController(ICarImageService carImageService)
        {
            _carImageService = carImageService;
        }

        [HttpPost("addcarimage")]
        public IActionResult AddCarImage([FromForm] IFormFile imageFile, [FromForm] CarImage carImage)
        {
            if (!FileOperations.CheckImageFile(imageFile))
            {
                return BadRequest(new { Message = "Resim dosya formatı hatalı!" });
            }
            carImage.ImagePath = Guid.NewGuid() + Path.GetExtension(imageFile.FileName);
            var result = _carImageService.AddCarImage(carImage);            
            if (result.Success) {                
                FileOperations.WriteImageFile(imageFile, @"wwwroot\images", carImage.ImagePath);
                return Ok(result); 
            }
            return BadRequest(result);
        }

        [HttpPost("updatecarimage")]
        public IActionResult UpdateCarImage([FromForm] IFormFile imageFile, [FromForm] CarImage carImage)
        {            
            if (!FileOperations.CheckImageFile(imageFile))
            { 
                return BadRequest(new { Message = "Resim dosya formatı hatalı!" });
            }
            carImage.ImagePath = Guid.NewGuid() + Path.GetExtension(imageFile.FileName);
            var result = _carImageService.UpdateCarImage(carImage);
            if (result.Success)
            {
                FileOperations.WriteImageFile(imageFile, @"wwwroot\images", carImage.ImagePath);
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
                FileOperations.DeleteImageFile(@"wwwroot\images\", result.Data.ImagePath);                
                var deleted = _carImageService.DeleteCarImage(carImage);
                if (deleted.Success) return Ok(deleted);
            }
            return BadRequest();
        }

        [HttpGet("listcarimage")]
        public IActionResult ListCarImage(int carId)
        {
            var result = _carImageService.GetCarImagesByCarId(carId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }
    }
}
