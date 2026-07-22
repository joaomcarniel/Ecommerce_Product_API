using Ecommerce_Product_API.DTOs;
using Ecommerce_Product_API.Models;

namespace Ecommerce_Product_API.Services
{
    public interface IProductService
    {
        Task<ProductDTO> GetAllVariationsByProduct(int productId);
        Task<List<ProductVariantDTO>> GetVariantBySKU(string sku);
        Task<List<ProductUpdateResponse>> UpdatePriceByProductId(List<PriceUpdateByProductIdDTO> prices);
        Task<List<ProductUpdateResponse>> UpdatePriceBySku(List<PriceUpdateBySkuDTO> prices);
        Task<List<ProductUpdateResponse>> UpdateStockBySky(List<StockUpdateBySkuDTO> stocks);
    }
}
