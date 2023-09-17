using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Inserts
{
    public class DeptoTemplatedInserts : IEntityTypeConfiguration<DepartmentTemplate>
    {
        public void Configure(EntityTypeBuilder<DepartmentTemplate> builder)
        {
            string[] names = { "Auto Propio", "Servicio Viaje", "Viaticos" };
            Insert(builder, names, autoincrement: 1, departmentId: 1);

            string[] names2 = { "Materiales de Construccion", "Placas de Carpinteria" };
            Insert(builder, names2, autoincrement: (names.Length + 1), departmentId: 2);
        }

        private void Insert(
            EntityTypeBuilder<DepartmentTemplate> builder,
            string[] names,
            int autoincrement,
            int departmentId
            )
        {
            if (autoincrement < 1)
                throw new Exception("El id debe ser mayor a 0");

            foreach (var name in names)
                builder.HasData(new DepartmentTemplate()
                {
                    DepartmentTemplateId = autoincrement++,
                    DeptartmentId = departmentId,
                    DepartmentTemplateName = name
                });
        }
    }
}
