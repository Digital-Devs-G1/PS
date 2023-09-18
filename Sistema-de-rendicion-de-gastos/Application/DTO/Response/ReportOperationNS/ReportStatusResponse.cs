namespace Application.DTO.Response.ReportOperationNS
{
    public class ReportStatusResponse
    {
        public int ReportId { get; set; }

        public string Description { get; set; }

        public double Amount { get; set; }

        public string Status { get; set; }

        public DateTime? DateTracking { get; set; }
    }
}
