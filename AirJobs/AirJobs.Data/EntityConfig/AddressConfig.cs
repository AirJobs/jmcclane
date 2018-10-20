using AirJobs.Domain.Entities.Address;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AirJobs.Data.EntityConfig
{
    public class AddressConfig : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.ToTable("Address");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .ValueGeneratedNever();

            builder.Property(x => x.Street)
                .HasColumnType("varchar(500)")
                .IsRequired();

            builder.Property(x => x.Number)
                .HasColumnType("varchar(15)")
                .IsRequired();

            builder.Property(x => x.Neighborhood)
                .HasColumnType("varchar(250)")
                .IsRequired();

            builder.OwnsOne(x => x.GeoLocation, config =>
            {
                config.Property(geo => geo.Latitude)
                    .IsRequired()
                    .HasColumnName("Latitude");

                config.Property(x => x.Longitude)
                    .IsRequired()
                    .HasColumnName("Longitude");

                config.Ignore(x => x.Altitude);
                config.Ignore(x => x.Course);
                config.Ignore(x => x.HorizontalAccuracy);
                config.Ignore(x => x.Speed);
                config.Ignore(x => x.VerticalAccuracy);
            });

            builder.HasOne(x => x.City)
                .WithMany(x => x.Addresses)
                .HasForeignKey(x => x.CityId)
                .IsRequired();

            builder.HasOne(x => x.User)
                .WithMany(x => x.Addresses)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();
        }
    }
}