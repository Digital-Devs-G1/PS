using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO.Request
{
    public class AddReportRequest
    {
        public required int TemplateId { get; set; }
        public required ReportRequest Report { get; set; }
        public required IList<FieldRequest> Fields { get; set; }

    }
}
