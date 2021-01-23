
using System.Collections.Generic;

namespace OOP1.Abstract
{
    interface ICreditManager
    {
        public void Calculate(ICustomer customer, List<ILoggerService> loggerServices);
    }
}
