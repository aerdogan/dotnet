using OOP1.Abstract;
using OOP1.Concrete;
using System.Collections.Generic;

namespace OOP1
{
    class Program
    {
        static void Main(string[] args)
        {

            // Customers
            CorporateCustomer customer1 = new CorporateCustomer();
            customer1.Id = 1;
            customer1.CustomerNumber = "00001";
            customer1.CompanyName = "Test Company";
            customer1.Job = Jobs.Officer;
            customer1.Add();

            IndividualCustomer customer2 = new IndividualCustomer();
            customer2.Id = 2;
            customer2.CustomerNumber = "00002";
            customer2.Name = "Name";
            customer2.SurName = "SurName";
            customer2.Job = Jobs.Student;
            customer2.Add();


            List<ILoggerService> loggers = new List<ILoggerService> { new DatabaseLoggerService(), new SmsLoggerService() };

            // polymorphism example...
            ICreditManager carcreditManager = new CarCreditManager();
            ICreditManager homecreditManager = new HomeCreditManager();

            carcreditManager.Calculate(customer1, loggers);
            carcreditManager.Calculate(customer2, loggers);

            homecreditManager.Calculate(customer1, loggers);
            homecreditManager.Calculate(customer2, loggers);
        }
    }
}
