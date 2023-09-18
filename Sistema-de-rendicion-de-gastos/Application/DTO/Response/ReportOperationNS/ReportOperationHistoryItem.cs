
namespace Application.DTO.Response.ReportOperationNS
{
    public class ReportOperationHistoryItem
    {
        public required string ReportOperationName { get; set; }
        public required int EmployeeId { get; set; }
        public required DateTime? TrackingDate { get; set; }
    }
}
