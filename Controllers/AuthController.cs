using System.Threading.Tasks;
using FriendApp.API.Data;
using FriendApp.API.Dtos;
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
        public async Task<IActionResult> Register(UserForRegisterDto userForRegisterDto) 
        {
            // Validate Request


            userForRegisterDto.Username = userForRegisterDto.Username.ToLower();

            if(await _repo.UserExists(userForRegisterDto.Username)){
                return BadRequest("Username already taken");
            }

            var userToCreate = new User {UserName = userForRegisterDto.Username};

            var createdUser = await _repo.Register(userToCreate, userForRegisterDto.Password);

            return StatusCode(201);
        }

    }
}