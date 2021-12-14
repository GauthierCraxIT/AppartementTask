using AppartementTask.DAO;
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




    }
}
