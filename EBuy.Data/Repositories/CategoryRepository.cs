using EBuy.Core.Models;
using EBuy.Core.Repositories;
using Microsoft.EntityFrameworkCore;
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
        public CategoryRepository(DbContext context) : base(context)
        { }

        public async Task<IEnumerable<Category>> GetAllByParentCategoryId(int parentCategoryId)
        {
            return await EBuyDbContext.Set<Category>().Where(c => c.ParentCategoryId == parentCategoryId).ToListAsync();
        }

        private EBuyDbContext EBuyDbContext
        {
#pragma warning disable CS8603 // Possible null reference return.
            get { return Context as EBuyDbContext; }
#pragma warning restore CS8603 // Possible null reference return.             
        }
    }
}
