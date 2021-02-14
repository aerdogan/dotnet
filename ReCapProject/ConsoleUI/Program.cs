using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());
          
            Car newCar = new Car();
            newCar.Name = "Ford";
            newCar.BrandId = 1;
            newCar.ColorId = 3;
            newCar.ModelYear = 2007;
            newCar.DailyPrice = 250;
            newCar.Description = "2007 model Beyaz Ford";
            carManager.Add(newCar);

            Car car1 = carManager.GetById(1);
            Console.WriteLine("Araç No: " + car1.Id + " Günlük Fiyat: " + car1.DailyPrice +
                 " Model: " + car1.ModelYear + " Açıklama: " + car1.Description);
            




        }
    }
}
