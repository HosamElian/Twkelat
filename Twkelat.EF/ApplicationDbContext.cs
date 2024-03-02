using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Twkelat.Persistence.Models;

namespace Twkelat.EF
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<Document> Documents { get; set; }
        public DbSet<Block> Blocks { get; set; }
        public DbSet<Delegation> Delegations { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<IdentityRole>()
                .HasData([
                new IdentityRole
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "User",
                    ConcurrencyStamp = Guid.NewGuid().ToString(),
                    NormalizedName = "USER".ToUpper()
                },
                 new IdentityRole
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Admin",
                    ConcurrencyStamp = Guid.NewGuid().ToString(),
                    NormalizedName = "Admin".ToUpper()
                },

                ]);
        }
    }
}
