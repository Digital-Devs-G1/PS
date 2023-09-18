
namespace Application.DTO.Response.ReportOperationNS
{
    public class ReportOperationHistoryItem
    {
        public int ReportTrankingId { get; set; }

        public required int ReportOperationId { get; set; }

        public DateTime? DateTracking { get; set; }
    }
}
