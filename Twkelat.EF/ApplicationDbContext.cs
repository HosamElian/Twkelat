using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Twkelat.Persistence.Models;

namespace Twkelat.EF
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<Block> Blocks { get; set; }
        public DbSet<PowerAttorneyType> PowerAttorneyTypes { get; set; }
        public DbSet<Templete> Templetes { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ApplicationUser>()
                .HasIndex(a => a.CivilId).IsUnique();

            builder.Entity<Templete>().HasData(
                new Templete { Id = 1, Name = "Lawsuits" },
                new Templete { Id = 2, Name = "Driving" },
                new Templete { Id = 3, Name = "Review all ministries" },
                new Templete { Id = 4, Name = "marriage" },
                new Templete { Id = 5, Name = "Bank transaction" },
                new Templete { Id = 6, Name = "Company Creation" },
                new Templete { Id = 7, Name = "Company modification" },
                new Templete { Id = 8, Name = "Public" }


                );
            builder.Entity<PowerAttorneyType>().HasData(
                new PowerAttorneyType { Id = 1, Name = "Public" },
                new PowerAttorneyType { Id = 2, Name = "Private" }
                );

            
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
