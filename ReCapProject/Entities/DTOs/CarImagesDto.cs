using Core.Entities;
using Microsoft.AspNetCore.Http;

namespace Entities.DTOs
{
    public class CarImagesDto : IDto
    {
        public int Id { get; set; } = 0;
        public int CarId { get; set; }
        public IFormFile ImageFile { get; set; }
    }
}