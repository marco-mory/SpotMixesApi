using System.Collections.Generic;
using System.Threading.Tasks;
using SpotMixesApi.Models;

namespace SpotMixesApi.Services.Interfaces
{
    public interface IAudioService
    {
        Task<List<Audio>> GetAllAudios();
        Task<Audio> GetAudioById(string id);
        Task CreateAudio(Audio audio);
        Task UpdateAudio(Audio audio);
        Task DeleteAudio(string id);
    }
}