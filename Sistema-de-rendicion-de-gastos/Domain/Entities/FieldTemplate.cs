using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class FieldTemplate
    {
        // PK
        public required int FieldTemplateId { get; set; }
        public required string FieldNameId { get; set; }

        // FK
        public required int DataTypeId { get; set; }
        public DataType? DataTypeNav { get; set; }

        // DATA
        public required bool Enabled { get; set; }
    }
}
