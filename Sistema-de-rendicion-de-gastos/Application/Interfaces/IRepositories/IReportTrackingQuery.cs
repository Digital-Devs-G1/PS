using Application.DTO.Response;
using Domain.Entities;

namespace Application.Interfaces.IRepositories
{
    public interface IReportTrackingQuery
    {
        public Task<IList<ReportOperationHistory>> GetEmployeeReportInteractions(int employeeId);
        public Task<IList<ReportOperationHistory>> GetReportHistoryByCreator(int employeeId);
        Task<IEnumerable<ReportTracking>> GetByReportId(int reportId);
        Task<ReportTracking> GetLastTrackingByReportIdAsync(int reportId);
    }
}
