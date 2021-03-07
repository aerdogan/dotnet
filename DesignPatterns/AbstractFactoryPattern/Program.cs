using System;

namespace AbstractFactoryPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductManager pm = new ProductManager(new Factor2());
            pm.GetAll();
            Console.ReadLine();
        }
    }

    public abstract class Logging
    {
        public abstract void Log(string message);
    }
    public class Log4NetLogger : Logging
    {
        public override void Log(string message)
        {
            Console.WriteLine("Logged with Log4Net");
        }
    }
    public class NLogger : Logging
    {
        public override void Log(string message)
        {
            Console.WriteLine("Logged with NLogger");
        }
    }

    public abstract class Caching
    {
        public abstract void Cache(string data);
    }
    public class MemCache : Caching
    {
        public override void Cache(string data)
        {
            Console.WriteLine("Cached with MemCache");
        }
    }
    public class RedisCache : Caching
    {
        public override void Cache(string data)
        {
            Console.WriteLine("Cached with Redis");
        }
    }

    public abstract class ExampleAbstractFactory
    {
        public abstract Logging CreateLogger();
        public abstract Caching CreateCaching();
    }
    public class Factor1 : ExampleAbstractFactory
    {
        public override Caching CreateCaching()
        {
            return new RedisCache();            
        }

        public override Logging CreateLogger()
        {
            return new Log4NetLogger();
        }
    }
    public class Factor2 : ExampleAbstractFactory
    {
        public override Caching CreateCaching()
        {
            return new RedisCache();
        }

        public override Logging CreateLogger()
        {
            return new NLogger();
        }
    }

    public class ProductManager
    {
        private ExampleAbstractFactory _exampleFactory; 
        private Logging _logging;
        private Caching _caching;
        
        public ProductManager(ExampleAbstractFactory exampleFactory) 
        {
            _exampleFactory = exampleFactory;
            _logging = _exampleFactory.CreateLogger();
            _caching = _exampleFactory.CreateCaching();
        }

        public void GetAll()
        {
            _logging.Log("Logged");
            _caching.Cache("Data");
            Console.WriteLine("Product Listed!");
        }
    }

}
