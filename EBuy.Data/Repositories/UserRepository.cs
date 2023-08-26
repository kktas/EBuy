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
    public class UserRepository : Repository<User>, IUserRepository
    {
        public Task<IEnumerable<User>> GetAllWithBusinessAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<User>> GetAllWithBusinessByBusinessIdAsync(int businessId)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetWithBusinessByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
