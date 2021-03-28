using Core.Entities;
using System;

namespace Entities.Concrete
{
    public class Payment : IEntity
    {
        public int Id { get; set; }
        public DateTime PaymentDate { get; set; }
        public int CustomerId { get; set; }
        public int? CardId { get; set; }
        public decimal Total { get; set; }
    }
}