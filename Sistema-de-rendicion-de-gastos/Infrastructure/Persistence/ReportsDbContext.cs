using Domain.Entities;
using Infrastructure.Persistence.Configurations;
using Infrastructure.Persistence.Inserts;
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
        public DbSet<FieldTemplate> FieldTemplateds { get; set; }
        public DbSet<FieldTemplate> DeptoTemplates { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-VAO1UL8\MAXIMILIANO;Database=ExpenseReport;Trusted_Connection=true;TrustServerCertificate=True;");
            optionsBuilder.EnableSensitiveDataLogging();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ReportOperationConfiguration());
            modelBuilder.ApplyConfiguration(new ReportConfiguration());
            modelBuilder.ApplyConfiguration(new ReportTrackingConfiguration());
            modelBuilder.ApplyConfiguration(new VariableFieldConfiguration());
            modelBuilder.ApplyConfiguration(new DataTypeConfiguration());
            modelBuilder.ApplyConfiguration(new FieldTemplateConfiguration());
            modelBuilder.ApplyConfiguration(new DeptoTemplateConfiguration());

            modelBuilder.ApplyConfiguration(new DataTypeInserts());
            modelBuilder.ApplyConfiguration(new ReportInserts());
            modelBuilder.ApplyConfiguration(new VariableFieldInserts());
            modelBuilder.ApplyConfiguration(new FieldTemplatedInserts());
            modelBuilder.ApplyConfiguration(new DeptoTemplatedInserts());
            modelBuilder.ApplyConfiguration(new ReportOperationInserts());
            modelBuilder.ApplyConfiguration(new ReportTrackingInserts());
        }
    }
}
