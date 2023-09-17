using EBuy.Core.Models;

namespace EBuy.Core.Services
{
    public interface IBusinessService
    {
        Task<IEnumerable<Business>> GetBusinesses();
        Task<Business> GetBusinessesById(int id);
        Task<Business> CreateBusiness(Business newBusiness);
        Task UpdateBusiness(Business businessToBeUpdated, Business business);
        Task DeleteBusiness(Business business);
    }
}
