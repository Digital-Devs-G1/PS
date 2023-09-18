
namespace Application.DTO.Response.ReportOperationNS
{
    public class ReportOperationHistory
    {
        public int ReportId { get; set; }
        public required IList<ReportOperationHistoryItem> Operations { get; set; }
    }
}
