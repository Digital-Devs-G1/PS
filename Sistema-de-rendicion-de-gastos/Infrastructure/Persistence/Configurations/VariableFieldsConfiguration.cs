using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations
{
    public class VariableFieldConfiguration : IEntityTypeConfiguration<VariableField>
    {
        public void Configure(EntityTypeBuilder<VariableField> table)
        {
            table.HasKey(x => new { x.ReportId, x.Label });
            table.HasOne(variableField => variableField.ReportNav)
                .WithMany(report => report.Fields)
                .HasForeignKey(variableField => variableField.ReportId);
            table.HasOne(variableField => variableField.DataTypeNav)
                .WithMany(dataType => dataType.Fields)
                .HasForeignKey(variableField => variableField.DataTypeId);
            table.Property(x => x.Label)
                .HasMaxLength(20);
            table.Property(x => x.Value)
                .HasMaxLength(50);
        }
    }
}
