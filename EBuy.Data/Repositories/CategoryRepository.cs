using EBuy.Core.Models;
using EBuy.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EBuy.Data.Repositories
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {


        public Task<IEnumerable<Category>> GetAllWithParentCategoryAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Category>> GetAllWithParentCategoryByCategoryId(int categoryId)
        {
            throw new NotImplementedException();
        }

        public Task<Category> GetWithParentCategoryByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
