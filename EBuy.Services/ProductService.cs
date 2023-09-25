using EBuy.Core;
using EBuy.Core.Models;
using EBuy.Core.Services;

namespace EBuy.Services;

public class ProductService : IProductService
{
    private readonly IUnitOfWork _unitOfWork;
    public ProductService(IUnitOfWork unitOfWork)
    {
        this._unitOfWork = unitOfWork;
    }
    public async Task<Product> CreateProduct(Product product)
    {
        await _unitOfWork.Products.AddAsync(product);
        await _unitOfWork.CommitAsync();

        return product;
    }

    public async Task DeleteProduct(Product product)
    {
        _unitOfWork.Products.Remove(product);
        await _unitOfWork.CommitAsync();
    }

    public async Task<IEnumerable<Product>> GetAllProducts()
    {
        return await _unitOfWork.Products.GetAllAsync();
    }

    public async Task<Product> GetProductById(int id)
    {
        return await _unitOfWork.Products.GetByIdAsync(id);
    }

    public async Task UpdateProduct(Product productToBeUpdated, Product product)
    {
        productToBeUpdated.BusinessId = product.BusinessId;
        productToBeUpdated.CategoryId = product.CategoryId;
        productToBeUpdated.Name = product.Name;
        productToBeUpdated.Price = product.Price;
        productToBeUpdated.Image = product.Image;
        productToBeUpdated.Description = product.Description;
        productToBeUpdated.Properties = product.Properties;
        productToBeUpdated.DeletedAt = product.DeletedAt;
        productToBeUpdated.DeletedBy = product.DeletedBy;

        await _unitOfWork.CommitAsync();
    }
}
