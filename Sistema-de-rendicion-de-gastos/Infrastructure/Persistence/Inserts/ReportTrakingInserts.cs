using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using static Infrastructure.Persistence.Inserts.ReportOperationEnum;

namespace Infrastructure.Persistence.Configurations
{
    public class ReportTrackingInserts : IEntityTypeConfiguration<ReportTracking>
    {
        public void Configure(EntityTypeBuilder<ReportTracking> builder)
        {
            builder.HasData(
                new ReportTracking()
                {
                    ReportTrackingId = 1,
                    ReportId = 1,
                    EmployeeId = 1,
                    ReportOperationId = (int)Create,
                    TrackingDate = new DateTime(2023, 9, 5, 14, 30, 20)
                },
                new ReportTracking()
                {
                    ReportTrackingId = 2,
                    ReportId = 2,
                    EmployeeId = 2,
                    ReportOperationId = (int)Create,
                    TrackingDate = new DateTime(2023, 9, 7, 9, 20, 9)
                },
                new ReportTracking()
                {
                    ReportTrackingId = 3,
                    ReportId = 2,
                    EmployeeId = 3,
                    ReportOperationId = (int)Review,
                    TrackingDate = new DateTime(2023, 9, 15, 16, 15, 43)
                },
                new ReportTracking()
                {
                    ReportTrackingId = 4,
                    ReportId = 3,
                    EmployeeId = 2,
                    ReportOperationId = (int)Create,
                    TrackingDate = new DateTime(2023, 9, 17, 18, 33, 1)
                }
            );
        }
    }
}
