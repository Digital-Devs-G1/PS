using Application.DTO.Response.ReportOperationNS;
using Domain.Entities;

namespace Application.Interfaces.IRepositories
{
    public interface IReportTrackingQuery : IGenericRepository<ReportTracking>
    {
        public Task<IList<ReportInteraction>> GetEmployeeReportInteractions(int employeeId);
        public Task<IList<ReportOperationHistory>> GetReportHistoryByCreator(int employeeId);
        Task<IEnumerable<ReportTracking>> GetByReportId(int reportId);
        Task<ReportTracking> GetLastTrackingByReportIdAsync(int reportId);
    }
}
