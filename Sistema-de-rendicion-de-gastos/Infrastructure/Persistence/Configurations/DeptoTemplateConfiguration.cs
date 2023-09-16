using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Configurations
{
    public class DeptoTemplateConfiguration : IEntityTypeConfiguration<DepartmentTemplate>
    {
        public void Configure(EntityTypeBuilder<DepartmentTemplate> builder)
        {
            builder.HasKey(dt => dt.DepartmentTemplateId); 
            builder.Property(dt => dt.DepartmentTemplateName).HasMaxLength(15);
        }
    }
}
