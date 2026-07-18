using Ecommerce_Product_API.Models;
using Ecommerce_Product_API.Repositories;

namespace Ecommerce_Product_API.Services
{
    public class ProductService : IProductService
    {
        IProductRepository repository;

        public ProductService(IProductRepository repository)
        {
            this.repository = repository;
        }

        public async Task<List<ProductVariant>> GetVariantBySKU(string sku)
        {
            try
            {
                List<ProductVariant> variants = await  repository.GetVariantBySKU(sku);
                return variants;
            }
            catch (Exception ex)
            {
                throw new Exception ($"Error retrieving product variant by SKU: {ex.Message}");
            }
        }
    }
}
