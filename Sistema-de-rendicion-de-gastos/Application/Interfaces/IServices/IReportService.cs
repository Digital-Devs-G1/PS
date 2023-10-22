using Application.DTO.Request;
using Application.DTO.Response;
using Application.DTO.Response.ReportOperationNS;
using Application.DTO.Response.Response.EntityProxy;

namespace Application.Interfaces.IServices
{
    public interface IReportService
    {
        public Task<List<ReportStatusResponse>> GetReportsStatusById(int employeeId);

        public Task<ReportStatusResponse> GetReportStatusById(int reportId);

        public Task AddReport(ReportRequest request, List<string> fields);

        public Task<IList<ReportResponse>> GetPendingApprovals(int approverId);
    }
}
