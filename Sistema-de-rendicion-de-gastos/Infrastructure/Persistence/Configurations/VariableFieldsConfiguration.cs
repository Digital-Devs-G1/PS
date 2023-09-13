using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations
{
    public class VariableFieldsConfiguration : IEntityTypeConfiguration<VariableFields>
    {
        public void Configure(EntityTypeBuilder<VariableFields> builder)
        {
            throw new NotImplementedException();
        }
    }
}
