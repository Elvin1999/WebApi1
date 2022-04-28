using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi1.DataAccess;
using WebApi1.Entities;

namespace WebApi1.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        IProductDal _productDal;

        public ProductController(IProductDal productDal)
        {
            _productDal = productDal;
        }

        [HttpGet("")]
        public IActionResult Get()
        {
            var products = new List<Product>
            {
                new Product
                {
                     CategoryId=1,
                      ProductId=1,
                       ProductName="Appl Watch",
                        UnitInStock=10,
                         UnitPrice=30
                }
            };
            return Ok(products);
        }
    }
}
