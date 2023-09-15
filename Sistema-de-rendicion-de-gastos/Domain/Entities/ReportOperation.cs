namespace Domain.Entities
{
    public class ReportOperation
    {
        public required int ReportOperationId { get; set; }

        public required string ReportOperationName { get; set;}

        public ICollection<ReportTracking>? Trackings { get; set; }
    }
}
