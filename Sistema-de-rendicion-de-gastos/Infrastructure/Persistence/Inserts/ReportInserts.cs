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
                    ReportId = 1,
                    EmployeeId = 1,
                    Description = "Bolsa de cemento",
                    Amount = 7500.0
                }, 
                new Report()
                {
                    ReportId = 2,
                    EmployeeId = 2,
                    Description = "Placa Mdf",
                    Amount = 15000.0
                }, 
                new Report()
                {
                    ReportId = 3,
                    EmployeeId = 2,
                    Description = "Bola de cal",
                    Amount = 3500
                }
            );
        }
    }
}
