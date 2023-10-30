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
            builder.HasKey(ft => new {ft.FieldTemplateId, ft.FieldNameId});
            builder.Property(ft => ft.DataTypeId);
            builder.Property(ft => ft.FieldNameId).HasMaxLength(20);
        }
    }
}
