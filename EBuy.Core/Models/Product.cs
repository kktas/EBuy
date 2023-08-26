using EBuy.Core.Models.ModelContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBuy.Core.Models
{
    public class Product : IModelAudit
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Properties { get; set; }
        public double Price { get; set; }
        public byte[] Image { get; set}
        public Category Category { get; set; }
        public int CategoryId { get; set; }
        public Business Business { get; set; }
        public int BusinessId { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public int CreatedBy { get; set; } = 0;
        public DateTime DeletedAt { get; set; }
        public int DeletedBy { get; set; }
    }
}
