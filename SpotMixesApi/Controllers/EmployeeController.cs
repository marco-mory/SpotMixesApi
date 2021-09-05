using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SpotMixesApi.Models;
using SpotMixesApi.Services;

namespace SpotMixesApi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class EmployeeController : Controller
    {
        private readonly EmployeeService _employeeService;

        public EmployeeController(EmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEmployees() => Ok(await _employeeService.GetAllEmployees());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployeeById(string id) => Ok(await _employeeService.GetEmployeeById(id));
       

        [HttpPost]
        public async Task<IActionResult> CreateEmployee([FromBody] Employee employee)
        {
            await _employeeService.CreateEmployee(employee);
            return Created("Created", true);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmployee([FromBody] Employee employee, string id)
        {
            employee.Id = id;
            await _employeeService.UpdateEmployee(employee);
            return Created("Updated", true);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(string id)
        {
            await _employeeService.DeleteEmployee(id);
            return NoContent(); //success
        }
    }
}