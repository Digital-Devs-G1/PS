namespace Domain.Entities
{
    public class Report
    {
        public int ReportId { get; set; }

        public string Description { get; set; }

        public int Amount { get; set; }

        public ICollection<ReportTracking> Trackings { get; set; }
        public ICollection<VariableField> Fields { get; set; }
    }
}
