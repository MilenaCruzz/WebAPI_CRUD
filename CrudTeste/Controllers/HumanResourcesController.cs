using CrudTeste.Domain.Entities;
using CrudTeste.Domain.Model.HumanResources;
using CrudTeste.Domain.VOs.HumanResources;
using CrudTeste.Service.DTOs.Employee;
using CrudTeste.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CrudTeste.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HumanResourcesController : Controller
    {
        private readonly IHumanResourcesService _humanResourcesService;

        public HumanResourcesController(IHumanResourcesService humanResourcesService)
        {
            _humanResourcesService = humanResourcesService;
        }

        [HttpGet]
        [Route("GetAllEmployees")]

        public async Task<IEnumerable<EmployeeDTO>> GetAll()
        {
            return await _humanResourcesService.GetAllEmployees();
        }

        [HttpGet]
        [Route("GetEmployee/{id}")]
        public async Task<EmployeeDTO> GetEmployee(int id)
        {
            return await _humanResourcesService.GetEmployeeById(id);
        }

        [HttpGet]
        [Route("EmployeeContact/{id}")]

        public async Task<EmployeeContactDTO> GetEmployeeContact(int id)
        {
            return await _humanResourcesService.GetEmployeeContactById(id);
        }
    }
}
