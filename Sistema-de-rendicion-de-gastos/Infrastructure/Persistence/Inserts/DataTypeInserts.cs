using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using static Infrastructure.Persistence.Inserts.DataTypeEnum;

namespace Infrastructure.Persistence.Inserts
{
    public class DataTypeInserts : IEntityTypeConfiguration<DataType>
    {
        public void Configure(EntityTypeBuilder<DataType> builder)
        {
            builder.HasData(
                new DataType()
                {
                    DataTypeId = (int)Int,
                    Name = "Entero"
                },
                new DataType()
                {
                    DataTypeId = (int)Str,
                    Name = "String"
                },
                new DataType()
                {
                    DataTypeId = (int)Date,
                    Name = "Date"
                },
                new DataType()
                {
                    DataTypeId = (int)Bool,
                    Name = "Bool"
                }, 
                new DataType()
                {
                    DataTypeId = (int)Dec,
                    Name = "Decimal"
                }
            );
        }
    }
}
