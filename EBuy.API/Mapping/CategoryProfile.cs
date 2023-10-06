using AutoMapper;
using EBuy.API.DTO.Category;
using EBuy.Core.Models;

namespace EBuy.API.Mapping
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            //Domain to Resource
            CreateMap<Category, CategoryDTO>();

            //Resource to Domain
            CreateMap<CategoryDTO, Category>();
            CreateMap<CreateCategoryDTO, Category>();
            CreateMap<UpdateCategoryDTO, Category>();
        }
    }
}
