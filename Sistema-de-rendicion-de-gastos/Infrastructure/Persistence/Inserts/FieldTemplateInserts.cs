using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using static Infrastructure.Persistence.Inserts.DataTypeEnum;

namespace Infrastructure.Persistence.Inserts
{
    internal class Field
    {
        public string Name { get; set; }
        public int TypeId { get; set; }

        public Field(string name, int typeId)
        {
            TypeId = typeId;
            Name = name;
        }
    }

    public class FieldTemplateInserts : IEntityTypeConfiguration<FieldTemplate>
    {
        private int _autoincrement = 1;
        public void Configure(EntityTypeBuilder<FieldTemplate> builder)
        {
            DeptoOneTemplates(builder);
            DeptoTwoTemplates(builder);
            DeptoThreeTemplates(builder);
        }

        // Al departamento 3 se le asignaron 2 templates en DeptoTemplateInserts
        private void DeptoThreeTemplates(EntityTypeBuilder<FieldTemplate> builder)
        {
            AddTemplate(builder, new List<Field>()
            {
                new Field("Proveedor", (int)Str),
                new Field("Tel. Proveedor", (int)Int)
            });
            AddTemplate(builder, new List<Field>()
            {
                new Field("Ancho [mm]", (int)Int),
                new Field("Alto [mm]", (int)Int),
                new Field("Peso [Kg]", (int)Dec)
            });
        }

        // Al departamento 2 se le asignaron 3 templates en DeptoTemplateInserts
        private void DeptoOneTemplates(EntityTypeBuilder<FieldTemplate> builder)
        {
            AddTemplate(builder, new List<Field>()
            {
                new Field("Destino", (int)Str),
                new Field("Km", (int)Dec),
                new Field("HuboPeajes", (int)Bool),
                new Field("Monto Peajes", (int)Dec),
            });
            AddTemplate(builder, new List<Field>()
            {
                new Field("Destino", (int)Str),
                new Field("Nombre Servicio", (int)Str),
                new Field("Comprobante", (int)Str)
            });
            AddTemplate(builder, new List<Field>()
            {
                new Field("Viatico", (int)Str),
                new Field("Motivo", (int)Str),
                new Field("Comprobante", (int)Str)
            });
        }

        // Al departamento 2 se le asignaron 2 templates en DeptoTemplateInserts
        private void DeptoTwoTemplates(EntityTypeBuilder<FieldTemplate> builder)
        {
            AddTemplate(builder, new List<Field>()
            {
                new Field("Proveedor", (int)Str),
                new Field("Contacto", (int)Int),
                new Field("Nombre Material", (int)Str),
                new Field("Peso [Kg]", (int)Dec),
                new Field("Ancho [mm]", (int)Int),
                new Field("Alto [mm]", (int)Int),
            });
            AddTemplate(builder, new List<Field>()
            {
                new Field("Viatico", (int)Str),
                new Field("Motivo", (int)Str),
                new Field("Comprobante", (int)Str)
            });
        }

        private void AddTemplate(
            EntityTypeBuilder<FieldTemplate> builder,
            IList<Field> fieldsValues
            )
        {
            List<FieldTemplate> templateFields = new List<FieldTemplate>();
            foreach (var field in fieldsValues)
                templateFields.Add(new FieldTemplate()
                {
                    FieldTemplateId = _autoincrement,
                    FieldName = field.Name,
                    DataTypeId = field.TypeId,
                    Enabled = true,
                }
                );
            _autoincrement++;
            builder.HasData(templateFields);
        }
    }
}
