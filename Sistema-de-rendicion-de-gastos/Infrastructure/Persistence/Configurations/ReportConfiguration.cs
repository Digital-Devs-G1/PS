using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations
{
    public class ReportConfiguration : IEntityTypeConfiguration<Report>
    {
        public void Configure(EntityTypeBuilder<Report> builder)
        {
            builder.HasKey(e => e.ReportId);

            builder.Property(e => e.Description)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(e => e.Amount)
                .IsRequired();
        }
    }
}
