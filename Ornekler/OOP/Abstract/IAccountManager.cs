using System.Collections.Generic;

namespace OOP1.Abstract
{
    interface IAccountManager
    {
        public void DoAccount( ICreditManager creditManager, ICustomer customer, List<ILoggerService> loggerServices);
    }
}
