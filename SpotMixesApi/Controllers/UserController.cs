using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SpotMixesApi.Models;
using SpotMixesApi.Services;

namespace SpotMixesApi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers() => Ok(await _userService.GetAllUsers());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(string id) => Ok(await _userService.GetUserById(id));

        [HttpPost]
        public async Task<ActionResult> CreateUser([FromBody] User user)
        {
            await _userService.CreateUser(user);
            return Created("Created", true);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser([FromBody] User user, string id)
        {
            user.Id = id;
            await _userService.UpdateUser(user);
            return Created("Updated", true);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUser(string id)
        {
            await _userService.DeleteUser(id);
            return NoContent();
        }
    }
}