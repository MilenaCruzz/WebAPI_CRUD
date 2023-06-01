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
        [Route("GetEmployee/{id}")]
        public async Task<EmployeeDTO> GetEmployee(int id)
        {
            return await _humanResourcesService.GetEmployeeById(id);
        }
    }
}
