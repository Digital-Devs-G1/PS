

namespace Domain.Entities
{
    public class FieldTemplate
    {
        // PK
        public required int DepartmentTemplateId { get; set; }
        public required int OrdinalNumber { get; set; }

        public required string Name { get; set; }

        // FK
        public required int DataTypeId { get; set; }
        public DataType? DataTypeNav { get; set; }

        // DATA
        public required bool Enabled { get; set; }
    }
}
