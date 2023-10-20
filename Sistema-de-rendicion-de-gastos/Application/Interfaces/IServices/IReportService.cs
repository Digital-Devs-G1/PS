using Application.DTO.Request;
using Application.DTO.Response;
using Application.DTO.Response.ReportOperationNS;

namespace Application.Interfaces.IServices
{
    public interface IReportService
    {
        Task<List<ReportStatusResponse>> GetReportsStatusById(int employeeId);

        Task<ReportStatusResponse> GetReportStatusById(int reportId);

        Task AddReport(ReportRequest request);

        Task<bool> ExistReportById(int reportId);
    }
}
