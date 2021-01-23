using OOP1.Abstract;
using System.Collections.Generic;

namespace OOP1.Concrete
{
    class AccountManager : IAccountManager
    {
        public void DoAccount(ICreditManager creditManager, ICustomer customer, List<ILoggerService> loggerServices)
        {
            creditManager.Calculate(customer);

            foreach (var loggerService in loggerServices)
            {
                loggerService.Log();
            }
        }
    }
}
