using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO.Response.Response.EntityProxy
{
    public class ReportResponse
    {
        public required int ReportId { get; set; }

        public required string Description { get; set; }

        public required double Amount { get; set; }

        public required string DateTracking { get; set; }
    }
}
