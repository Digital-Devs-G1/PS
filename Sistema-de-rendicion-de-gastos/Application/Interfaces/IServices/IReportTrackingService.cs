using Application.DTO.Response;
using Domain.Entities;

namespace Application.Interfaces.IServices
{
    public interface IReportTrackingService
    {
        public Task<IList<ReportOperationHistory>> GetEmployeeReportInteractions(int employeeId);
        public Task<IList<ReportOperationHistory>> GetReportHistoryByCreator(int employeeId);
        Task<IEnumerable<ReportTracking>> GetByReportId(int reportId);

        Task<ReportTracking> GetLastTrackingByReportId(int reportId);

        Task AddCreationTracking(int reportId, int employeeId);
    }
}
