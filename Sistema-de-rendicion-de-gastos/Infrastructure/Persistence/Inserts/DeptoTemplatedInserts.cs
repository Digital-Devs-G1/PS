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
            builder.HasData(
                new DepartmentTemplate()
                {
                    DepartmentTemplateId = 1,
                    DeptartmentId = 1,
                    DepartmentTemplateName = "Auto Propio"

                },
                new DepartmentTemplate()
                {
                    DepartmentTemplateId = 2,
                    DeptartmentId = 1,
                    DepartmentTemplateName = "Servicio Viaje"

                },
                new DepartmentTemplate()
                {
                    DepartmentTemplateId = 3,
                    DeptartmentId = 1,
                    DepartmentTemplateName = "Viaticos"
                },
                new DepartmentTemplate()
                {
                    DepartmentTemplateId = 4,
                    DeptartmentId = 2,
                    DepartmentTemplateName = "Material.Const."
                },
                new DepartmentTemplate()
                {
                    DepartmentTemplateId = 5,
                    DeptartmentId = 2,
                    DepartmentTemplateName = "Viaticos"
                }
            );
        }
    }
}
