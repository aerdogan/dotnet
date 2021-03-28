using Core.Entities;

namespace Entities.Concrete
{
    public class Card : IEntity
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string CardOwnerName { get; set; }
        public string CardNumber { get; set; }
        public string CardExpirationDate { get; set; }
        public int CardCvv { get; set; }
    }
}
