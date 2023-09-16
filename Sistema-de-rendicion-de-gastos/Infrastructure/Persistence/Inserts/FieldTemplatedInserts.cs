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
                    TemplateId = 1,
                    Label = "Fecha",
                    DataTypeId = 3,
                    Enabled = true,
                },
                new FieldTemplate()
                {
                    TemplateId = 1,
                    Label = "Destino",
                    DataTypeId = 2,
                    Enabled = true,
                },
                new FieldTemplate()
                {
                    TemplateId = 1,
                    Label = "Km",
                    DataTypeId = 5,
                    Enabled = true,
                },
                new FieldTemplate()
                {
                    TemplateId = 1,
                    Label = "Peajes",
                    DataTypeId = 4,
                    Enabled = true,
                },
                new FieldTemplate()
                {
                    TemplateId = 1,
                    Label = "Monto Peajes",
                    DataTypeId = 5,
                    Enabled = true,
                }
            );
            builder.HasData(
                new FieldTemplate()
                {
                    TemplateId = 2,
                    Label = "Fecha",
                    DataTypeId = 3,
                    Enabled = true,
                },
                new FieldTemplate()
                {
                    TemplateId = 2,
                    Label = "Destino",
                    DataTypeId = 2,
                    Enabled = true,
                },
                new FieldTemplate()
                {
                    TemplateId = 2,
                    Label = "Nombre Servicio",
                    DataTypeId = 2,
                    Enabled = true,
                },
                new FieldTemplate()
                {
                    TemplateId = 2,
                    Label = "Comprobante",
                    DataTypeId = 2,
                    Enabled = true,
                }
            );
            builder.HasData(
                new FieldTemplate()
                {
                    TemplateId = 3,
                    Label = "Fecha",
                    DataTypeId = 3,
                    Enabled = true,
                },
                new FieldTemplate()
                {
                    TemplateId = 3,
                    Label = "Viatico",
                    DataTypeId = 2,
                    Enabled = true,
                },
                new FieldTemplate()
                {
                    TemplateId = 3,
                    Label = "Motivo",
                    DataTypeId = 2,
                    Enabled = true,
                },
                new FieldTemplate()
                {
                    TemplateId = 3,
                    Label = "Comprobante",
                    DataTypeId = 2,
                    Enabled = true,
                }
            );

            // Depto 2
            builder.HasData(
                new FieldTemplate()
                {
                    TemplateId = 4,
                    Label = "Fecha",
                    DataTypeId = 3,
                    Enabled = true,
                },
                new FieldTemplate()
                {
                    TemplateId = 4,
                    Label = "Proveedor",
                    DataTypeId = 2,
                    Enabled = true,
                },
                new FieldTemplate()
                {
                    TemplateId = 4,
                    Label = "Contacto",
                    DataTypeId = 1,
                    Enabled = true,
                },
                new FieldTemplate()
                {
                    TemplateId = 4,
                    Label = "Nombre Material",
                    DataTypeId = 2,
                    Enabled = true,
                },
                new FieldTemplate()
                {
                    TemplateId = 4,
                    Label = "Peso [Kg]",
                    DataTypeId = 5,
                    Enabled = true,
                },
                new FieldTemplate()
                {
                    TemplateId = 4,
                    Label = "Ancho [mm]",
                    DataTypeId = 5,
                    Enabled = true,
                },
                new FieldTemplate()
                {
                    TemplateId = 4,
                    Label = "Alto [mm]",
                    DataTypeId = 5,
                    Enabled = true,
                }
            );

            builder.HasData(
                new FieldTemplate()
                {
                    TemplateId = 5,
                    Label = "Fecha",
                    DataTypeId = 3,
                    Enabled = true,
                },
                new FieldTemplate()
                {
                    TemplateId = 5,
                    Label = "Viatico",
                    DataTypeId = 2,
                    Enabled = true,
                },
                new FieldTemplate()
                {
                    TemplateId = 5,
                    Label = "Motivo",
                    DataTypeId = 2,
                    Enabled = true,
                },
                new FieldTemplate()
                {
                    TemplateId = 5,
                    Label = "Comprobante",
                    DataTypeId = 2,
                    Enabled = true,
                }
            );
        }
    }
}
