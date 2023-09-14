namespace Domain.Entities
{
    public class ReportTracking
    {
        public int ReportTrackingId { get; set; }

        public int EmployeeId { get; set; }

        public int ReportId { get; set; }

        public Report Report { get; set; }

        public int ReportOperationId { get; set; }

        public ReportOperation ReportOperation { get; set; }

        public DateTime DateTracking { get; set; }
    }
}
