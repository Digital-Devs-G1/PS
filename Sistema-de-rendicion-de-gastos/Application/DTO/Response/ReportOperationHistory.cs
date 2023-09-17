using Domain.Entities;

namespace Application.DTO.Response
{
    public class ReportOperationHistory
    {
        public int ReportId { get; set; }
        public required IList<ReportTracking> Operations { get; set; }
    }
}
