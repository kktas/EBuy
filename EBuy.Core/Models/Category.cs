using EBuy.Core.Models.ModelBase;

namespace EBuy.Core.Models
{
    public class Category : ModelAudit
    {
        public string Name { get; set; }
        public Category? ParentCategory { get; set; }
        public int? ParentCategoryId { get; set; }
        public ICollection<Product> Products { get; set; }
        public ICollection<Category> ChildCategories { get; set; }
        public ICollection<CategoryProperty> CategoryProperties { get; set; }
    }
}
