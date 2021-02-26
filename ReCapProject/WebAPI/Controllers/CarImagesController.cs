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
        public IActionResult AddCarImage(IFormFile imageFile, int carId)
        {
            if (!FileOperations.CheckImageFile(imageFile))
            {
                return BadRequest(new { Message = "Resim dosya formatı hatalı!" });
            }
            string newImageName = Guid.NewGuid() + Path.GetExtension(imageFile.FileName);            
            var result = _carImageService.AddCarImage(new CarImage { CarId = carId, ImagePath = newImageName });            
            if (result.Success) {                
                FileOperations.WriteImageFile(imageFile, @"wwwroot\images", newImageName);
                return Ok(result); 
            }
            return BadRequest(result);
        }

        [HttpPost("updatecarimage")]
        public IActionResult UpdateCarImage(IFormFile imageFile, int carId, int carImageId)
        {            
            if (!FileOperations.CheckImageFile(imageFile))
            { 
                return BadRequest(new { Message = "Resim dosya formatı hatalı!" });
            }                

            string newImageName = Guid.NewGuid() + Path.GetExtension(imageFile.FileName);
            var result = _carImageService.UpdateCarImage(new CarImage
            {
                Id = carImageId,
                CarId = carId,
                ImagePath = newImageName
            });
            if (result.Success)
            {
                FileOperations.WriteImageFile(imageFile, @"wwwroot\images", newImageName);
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("deletecarimage")]
        public IActionResult DeleteCarImage(int carImageId)
        {
            var carImage = _carImageService.GetById(carImageId);            
            if (carImage.Success)
            {
                FileOperations.DeleteImageFile(@"wwwroot\images\", carImage.Data.ImagePath);                
                var result = _carImageService.DeleteCarImage(new CarImage { Id = carImageId });
                if (result.Success) return Ok(result);
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
