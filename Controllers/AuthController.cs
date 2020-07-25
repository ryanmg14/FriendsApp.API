using System.Threading.Tasks;
using FriendApp.API.Data;
using FriendApp.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace FriendApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _repo;
        public AuthController(IAuthRepository repo)
        {
            _repo = repo;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(string username, string password) 
        {
            // Validate Request


            username = username.ToLower();

            if(await _repo.UserExists(username)){
                return BadRequest("Username already taken");
            }

            var userToCreate = new User {UserName = username};

            var createdUser = await _repo.Register(userToCreate, password);

            return StatusCode(201);
        }

    }
}