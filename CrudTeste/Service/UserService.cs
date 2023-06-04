using AutoMapper;
using CrudTeste.Domain.Entities;
using CrudTeste.Domain.Model.User;
using CrudTeste.Domain.VOs;
using CrudTeste.Infrastructure.Repositories;
using CrudTeste.Infrastructure.Repositories.Interfaces;
using CrudTeste.Service.DTOs.User;
using CrudTeste.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net;
using System.Runtime.CompilerServices;

namespace CrudTeste.Service
{
    public class UserService : IUserService
    {
         private readonly IUserRepository _userRepository;
         private readonly IMapper _mapper;
         public UserService(IUserRepository userRepository, IMapper mapper)
         {
             _userRepository = userRepository;
             _mapper = mapper;
         }

         public async Task<IEnumerable<UserDTO>> GetAllUsers()
        {
               var users = await _userRepository.GetAll();

            var listUsers = _mapper.Map<IEnumerable<User>, IEnumerable<UserDTO>>(users);

            return listUsers;
        }

        public async Task<UserDTO> GetUserById(int id)
        {

            var userData = await _userRepository.GetById(id);
            var userDTO = _mapper.Map<UserDTO>(userData);

            if (userData != null)
            {
                 userDTO = new UserDTO
                {
                    FirstName = userData.FirstName,
                    MiddleName = userData.MiddleName,
                    LastName = userData.LastName,
                    EmailAddress = userData.EmailAddress
                };
            }

            return userDTO;
        }

        public void PostNewUser([FromBody] PostUserModel model)
        {
           
            var newUser = new User
            {
                FirstName = model.FirstName,
                MiddleName = model.MiddleName,
                LastName = model.LastName,
                EmailAddress = model.EmailAddress
            };
              _userRepository.Add(newUser);    
        }
        public async Task UpdateUser([FromBody] UpdateUserModel model, int idUser)
        {
            Domain.Entities.User userData = await _userRepository.GetById(idUser);
            
            if(userData != null)
            {
                userData.FirstName = model.FirstName;
                userData.MiddleName = model.MiddleName;
                userData.LastName =model.LastName;
                userData.EmailAddress = model.EmailAddress;
            }

            _userRepository.Update(userData, idUser);
        }
        public async Task DeleteUser(int idUser)
        {
            Domain.Entities.User userData = await _userRepository.GetById(idUser);

            if( userData != null )
            {
                 _userRepository.Delete(idUser);
            }     
        }
    }

}
