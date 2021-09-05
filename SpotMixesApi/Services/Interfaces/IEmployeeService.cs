using System.Collections.Generic;
using System.Threading.Tasks;
using SpotMixesApi.Models;

namespace SpotMixesApi.Services.Interfaces
{
    public interface IEmployeeService
    {
        Task<List<Employee>> GetAllEmployees();
        Task<Employee> GetEmployeeById(string id);
        Task CreateEmployee(Employee employee);
        Task UpdateEmployee(Employee employee);
        Task DeleteEmployee(string id);
    }
}