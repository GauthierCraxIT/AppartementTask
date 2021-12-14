using AppartementTask.DAO;
using AppartementTask.Models;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace AppartementTask.Services
{
    public class AuthService
    {

        public Context context { get; set; }
        public UserManager<Person> userManager { get; set; }
        public SignInManager<Person> signInManager { get; set; }
        public JwtAuthService jwtAuthService { get; set; }
        public JwtTokenConfig jwtTokenConfig { get; set; }

        public IMapper mapper { get; set; }

        public AuthService(Context context, UserManager<Person> userManager, SignInManager<Person> signInManager, IMapper mapper, JwtAuthService jwtAuthService, JwtTokenConfig jwtTokenConfig)
        {
            this.context = context;
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.mapper = mapper;
            this.jwtAuthService = jwtAuthService;
            this.jwtTokenConfig = jwtTokenConfig;
        }



        public SignInJwtResult Login(LoginDto loginDto)
        {
            var person = this.context.People.FirstOrDefault(x => x.Email.Equals(loginDto.Email));
            if (person == null)
                return null;

            var result = this.signInManager.CheckPasswordSignInAsync(person, loginDto.Password, false).Result;
            if (result.Succeeded)
            {
                var jwtResult = DoJwtLogin(person);
                if (jwtResult.Success)
                    return jwtResult;
            }

            return null;
        }

        public SignInJwtResult Register(RegisterDto registerDto)
        {
            var person = this.mapper.Map<Person>(registerDto);
            if (person == null)
                return null;

            var result = userManager.CreateAsync(person, registerDto.Password).Result;
            if (result.Succeeded)
            {
                var roleResult = this.userManager.AddToRoleAsync(person, "User").Result;

                var jwtResult = DoJwtLogin(person);
                if (jwtResult.Success)
                    return jwtResult;
            }
                
            
            return null;
        }

        private SignInJwtResult DoJwtLogin(Person person)
        {

            SignInJwtResult result = new SignInJwtResult();

            var claims = BuildClaims(person);
            result.Person = person;
            result.AccessToken = jwtAuthService.BuildToken(claims);
            result.RefreshToken = jwtAuthService.BuildRefreshToken();

            context.RefreshTokens.Add(new RefreshToken { PersonId = person.Id, Token = result.RefreshToken, IssuedAt = DateTime.Now, ExpiresAt = DateTime.Now.AddMinutes(jwtTokenConfig.RefreshTokenExpiration) });
            context.SaveChanges();

            result.Success = true;
            return result;
        }

        private SignInJwtResult CreateSignInJwtResult(string AccessToken, string RefreshToken)
        {
            ClaimsPrincipal claimsPrincipal = jwtAuthService.GetPrincipalFromToken(AccessToken);
            SignInJwtResult result = new SignInJwtResult();

            if (claimsPrincipal == null) return result;

            string id = claimsPrincipal.Claims.First(x => x.Type == "id").Value;
            var person = context.People.Find(id);

            if (person == null) return null;

            var token = context.RefreshTokens
        .Where(f => f.PersonId == person.Id
                && f.Token == RefreshToken
                && f.ExpiresAt >= DateTime.Now)
        .FirstOrDefault();

            if (token == null) return result;

            var claims = BuildClaims(person);

            result.Person = person;
            result.AccessToken = jwtAuthService.BuildToken(claims);
            result.RefreshToken = jwtAuthService.BuildRefreshToken();

            context.RefreshTokens.Remove(token);
            context.RefreshTokens.Add(new RefreshToken { PersonId = person.Id, Token = result.RefreshToken, IssuedAt = DateTime.Now, ExpiresAt = DateTime.Now.AddMinutes(jwtTokenConfig.RefreshTokenExpiration) });
            context.SaveChanges();

            result.Success = true;

            return result;


        }

        private Claim[] BuildClaims(Person person)
        {
            var claims = new[]
            {
                new Claim("id",person.Id),
                new Claim(ClaimTypes.Name,person.Email)
            };

            return claims;
        }
    }
}
