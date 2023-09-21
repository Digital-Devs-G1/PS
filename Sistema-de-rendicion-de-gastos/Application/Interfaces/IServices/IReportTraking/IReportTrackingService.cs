using Application.DTO.Response.ReportOperationNS;
using Domain.Entities;

namespace Application.Interfaces.IServices.IReportTraking
{
    public interface IReportTrackingService
    {
        public Task<IList<ReportInteraction>> GetEmployeeReportInteractions(int employeeId);
        public Task<IList<ReportOperationHistory>> GetReportHistoryByCreator(int employeeId);
        Task<IEnumerable<ReportTracking>> GetByReportId(int reportId);
        Task<ReportTracking> GetLastTrackingByReportId(int reportId);

        Task AddCreationTracking(int reportId, int employeeId);
    }
}
