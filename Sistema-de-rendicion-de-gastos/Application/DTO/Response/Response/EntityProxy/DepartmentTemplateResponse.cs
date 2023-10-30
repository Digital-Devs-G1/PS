using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO.Response.Response.EntityProxy
{
    public class DepartmentTemplateResponse
    {
        public readonly DepartmentTemplate _deptoTemp;

        public DepartmentTemplateResponse(DepartmentTemplate deptoTemp)
        {
            _deptoTemp = deptoTemp;
        }

        public int DepartmentTemplateId { get { return _deptoTemp.DepartmentTemplateId; } set { _deptoTemp.DepartmentTemplateId = value; } }
        public string DepartmentTemplateName { get { return _deptoTemp.DepartmentTemplateName; } set { _deptoTemp.DepartmentTemplateName = value; } }
        // FK
        //public ICollection<FieldTemplate>? FieldTemplateCol { get; set; }

    }
}
