using OOP1.Abstract;
using System;

namespace OOP1.Concrete
{
    public class FileLoggerService : ILoggerService
    {
        public void Log()
        {
            Console.WriteLine("File Log is success!");
        }
    }
}
