using AutoMapper;
using EBuyAPI_DTO.Product;
using EBuy.Core.Models;

namespace EBuy.API.Mapping
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            //Domain to Resource
            CreateMap<Product, ProductDTO>();

            //Resource to Domain
            CreateMap<ProductDTO, Product>();
            CreateMap<CreateProductDTO, Product>();
            CreateMap<UpdateProductDTO, Product>();
        }
    }
}
