using System;
using System.Collections.Generic;

namespace Ecommerce_Product_API.Models;

public partial class Attribute
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<AttributeValue> AttributeValues { get; set; } = new List<AttributeValue>();
}
