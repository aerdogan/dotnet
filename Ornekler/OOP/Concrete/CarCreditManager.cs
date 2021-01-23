using OOP1.Abstract;
using System;
using System.Collections.Generic;

namespace OOP1.Concrete
{
    class CarCreditManager : ICreditManager
    {
        public void Calculate(ICustomer customer)
        {
            Console.WriteLine("Car Credit Calculated! -> " + customer.Job );
        }
    }
}
