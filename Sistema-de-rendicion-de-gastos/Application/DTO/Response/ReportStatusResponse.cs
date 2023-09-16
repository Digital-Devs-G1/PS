namespace Application.DTO.Response
{
    public class ReportStatusResponse
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public double Amount { get; set; }

        public string Status { get; set; }

        public DateTime? DateTracking { get; set; }
    }
}
