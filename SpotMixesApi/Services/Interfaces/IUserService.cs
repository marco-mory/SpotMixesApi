using System.Collections.Generic;
using System.Threading.Tasks;
using SpotMixesApi.Models;

namespace SpotMixesApi.Services.Interfaces
{
    public interface IUserService
    {
        Task<List<User>> GetAllUsers();
        Task<User> GetUserById(string id);
        Task CreateUser(User user);
        Task UpdateUser(User user);
        Task DeleteUser(string id);
    }
}