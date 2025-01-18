using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DontForgetBackend.Core.Interfaces;
using DontForgetBackend.Application.Service;
using DontForgetBackend.API.Contracts;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace DontForgetBackend.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost]
        public async Task<IResult> Authorization( LoginUserRequest request)
        {
            var token = await _authService.Login(request.Login, request.Password);

            HttpContext.Response.Cookies.Append("Tk", token);

            return Results.Ok(token);
        }

        [Authorize]
        [HttpDelete("Exit")]
        public async Task<IResult> Exit()
        {
            HttpContext.Response.Cookies.Delete("Tk");
            return Results.Ok();
        }

        [Authorize]
        [HttpGet("UserInfo")]
        public IActionResult UserInfo()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var userName = User.FindFirstValue(ClaimTypes.Name);

            return Ok(new { userId, userName });
        }
    }
}
