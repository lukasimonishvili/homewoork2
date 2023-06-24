using API.Services;
using API.Validators;
using DOMAIN;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("/api/[Controller]")]
    public class AuthController : Controller
    {
        private readonly AuthService _authService;

        public AuthController(AuthService authService)
        {
            _authService = authService;
        }


        [HttpPost("register")]
        public IActionResult CreateRespodent([FromBody] RespodentAutheDTO respodent)
        {
            var validator = new RespodentValidator().Validate(respodent);
            var errorMessages = "";
            foreach (var error in validator.Errors)
            {
                errorMessages += error.ErrorMessage + ", ";
            }

            if (validator.IsValid)
            {
                var created = _authService.AddRespodent(respodent);
                if (created)
                {
                    return Ok("Success");

                }
                else
                {
                    return Conflict($"user wirn username: {respodent.Username} already exists");
                }
            }
            else
            {
                return BadRequest(errorMessages);
            }
        }

        [HttpPost("login")]
        public IActionResult Authentication([FromBody] LoginDto login)
        {
            var loginResult = _authService.LoginUser(login);

            if (loginResult == null)
            {
                return Unauthorized("Incrorrect username or password");
            }

            return Ok(loginResult);
        }

        [HttpPost("refreshToken")]
        public IActionResult RefreshToken([FromBody] RefreshTokenDto data)
        {
            var refreshToken = _authService.RefreshToken(data.token);

            if (refreshToken == null)
            {
                return Unauthorized("Invalid Token Detected");
            }

            return Ok(refreshToken);
        }
    }
}
