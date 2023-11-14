using AutoMapper;
using EBuyAPI_DTO.ProductProperty;
using EBuy.Core.Models;

namespace EBuy.API.Mapping
{
    public class ProductPropertyProfile : Profile
    {
        public ProductPropertyProfile()
        {
            //Domain to Resource
            CreateMap<ProductProperty, ProductPropertyDTO>();

            //Resource to Domain
            CreateMap<ProductPropertyDTO, ProductProperty>();
            CreateMap<CreateProductPropertyDTO, ProductProperty>();
            CreateMap<UpdateProductPropertyDTO, ProductProperty>();
        }
    }
}
