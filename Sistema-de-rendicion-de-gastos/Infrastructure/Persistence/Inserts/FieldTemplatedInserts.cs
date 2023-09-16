using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Inserts
{
    public class FieldTemplatedInserts : IEntityTypeConfiguration<FieldTemplate>
    {
        public void Configure(EntityTypeBuilder<FieldTemplate> builder)
        {
            // Depto 1
            builder.HasData(
                new FieldTemplate()
                {
                    FieldTemplateId = 1,
                    FieldNameId = "Fecha",
                    DataTypeId = 3,
                    Enabled = true,
                },
                new FieldTemplate()
                {
                    FieldTemplateId = 1,
                    FieldNameId = "Destino",
                    DataTypeId = 2,
                    Enabled = true,
                },
                new FieldTemplate()
                {
                    FieldTemplateId = 1,
                    FieldNameId = "Km",
                    DataTypeId = 5,
                    Enabled = true,
                },
                new FieldTemplate()
                {
                    FieldTemplateId = 1,
                    FieldNameId = "Peajes",
                    DataTypeId = 4,
                    Enabled = true,
                },
                new FieldTemplate()
                {
                    FieldTemplateId = 1,
                    FieldNameId = "Monto Peajes",
                    DataTypeId = 5,
                    Enabled = true,
                }
            );
            builder.HasData(
                new FieldTemplate()
                {
                    FieldTemplateId = 2,
                    FieldNameId = "Fecha",
                    DataTypeId = 3,
                    Enabled = true,
                },
                new FieldTemplate()
                {
                    FieldTemplateId = 2,
                    FieldNameId = "Destino",
                    DataTypeId = 2,
                    Enabled = true,
                },
                new FieldTemplate()
                {
                    FieldTemplateId = 2,
                    FieldNameId = "Nombre Servicio",
                    DataTypeId = 2,
                    Enabled = true,
                },
                new FieldTemplate()
                {
                    FieldTemplateId = 2,
                    FieldNameId = "Comprobante",
                    DataTypeId = 2,
                    Enabled = true,
                }
            );
            builder.HasData(
                new FieldTemplate()
                {
                    FieldTemplateId = 3,
                    FieldNameId = "Fecha",
                    DataTypeId = 3,
                    Enabled = true,
                },
                new FieldTemplate()
                {
                    FieldTemplateId = 3,
                    FieldNameId = "Viatico",
                    DataTypeId = 2,
                    Enabled = true,
                },
                new FieldTemplate()
                {
                    FieldTemplateId = 3,
                    FieldNameId = "Motivo",
                    DataTypeId = 2,
                    Enabled = true,
                },
                new FieldTemplate()
                {
                    FieldTemplateId = 3,
                    FieldNameId = "Comprobante",
                    DataTypeId = 2,
                    Enabled = true,
                }
            );

            // Depto 2
            builder.HasData(
                new FieldTemplate()
                {
                    FieldTemplateId = 4,
                    FieldNameId = "Fecha",
                    DataTypeId = 3,
                    Enabled = true,
                },
                new FieldTemplate()
                {
                    FieldTemplateId = 4,
                    FieldNameId = "Proveedor",
                    DataTypeId = 2,
                    Enabled = true,
                },
                new FieldTemplate()
                {
                    FieldTemplateId = 4,
                    FieldNameId = "Contacto",
                    DataTypeId = 1,
                    Enabled = true,
                },
                new FieldTemplate()
                {
                    FieldTemplateId = 4,
                    FieldNameId = "Nombre Material",
                    DataTypeId = 2,
                    Enabled = true,
                },
                new FieldTemplate()
                {
                    FieldTemplateId = 4,
                    FieldNameId = "Peso [Kg]",
                    DataTypeId = 5,
                    Enabled = true,
                },
                new FieldTemplate()
                {
                    FieldTemplateId = 4,
                    FieldNameId = "Ancho [mm]",
                    DataTypeId = 5,
                    Enabled = true,
                },
                new FieldTemplate()
                {
                    FieldTemplateId = 4,
                    FieldNameId = "Alto [mm]",
                    DataTypeId = 5,
                    Enabled = true,
                }
            );

            builder.HasData(
                new FieldTemplate()
                {
                    FieldTemplateId = 5,
                    FieldNameId = "Fecha",
                    DataTypeId = 3,
                    Enabled = true,
                },
                new FieldTemplate()
                {
                    FieldTemplateId = 5,
                    FieldNameId = "Viatico",
                    DataTypeId = 2,
                    Enabled = true,
                },
                new FieldTemplate()
                {
                    FieldTemplateId = 5,
                    FieldNameId = "Motivo",
                    DataTypeId = 2,
                    Enabled = true,
                },
                new FieldTemplate()
                {
                    FieldTemplateId = 5,
                    FieldNameId = "Comprobante",
                    DataTypeId = 2,
                    Enabled = true,
                }
            );
        }
    }
}
