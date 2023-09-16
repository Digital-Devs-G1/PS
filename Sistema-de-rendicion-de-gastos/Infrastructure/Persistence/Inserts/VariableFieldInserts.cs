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
                    Label = "Proveedor",
                    Value = "Constructura X SRL",
                    DataTypeId = 2
                },
                new VariableField()
                {
                    ReportId = 1,
                    Label = "Tel. Proveedor",
                    Value = "42561873",
                    DataTypeId = 1
                },
                new VariableField()
                {
                    ReportId = 2,
                    Label = "Ancho[mm]",
                    Value = "270",
                    DataTypeId = 1
                },
                new VariableField()
                {
                    ReportId = 2,
                    Label = "Alto",
                    Value = "180",
                    DataTypeId = 1
                },
                new VariableField()
                {
                    ReportId = 2,
                    Label = "Peso[kg]",
                    Value = "58.8",
                    DataTypeId = 5
                },
                new VariableField()
                {
                    ReportId = 3,
                    Label = "Proveedor",
                    Value = "Constructura X SRL",
                    DataTypeId = 2
                },
                new VariableField()
                {
                    ReportId = 3,
                    Label = "Tel. Proveedor",
                    Value = "42561873",
                    DataTypeId = 1
                }
            );
        }
    }
}
