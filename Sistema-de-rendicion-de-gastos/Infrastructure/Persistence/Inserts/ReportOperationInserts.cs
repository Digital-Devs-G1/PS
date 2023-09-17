using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using static Infrastructure.Persistence.Inserts.ReportOperationEnum;

{
    public class ReportOperationInserts : IEntityTypeConfiguration<ReportOperation>
    {
        public void Configure(EntityTypeBuilder<ReportOperation> builder)
        {
            builder.HasData(
                new ReportOperation()
                {
                    ReportOperationId = (int)Create,
                    ReportOperationName = "Creacion"
                },
                new ReportOperation()
                {
                    ReportOperationId = (int)Review,
                    ReportOperationName = "Revision"
                },
                new ReportOperation()
                {
                    ReportOperationId = (int)Approval,
                    ReportOperationName = "Aprobacion"
                },
                new ReportOperation()
                {
                    ReportOperationId = (int)Refuse,
                    ReportOperationName = "Rechazo"
                }
            );
        }
    }
}
