using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AirJobs.IdentityServer.Context
{
    public class IdentityContext : IdentityDbContext<ApplicationUser>
    {
        public IdentityContext(DbContextOptions<IdentityContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ApplicationUser>().ToTable("_IdentityUser");
            builder.Entity<IdentityRole>().ToTable("_IdentityRole");
            builder.Entity<IdentityUserClaim<string>>().ToTable("_IdentityUserClaim");
            builder.Entity<IdentityUserRole<string>>().ToTable("_IdentityUserRole");
            builder.Entity<IdentityUserLogin<string>>().ToTable("_IdentityUserLogin");
            builder.Entity<IdentityRoleClaim<string>>().ToTable("_IdentityRoleClaim");
            builder.Entity<IdentityUserToken<string>>().ToTable("_IdentityUserToken");
        }
    }
}
