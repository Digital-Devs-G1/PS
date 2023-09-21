using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations
{
    public class VariableFieldConfiguration : IEntityTypeConfiguration<VariableField>
    {
        public void Configure(EntityTypeBuilder<VariableField> table)
        {
            table.HasKey(x => new { x.ReportId, x.OrdinalNumberId });
            table.HasOne(variableField => variableField.ReportNav)
                .WithMany()
                .HasForeignKey(variableField => variableField.ReportId);
            table.HasOne(variableField => variableField.DataTypeNav)
                .WithMany()
                .HasForeignKey(variableField => variableField.DataTypeId);
            table.Property(x => x.Name)
                .HasMaxLength(20);
            table.Property(x => x.Value)
                .HasMaxLength(50);
        }
    }
}