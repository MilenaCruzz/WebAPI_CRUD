using AutoMapper;
using CrudTeste.Domain.Entities;
using CrudTeste.Service.DTOs;

namespace CrudTeste.Service.AutoMapper
{
    public class AutoMapperConfig : Profile
    {

        public AutoMapperConfig()
        {
            CreateMap<UserDTO, User>();
            CreateMap<User, UserDTO>();
            
        }


    }
}
