using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations
{
    public class DepartmentTemplateConfiguration : IEntityTypeConfiguration<DepartmentTemplate>
    {
        public void Configure(EntityTypeBuilder<DepartmentTemplate> builder)
        {
            builder.HasKey(dt => dt.DepartmentTemplateId); 
            builder.Property(dt => dt.DepartmentTemplateName).HasMaxLength(30);
        }
    }
}
