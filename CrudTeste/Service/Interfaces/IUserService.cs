using CrudTeste.Domain.Entities;
using CrudTeste.Domain.Model;
using CrudTeste.Domain.VOs;
using CrudTeste.Infrastructure.Repositories;
using CrudTeste.Infrastructure.Repositories.Interfaces;
using CrudTeste.Service.DTOs.User;
using Microsoft.AspNetCore.Mvc;

namespace CrudTeste.Service.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<UserDTO>> GetAllUsers();

        Task<UserDTO> GetUserById(int id);
        void PostNewUser(PostUserModel model);

        Task UpdateUser(UpdateUserModel model, int idUser);

        Task DeleteUser(int idUser);

    }
}
