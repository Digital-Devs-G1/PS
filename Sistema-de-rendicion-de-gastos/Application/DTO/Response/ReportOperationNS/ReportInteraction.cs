
namespace Application.DTO.Response.ReportOperationNS
{
    public class ReportInteraction
    {
        public required int ReportId { get; set; }
        public required string ReportOperationName { get; set; }
        public required DateTime? TrackingDate { get; set; }
    }
}
