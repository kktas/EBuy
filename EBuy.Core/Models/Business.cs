using EBuy.Core.Models.ModelBase;

namespace EBuy.Core.Models
{
    public class Business : ModelAudit
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public ICollection<User> Users { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}