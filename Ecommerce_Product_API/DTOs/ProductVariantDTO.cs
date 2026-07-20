namespace Ecommerce_Product_API.DTOs
{
    public class ProductVariantDTO
    {
        public int VariantId { get; set; }

        public int ProductId { get; set; }

        public string Sku { get; set; } = null!;

        public decimal BasePrice { get; set; }

        public decimal SalePrice { get; set; }

        public int Stock { get; set; }

        public DateTime? CreateDate { get; set; }

        public DateTime? UpdateDate { get; set; }
    }
}
