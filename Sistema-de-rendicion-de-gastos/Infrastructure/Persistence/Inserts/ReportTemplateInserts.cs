using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Inserts
{
    public class ReportTemplateInserts : IEntityTypeConfiguration<ReportTemplate>
    {
        private int _autoincrement = 1;

        public void Configure(EntityTypeBuilder<ReportTemplate> builder)
        {
            string[] names = { "Auto Propio", "Servicio Viaje", "Viaticos" };
            Insert(builder, names, departmentId: 1);

            string[] names2 = { "Gastos varios", "Materia prima" };
            Insert(builder, names2, departmentId: 2);

            string[] names3 = { "Materiales de Construccion", "Placas de Carpinteria" };
            Insert(builder, names3, departmentId: 3);
        }

        private void Insert(
            EntityTypeBuilder<ReportTemplate> builder,
            string[] names,
            int departmentId
            )
        {
            if (_autoincrement < 1)
                throw new Exception("El id debe ser mayor a 0");

            foreach (var name in names)
                builder.HasData(new ReportTemplate()
                {
                    ReportTemplateId = _autoincrement++,
                    DepartmentId = departmentId,
                    ReportTemplateName = name
                });
        }
    }
}
