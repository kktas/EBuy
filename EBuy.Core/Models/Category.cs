using EBuy.Core.Models.ModelContracts;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBuy.Core.Models
{
    public class Category : IModelAudit
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Category ParentCategory { get; set; }
        public int ParentCategoryId { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public int CreatedBy { get; set; } = 0;
        public DateTime DeletedAt { get; set; }
        public int DeletedBy { get; set; }
        public ICollection<Product> Products { get; set; }
        public ICollection<Category> ChildCategories { get; set; }
        public ICollection<ProductPropertyType> ProductPropertyTypes { get; set; }
    }
}
