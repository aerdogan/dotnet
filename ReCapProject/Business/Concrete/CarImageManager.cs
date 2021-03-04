using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Aspects.Cancelation;
using Core.Utilities.Business;
using Core.Utilities.FileOperations;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;

        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }

        [SecuredOperation("carimage.add")]
        [ValidationAspect(typeof(CarImageValidator))]
        [CancellationTokenAspect]
        public IResult Add(CarImagesDto carImagesDto)
        {
            var result = BusinessRules.Run(CheckCarImagesCount(carImagesDto.CarId));
            if (result != null) return result;
            CarImage carimage = new CarImage
            {
                CarId = carImagesDto.CarId,
                ImagePath = FileOperations.SaveImageFile(carImagesDto.ImageFile),
                Date = DateTime.Now
            };
            _carImageDal.Add(carimage);
            return new SuccessResult(Messages.CarImageAdded);
        }

        [SecuredOperation("carimage.update")]
        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Update(CarImagesDto carImagesDto)
        {
            var result = _carImageDal.Get(ci => ci.Id == carImagesDto.Id);
            if (result == null) return new ErrorResult(Messages.CarImageNotFound);
            FileOperations.DeleteImageFile(result.ImagePath);
            result.ImagePath = FileOperations.SaveImageFile(carImagesDto.ImageFile);
            result.Date = DateTime.Now;
            _carImageDal.Update(result);
            return new SuccessResult(Messages.CarImageUpdated);
        }

        [SecuredOperation("carimage.delete")]
        public IResult Delete(CarImagesDto carImagesDto)
        {
            var result = _carImageDal.Get(ci => ci.Id == carImagesDto.Id);
            if (result == null) return new ErrorResult(Messages.CarImageNotFound);
            FileOperations.DeleteImageFile(result.ImagePath);
            _carImageDal.Delete(result);
            return new SuccessResult(Messages.CarImageDeleted);
        }

        private IResult CheckCarImagesCount(int carId)
        {
            var result = _carImageDal.GetAll(ci => ci.CarId == carId).Count < 5;
            if (!result) return new ErrorResult(Messages.CarImageCountExceeded);
            return new SuccessResult();
        }

        public IDataResult<CarImage> GetById(int carImageId)
        {
            CarImage result = _carImageDal.Get(ci => ci.Id == carImageId);
            if (result == null) return new ErrorDataResult<CarImage>(Messages.CarImageNotFound);
            return new SuccessDataResult<CarImage>(result);
        }

        public IDataResult<List<CarImage>> GetByCarId(int carId)
        {
            var result = _carImageDal.GetAll(ci => ci.CarId == carId);
            if (result.Any()) return new SuccessDataResult<List<CarImage>>(result);
            return new SuccessDataResult<List<CarImage>>(new List<CarImage> 
            {
                new CarImage{  CarId = carId,  ImagePath = "default.jpg", Date = DateTime.Now }
            });
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll());
        }

        public IResult DeleteByCarId(int carId)
        {
            var result = _carImageDal.GetAll(ci => ci.CarId == carId);
            foreach (var item in result)
            {
                FileOperations.DeleteImageFile(item.ImagePath);
                _carImageDal.Delete(item);
            }
            return new SuccessResult(Messages.CarImagesDeleted);
        }
    }
}
