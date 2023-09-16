using Application.DTO.Response;

namespace Application.Interfaces.IServices
{
    public interface IReportService
    {
        Task<List<ReportStatusResponse>> GetReportsStatusById(int employeeId);

        Task<ReportStatusResponse> GetReportStatusById(int reportId);
    }
}
