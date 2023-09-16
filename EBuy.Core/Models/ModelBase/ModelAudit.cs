using EBuy.Core.Models.ModelContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBuy.Core.Models.ModelBase
{
    public class ModelAudit : IModelAudit
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public int CreatedBy { get; set; } = 0;
        public DateTime? DeletedAt { get; set; } = null;
        public int? DeletedBy { get; set; } = null;
    }
}
