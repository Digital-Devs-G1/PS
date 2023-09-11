using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.Extensions.Options;

namespace Infrastructure.Persistence
{
    public class ReportsDbContext : DbContext
    {
        public DbSet<VariableField> VariableFields { get; set; }
        public DbSet<DataType> DataType { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=MSI;Database=RendicionGastos;User Id=rootPS;Password=1234;Integrated Security=True;TrustServerCertificate=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<VariableField>(InitVariableFieldsTable);
            modelBuilder.Entity<DataType>(InitDataType);
        }

        public void InitVariableFieldsTable(EntityTypeBuilder<VariableField> table)
        {
            table.HasKey(x => new { x.ReportId, x.Label });
            table.HasOne(x => x.ReportNav)
                .WithMany()
                .HasForeignKey(x => x.ReportId);
            table.HasOne(x => x.DataTypeNav)
                .WithMany()
                .HasForeignKey(x => x.DataTypeId);
            table.Property(x => x.Label)
                .HasMaxLength(20);
            table.Property(x => x.Value)
                .HasMaxLength(50);
        }

        public void InitDataType(EntityTypeBuilder<DataType> table)
        {
            table.HasKey(x => x.DataTypeId);
            table.Property(x => x.Name)
                .HasMaxLength(10);
        }
    }
}
