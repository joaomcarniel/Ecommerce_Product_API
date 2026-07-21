using Ecommerce_Product_API.Models;

namespace Ecommerce_Product_API.Repositories
{
    public interface IProductRepository
    {
        Task<Product> GetProductById(int productId);
        Task<List<ProductVariant>> GetVariantBySKU(string sku);
        Task<List<ProductVariant>> GetAllVariantsByProductId(int productId);
        Task UpdatePriceBySku(string sku, decimal basePrice, decimal salePrice);
    }
}
