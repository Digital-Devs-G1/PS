namespace Application.DTO.Request
{
    public class ReportRequest
    {
        public int TemplateId { get; set; }

        public int EmployeeId { get; set; }

        public string Description { get; set; }

        public double Amount { get; set; }
    }
}
