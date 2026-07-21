using Ecommerce_Product_API.DTOs;
using Ecommerce_Product_API.Models;

namespace Ecommerce_Product_API.Services
{
    public interface IProductService
    {
        Task<ProductDTO> GetAllVariationsByProduct(int productId);
        Task<List<ProductVariantDTO>> GetVariantBySKU(string sku);
        Task<List<PriceUpdateResponse>> UpdatePriceByProductId(List<PriceUpdateByProductIdDTO> prices);
        Task<List<PriceUpdateResponse>> UpdatePriceBySku(List<PriceUpdateBySkuDTO> prices);
    }
}
