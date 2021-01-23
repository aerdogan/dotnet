using OOP1.Abstract;
using System;

namespace OOP1.Concrete
{
    class HomeCreditManager : ICreditManager
    {
        public void Calculate(ICustomer customer)
        {
            Console.WriteLine("Home Credit Calculated! -> " + customer.Job);
        }
    }
}
