using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO.Request
{
    public class FieldTemplateRequest
    {
        public required int FieldTemplateId { get; set; }
        public required string FieldNameId { get; set; }
        public required int DataTypeId { get; set; }
    }
}
