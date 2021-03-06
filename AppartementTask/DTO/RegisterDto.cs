using AppartementTask.DTO;

namespace AppartementTask.DAO
{
    public class RegisterDto : UpdateTokenDto
    {
        public string Email { get; set; }

        public string Password { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string UserName { get; set; }

    }
}
