using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;

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
            newCar.ColorId = 2;
            newCar.ModelYear = 2007;
            newCar.DailyPrice = 250;
            newCar.Description = "2007 model Beyaz Ford";
            carManager.Add(newCar);
            
            ColorManager colorManager = new ColorManager(new EfColorDal());

            Color renk = new Color();
            renk.Name = "Siyah";
            colorManager.Add(renk);
          

            BrandManager brandManager = new BrandManager(new EfBrandDal());

            Brand marka = new Brand();
            marka.Id = 2;
            marka.Name = "Opel";
            brandManager.Add(marka);

           
            
            List<CarDetailDto> liste = carManager.GetCarDetails();
            foreach (var car in liste)
            {
                Console.WriteLine("Araç: " + car.CarName +" Marka: " + car.BrandName + " Color: " + car.ColorName + " Fiyat: " + car.DailyPrice);
            }
            
        }
    }
}
