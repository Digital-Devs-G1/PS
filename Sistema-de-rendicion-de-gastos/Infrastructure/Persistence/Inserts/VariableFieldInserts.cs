using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using static Infrastructure.Persistence.Inserts.DataTypeEnum;

namespace Infrastructure.Persistence.Inserts
{
    public class VariableFieldInserts : IEntityTypeConfiguration<VariableField>
    {
        public void Configure(EntityTypeBuilder<VariableField> builder)
        {
            ConstructionMaterialReport(builder, 1);
            CarpentryMaterialReport(builder);
            ConstructionMaterialReport(builder, 2);
        }

        public void ConstructionMaterialReport(
            EntityTypeBuilder<VariableField> builder,
            int reportId)
        {
            builder.HasData(
                new VariableField()
                {
                    ReportId = reportId,
                    NameId = "Proveedor",
                    Value = "Constructura X SRL",
                    DataTypeId = (int) Str
                },
                new VariableField()
                {
                    ReportId = reportId,
                    NameId = "Tel. Proveedor",
                    Value = "42561873",
                    DataTypeId = (int)Int
                }
            );
        }

        public void CarpentryMaterialReport(EntityTypeBuilder<VariableField> builder)
        {
            builder.HasData(
                new VariableField()
                {
                    ReportId = 2,
                    NameId = "Ancho [mm]",
                    Value = "270",
                    DataTypeId = (int)Int
                },
                new VariableField()
                {
                    ReportId = 2,
                    NameId = "Alto [mm]",
                    Value = "180",
                    DataTypeId = (int)Int
                },
                new VariableField()
                {
                    ReportId = 2,
                    NameId = "Peso [kg]",
                    Value = "58.8",
                    DataTypeId = (int)Dec
                }
            );
        }
    }
}
