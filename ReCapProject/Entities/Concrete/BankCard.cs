using Core.Entities;

namespace Entities.Concrete
{
    public class BankCard : IEntity
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string CartOwnerName { get; set; }
        public string CardNumber { get; set; }
        public string ExpirationDate { get; set; }
        public int CardCvv { get; set; }
    }
}
