namespace Domain.Entities
{
    public class ReportOperation
    {
        public int ReportOperationId { get; set; }

        public string ReportOperationName { get; set;}

        public ICollection<ReportTracking> Trackings { get; set; }
    }
}
