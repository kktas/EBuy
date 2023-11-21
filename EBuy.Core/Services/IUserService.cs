using EBuy.Core.Models;

namespace EBuy.Core.Services
{
    public interface IUserService
    {
        public Task<IEnumerable<User>> GetAllUsers(string? full_name);
        public Task<User> GetUserById(int id);
        public Task<User> CreateUser(User user);
        public Task<IEnumerable<User>> GetUsersByBusinessId(int businessId);
        public Task UpdateUserInfo(User userToBeUpdated, User user);
        public Task UpdateUserPassword(User userToBeUpdated, string password);
        public Task DeleteUser(User user);
    }
}
