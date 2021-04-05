using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, ReCapContext>, ICarDal
    {
        public List<Car> GetCarsByBrandId(int brandId)
        {
            using (ReCapContext context = new ReCapContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands
                             on c.BrandId equals b.Id
                             where c.BrandId == brandId
                             select c;

                return result.ToList();
            }
        }

        public List<Car> GetCarsByColorId(int colorId)
        {
            using (ReCapContext context = new ReCapContext())
            {
                var result = from c in context.Cars
                             join cl in context.Colors
                             on c.ColorId equals cl.Id
                             where c.ColorId == colorId
                             select c;

                return result.ToList();
            }
        }

        public CarDetailDto GetCarDetailsById(Expression<Func<CarDetailDto, bool>> filter = null)
        {
            using (ReCapContext context = new ReCapContext())
            {
                var result = from c in context.Cars
                             join co in context.Colors on c.ColorId equals co.Id
                             join b in context.Brands on c.BrandId equals b.Id
                             select new CarDetailDto
                             {
                                 Id = c.Id,
                                 Name = c.Name,
                                 ColorId = c.ColorId,
                                 ColorName = co.Name,
                                 BrandId = c.BrandId,
                                 BrandName = b.Name,
                                 ModelYear = c.ModelYear,
                                 DailyPrice = c.DailyPrice,
                                 Description = c.Description
                             };
                return filter == null ? result.FirstOrDefault() : result.Where(filter).FirstOrDefault();
            }
        }

        public List<CarDetailDto> GetCarDetails(Expression<Func<CarDetailDto, bool>> filter = null)
        {
            using (ReCapContext context = new ReCapContext())
            {
                var result = from c in context.Cars
                             join co in context.Colors on c.ColorId equals co.Id
                             join b in context.Brands on c.BrandId equals b.Id
                             select new CarDetailDto
                             {
                                 Id = c.Id,
                                 Name = c.Name,
                                 ColorId = c.ColorId,
                                 ColorName = co.Name,
                                 BrandId = c.BrandId,
                                 BrandName = b.Name,
                                 ModelYear = c.ModelYear,
                                 DailyPrice = c.DailyPrice,
                                 Description = c.Description
                             };
                return filter == null ? result.ToList() : result.Where(filter).ToList();
            }
        }
    }
}