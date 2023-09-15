namespace Domain.Entities
{
    public class Report
    {
        public required int ReportId { get; set; }

        public required string Description { get; set; }

        public required double Amount { get; set; }

        public ICollection<ReportTracking>? Trackings { get; set; }
        public ICollection<VariableField>? Fields { get; set; }
    }
}
