using AirJobs.Data.EntityConfig;
using AirJobs.Domain.Entities.Addresses;
using AirJobs.Domain.Entities.Jobs;
using AirJobs.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;

namespace AirJobs.Data.Context
{
    public class AirJobsContext : DbContext
    {
        public AirJobsContext(DbContextOptions<AirJobsContext> options) : base(options)
        {
        }

        public DbSet<User> User { get; set; }
        public DbSet<Job> Job { get; set; }
        public DbSet<Country> Country { get; set; }
        public DbSet<State> State { get; set; }
        public DbSet<City> City { get; set; }
        public DbSet<Address> Address { get; set; }
        public DbSet<Scheduling> Scheduling { get; set; }
        public DbSet<Favorite> Favorite { get; set; }
        public DbSet<Evaluation> Evaluation { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new UserConfig());
            modelBuilder.ApplyConfiguration(new JobConfig());
            modelBuilder.ApplyConfiguration(new AddressConfig());
            modelBuilder.ApplyConfiguration(new CityConfig());
            modelBuilder.ApplyConfiguration(new StateConfig());
            modelBuilder.ApplyConfiguration(new CountryConfig());
            modelBuilder.ApplyConfiguration(new SchedulingConfig());
            modelBuilder.ApplyConfiguration(new FavoriteConfig());
            modelBuilder.ApplyConfiguration(new EvaluationConfig());
        }
    }
}