using System;

namespace AdapterPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductManager pm = new ProductManager(new Log4NetAdapter());
            pm.Save();
            Console.ReadLine();
        }
    }

    class ProductManager
    {
        private ILogger _logger;
        public ProductManager(ILogger logger)
        {
            _logger = logger;
        }

        public void Save()
        {
            _logger.Log("User Data");
            Console.WriteLine("Saved");
        }
    }

    interface ILogger
    {
        void Log(string message);
    }
    class TestLogger : ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine("TestLogger, {0}", message);
        }
    }

    class Log4NetLogger
    {
        public void LogMessage(string message)
        {
            Console.WriteLine("Log4NetLogger, {0}", message);
        }
    }

    class Log4NetAdapter : ILogger
    {
        public void Log(string message)
        {
            Log4NetLogger log4Net = new Log4NetLogger();
            log4Net.LogMessage(message);
        }
    }

}
