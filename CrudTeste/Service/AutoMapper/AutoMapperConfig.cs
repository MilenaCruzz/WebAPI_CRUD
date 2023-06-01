﻿using AutoMapper;
using CrudTeste.Domain.Entities;
using CrudTeste.Domain.VOs;
using CrudTeste.Service.DTOs.Employee;
using CrudTeste.Service.DTOs.User;

namespace CrudTeste.Service.AutoMapper
{
    public class AutoMapperConfig : Profile
    {

        public AutoMapperConfig()
        {
            CreateMap<UserDTO, User>();
            CreateMap<User, UserDTO>();
            CreateMap<EmployeeVO, EmployeeDTO>();
            CreateMap<EmployeeDTO, EmployeeVO>();
            
        }


    }
}
