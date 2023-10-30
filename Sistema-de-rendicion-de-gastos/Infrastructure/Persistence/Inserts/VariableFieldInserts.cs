using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using static Application.Enums.DataTypeEnum;

namespace Infrastructure.Persistence.Inserts
{
    public class VariableFieldInserts : IEntityTypeConfiguration<VariableField>
    {
        public void Configure(EntityTypeBuilder<VariableField> builder)
        {
            var reportId = 0;
            ConstructionMaterialReport(builder, ++reportId);
            CarpentryMaterialReport(builder, ++reportId);
            ConstructionMaterialReport(builder, ++reportId);
        }

        public void ConstructionMaterialReport(
            EntityTypeBuilder<VariableField> builder,
            int reportId
            )
        {
            var ordinalNumber = 0;
            builder.HasData(
                new VariableField()
                {
                    ReportId = reportId,
                    Name = "Proveedor",
                    Value = "Constructura X SRL",
                    DataTypeId = (int) Str
                },
                new VariableField()
                {
                    ReportId = reportId,
                    Name = "Tel. Proveedor",
                    Value = "42561873",
                    DataTypeId = (int)Int
                }
            );
        }

        public void CarpentryMaterialReport(
            EntityTypeBuilder<VariableField> builder,
            int reportId
            )
        {
            builder.HasData(
                new VariableField()
                {
                    ReportId = reportId,
                    Name = "Ancho [mm]",
                    Value = "270",
                    DataTypeId = (int)Int
                },
                new VariableField()
                {
                    ReportId = reportId,
                    Name = "Alto [mm]",
                    Value = "180",
                    DataTypeId = (int)Int
                },
                new VariableField()
                {
                    ReportId = reportId,
                    Name = "Peso [kg]",
                    Value = "58.8",
                    DataTypeId = (int)Dec
                }
            );
        }
    }
}
