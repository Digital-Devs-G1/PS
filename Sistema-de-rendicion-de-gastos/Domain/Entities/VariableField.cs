
namespace Domain.Entities
{
    public class VariableField
    {
        public int ReportId { get; set; }
        public Report ReportNav { get; set; }
        public string Label { get; set; }
        public string Value { get; set; }

        public int DataTypeId { get; set; }
        public DataType DataTypeNav { get; set; }
    }
}
