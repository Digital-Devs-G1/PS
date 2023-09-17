using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations
{
    public class ReportOperationInserts : IEntityTypeConfiguration<ReportOperation>
    {
        public void Configure(EntityTypeBuilder<ReportOperation> builder)
        {
            builder.HasData(
                new ReportOperation()
                {
                    ReportOperationId = 1,
                    ReportOperationName = "Creacion"
                },
                new ReportOperation()
                {
                    ReportOperationId = 2,
                    ReportOperationName = "Revision"
                },
                new ReportOperation()
                {
                    ReportOperationId = 3,
                    ReportOperationName = "Aprobacion"
                },
                new ReportOperation()
                {
                    ReportOperationId = 4,
                    ReportOperationName = "Rechazo"
                }
            );
        }
    }
}
