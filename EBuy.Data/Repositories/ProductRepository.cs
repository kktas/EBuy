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
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(DbContext context) : base(context)
        {
        }

        private EBuyDbContext EBuyDbContext
        {
#pragma warning disable CS8603 // Possible null reference return.
            get { return Context as EBuyDbContext; }
#pragma warning restore CS8603 // Possible null reference return.       
        }
    }
}
