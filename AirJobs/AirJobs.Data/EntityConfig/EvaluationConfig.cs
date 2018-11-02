using AirJobs.Domain.Entities.Jobs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AirJobs.Data.EntityConfig
{
    public class EvaluationConfig : IEntityTypeConfiguration<Evaluation>
    {
        public void Configure(EntityTypeBuilder<Evaluation> builder)
        {
            // Table
            builder.ToTable("Evaluation");

            // Properties
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Stars)
                .IsRequired();

            builder.Property(x => x.Description)
                .IsRequired()
                .HasColumnType("varchar(1000)");

            // RelationShips
            builder.HasOne(x => x.User)
                .WithMany()
                .HasForeignKey(x => x.UserId)
                .IsRequired();

            builder.HasOne(x => x.Job)
                .WithMany(x => x.Evaluations)
                .HasForeignKey(x => x.JobId)
                .IsRequired();

            builder.HasOne(x => x.Scheduling)
                .WithOne(x => x.Evaluation)
                .HasForeignKey<Evaluation>(x => x.SchedulingId);
        }
    }
}
