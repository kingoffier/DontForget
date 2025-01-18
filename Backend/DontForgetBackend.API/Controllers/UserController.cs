using DontForgetBackend.API.Contracts;
using DontForgetBackend.Core.Interfaces;
using DontForgetBackend.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace DontForgetBackend.API.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _usersService;
        public UserController(IUserService usersService)
        {
            _usersService = usersService;
        }


        [HttpGet("GetAllUsers")]
        public async Task<ActionResult<List<UserResponse>>> GetUsers()
        {
            var users = await _usersService.GetAllUsers();

            var response = users.Select(b => new UserResponse(b.Id, b.Email, b.FirstName, b.SecondName, b.Password, b.Login));

            return Ok(response);
        }

        [HttpPost("CreateNewUser")]
        public async Task<ActionResult<int>> CreateUser([FromBody] UserRequest request)
        {
            var (user, error) = UserModel.Create(
                request.Id,
                request.Email,
                request.FirstName,
                request.SecondName,
                request.Password,
                request.Login
                );

            if (!string.IsNullOrEmpty(error))
            {
                return BadRequest(error);
            }

            var userId = await _usersService.AddUser(user);

            return Ok(userId);
        }

        [HttpPut("UpdateUser/{id:int}")]
        public async Task<ActionResult<int>> UpdateUser(int id, [FromBody] UserRequest request)
        {
            var userId = await _usersService.UpdateUser(id, request.Email, request.FirstName, request.SecondName, request.Password, request.Login);
            return Ok(userId);
        }

        [HttpDelete("DeleteUser/{id:int}")]
        public async Task<ActionResult<int>> DeleteUser(int id)
        {
            return Ok(await _usersService.DeleteUser(id));
        }
    }
}
