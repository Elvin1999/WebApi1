using WebApi1.Entities;

namespace WebApi1.DataAccess
{
    public class EfProductDal:EfEntityRepositoryBase<Product,NorthwindContext>,IProductDal
    {
    }
}
