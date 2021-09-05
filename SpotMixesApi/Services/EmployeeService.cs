using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using SpotMixesApi.DataAccess;
using SpotMixesApi.Models;
using SpotMixesApi.Services.Interfaces;

namespace SpotMixesApi.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IMongoCollection<Employee> _employee;

        public EmployeeService(ISpotMixesDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _employee = database.GetCollection<Employee>("Employees");
        }

        public async Task<List<Employee>> GetAllEmployees() =>
            await _employee.FindAsync(Employee =>true).Result.ToListAsync();

        public async Task<Employee> GetEmployeeById(string id) =>
            await _employee.FindAsync(new BsonDocument { { "_id", new ObjectId(id) } }).Result.FirstAsync();

        public async Task CreateEmployee(Employee employee) =>
            await _employee.InsertOneAsync(employee);

        public async Task UpdateEmployee(Employee employeeIn) =>
            await _employee.ReplaceOneAsync(employee => employee.Id == employeeIn.Id, employeeIn);

        public async Task DeleteEmployee(string id) =>
            await _employee.DeleteOneAsync(employee => employee.Id == id);
    }
}