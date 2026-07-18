using Ecommerce_Product_API.Models;

namespace Ecommerce_Product_API.Repositories
{
    public interface IProductRepository
    {
        Task<List<ProductVariant>> GetVariantBySKU(string sku);
    }
}
