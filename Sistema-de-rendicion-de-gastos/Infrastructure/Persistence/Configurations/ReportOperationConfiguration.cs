using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations
{
    public class ReportOperationConfiguration : IEntityTypeConfiguration<ReportOperation>
    {
        public void Configure(EntityTypeBuilder<ReportOperation> builder)
        {
            builder.HasKey(e => e.ReportOperationId);

            builder.Property(e => e.ReportOperationName)
                .IsRequired()
                .HasMaxLength(10);
        }
    }
}
