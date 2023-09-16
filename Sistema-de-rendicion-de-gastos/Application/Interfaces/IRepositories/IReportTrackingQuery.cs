using Application.DTO.Response;

namespace Application.Interfaces.IRepositories
{
    public interface IReportTrackingQuery
    {
        public Task<IList<ReportOperationHistory>> GetEmployeeReportInteractions(int employeeId);
        public Task<IList<ReportOperationHistory>> GetReportHistoryByCreator(int employeeId);
    }
}
