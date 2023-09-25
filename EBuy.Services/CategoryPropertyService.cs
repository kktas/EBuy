using EBuy.Core;
using EBuy.Core.Models;
using EBuy.Core.Services;

namespace EBuy.Services;

public class CategoryPropertyService : ICategoryPropertyService
{
    private readonly IUnitOfWork _unitOfWork;
    public CategoryPropertyService(IUnitOfWork unitOfWork)
    {
        this._unitOfWork = unitOfWork;
    }
    public async Task<CategoryProperty> CreateCategoryProperty(CategoryProperty categoryProperty)
    {
        await _unitOfWork.CategoryProperties.AddAsync(categoryProperty);
        await _unitOfWork.CommitAsync();
        return categoryProperty;
    }

    public async Task DeleteCategoryProperty(CategoryProperty categoryProperty)
    {
        _unitOfWork.CategoryProperties.Remove(categoryProperty);
        await _unitOfWork.CommitAsync();
    }

    public async Task<IEnumerable<CategoryProperty>> GetAllCategoryProperties()
    {
        return await _unitOfWork.CategoryProperties.GetAllAsync();
    }

    public async Task<CategoryProperty> GetCategoryPropertyById(int id)
    {
        return await _unitOfWork.CategoryProperties.GetByIdAsync(id);
    }

    public async Task UpdateCategoryProperty(CategoryProperty categoryPropertyToBeUpdated, CategoryProperty categoryProperty)
    {
        categoryPropertyToBeUpdated.Name = categoryProperty.Name;
        categoryPropertyToBeUpdated.CategoryId = categoryProperty.CategoryId;
        categoryPropertyToBeUpdated.DeletedAt = categoryProperty.DeletedAt;
        categoryPropertyToBeUpdated.DeletedBy = categoryProperty.DeletedBy;

        await _unitOfWork.CommitAsync();
    }
}
