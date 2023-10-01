using EBuy.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBuy.Core
{
    public interface IUnitOfWork
    {
        IBusinessRepository Businesses { get; }
        ICategoryRepository Categories { get; }
        IProductRepository Products { get; }
        IProductPropertyRepository ProductProperties { get; }
        IProductPropertyTypeRepository ProductPropertyTypes { get; }
        IUserRepository Users { get; }
        Task<int> CommitAsync();
    }
}
