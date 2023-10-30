using Application.DTO.Request;
using Application.DTO.Response;
using Application.DTO.Response.ReportOperationNS;
using Application.DTO.Response.Response.EntityProxy;
using Domain.Entities;

namespace Application.Interfaces.IServices
{
    public interface IReportService
    {
        public Task<List<ReportStatusResponse>> GetReportsStatusById(int employeeId);

        public Task<ReportStatusResponse> GetReportStatusById(int reportId);

        public Task<int> AddReport(AddReportRequest reportRequest, int employeeId);

        public Task<IList<ReportResponse>> GetPendingApprovals(int approverId);
        public  Task<Report> GetById(int id);
        public Task<bool> ExistReportById(int reportId);
    }
}
