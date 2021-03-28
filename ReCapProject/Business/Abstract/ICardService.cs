using Core.Utilities.Results;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface ICardService
    {
        IResult Add(Card card);
        IDataResult<List<Card>> GetByCustomerId(int customerId);
    }
}
