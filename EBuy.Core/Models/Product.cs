using EBuy.Core.Models.ModelBase;

namespace EBuy.Core.Models
{
    public class Product : ModelAudit
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Properties { get; set; }
        public double Price { get; set; }
        public byte[] Image { get; set; }
        public Category Category { get; set; }
        public int CategoryId { get; set; }
        public Business Business { get; set; }
        public int BusinessId { get; set; }
    }
}
