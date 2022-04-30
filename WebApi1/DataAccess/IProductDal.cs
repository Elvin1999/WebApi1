using WebApi1.Entities;
using WebApi1.Models;

namespace WebApi1.DataAccess
{
    public interface IProductDal : IEntityRepository<Product>
    {
        List<ProductModel> GetProductsWithDetailts();
    }
}
