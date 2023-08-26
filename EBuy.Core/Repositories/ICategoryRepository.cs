using EBuy.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBuy.Core.Repositories
{
    public interface ICategoryRepository : IRepository<Category>
    {
        Task<IEnumerable<Category>> GetAllWithParentCategoryAsync();
        Task<Category> GetWithParentCategoryByIdAsync(int id);
        Task<IEnumerable<Category>> GetAllWithParentCategoryByCategoryId(int categoryId);

    }
}
