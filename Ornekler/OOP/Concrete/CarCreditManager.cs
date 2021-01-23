using OOP1.Abstract;
using System;
using System.Collections.Generic;

namespace OOP1.Concrete
{
    class CarCreditManager : ICreditManager
    {

        public void Calculate(ICustomer customer, List<ILoggerService> loggerServices)
        {
            Console.WriteLine("Car Credit Calculated for : " + customer.CustomerNumber + "( " + customer.Job + " )");
            foreach (var loggerService in loggerServices)
            {
                loggerService.Log();
            }
            
        }
    }
}
