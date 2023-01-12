using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using System.Reflection.Metadata;
using UserMangment.Models;

namespace UserMangment.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<IdentityUser>().ToTable("User", "Security");
            builder.Entity<ApplicationUser>().ToTable("User", "Security");
            builder.Entity<IdentityRole>().ToTable("Role", "Security");
            builder.Entity<IdentityUserRole<string>>().ToTable("UserRole", "Security");
            builder.Entity<IdentityUserClaim<string>>().ToTable("UserClaim", "Security");
            builder.Entity<IdentityUserLogin<string>>().ToTable("UserLogin", "Security");
            builder.Entity<IdentityRoleClaim<string>>().ToTable("RoleClaim", "Security");
            builder.Entity<IdentityUserToken<string>>().ToTable("UserToken", "Security");

            //seed

           //builder.Entity<IdentityRole>().HasData(new IdentityRole { Id = Guid.NewGuid().ToString() });


        }
    }
}