using AutoMapper;
using EBuyAPI_DTO.Business;
using EBuy.Core.Models;

namespace EBuy.API.Mapping
{
    public class BusinessProfile : Profile
    {
        public BusinessProfile()
        {
            //Domain to Resource
            CreateMap<Business, BusinessDTO>();

            //Resource to Domain
            CreateMap<BusinessDTO, Business>();
            CreateMap<CreateBusinessDTO, Business>();
            CreateMap<UpdateBusinessDTO, Business>();
        }
    }
}
