using BusinessLayer.Abstract;
using EntityLayer.Entities.DTOs.BaseDto.UserDto;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : Controller
    {
        private IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public ActionResult Login(LoginDto userForLoginDto)
        {
            var userToLogin = _authService.Login(userForLoginDto);
            if (!userToLogin.IsCompletedSuccessfully)
            {
                return BadRequest("error");
            }

            var result = _authService.CreateAccessToken(userToLogin.Result);
            if (result.IsCompletedSuccessfully)
            {
                return Ok(result);
            }

            return BadRequest("error");
        }

        [HttpPost("register")]
        public ActionResult Register(RegisterDto userForRegisterDto)
        {
            var userExists = _authService.UserExists(userForRegisterDto.Email);
            if (!userExists.IsCompletedSuccessfully)
            {
                return BadRequest("error");
            }

            var registerResult = _authService.Register(userForRegisterDto, userForRegisterDto.Password);
            var result = _authService.CreateAccessToken(registerResult.Result);
            if (result.IsCompletedSuccessfully)
            {
                return Ok(result);
            }

            return BadRequest("error");
        }
    }
}