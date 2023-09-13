using Domain.Entities;
using Infrastructure.Persistence.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence
{
    public class ReportsDbContext : DbContext
    {
        public DbSet<VariableFields> VariableFields { get; set; }
        public DbSet<DataType> DataType { get; set; }
        public DbSet<ReportOperation> ReportOperations { get; set; }
        public DbSet<Report> Reports { get; set; }
        public DbSet<ReportTracking> ReportTrackings { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer("Server=MSI;Database=Cinema;User Id=rootPS;Password=1234;Integrated Security=True;TrustServerCertificate=True");
            optionsBuilder.UseSqlServer("Server=DESKTOP-VAO1UL8\\MAXIMILIANO;Database=ExpenseReport;Trusted_Connection=true;TrustServerCertificate=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<VariableFields>()
            .HasOne(v => v.Report)
            .WithMany()
            .HasForeignKey(v => v.ReportId)
            .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.ApplyConfiguration(new ReportOperationConfiguration());

            modelBuilder.ApplyConfiguration(new ReportConfiguration());

            modelBuilder.ApplyConfiguration(new ReportTrackingConfiguration());
        }
    }
}
