using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Inserts
{
    public class VariableFieldInserts : IEntityTypeConfiguration<VariableField>
    {
        public void Configure(EntityTypeBuilder<VariableField> builder)
        {
            builder.HasData(
                new VariableField()
                {
                    ReportId = 1,
                    NameId = "Proveedor",
                    Value = "Constructura X SRL",
                    DataTypeId = 2
                },
                new VariableField()
                {
                    ReportId = 1,
                    NameId = "Tel. Proveedor",
                    Value = "42561873",
                    DataTypeId = 1
                },
                new VariableField()
                {
                    ReportId = 2,
                    NameId = "Ancho[mm]",
                    Value = "270",
                    DataTypeId = 1
                },
                new VariableField()
                {
                    ReportId = 2,
                    NameId = "Alto",
                    Value = "180",
                    DataTypeId = 1
                },
                new VariableField()
                {
                    ReportId = 2,
                    NameId = "Peso[kg]",
                    Value = "58.8",
                    DataTypeId = 5
                },
                new VariableField()
                {
                    ReportId = 3,
                    NameId = "Proveedor",
                    Value = "Constructura X SRL",
                    DataTypeId = 2
                },
                new VariableField()
                {
                    ReportId = 3,
                    NameId = "Tel. Proveedor",
                    Value = "42561873",
                    DataTypeId = 1
                }
            );
        }
    }
}
