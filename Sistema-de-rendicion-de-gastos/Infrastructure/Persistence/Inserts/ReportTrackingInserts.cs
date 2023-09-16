using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Inserts
{
    public class ReportTrackingInserts : IEntityTypeConfiguration<ReportTracking>
    {
        public void Configure(EntityTypeBuilder<ReportTracking> builder)
        {
            builder.HasData(
                new ReportTracking()
                {
                    Id = 1,
                    EmployeeId = 1,
                    ReportId = 1,
                    ReportOperationId = 1,
                    DateTracking = DateTime.Now,
                },
                new ReportTracking()
                {
                    Id = 2,
                    EmployeeId = 1,
                    ReportId = 2,
                    ReportOperationId = 1,
                    DateTracking = DateTime.Now,
                }
            );
        }
    }
}
