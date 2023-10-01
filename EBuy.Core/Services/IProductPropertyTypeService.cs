using EBuy.Core.Models;

namespace EBuy.Core.Services
{
    public interface IProductPropertyTypeService
    {
        Task<IEnumerable<ProductPropertyType>> GetAllProductPropertyTypes();
        Task<ProductPropertyType> GetProductPropertyTypeById(int id);
        Task<ProductPropertyType> CreateProductPropertyType(ProductPropertyType productPropertyType);
        Task UpdateProductPropertyType(ProductPropertyType ProductPropertyTypeToBeUpdated, ProductPropertyType productPropertyType);
        Task DeleteProductPropertyType(ProductPropertyType productPropertyType);
    }
}
