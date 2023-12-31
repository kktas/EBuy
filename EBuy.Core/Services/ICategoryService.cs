﻿using EBuy.Core.Models;

namespace EBuy.Core.Services
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category>> GetAllCategories();
        Task<Category> GetCategoryById(int id);
        Task<IEnumerable<Category>> GetAllByParentCategoryId(int parentCategoryId);
        Task<Category> CreateCategory(Category category);
        Task UpdateCategory(Category categoryToBeUpdated, Category category);
        Task DeleteCategory(Category category);
    }
}
