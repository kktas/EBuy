using EBuy.Core.Models.ModelContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

namespace EBuy.Core.Models
{
    public class Business : IModelAudit
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public int CreatedBy { get; set; } = 0;
        public DateTime DeletedAt { get; set; }
        public int DeletedBy { get; set; }
        public ICollection<User> Users { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
