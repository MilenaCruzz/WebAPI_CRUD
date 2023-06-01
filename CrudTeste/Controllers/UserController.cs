using CrudTeste.Domain.Entities;
using CrudTeste.Domain.Model;
using CrudTeste.Infrastructure.Repositories.Interfaces;
using CrudTeste.Service.DTOs.User;
using CrudTeste.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.ComponentModel;

namespace CrudTeste.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IUserRepository _userRepository;

        public UserController(IUserService userService, IUserRepository userRepository)
        {
            _userService = userService;
            _userRepository = userRepository;

        }


        [HttpGet]
        [Route("{idUser}")]

        public async Task<UserDTO> GetUserId(int idUser)
        {
            return await _userService.GetUserById(idUser);
        }


        [HttpGet]
        [Route("GetAll")]

        public async Task<IEnumerable<UserDTO>> GetAll()
        {
            return await _userService.GetAllUsers();
        }

        [HttpPost]

        public void PostUser([FromBody]PostUserModel model)
        {
            _userService.PostNewUser(model);    
        }

        [HttpPut]
        [Route("{idUser}")]

        public async Task PutUser([FromBody] UpdateUserModel model, int idUser)
        {
             await  _userService.UpdateUser(model, idUser);
        }

        [HttpDelete]
        [Route("{idUser}")]

        public async Task DeleteUser(int idUser)
        {
           await _userService.DeleteUser(idUser);
        }

       

    } 
}
