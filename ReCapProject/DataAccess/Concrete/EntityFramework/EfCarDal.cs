﻿using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, NorthwindContext>, ICarDal
    {
        public List<Car> GetCarsByBrandId(int brandId)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands
                             on c.BrandId equals b.Id
                             select c;

                return result.ToList();
            }
        }

        public List<Car> GetCarsByColorId(int colorId)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var result = from c in context.Cars
                             join cl in context.Colors
                             on c.ColorId equals cl.Id
                             select c;

                return result.ToList();
            }
        }
    }
}