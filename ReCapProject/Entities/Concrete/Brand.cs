using Core.Entities;
using System.ComponentModel.DataAnnotations;

namespace Entities.Concrete
{
    public class Brand : IEntity
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
