

namespace Domain.Entities
{
    public class ReportTemplateField : BaseEntity
    {
        // PK
        public required int ReportTemplateId { get; set; }
        public ReportTemplate? ReportTemplateNav { get; set; }

        public required string Name { get; set; }

        // FK
        public required int DataTypeId { get; set; }
        public DataType? DataTypeNav { get; set; }

        // DATA
        public required bool Enabled { get; set; }
    }
}
