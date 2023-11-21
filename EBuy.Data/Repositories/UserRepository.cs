using EBuy.Core.Models;
using EBuy.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EBuy.Data.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(DbContext context) : base(context) { }

        public async Task<IEnumerable<User>> GetAllWithBusinessAsync(string? full_name)
        {
            return await EBuyDbContext.Users
                .Include(u => u.Business)
                .Where(u => full_name == null || (u.FirstName + " " + u.LastName).Contains(full_name))
                .ToListAsync();
        }

        public async Task<IEnumerable<User>> GetAllWithBusinessByBusinessIdAsync(int businessId)
        {
            return await EBuyDbContext.Users
                .Include(u => u.Business)
                .Where(u => u.BusinessId == businessId)
                .ToListAsync();
        }

        public Task<User> GetWithBusinessByIdAsync(int id)
        {
            return EBuyDbContext.Users
                .Include(u => u.Business)
                .SingleAsync(u => u.Id == id);
        }

        private EBuyDbContext EBuyDbContext
        {
#pragma warning disable CS8603 // Possible null reference return.
            get { return Context as EBuyDbContext; }
#pragma warning restore CS8603 // Possible null reference return.       
        }
    }
}
