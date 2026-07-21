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

        public async Task UpdatePriceBySku(string sku, decimal basePrice, decimal salePrice)
        {
            var productVariation = await _context.ProductVariants.FirstOrDefaultAsync(p => p.Sku == sku);

            if (productVariation == null)
                throw new Exception("Product Variation not found.");

            productVariation.BasePrice = basePrice;
            productVariation.SalePrice = salePrice;


            await _context.SaveChangesAsync();
        }

        public async Task UpdatePriceByProductId(int productId, decimal basePrice, decimal salePrice)
        {
            var productVariation = await _context.ProductVariants.Where(p => p.ProductId == productId).ToListAsync();

            if (productVariation == null)
                throw new Exception("Products not found.");

            foreach(var product in productVariation)
            {
                product.BasePrice = basePrice;
                product.SalePrice = salePrice;
            }
            await _context.SaveChangesAsync();
        }

    }
}
