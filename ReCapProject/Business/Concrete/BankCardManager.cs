using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class BankCardManager : IBankCardService
    {
        IBankCardDal _bankCardDal;

        public BankCardManager(IBankCardDal bankCardDal)
        {
            _bankCardDal = bankCardDal;
        }

        public IResult Add(BankCard bankCard)
        {
            _bankCardDal.Add(bankCard);
            return new SuccessResult(Messages.BankCardAdded);
        }


        public IResult Checkout(BankCard bankCard, bool saveCard)
        {
            /* puanı yeterlimi kontrol et 
             * bakiye yeterlimi kontrol et
            */
            if (saveCard)
            {
                _bankCardDal.Add(bankCard);
            }
            return new SuccessResult(Messages.PaymentSuccessful);
        }

        public IDataResult<List<BankCard>> GetAllByCustomerId(int customerId)
        {
            return new SuccessDataResult<List<BankCard>>(_bankCardDal.GetAll(bc => bc.CustomerId == customerId));
        }

        public IDataResult<BankCard> GetById(int id)
        {
            return new SuccessDataResult<BankCard>(_bankCardDal.Get(bc => bc.Id == id));
        }
    }
}
