using EBuy.Core;
using EBuy.Core.Models;
using EBuy.Core.Services;

namespace EBuy.Services;

public class UserService : IUserService
{
    private readonly IUnitOfWork _unitOfWork;
    public UserService(IUnitOfWork unitOfWork)
    {
        this._unitOfWork = unitOfWork;
    }
    public async Task<User> CreateUser(User user)
    {
        await _unitOfWork.Users.AddAsync(user);
        await _unitOfWork.CommitAsync();

        return user;
    }

    public async Task DeleteUser(User user)
    {
        _unitOfWork.Users.Remove(user);
        await _unitOfWork.CommitAsync();
    }

    public async Task<IEnumerable<User>> GetAllUsers()
    {
        return await _unitOfWork.Users.GetAllWithBusinessAsync();
    }

    public async Task<User> GetUserById(int id)
    {
        return await _unitOfWork.Users.GetWithBusinessByIdAsync(id);
    }

    public async Task<IEnumerable<User>> GetUsersByBusinessId(int businessId)
    {
        return await _unitOfWork.Users.GetAllWithBusinessByBusinessIdAsync(businessId);
    }

    public async Task UpdateUserInfo(User userToBeUpdated, User user)
    {
        userToBeUpdated.Address = user.Address;
        userToBeUpdated.FirstName = user.FirstName;
        userToBeUpdated.LastName = user.LastName;
        userToBeUpdated.Email = user.Email;
        userToBeUpdated.PhoneNumber = user.PhoneNumber;
        userToBeUpdated.DeletedAt = user.DeletedAt;
        userToBeUpdated.DeletedBy = user.DeletedBy;

        await _unitOfWork.CommitAsync();
    }

    public async Task UpdateUserPassword(User userToBeUpdated, string password)
    {
        userToBeUpdated.Password = password;

        await _unitOfWork.CommitAsync();
    }
}
