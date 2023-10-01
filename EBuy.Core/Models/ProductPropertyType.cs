using EBuy.Core.Models.ModelBase;

namespace EBuy.Core.Models
{
    public class ProductPropertyType : ModelAudit
    {
        public string Name { get; set; }
        public Category Category { get; set; }
        public int CategoryId { get; set; }
        public ICollection<ProductProperty> ProductProperties { get; set; }
    }
}
