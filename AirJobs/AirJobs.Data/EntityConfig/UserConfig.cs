using AirJobs.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AirJobs.Data.EntityConfig
{
    public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");

            builder.HasKey(x => x.Id);

            builder.OwnsOne(x => x.Name, name =>
            {
                name.Property(x => x.FirstName)
                    .HasColumnType("varchar(30)")
                    .HasColumnName("FirstName")
                    .IsRequired();

                name.Property(x => x.LastName)
                    .HasColumnType("varchar(200)")
                    .HasColumnName("LastName")
                    .IsRequired();
            });
        }
    }
}