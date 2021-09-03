using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using SpotMixesApi.DataAccess;
using SpotMixesApi.Models;
using SpotMixesApi.Services.Interfaces;

namespace SpotMixesApi.Services
{
    public class UserService : IUserService
    {
        private readonly IMongoCollection<User> _users;

        public UserService(ISpotMixesDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _users = database.GetCollection<User>("Users");
        }

        public async Task<List<User>> GetAllUsers() =>
            await _users.FindAsync(user => true).Result.ToListAsync();

        public async Task<User> GetUserById(string id) =>
            await _users.FindAsync(new BsonDocument {{"_id", new ObjectId(id)}}).Result.FirstAsync();

        public async Task CreateUser(User user) =>
            await _users.InsertOneAsync(user);

        public async Task UpdateUser(User userIn) =>
            await _users.ReplaceOneAsync(user => user.Id == userIn.Id, userIn);

        public async Task DeleteUser(string id) =>
            await _users.DeleteOneAsync(user => user.Id == id);
    }
}