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
    public class DeptoTemplatedInserts : IEntityTypeConfiguration<DeptoTemplate>
    {
        public void Configure(EntityTypeBuilder<DeptoTemplate> builder)
        {
            builder.HasData(
                new DeptoTemplate()
                {
                    TemplateId = 1,
                    DeptoId = 1,
                    Name = "Auto Propio"

                },
                new DeptoTemplate()
                {
                    TemplateId = 2,
                    DeptoId = 1,
                    Name = "Servicio Viaje"

                },
                new DeptoTemplate()
                {
                    TemplateId = 3,
                    DeptoId = 1,
                    Name = "Viaticos"
                },
                new DeptoTemplate()
                {
                    TemplateId = 4,
                    DeptoId = 2,
                    Name = "Material.Const."
                },
                new DeptoTemplate()
                {
                    TemplateId = 5,
                    DeptoId = 2,
                    Name = "Viaticos"
                }
            );
        }
    }
}
