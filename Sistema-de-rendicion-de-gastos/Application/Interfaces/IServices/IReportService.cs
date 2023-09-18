using Application.DTO.Response;
using Domain.Entities;

namespace Application.Interfaces.IServices
{
    public interface IReportService
    {
        Task<List<ReportStatusResponse>> GetReportsStatusById(int employeeId);

        Task<ReportStatusResponse> GetReportStatusById(int reportId);

    }
}
