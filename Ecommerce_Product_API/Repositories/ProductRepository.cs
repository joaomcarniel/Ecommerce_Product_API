using Ecommerce_Product_API.Contexts;
using Ecommerce_Product_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce_Product_API.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly HarvestContext _context;

        public ProductRepository(HarvestContext context)
        {
            _context = context;
        }

        public async Task<Product> GetProductById(int productId)
        {
            return await _context.Products.Where(x => x.ProductId == productId).FirstOrDefaultAsync();
        }

        public async Task<List<ProductVariant>> GetVariantBySKU(string sku)
        {
            return await _context.ProductVariants.Where(x => x.Sku == sku).ToListAsync();
        }

        public async Task<List<ProductVariant>> GetAllVariantsByProductId(int productId)
        {
            return await _context.ProductVariants.Where(x => x.ProductId == productId).ToListAsync();
        }
    }
}
