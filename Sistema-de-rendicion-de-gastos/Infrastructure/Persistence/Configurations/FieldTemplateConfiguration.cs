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
    public class FieldTemplateConfiguration : IEntityTypeConfiguration<FieldTemplate>
    {
        public void Configure(EntityTypeBuilder<FieldTemplate> builder)
        {
            builder.HasKey(ft => new {ft.FieldTemplateId, ft.FieldName});
            builder.HasOne(fieldTemplate => fieldTemplate.DataTypeNav)
                   .WithMany()
                   .HasForeignKey(fieldTemplate => fieldTemplate.DataTypeId);
            builder.Property(ft => ft.FieldName).HasMaxLength(20);
        }
    }
}
