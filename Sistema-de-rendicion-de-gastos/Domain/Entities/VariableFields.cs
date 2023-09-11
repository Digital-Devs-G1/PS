using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class VariableFields
    {
        public string Label { get; set; }
        public string Value { get; set; }

        public int DataType { get; set; }
        public DataType DataTypeNav { get; set; }
        public int ReportId { get; set; }
        public Report ReportNav { get; set; }
    }
}
