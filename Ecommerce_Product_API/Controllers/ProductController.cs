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
        public async Task<ActionResult<List<ProductVariant>>> GetProductVariant([FromHeader] string sku)
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
    }
}
