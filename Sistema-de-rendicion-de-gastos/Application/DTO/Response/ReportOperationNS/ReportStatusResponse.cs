namespace Application.DTO.Response.ReportOperationNS
{
    public class ReportStatusResponse
    {
        public required int ReportId { get; set; }

        public required string Description { get; set; }

        public required double Amount { get; set; }

        public required string Status { get; set; }

        public required DateTime? DateTracking { get; set; }
    }
}
