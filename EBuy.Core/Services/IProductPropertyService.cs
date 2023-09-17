using EBuy.Core.Models;

namespace EBuy.Core.Services
{
    public interface IProductPropertyService
    {
        Task<IEnumerable<ProductProperty>> GetAllProductProperties();
        Task<ProductProperty> GetProductPropertyById(int id);
        Task<ProductProperty> CreateProductProperty(ProductProperty productProperty);
        Task UpdateProductProperty(ProductProperty productPropertyToBeUpdated, ProductProperty productProperty);
        Task DeleteProductProperty(ProductProperty productProperty);
    }
}
