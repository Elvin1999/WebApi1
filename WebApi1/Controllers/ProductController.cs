using Microsoft.AspNetCore.Authorization;
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
        [Authorize(Roles = "Admin")]
        public IActionResult Get()
        {
            var products = _productDal.GetList();
            return Ok(products);
        }

        [HttpGet("{productId}")]
        public IActionResult Get(int productId)
        {
            try
            {
            var product = _productDal.Get(p => p.ProductId == productId);
                if (product == null)
                {
                    return NotFound($"There is not product with id : {productId}");
                }
                return Ok(product);
            }
            catch (Exception)
            {

            }
            return BadRequest();
        }

        [HttpPost]
        public IActionResult Post([FromForm]Product product)
        {
            try
            {
                _productDal.Add(product);
                return new StatusCodeResult(200);
            }
            catch (Exception)
            {
            }
            return BadRequest();
        }

        [HttpPut]
        public IActionResult Put(Product product)
        {
            try
            {
                _productDal.Update(product);
                return Ok();
            }
            catch (Exception)
            {
            }
            return BadRequest();
        }

        [HttpDelete("{productId}")]
        public IActionResult Delete(int productId)
        {
            try
            {
                _productDal.Delete(new Product { ProductId = productId });
                return Ok();
            }
            catch (Exception)
            {
            }
            return BadRequest();
        }

        [HttpGet("GetProductsDetails")]
        public IActionResult GetProductsWithDetails()
        {
            try
            {
                var result = _productDal.GetProductsWithDetailts();
                return Ok(result);
            }
            catch (Exception)
            {
            }
            return BadRequest();
        }


    }
}
