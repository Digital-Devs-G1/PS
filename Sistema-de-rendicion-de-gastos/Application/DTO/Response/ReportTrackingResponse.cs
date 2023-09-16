using Domain.Entities;

namespace Application.DTO.Response
{
    public class ReportTrackingResponse
    {
        public int Id { get; set; }

        public required int EmployeeId { get; set; }

        public required int ReportId { get; set; }

        public required int ReportOperationId { get; set; }

        public DateTime? DateTracking { get; set; }
    }
}
