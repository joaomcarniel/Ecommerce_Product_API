namespace Ecommerce_Product_API.DTOs
{
    public class PriceUpdateByProductIdDTO
    {
        public int ProductId { get; set; }
        public decimal BasePrice { get; set; }
        public decimal SalePrice { get; set; }
    }
}
