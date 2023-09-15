
namespace Domain.Entities
{
    public class VariableField
    {
        public required int ReportId { get; set; }
        public Report? ReportNav { get; set; }
        public required string Label { get; set; }
        public required string Value { get; set; }

        public required int DataTypeId { get; set; }
        public DataType? DataTypeNav { get; set; }
    }
}
