using AutoMapper;
using Ecommerce_Product_API.DTOs;
using Ecommerce_Product_API.Models;

namespace Ecommerce_Product_API.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ProductVariant, ProductVariantDTO>();
            CreateMap<ProductVariantDTO, ProductVariant>();
            CreateMap<Product, ProductDTO>();
            CreateMap<ProductDTO, Product>();

        }
    }
}
