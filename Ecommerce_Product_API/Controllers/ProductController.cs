using Ecommerce_Product_API.DTOs;
using Ecommerce_Product_API.Models;
using Ecommerce_Product_API.Services;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce_Product_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        IProductService productService;

        public ProductController(IProductService productService)
        {
            this.productService = productService;
        }

        [HttpGet]
        [Route("GetProductVariation")]
        public async Task<ActionResult<List<ProductVariantDTO>>> GetProductVariant([FromHeader] string sku)
        {
            try
            {
                var productVariants = await productService.GetVariantBySKU(sku);
                return Ok(productVariants);
            }
            catch(Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpGet]
        [Route("GetAllVariationsByProduct")]
        public async Task<ActionResult<ProductDTO>> GetAllVariationsByProduct([FromHeader] int productId)
        {
            try
            {
                var product = await productService.GetAllVariationsByProduct(productId);
                return Ok(product);
            }
            catch(Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}
