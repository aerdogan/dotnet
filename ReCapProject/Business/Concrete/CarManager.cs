using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;
        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public void Add(Car car)
        {
            _carDal.Add(car);
            Console.WriteLine("Yeni Araç Eklendi : " + car.Description );
        }
        public void Update(Car car)
        {
            _carDal.Update(car);
            Console.WriteLine( car.Id + " Numaralı Araç Güncellendi : " + car.Description);
        }

        public void Delete(Car car)
        {
            _carDal.Delete(car);
            Console.WriteLine("Araç Silindi : " + car.Description);
        }

        public List<Car> GetAll()
        {
            Console.WriteLine("Araçlar.... :");
            return _carDal.GetAll();
        }

        public Car GetById(int id)
        {
            return _carDal.GetById(id);
        }

    }
}
