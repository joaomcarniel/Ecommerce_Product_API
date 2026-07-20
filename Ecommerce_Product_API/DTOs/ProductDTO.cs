using Ecommerce_Product_API.Models;

namespace Ecommerce_Product_API.DTOs
{
    public class ProductDTO
    {
        public int ProductId { get; set; }

        public string Title { get; set; } = null!;

        public string ShortDescription { get; set; } = null!;

        public string? LongDescriptionProduct { get; set; }

        public string? BrandProduct { get; set; }

        public string CategoryProduct { get; set; } = null!;

        public bool IsActive { get; set; }

        public DateTime? CreateDate { get; set; }

        public DateTime? UpdateDate { get; set; }

        public virtual ICollection<ProductVariantDTO> ProductVariants { get; set; } = new List<ProductVariantDTO>();
    }
}
