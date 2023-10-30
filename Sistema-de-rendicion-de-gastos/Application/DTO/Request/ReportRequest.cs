namespace Application.DTO.Request
{
    public class ReportRequest
    {
        public required string Description { get; set; }

        public required double Amount { get; set; }
    }
}
