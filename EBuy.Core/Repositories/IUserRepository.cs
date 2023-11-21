using EBuy.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBuy.Core.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        Task<IEnumerable<User>> GetAllWithBusinessAsync(string? full_name);
        Task<User> GetWithBusinessByIdAsync(int id);
        Task<IEnumerable<User>> GetAllWithBusinessByBusinessIdAsync(int businessId);
    }
}
