using Core.Utilities.Results;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface ICarImageService
    {
        IResult AddCarImage(CarImage carImage);
        IResult UpdateCarImage(CarImage carImage);
        IResult DeleteCarImage(CarImage carImage);

        IDataResult<CarImage> GetById(int carImageId);
        IDataResult<List<CarImage>> GetAll();

        IDataResult<List<CarImage>> GetCarImagesByCarId(int carId);
        IResult CheckCarImagesCount(int carId);
    }
}
