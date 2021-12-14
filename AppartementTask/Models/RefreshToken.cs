using System.ComponentModel.DataAnnotations;

namespace AppartementTask.Models
{
    public class RefreshToken
    {
         [Key]
        public string Token { get; set; }
        public string PersonId { get; set; }
        public DateTime IssuedAt { get; set; }
        public DateTime ExpiresAt { get; set; }
    }
}
