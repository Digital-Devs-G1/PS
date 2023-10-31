using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Runtime.Intrinsics.Arm;

namespace Infrastructure.Persistence.Configurations
{
    public class DepartmentTemplateConfiguration : IEntityTypeConfiguration<ReportTemplate>
    {
        public void Configure(EntityTypeBuilder<ReportTemplate> builder)
        {
            builder.HasKey(dt => dt.ReportTemplateId); 
            builder.HasMany(dt => dt.ReportTemplateFieldsCol)
                .WithOne(f=>f.ReportTemplateNav)
                .HasForeignKey(f => f.ReportTemplateId);
            builder.Property(dt => dt.ReportTemplateName).HasMaxLength(30);
        }
    }
}
