using Core.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Concrete
{
    public class CarImage:IEntity
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        public string ImagePath { get; set; }
        public DateTime Date { get; set; }
        
        [NotMapped]
        public IFormFile ImageFile { get; set; }
    }
}