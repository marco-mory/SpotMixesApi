using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using SpotMixesApi.DataAccess;
using SpotMixesApi.Models;
using SpotMixesApi.Services.Interfaces;

namespace SpotMixesApi.Services
{
    public class PlayListService : IPlayListService
    {
        private readonly IMongoCollection<PlayList> _playList;

        public PlayListService(ISpotMixesDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _playList = database.GetCollection<PlayList>("PlayLists");
        }

        public async Task<List<PlayList>> GetAllPlayLists() =>
            await _playList.FindAsync(playlist => true).Result.ToListAsync();

        public async Task<PlayList> GetPlayListById(string id) =>
            await _playList.FindAsync(new BsonDocument {{"_id", new ObjectId(id)}}).Result.FirstAsync();

        public async Task CreatePlayList(PlayList playList) =>
            await _playList.InsertOneAsync(playList);

        public async Task UpdatePlayList(PlayList playList) =>
            await _playList.ReplaceOneAsync(playlist => playlist.Id == playList.Id, playList);

        public async Task DeletePlayList(string id) =>
            await _playList.DeleteOneAsync(playList => playList.Id == id);
    }
}