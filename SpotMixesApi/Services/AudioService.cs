using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using SpotMixesApi.DataAccess;
using SpotMixesApi.Models;
using SpotMixesApi.Services.Interfaces;

namespace SpotMixesApi.Services
{
    public class AudioService : IAudioService
    {
        private readonly IMongoCollection<Audio> _audios;

        public AudioService(ISpotMixesDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _audios = database.GetCollection<Audio>("Audios");
        }
        public async Task<List<Audio>> GetAllAudios()=>
            await _audios.FindAsync(audio => true).Result.ToListAsync();

        public async Task<Audio> GetAudioById(string id) =>
            await _audios.FindAsync(new BsonDocument { { "_id", new ObjectId(id) } }).Result.FirstAsync();
        public async Task CreateAudio(Audio audio) =>
            await _audios.InsertOneAsync(audio);

        public async Task UpdateAudio(Audio audioIn) =>
            await _audios.ReplaceOneAsync(audio => audio.Id == audioIn.Id, audioIn);
        public async Task DeleteAudio(string id) =>
            await _audios.DeleteManyAsync(audio => audio.Id == id);
    }
}