namespace Ecommerce_Product_API.Models;

public partial class ProductVariant
{
    public int VariantId { get; set; }

    public int ProductId { get; set; }

    public string Sku { get; set; } = null!;

    public decimal BasePrice { get; set; }

    public decimal SalePrice { get; set; }

    public int Stock { get; set; }

    public DateTime? CreateDate { get; set; }

    public DateTime? UpdateDate { get; set; }

    public virtual Product Product { get; set; } = null!;

    public virtual ICollection<VariantAttributeValue> VariantAttributeValues { get; set; } = new List<VariantAttributeValue>();
}
