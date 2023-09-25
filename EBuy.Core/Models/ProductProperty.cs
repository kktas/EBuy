using EBuy.Core.Models.ModelBase;

namespace EBuy.Core.Models
{
    public class ProductProperty : ModelAudit
    {
        public string Name { get; set; }
        public CategoryProperty CategoryProperty { get; set; }
        public int CategoryPropertyId { get; set; }
    }
}
