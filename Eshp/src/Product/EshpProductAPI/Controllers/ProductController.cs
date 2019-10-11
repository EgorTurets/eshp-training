using EshpProductCommon;
using EshpProductService.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace EshpProductAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("base/{count}/{page}")]
        public ActionResult<IEnumerable<ProductBase>> GetProducts(int count, int page)
        {
            var result = _productService.GetProductsBase(count, page);

            return new JsonResult(result);
        }

        [HttpGet("base/{id}")]
        public ActionResult<ProductBase> GetProduct(int id)
        {
            var result = _productService.GetProductById(id);

            return new JsonResult(result);
        }

        public ActionResult<List<ProductBase>> GetProductList()
        {
            return null;
        }

        [HttpPost]
        public ActionResult<ProductBase> CreateProduct([FromBody] ProductBase product)
        {
            var result = _productService.CreateProduct(product);

            return new JsonResult(result);
        }
    }
}