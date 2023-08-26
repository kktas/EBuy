using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBuy.Core.Models.ModelContracts
{
    public interface IModelAudit : IModel
    {
        public DateTime CreatedAt { get; set; }
        public int CreatedBy { get; set; }
        public DateTime DeletedAt { get; set; }
        public int DeletedBy { get; set; }
    }
}
