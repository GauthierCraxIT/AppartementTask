namespace AppartementTask.Models
{
    public class SignInJwtResult
    {
        public bool Success { get; set; }
        public Person Person{ get; set; }
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }

        public SignInJwtResult()
        {
            Success = false;
        }
    }
}
