using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SpotMixesApi.Models;
using SpotMixesApi.Services;

namespace SpotMixesApi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AudioController : Controller
    {
        private readonly AudioService _audioService;

        public AudioController(AudioService audioService)
        {
            _audioService = audioService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAudios() => Ok(await _audioService.GetAllAudios());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAudioById(string id) => Ok(await _audioService.GetAudioById(id));

        [HttpPost]
        public async Task<IActionResult> CreateAudio([FromBody]Audio audio)
        {
            await _audioService.CreateAudio(audio);
            return Created("Created", true);
        }

        [HttpPut("{id}")]

        public async Task<IActionResult> UpdateAudio([FromBody] Audio audio,string id)
        {
            audio.Id = id;
            await _audioService.UpdateAudio(audio);
            return Created("Updated", true);

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult>DeleteAudio(string id)
        {
            await _audioService.DeleteAudio(id);
            return NoContent();
        }
    }
}