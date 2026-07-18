using Ecommerce_Product_API.Models;

namespace Ecommerce_Product_API.Services
{
    public interface IProductService
    {
        Task<List<ProductVariant>> GetVariantBySKU(string sku);
    }
}
