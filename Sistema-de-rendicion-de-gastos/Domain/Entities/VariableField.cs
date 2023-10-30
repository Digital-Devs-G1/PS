
namespace Domain.Entities
{
    public class VariableField : BaseEntity
    {
        // PK y FK
        public int? ReportId { get; set; }
        public Report? ReportNav { get; set; }
        public required string Name { get; set; }

        // FK
        public required int DataTypeId { get; set; }
        public DataType? DataTypeNav { get; set; }

        // DATA
        public required string Value { get; set; }
    }
}
