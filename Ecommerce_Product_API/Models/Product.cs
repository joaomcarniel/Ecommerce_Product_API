using System;
using System.Collections.Generic;

namespace Ecommerce_Product_API.Models;

public partial class Product
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

    public virtual ICollection<ProductVariant> ProductVariants { get; set; } = new List<ProductVariant>();
}
