using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class VariableFields
    {
        [Key, ForeignKey("Report")]
        public int ReportId { get; set; }
        public Report Report { get; set; }
        public string Label { get; set; }
        public string Value { get; set; }
        public int DataType { get; set; }
        public DataType DataTypeNav { get; set; }
    }
}
