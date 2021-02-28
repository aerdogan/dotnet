using Business.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Mvc;

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

        [HttpPost]
        public IActionResult Add([FromForm] CarImagesDto carImagesDto)
        {
            var result = _carImageService.Add(carImagesDto);
            if (!result.Success) return BadRequest(result);
            return Ok(result);
        }

        [HttpPut]
        public IActionResult Update([FromForm] CarImagesDto carImagesDto)
        {
            var result = _carImageService.Update(carImagesDto);
            if (!result.Success) return BadRequest(result);
            return Ok(result);
        }

        [HttpDelete("delete")]
        public IActionResult Delete(int id)
        {
            var result = _carImageService.Delete(id);
            if (!result.Success) return BadRequest(result);
            return Ok(result);
        }

        [HttpDelete("deletebycarid")]
        public IActionResult DeleteByCarId(int carId)
        {
            var result = _carImageService.DeleteByCarId(carId);
            if (!result.Success) return BadRequest(result);
            return Ok(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _carImageService.GetById(id);
            if (!result.Success) return BadRequest(result);
            return Ok(result);
        }

        [HttpGet("getbycarid")]
        public IActionResult GetByCarId(int carId)
        {
            var result = _carImageService.GetByCarId(carId);
            if (!result.Success) return BadRequest();
            return Ok(result);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _carImageService.GetAll();
            if (!result.Success) return BadRequest(result);
            return Ok(result);
        }
    }
}
