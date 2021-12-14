using AppartementTask.DAO;
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

            bool canLogin = this.authService.Login(loginDao);
            if (canLogin)
                return Ok();

            return BadRequest();
        }


        [HttpPost]
        [Route("register")]
        public IActionResult Register(RegisterDto registerDao)
        {
            bool canRegister = this.authService.Register(registerDao);
            if (canRegister)
                return Ok();

            return BadRequest();
        }


    }
}
