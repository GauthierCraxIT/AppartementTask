using AppartementTask.DAO;
using AppartementTask.Models;
using AutoMapper;
using Microsoft.AspNetCore.Identity;

namespace AppartementTask.Services
{
    public class AuthService
    {

        public Context context { get; set; }
        public UserManager<Person> userManager { get; set; }
        public SignInManager<Person> signInManager { get; set; }

        public IMapper mapper { get; set; }

        public AuthService(Context context, UserManager<Person> userManager, SignInManager<Person> signInManager, IMapper mapper)
        {
            this.context = context;
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.mapper = mapper;
        }


        public bool Login(LoginDto loginDto)
        {
            var person = this.context.People.FirstOrDefault(x => x.Email.Equals(loginDto.Email));
            if (person == null)
                return false;

            var result = this.signInManager.CheckPasswordSignInAsync(person, loginDto.Password, false).Result;
            if (result.Succeeded)
                return true;

            return false;
        }

        public bool Register(RegisterDto registerDto)
        {
            var person = this.mapper.Map<Person>(registerDto);
            if (person == null)
                return false;

            var result = userManager.CreateAsync(person, registerDto.Password).Result;
            if (result.Succeeded)
            {
                var roleResult = this.userManager.AddToRoleAsync(person, "User").Result;
                return true;
            }
                
            
            return false;
        }
    }
}
