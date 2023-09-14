using Domain.Entities;
using Infrastructure.Persistence.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence
{
    public class ReportsDbContext : DbContext
    {
        public DbSet<VariableField> VariableFields { get; set; }
        public DbSet<DataType> DataType { get; set; }
        public DbSet<ReportOperation> ReportOperations { get; set; }
        public DbSet<Report> Reports { get; set; }
        public DbSet<ReportTracking> ReportTrackings { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=MSI;Database=RendicionGastos;User Id=rootPS;Password=1234;Integrated Security=True;TrustServerCertificate=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ReportOperationConfiguration());
            modelBuilder.ApplyConfiguration(new ReportConfiguration());
            modelBuilder.ApplyConfiguration(new ReportTrackingConfiguration());
            modelBuilder.ApplyConfiguration(new VariableFieldConfiguration());
            modelBuilder.ApplyConfiguration(new DataTypeConfiguration());
        }
    }
}
