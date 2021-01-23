using OOP1.Abstract;
using System;

namespace OOP1.Concrete
{
    public class DatabaseLoggerService : ILoggerService
    {
        public void Log()
        {
            Console.WriteLine("Database Log is success!");
        }
    }
}
