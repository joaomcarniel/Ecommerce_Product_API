namespace Ecommerce_Product_API.DTOs
{
    public class AttributesDto
    {
        public string sku { get; set; }
        public List<AttributeValueDto> attributes { get; set; }
        
    }

    public class AttributeValueDto
    {
        public string attribute { get; set; }
        public string value { get; set; }
    }
}
