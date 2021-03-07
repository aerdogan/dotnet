using System;

namespace FacadePattern
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomerManager cm = new CustomerManager();
            cm.Save();
            Console.ReadLine();
        }
    }

    internal interface ILogging
    {
        void Log();
    }
    class Logging : ILogging
    {
        public void Log()
        {
            Console.WriteLine("Logged");
        }
    }

    internal interface ICaching
    {
        void Cache();
    }
    class Caching : ICaching
    {
        public void Cache()
        {
            Console.WriteLine("Cached");
        }
    }

    internal interface IAuthorize
    {
        void CheckUser();
    }
    class Authorize : IAuthorize
    {
        public void CheckUser()
        {
            Console.WriteLine("User Checked");
        }
    }

    internal interface IValidate
    {
        void Validate();
    }
    class Validation : IValidate
    {
        public void Validate()
        {
            Console.WriteLine("Validated");
        }
    }

    class CustomerManager 
    {
        private Facade _facade;
        public CustomerManager()
        {
            _facade = new Facade();
        }

        public void Save()
        {
            _facade.caching.Cache();
            _facade.authorize.CheckUser();
            _facade.logging.Log();
            _facade.validate.Validate();
            Console.WriteLine("Saved");
        }
    }
    class Facade
    {
        public ILogging logging;
        public ICaching caching;
        public IAuthorize authorize;
        public IValidate validate;

        public Facade()
        {
            logging = new Logging();
            caching = new Caching();
            authorize = new Authorize();
            validate = new Validation();
        }
    }
}
