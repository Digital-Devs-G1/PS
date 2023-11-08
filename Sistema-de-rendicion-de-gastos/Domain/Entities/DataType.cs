using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class DataType : BaseEntity
    {
        // PK
        public required int DataTypeId { get; set; }

        // FK
        public ICollection<VariableField>? VariableFieldCol { get; set; }

        // DATA
        public required string Name { get; set; }
    }
}
