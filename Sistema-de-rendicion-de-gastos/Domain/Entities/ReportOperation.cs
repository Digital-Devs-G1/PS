namespace Domain.Entities
{
    public class ReportOperation : BaseEntity
    {
        // PK
        public required int ReportOperationId { get; set; }

        // FK
        //public ICollection<ReportTracking>? ReportTrackingCol { get; set; }
    
        // DATA
        public required string ReportOperationName { get; set; }
    }
}
