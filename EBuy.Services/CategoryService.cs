using EBuy.Core;
using EBuy.Core.Models;
using EBuy.Core.Services;

namespace EBuy.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoryService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<Category> CreateCategory(Category category)
        {
            await _unitOfWork.Categories.AddAsync(category);
            await _unitOfWork.CommitAsync();

            return category;
        }

        public async Task DeleteCategory(Category category)
        {
            _unitOfWork.Categories.Remove(category);
            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<Category>> GetAllCategories()
        {
            return await _unitOfWork.Categories.GetAllAsync();
        }

        public async Task<Category> GetCategoryById(int id)
        {
            return await _unitOfWork.Categories.GetByIdAsync(id); ;
        }

        public async Task<IEnumerable<Category>> GetAllByParentCategoryId(int parentCategoryId)
        {
            return await _unitOfWork.Categories.GetAllByParentCategoryId(parentCategoryId);
        }

        public async Task UpdateCategory(Category categoryToBeUpdated, Category category)
        {
            categoryToBeUpdated.Name = category.Name;
            categoryToBeUpdated.ParentCategoryId = category.ParentCategoryId;
            categoryToBeUpdated.DeletedAt = category.DeletedAt;
            categoryToBeUpdated.DeletedBy = category.DeletedBy;

            await _unitOfWork.CommitAsync();
        }
    }
}
