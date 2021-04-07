using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
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

        //[SecuredOperation("rental.add")]
        [ValidationAspect(typeof(RentalValidator))]
        public IResult Add(Rental rental)
        {
            if (!IsCarAvailable(rental.CarId)) return new ErrorResult(Messages.CarIsntAvailable);
            _rentalDal.Add(rental);
            return new SuccessResult(Messages.RentalAdded);
        }

        //[SecuredOperation("rental.update")]
        [ValidationAspect(typeof(RentalValidator))]
        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult(Messages.RentalUpdated);
        }

        //[SecuredOperation("rental.delete")]
        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult(Messages.RentalDeleted);
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(), Messages.RentalsListed);
        }

        public IDataResult<List<RentalDetailDto>> GetAllRentalDetails()
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetails(), Messages.RentalsListed);
        }

        public IDataResult<Rental> GetById(int id)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(r => r.Id == id));
        }

        public bool IsCarAvailable(int carId)
        {
            using (ReCapContext context = new ReCapContext())
            {
                var result = from r in context.Rentals
                             where r.CarId == carId && r.ReturnDate == null
                             select r;
                return (result.Count() == 0) ? true : false;
            }
        }

        public IResult CarIsReturned(int carId)
        {
            using (ReCapContext context = new ReCapContext())
            {
                Rental result = _rentalDal.Get(r => r.CarId == carId && r.ReturnDate == null);
                result.ReturnDate = DateTime.Now;
                _rentalDal.Update(result);
            }
            return new SuccessResult(Messages.RentalUpdated);
        }
    }
}
