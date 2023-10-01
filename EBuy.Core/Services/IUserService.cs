using EBuy.Core.Models;

namespace EBuy.Core.Services
{
    public interface IUserService
    {
        public Task<IEnumerable<User>> GetAllUsers();
        public Task<User> GetUserById(int id);
        public Task<User> CreateUser(User user);
        public Task<IEnumerable<User>> GetUsersByBusinessId(int businessId);
        public Task UpdateUser(User userToBeUpdated, User user);
        public Task DeleteUser(User user);
    }
}
