namespace Domain.Entities
{
    public class ReportOperation : BaseEntity
    {
        public required string ReportOperationName { get; set;}

        public ICollection<ReportTracking>? Trackings { get; set; }
    }
}
