using Core.Utilities.Results;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface ICategoryService
    {
        List<Category> GetAll();
        
        IResult Add(Category category);

        Category GetById(int categoryId);
    }
}
