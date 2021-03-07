using Ninject;
using System;

namespace DependencyInjectionPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            IKernel kernel = new StandardKernel();
            kernel.Bind<IProductDal>().To<NHProductDal>().InSingletonScope();            
            ProductManager productManager = new ProductManager(kernel.Get<IProductDal>());
            productManager.Save();
            Console.ReadLine();
        }
    }

    interface IProductDal 
    {
        void Save();
    }

    class EFProductDal:IProductDal 
    {
        public void Save()
        {
            Console.WriteLine("Saved with EF");
        }
    }

    class NHProductDal : IProductDal
    {
        public void Save()
        {
            Console.WriteLine("Saved with NH");
        }
    }

    class ProductManager 
    {
        private IProductDal _productDal;
        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }
        public void Save()
        {
            _productDal.Save(); 
        }
    }
}
