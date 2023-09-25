using EBuy.Core.Models;

namespace EBuy.Core.Services
{
    public interface ICategoryPropertyService
    {
        Task<IEnumerable<CategoryProperty>> GetAllCategoryProperties();
        Task<CategoryProperty> GetCategoryPropertyById(int id);
        Task<CategoryProperty> CreateCategoryProperty(CategoryProperty categoryProperty);
        Task UpdateCategoryProperty(CategoryProperty CategoryPropertyToBeUpdated, CategoryProperty categoryProperty);
        Task DeleteCategoryProperty(CategoryProperty categoryProperty);
    }
}
