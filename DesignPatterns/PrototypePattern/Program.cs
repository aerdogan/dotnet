using System;

namespace PrototypePattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Customer customer = new Customer { FirstName = "name", LastName = "surname", City = "city", Id = 1 };

            Customer customer1 = (Customer)customer.Clone();
            customer1.FirstName = "Test";

            Console.WriteLine(customer.FirstName);
            Console.WriteLine(customer1.FirstName);

            Console.ReadLine();
        }
    }

    public abstract class Person
    {
        public abstract Person Clone();
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    public class Customer : Person
    {
        public string City { get; set; }

        public override Person Clone()
        {
            return (Person)MemberwiseClone();
        }
    }

    public class Employee : Person
    {
        public decimal Salary { get; set; }

        public override Person Clone()
        {
            return (Person)MemberwiseClone();
        }
    }

}
