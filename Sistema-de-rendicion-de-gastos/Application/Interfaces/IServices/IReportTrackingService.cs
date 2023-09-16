using Application.DTO.Response;

namespace Application.Interfaces.IServices
{
    public interface IReportTrackingService
    {
        public Task<IList<ReportOperationHistory>> GetEmployeeReportInteractions(int employeeId);
        public Task<IList<ReportOperationHistory>> GetReportHistoryByCreator(int employeeId);
    }
}