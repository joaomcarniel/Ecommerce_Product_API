using Ecommerce_Product_API.DTOs;
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
        public async Task<ActionResult<List<ProductVariantDTO>>> GetProductVariant([FromHeader] string Sku)
        {
            try
            {
                var productVariants = await productService.GetVariantBySKU(Sku);
                return Ok(productVariants);
            }
            catch(Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpGet]
        [Route("GetAllVariationsByProduct")]
        public async Task<ActionResult<ProductDTO>> GetAllVariationsByProduct([FromHeader] int ProductId)
        {
            try
            {
                var product = await productService.GetAllVariationsByProduct(ProductId);
                return Ok(product);
            }
            catch(Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpPut]
        [Route("UpdateProductVariationPrice")]
        public async Task<ActionResult<PriceUpdateResponse>> UpdateProductVariationPrice([FromBody] List<PriceUpdateBySkuDTO> Prices)
        {
            try
            {
                var result = await productService.UpdateProductVariationPrice(Prices);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

    }
}
