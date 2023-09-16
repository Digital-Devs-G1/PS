using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class DepartmentTemplate
    {
        // PK
        public required int DepartmentTemplateId { get; set; }

        // FK
        //public ICollection<FieldTemplate>? FieldTemplateCol { get; set; }

        //DATA
        public required int DeptartmentId { get; set; }
        public required string DepartmentTemplateName { get; set; }
    }
}
