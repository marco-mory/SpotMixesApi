using System.Collections.Generic;
using System.Threading.Tasks;
using SpotMixesApi.Models;

namespace SpotMixesApi.Services.Interfaces
{
    public interface IPlayListService
    {
        Task<List<PlayList>> GetAllPlayLists();
        Task<PlayList> GetPlayListById(string id);
        Task CreatePlayList(PlayList playList);
        Task UpdatePlayList(PlayList playList);
        Task DeletePlayList(string id);
    }
}