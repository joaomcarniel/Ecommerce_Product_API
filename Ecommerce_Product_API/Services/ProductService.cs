using AutoMapper;
using Ecommerce_Product_API.DTOs;
using Ecommerce_Product_API.Models;
using Ecommerce_Product_API.Repositories;

namespace Ecommerce_Product_API.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository repository, IMapper mapper)
        {
            this._repository = repository;
            _mapper = mapper;
        }

        public async Task<ProductDTO> GetAllVariationsByProduct(int productId)
        {
            try
            {
                var product = await _repository.GetProductById(productId);
                var productDTO = _mapper.Map<ProductDTO>(product);
                var productVariations = await _repository.GetAllVariantsByProductId(productId);
                var productVariantDTOs = _mapper.Map<List<ProductVariantDTO>>(productVariations);
                productDTO.ProductVariants = productVariantDTOs;
                return productDTO;
            }
            catch(Exception ex)
            {
                throw new Exception($"Error retrieving all variations of product: {ex.Message}");
            }
        }

        public async Task<List<ProductVariantDTO>> GetVariantBySKU(string sku)
        {
            try
            {
                List<ProductVariant> variants = await _repository.GetVariantBySKU(sku);
                var responseDTO = _mapper.Map<List<ProductVariantDTO>>(variants);
                return responseDTO;
            }
            catch (Exception ex)
            {
                throw new Exception ($"Error retrieving product variant by SKU: {ex.Message}");
            }
        }
    }
}
