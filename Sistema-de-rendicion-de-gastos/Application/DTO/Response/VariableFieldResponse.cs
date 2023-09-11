using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO.Response
{
    public class VariableFieldResponse
    {
        public string Label { get; set; }
        public string Value { get; set; }

        public int DataTypeId { get; set; }
        public DataType DataTypeNav { get; set; }
        public int ReportId { get; set; }
        public Report ReportNav { get; set; }
    }
}
