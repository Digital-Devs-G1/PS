namespace Domain.Entities
{
    public class Report
    {
        // PK
        public required int ReportId { get; set; }

        // FK
        //public ICollection<ReportTracking>? ReportTrackingCol { get; set; }
        //public ICollection<VariableField>? VariableFieldCol { get; set; }

        // DATA
        public required int EmployeeId { get; set; }
        public required string Description { get; set; }
        public required double Amount { get; set; }
    }
}
