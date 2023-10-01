using EBuy.Core.Models.ModelBase;

namespace EBuy.Core.Models
{
    public class ProductProperty : ModelAudit
    {
        public string Name { get; set; }
        public ProductPropertyType ProductPropertyType { get; set; }
        public int ProductPropertyTypeId { get; set; }
    }
}
