using System;

namespace FactoryPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomerManager cm = new CustomerManager(new LoggerFactory2()); 
            cm.Save();
            Console.ReadLine();
        }

    }

    public interface ILoggerFactory
    {
        ILogger CreateLogger();
    }
    public class LoggerFactory : ILoggerFactory
    {
        public ILogger CreateLogger()
        {
            return new AELogger();
        }
    }
    public class LoggerFactory2 : ILoggerFactory
    {
        public ILogger CreateLogger()
        {
            return new MELogger();
        }
    }

    public interface ILogger
    {
        void Log();
    }
    public class AELogger : ILogger
    {
        public void Log()
        {
            Console.WriteLine("Logged with AELogger!...");
        }
    }
    public class MELogger : ILogger
    {
        public void Log()
        {
            Console.WriteLine("Logged with MELogger!...");
        }
    }

    public class CustomerManager
    {
        private ILoggerFactory _loggerFactory;
        public CustomerManager(ILoggerFactory loggerFactory)
        {
            _loggerFactory = loggerFactory;
        }
        public void Save()
        {
            Console.WriteLine("Kaydedildi!");
            ILogger logger = _loggerFactory.CreateLogger();
            logger.Log();
        }
    }

}
