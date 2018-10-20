using AirJobs.Domain.Entities.Job;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AirJobs.Data.EntityConfig
{
    public class JobConfig : IEntityTypeConfiguration<Job>
    {
        public void Configure(EntityTypeBuilder<Job> builder)
        {
            builder.ToTable("Job");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .ValueGeneratedNever();

            builder.Property(x => x.Title)
                .HasColumnType("varchar(250)")
                .IsRequired();

            builder.Property(x => x.Description)
                .HasColumnType("varchar(max)");

            builder.Property(x => x.ImageUrl)
                .HasColumnType("varchar(max)");

            builder.Property(x => x.CreatedDate)
                .HasDefaultValueSql("getdate()")
                .IsRequired();

            builder.Property(x => x.Price)
                .HasColumnType("money")
                .IsRequired();

            builder.HasOne(x => x.Address)
                .WithMany(x => x.Jobs)
                .HasForeignKey(x => x.AddressId)
                .IsRequired();
        }
    }
}