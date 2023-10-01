using EBuy.Core;
using EBuy.Core.Models;
using EBuy.Core.Services;

namespace EBuy.Services;

public class ProductPropertyTypeService : IProductPropertyTypeService
{
    private readonly IUnitOfWork _unitOfWork;
    public ProductPropertyTypeService(IUnitOfWork unitOfWork)
    {
        this._unitOfWork = unitOfWork;
    }
    public async Task<ProductPropertyType> CreateProductPropertyType(ProductPropertyType productPropertyType)
    {
        await _unitOfWork.ProductPropertyTypes.AddAsync(productPropertyType);
        await _unitOfWork.CommitAsync();
        return productPropertyType;
    }

    public async Task DeleteProductPropertyType(ProductPropertyType productPropertyType)
    {
        _unitOfWork.ProductPropertyTypes.Remove(productPropertyType);
        await _unitOfWork.CommitAsync();
    }

    public async Task<IEnumerable<ProductPropertyType>> GetAllProductPropertyTypes()
    {
        return await _unitOfWork.ProductPropertyTypes.GetAllAsync();
    }

    public async Task<ProductPropertyType> GetProductPropertyTypeById(int id)
    {
        return await _unitOfWork.ProductPropertyTypes.GetByIdAsync(id);
    }

    public async Task UpdateProductPropertyType(ProductPropertyType productPropertyTypeToBeUpdated, ProductPropertyType productPropertyType)
    {
        productPropertyTypeToBeUpdated.Name = productPropertyType.Name;
        productPropertyTypeToBeUpdated.CategoryId = productPropertyType.CategoryId;
        productPropertyTypeToBeUpdated.DeletedAt = productPropertyType.DeletedAt;
        productPropertyTypeToBeUpdated.DeletedBy = productPropertyType.DeletedBy;

        await _unitOfWork.CommitAsync();
    }
}
