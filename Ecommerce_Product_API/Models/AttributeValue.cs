using System;
using System.Collections.Generic;

namespace Ecommerce_Product_API.Models;

public partial class AttributeValue
{
    public int Id { get; set; }

    public int AttributeId { get; set; }

    public string AttributeValue1 { get; set; } = null!;

    public virtual Attribute Attribute { get; set; } = null!;
}
