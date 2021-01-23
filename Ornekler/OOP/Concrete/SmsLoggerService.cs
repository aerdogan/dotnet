using OOP1.Abstract;
using System;

namespace OOP1.Concrete
{
    public class SmsLoggerService : ILoggerService
    {
        public void Log()
        {
            Console.WriteLine("Sms send success!");
        }
    }
}
