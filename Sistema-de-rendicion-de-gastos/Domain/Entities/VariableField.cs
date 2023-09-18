
namespace Domain.Entities
{
    public class VariableField : BaseEntity
    {
        // PK
        public required string NameId { get; set; }

        // PK y FK
        public required int ReportId { get; set; }
        public Report? ReportNav { get; set; }

        // FK
        public required int DataTypeId { get; set; }
        public DataType? DataTypeNav { get; set; }

        // DATA
        public required string Value { get; set; }
    }
}
