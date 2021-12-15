using AppartementTask.DAO;
using AppartementTask.DTO;
using AppartementTask.Models;
using AppartementTask.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppartementTask.Controllers
{
    [Route("api/")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        public AuthService authService { get; set; }

        public AuthController(AuthService authService)
        {
            this.authService = authService;
        }


        [HttpPost]
        [Route("login")]
        public IActionResult Login(LoginDto loginDao)
        {

            SignInJwtResult result = this.authService.Login(loginDao);
            if (result != null)
            {
                return Ok(new LoginDto
                {
                    AccessToken = result.AccessToken,
                    RefreshToken = result.RefreshToken,
                    Email = result.Person.Email
                });
            }
                

            return BadRequest();
        }


        [HttpPost]
        [Route("register")]
        public IActionResult Register(RegisterDto registerDao)
        {
            SignInJwtResult result = this.authService.Register(registerDao);
            if (result != null)
            {
                return Ok(new RegisterDto
                {
                    AccessToken = result.AccessToken,
                    RefreshToken = result.RefreshToken,
                    Email = result.Person.Email
                });
            }

            return BadRequest();
        }

        [HttpPost]
        [Route("updatetokens")]
        public IActionResult UpdateTokens(UpdateTokenDto tokenDto)
        {
            SignInJwtResult result = this.authService.UpdateTokens(tokenDto.AccessToken, tokenDto.RefreshToken);
            if (result != null)
            {
                return Ok(new UpdateTokenDto
                {
                    AccessToken = result.AccessToken,
                    RefreshToken = result.RefreshToken
                });
            }

            else
                return null;
        }


        [HttpGet]
        [Route("isadmin")]
        public IActionResult IsAdmin(string accessToken)
        {
            Console.WriteLine("result finding out");
            var result = this.authService.IsAdmin(accessToken);
            Console.WriteLine("result: " + result);
            return Ok(result);
        }
    }
}
