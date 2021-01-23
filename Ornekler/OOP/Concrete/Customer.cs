using OOP1.Abstract;
using System;

namespace OOP1.Concrete
{
    public class Customer : ICustomer
    {
        public int Id { get; set; }
        public string CustomerNumber { get; set; }
        public Jobs Job { get; set; }

        public void Add()
        {
            Console.WriteLine("Customer Added : " + this.CustomerNumber);
        }
    }
}
