using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AppartementTask.Models
{
    public class Context : IdentityDbContext
    {
        public Context() { }

        public Context(DbContextOptions<Context> options) : base(options) { }

        
        public virtual DbSet<RefreshToken> RefreshTokens { get; set; }

        public virtual DbSet<Person> People { get; set; }

        public virtual DbSet<Residence> Residences { get; set; }
    }
}
