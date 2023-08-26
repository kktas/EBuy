using EBuy.Core.Models.ModelContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBuy.Core.Models
{
    public class ProductProperty : IModelAudit
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ProductPropertyType ProductPropertyType { get; set; }
        public int ProductPropertyTypeId { get; set; }
        public DateTime CreatedAt { get; set; }
        public int CreatedBy { get; set; }
        public DateTime DeletedAt { get; set; }
        public int DeletedBy { get; set; }
    }
}
