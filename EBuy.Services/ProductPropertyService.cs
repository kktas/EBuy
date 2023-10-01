using EBuy.Core;
using EBuy.Core.Models;
using EBuy.Core.Services;

namespace EBuy.Services;

public class ProductPropertyService : IProductPropertyService
{
    private readonly IUnitOfWork _unitOfWork;
    public ProductPropertyService(IUnitOfWork unitOfWork)
    {
        this._unitOfWork = unitOfWork;
    }
    public async Task<ProductProperty> CreateProductProperty(ProductProperty productProperty)
    {
        await _unitOfWork.ProductProperties.AddAsync(productProperty);
        await _unitOfWork.CommitAsync();
        return productProperty;
    }

    public async Task DeleteProductProperty(ProductProperty productProperty)
    {
        _unitOfWork.ProductProperties.Remove(productProperty);
        await _unitOfWork.CommitAsync();
    }

    public async Task<IEnumerable<ProductProperty>> GetAllProductProperties()
    {
        return await _unitOfWork.ProductProperties.GetAllAsync();
    }

    public async Task<ProductProperty> GetProductPropertyById(int id)
    {
        return await _unitOfWork.ProductProperties.GetByIdAsync(id);
    }

    public async Task UpdateProductProperty(ProductProperty productPropertyToBeUpdated, ProductProperty productProperty)
    {
        productPropertyToBeUpdated.Name = productProperty.Name;
        productPropertyToBeUpdated.ProductPropertyTypeId = productProperty.ProductPropertyTypeId;
        productPropertyToBeUpdated.DeletedAt = productProperty.DeletedAt;
        productPropertyToBeUpdated.DeletedBy = productProperty.DeletedBy;

        await _unitOfWork.CommitAsync();
    }
}
