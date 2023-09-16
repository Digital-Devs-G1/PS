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
            builder.HasKey(ft => new {ft.TemplateId, ft.Label});
            builder.HasOne(fieldTemplate => fieldTemplate.DataTypeNav)
                   .WithMany(dataType => dataType.FieldTemplateNav)
                   .HasForeignKey(fieldTemplate => fieldTemplate.DataTypeId);
            builder.HasOne(fieldTemplate => fieldTemplate.DeptoTemplateNav)
                   .WithMany(deptoTemplate => deptoTemplate.FieldTemplateCollec)
                   .HasForeignKey(fieldTemplate => fieldTemplate.TemplateId);
            builder.Property(ft => ft.Label).HasMaxLength(20);
        }
    }
}
