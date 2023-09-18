namespace Domain.Entities
{
    public class ReportTracking : BaseEntity
    {
        // PK
        public required int ReportTrackingId { get; set; }

        // FK
        public required int ReportId { get; set; }
        public Report? ReportNav { get; set; }
        public required int ReportOperationId { get; set; }
        public ReportOperation? ReportOperationNav { get; set; }

        // DATA
        public required int EmployeeId { get; set; }
        public DateTime? TrackingDate { get; set; }
    }
}
