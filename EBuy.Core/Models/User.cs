using EBuy.Core.Models.ModelBase;

namespace EBuy.Core.Models
{
    public class User : ModelAudit
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public Business? Business { get; set; }
        public int? BusinessId { get; set; }
    }
}
