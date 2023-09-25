using EBuy.Core;
using EBuy.Core.Models;
using EBuy.Core.Services;

namespace EBuy.Services
{
    public class BusinessService : IBusinessService
    {
        private readonly IUnitOfWork _unitOfWork;
        public BusinessService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }
        public async Task<Business> CreateBusiness(Business newBusiness)
        {
            await _unitOfWork.Businesses.AddAsync(newBusiness);
            await _unitOfWork.CommitAsync();
            return newBusiness;
        }

        public async Task DeleteBusiness(Business business)
        {
            _unitOfWork.Businesses.Remove(business);
            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<Business>> GetBusinesses()
        {
            return await _unitOfWork.Businesses.GetAllAsync();
        }

        public async Task<Business> GetBusinessesById(int id)
        {
            return await _unitOfWork.Businesses.GetByIdAsync(id);
        }

        public async Task UpdateBusiness(Business businessToBeUpdated, Business business)
        {
            businessToBeUpdated.Name = business.Name;
            businessToBeUpdated.Address = business.Address;
            businessToBeUpdated.PhoneNumber = business.PhoneNumber;
            businessToBeUpdated.DeletedAt = business.DeletedAt;
            businessToBeUpdated.DeletedBy = business.DeletedBy;

            await _unitOfWork.CommitAsync();
        }
    }
}
