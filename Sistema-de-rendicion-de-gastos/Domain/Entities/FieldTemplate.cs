using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class FieldTemplate
    {
        public required int TemplateId { get; set; }
        public DeptoTemplate? DeptoTemplateNav { get; set; }
        public required string Label { get; set; }
        public required bool Enabled { get; set; }

        public required int DataTypeId { get; set; }
        public DataType? DataTypeNav { get; set; }
    }
}
