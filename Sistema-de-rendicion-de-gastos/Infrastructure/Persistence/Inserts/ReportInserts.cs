using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations
{
    public class ReportInserts : IEntityTypeConfiguration<Report>
    {
        public void Configure(EntityTypeBuilder<Report> builder)
        {
            builder.HasData(
                new Report()
                {
                    Id = 1,
                    EmployeeId = 1,
                    Description = "Bolsa de cemento",
                    Amount = 7500.0
                }, 
                new Report()
                {
                    Id = 2,
                    EmployeeId = 1,
                    Description = "Placa Mdf",
                    Amount = 15000.0
                }
            );
        }
    }
}
