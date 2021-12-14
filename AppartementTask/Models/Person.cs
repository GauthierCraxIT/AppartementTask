using Microsoft.AspNetCore.Identity;

namespace AppartementTask.Models
{
    public class Person : IdentityUser
    {
        public virtual IEnumerable<Residence> Residence { get; set; }

    }
}
