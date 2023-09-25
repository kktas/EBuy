using EBuy.Core;
using EBuy.Core.Repositories;
using EBuy.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBuy.Data
{

    internal class UnitOfWork : IUnitOfWork
    {
        private readonly EBuyDbContext _context;
        private BusinessRepository _businessRepository;
        private CategoryRepository _categoryRepository;
        private ProductRepository _productRepository;
        private ProductPropertyRepository _productPropertyRepository;
        private CategoryPropertyRepository _categoryPropertyRepository;
        private UserRepository _userRepository;

        public UnitOfWork(EBuyDbContext context)
        {
            this._context = context;
        }

        public IBusinessRepository Businesses => _businessRepository ??= new BusinessRepository(this._context);
        public ICategoryRepository Categories => _categoryRepository ??= new CategoryRepository(this._context);
        public IProductRepository Products => _productRepository ??= new ProductRepository(this._context);
        public IProductPropertyRepository ProductProperty => _productPropertyRepository ??= new ProductPropertyRepository(this._context);
        public ICategoryPropertyRepository CategoryProperty => _categoryPropertyRepository ??= new CategoryPropertyRepository(this._context);
        public IUserRepository Users => _userRepository ??= new UserRepository(this._context);

        public Task<int> CommitAsync()
        {
            return _context.SaveChangesAsync();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
