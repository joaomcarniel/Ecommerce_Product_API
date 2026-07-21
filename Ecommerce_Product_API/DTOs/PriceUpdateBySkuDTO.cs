namespace Ecommerce_Product_API.DTOs
{
    public class PriceUpdateBySkuDTO
    {
        public string Sku { get; set; }
        public decimal BasePrice { get; set; }
        public decimal SalePrice { get; set; }
    }
}
