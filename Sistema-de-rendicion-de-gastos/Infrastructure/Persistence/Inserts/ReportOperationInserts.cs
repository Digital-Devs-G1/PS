using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Inserts
{
    public class ReportOperationInserts : IEntityTypeConfiguration<ReportOperation>
    {
        public void Configure(EntityTypeBuilder<ReportOperation> builder)
        {
            builder.HasData(
                new ReportOperation()
                {
                    Id = 1,
                    ReportOperationName = "Pendiente"
                },
                new ReportOperation()
                {
                    Id = 2,
                    ReportOperationName = "Aceptado"
                },
                new ReportOperation()
                {
                    Id = 3,
                    ReportOperationName = "Rechazado"
                }
            );
        }
    }
}
