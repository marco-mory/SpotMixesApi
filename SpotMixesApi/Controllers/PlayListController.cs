using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SpotMixesApi.Models;
using SpotMixesApi.Services;

namespace SpotMixesApi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class PlayListController : Controller
    {
        private readonly PlayListService _playListService;

        public PlayListController(PlayListService playListService)
        {
            _playListService = playListService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPlayLists() => Ok(await _playListService.GetAllPlayLists());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPlayListById(string id) => Ok(await _playListService.GetPlayListById(id));

        [HttpPost]
        public async Task<ActionResult> CreatePlayList([FromBody] PlayList playList)
        {
            await _playListService.CreatePlayList(playList);
            return Created("Created", true);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePlayList([FromBody] PlayList playList, string id)
        {
            playList.Id = id;
            await _playListService.UpdatePlayList(playList);
            return Created("Updated", true);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePlayList(string id)
        {
            await _playListService.DeletePlayList(id);
            return NoContent();
        }
    }
}