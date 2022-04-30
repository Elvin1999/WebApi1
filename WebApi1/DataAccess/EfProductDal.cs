using WebApi1.Entities;
using WebApi1.Models;

namespace WebApi1.DataAccess
{
    public class EfProductDal : EfEntityRepositoryBase<Product, NorthwindContext>, IProductDal
    {
        public List<ProductModel> GetProductsWithDetailts()
        {
            using (NorthwindContext context=new NorthwindContext())
            {
                var result = from p in context.Products
                             join c in context.Categories
                             on p.CategoryId equals c.CategoryId
                             select new ProductModel {
                             ProductId = p.ProductId,
                             CategoryName = c.CategoryName,
                             ProductName=p.ProductName,
                             UnitPrice = p.UnitPrice,
                             };
                return result.ToList();
            }
        }
    }
}
