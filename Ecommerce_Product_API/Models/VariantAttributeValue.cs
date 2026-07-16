using System;
using System.Collections.Generic;

namespace Ecommerce_Product_API.Models;

public partial class VariantAttributeValue
{
    public int Id { get; set; }

    public int VariantId { get; set; }

    public int AttributeValueId { get; set; }

    public virtual ProductVariant Variant { get; set; } = null!;
}
