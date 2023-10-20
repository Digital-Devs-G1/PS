using Application.DTO.Response.ReportOperationNS;
using Domain.Entities;

namespace Application.Interfaces.IServices.IReportTraking
{
    public interface IReportTrackingService
    {
        public Task<IList<ReportInteraction>> GetEmployeeReportInteractions(int employeeId);
        public Task<IList<ReportOperationHistory>> GetReportHistoryByCreator(int employeeId);
        public Task<IEnumerable<ReportTracking>> GetByReportId(int reportId);
        public Task<ReportTracking> GetLastTrackingByReportId(int reportId);

        public Task AddCreationTracking(int reportId, int employeeId);

        public Task AddAcceptTracking(int reportId, int employeeId);

        public Task AddDismissTracking(int reportId, int employeeId);
    }
}
