using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IBankCardService
    {
        IResult Add(BankCard bankCard);

        IResult Checkout(BankCard bankCard, bool saveCard);
        
        IDataResult<List<BankCard>> GetAllByCustomerId(int customerId);
        IDataResult<BankCard> GetById(int id);
    }
}
