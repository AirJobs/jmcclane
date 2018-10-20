using AirJobs.Domain.Entities.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AirJobs.Data.EntityConfig
{
    public class FavoriteConfig : IEntityTypeConfiguration<Favorite>
    {
        public void Configure(EntityTypeBuilder<Favorite> builder)
        {
            builder.ToTable("Favorite");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .ValueGeneratedNever();

            builder.Property(x => x.CreatedDate)
                .ValueGeneratedOnAdd()
                .HasDefaultValueSql("getdate()");

            builder.HasOne(x => x.Job)
                .WithMany(x => x.Favorites)
                .HasForeignKey(x => x.JobId)
                .IsRequired();

            builder.HasOne(x => x.User)
                .WithMany(x => x.Favorites)
                .HasForeignKey(x => x.UserId)
                .IsRequired();
        }
    }
}
