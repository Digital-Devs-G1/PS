using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Configurations
{
    public class FieldTemplateConfiguration : IEntityTypeConfiguration<ReportTemplateField>
    {
        public void Configure(EntityTypeBuilder<ReportTemplateField> builder)
        {
            builder.HasKey(ft => new {ft.ReportTemplateId, ft.Name});
            builder.HasOne(fieldTemplate => fieldTemplate.DataTypeNav);
            builder.Property(ft => ft.Name).HasMaxLength(20);
        }
    }
}
