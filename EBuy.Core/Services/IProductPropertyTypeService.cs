using EBuy.Core.Models;

namespace EBuy.Core.Services
{
    public interface IProductPropertyTypeService
    {
        Task<IEnumerable<ProductPropertyType>> GetAllProductPropertyTypes();
        Task<ProductPropertyType> GetProductPropertyTypeById(int id);
        Task<ProductPropertyType> CreateProductPropertyType(ProductPropertyType productProperty);
        Task UpdateProductPropertyType(ProductPropertyType productPropertyTypeToBeUpdated, ProductPropertyType productPropertyType);
        Task DeleteProductPropertyType(ProductPropertyType productPropertyType);
    }
}
