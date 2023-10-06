using AutoMapper;
using EBuy.API.DTO.User;
using EBuy.Core.Models;

namespace EBuy.API.Mapping
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            //Domain to Resource
            CreateMap<User, UserDTO>();

            //Resource to Domain
            CreateMap<UserDTO, User>();
            CreateMap<CreateUserDTO, User>();
            CreateMap<UpdateUserDTO, User>();
        }
    }
}
