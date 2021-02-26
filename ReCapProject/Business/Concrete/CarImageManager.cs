using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        private readonly ICarImageDal _carImageDal;

        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }

        [ValidationAspect(typeof(CarImageValidator))]
        public IResult AddCarImage(CarImage carImage)
        {
            var result = BusinessRules.Run(
                CheckCarImagesCount(carImage.CarId)
            );

            if (result == null)
            {
                carImage.Date = DateTime.Now;
                _carImageDal.Add(carImage);
                return new SuccessResult(Messages.CarImageAdded);
            }
            return new ErrorResult(Messages.CarImageNotAdded);
        }

        public IResult UpdateCarImage(CarImage carImage)
        {
            var entity = _carImageDal.Get(ci => ci.Id == carImage.Id);
            if (entity != null)
            {
                entity.ImagePath = carImage.ImagePath;
                entity.Date = DateTime.Now;
                _carImageDal.Update(entity);
                return new SuccessResult(Messages.CarImageUpdated);
            }
            return new ErrorResult(Messages.CarImageNotFound);
        }

        public IResult DeleteCarImage(CarImage carImage)
        {
            _carImageDal.Delete(carImage);
            return new SuccessResult(Messages.CarImageDeleted);
        }

        private IResult CheckCarImagesCount(int carId)
        {
            if (_carImageDal.GetAll(ci => ci.CarId == carId).Count < 5)
            {
                return new SuccessResult();
            }
            return new ErrorResult(Messages.CarImageCountExceeded);
        }

        public IDataResult<List<CarImage>> GetImagesByCarId(int carId)
        {
            var result = _carImageDal.GetAll(ci => ci.CarId == carId);
            if (!result.Any())
            {
                return new SuccessDataResult<List<CarImage>>(new List<CarImage>
                {
                    new CarImage{ ImagePath = "default.jpg", Date = DateTime.Now }
                });
            }
            return new SuccessDataResult<List<CarImage>>(result);
        }

        public IDataResult<CarImage> GetById(int carImageId)
        {
            CarImage carImage = _carImageDal.Get(ci => ci.Id == carImageId);
            if (carImage != null)
            {
                return new SuccessDataResult<CarImage>(carImage);
            }
            return new ErrorDataResult<CarImage>(Messages.CarImageNotFound);
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll());
        }
    }
}
