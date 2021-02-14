using Business.Concrete;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new InMemoryCarDal());

            foreach (Car car in carManager.GetAll())
            {
                Console.WriteLine("Araç No: " + car.Id+ " Günlük Fiyat: " + car.DailyPrice +
                 " Model: " + car.ModelYear + " Açıklama: " + car.Description );
            }

            Car newCar = new Car();
            newCar.Id = 5;
            newCar.BrandId = 1;
            newCar.ColorId = 3;
            newCar.ModelYear = 2007;
            newCar.DailyPrice = 250;
            newCar.Description = "2007 model Beyaz Ford";
            carManager.Add(newCar);

            Car car5 = carManager.GetById(5);
            Console.WriteLine("Araç No: " + car5.Id + " Günlük Fiyat: " + car5.DailyPrice +
                 " Model: " + car5.ModelYear + " Açıklama: " + car5.Description);

            car5.DailyPrice = 270;
            carManager.Update(car5);
            Console.WriteLine("Araç No: " + car5.Id + " Günlük Fiyat: " + car5.DailyPrice +
                 " Model: " + car5.ModelYear + " Açıklama: " + car5.Description);

            carManager.Delete(car5);
            
            foreach (Car car in carManager.GetAll())
            {
                Console.WriteLine("Araç No: " + car.Id + " Günlük Fiyat: " + car.DailyPrice +
                 " Model: " + car.ModelYear + " Açıklama: " + car.Description);
            }

        }
    }
}
