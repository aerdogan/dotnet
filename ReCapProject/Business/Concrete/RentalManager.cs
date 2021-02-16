using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        public IResult Add(Rental rental)
        {
            if (CarIsAvailable( rental.CarId))
            {
                _rentalDal.Add(rental);
                return new SuccessResult(Messages.RentalAdded);
            }
            return new ErrorResult(Messages.RentalCarIsntAvailable);
        }

        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult(Messages.RentalUpdated);
        }

        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult(Messages.RentalDeleted);
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(), Messages.RentalsListed);
        }

        public IDataResult<Rental> GetById(int id)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(r => r.Id == id));
        }

        public bool CarIsAvailable(int carId)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var result = from r in context.Rentals
                             where r.CarId == carId && r.ReturnDate == null
                             select r;
                return (result.Count() == 1) ? false : true;
            }
        }

        public IResult CarIsReturned(int carId)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                Rental rental = _rentalDal.Get(r => r.CarId == carId && r.ReturnDate == null);
                rental.ReturnDate = DateTime.Now;
                _rentalDal.Update(rental);
            }
            return new SuccessResult(Messages.RentalUpdated);;
        }

    }
}
