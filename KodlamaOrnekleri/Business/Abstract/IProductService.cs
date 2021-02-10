using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IProductService
    {
        IResult Add(Product product);

        IDataResult<List<Product>> GetAll();

        IDataResult<Product> GetById(int productId);

        IDataResult<List<Product>> GetAllByCategoryId(int Id);

        IDataResult<List<Product>> GetAllByUnitPrice(decimal min, decimal max);

        IDataResult<List<ProductDetailDto>> GetProductDetails();
    }
}