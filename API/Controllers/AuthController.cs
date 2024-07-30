using API.Repos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shared;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepo _authRepo;
        public AuthController(IAuthRepo authRepo)
        {
            _authRepo = authRepo;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterModel registerModel, string role)
        {
            var response = await _authRepo.RegisterAsync(registerModel, role);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return Ok(await response.Content.ReadAsStringAsync());
            }
            return BadRequest(await response.Content.ReadAsStringAsync());
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginModel loginModel)
        {
            var response = await _authRepo.LoginAsync(loginModel);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return Ok(await response.Content.ReadAsStringAsync());
            }
            return Unauthorized(await response.Content.ReadAsStringAsync());
        }
    }
}
