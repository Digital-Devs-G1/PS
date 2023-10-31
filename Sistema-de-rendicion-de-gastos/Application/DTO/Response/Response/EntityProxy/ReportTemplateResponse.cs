using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO.Response.Response.EntityProxy
{
    public class ReportTemplateResponse
    {
        public int ReportTemplateId { get; set; }
        public string ReportTemplateName { get ; set ;}
        // FK
        //public ICollection<FieldTemplate>? FieldTemplateCol { get; set; }

    }
}
