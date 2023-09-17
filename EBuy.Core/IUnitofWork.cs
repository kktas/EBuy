using EBuy.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBuy.Core
{
    internal interface IUnitofWork
    {
        IBusinessRepository BusinessRepository { get; }
        ICategoryRepository CategoryRepository { get; }
        IProductRepository ProductRepository { get; }
        IProductPropertyRepository ProductPropertyRepository { get; }
        IProductPropertyTypeRepository ProductPropertyTypeRepository { get; }
        IUserRepository UserRepository { get; }
        Task<int> CommitAsync();
    }
}
