using Application.DTO.Response.ReportOperationNS;
using Application.Interfaces.IRepositories.ICommand;
using Domain.Entities;

namespace Application.Interfaces.IRepositories.IQuery
{
    public interface IReportTrackingQuery : IGenericCommand<ReportTracking>
    {
        public Task<IList<ReportInteraction>> GetEmployeeReportInteractions(int employeeId);
        public Task<IList<ReportOperationHistory>> GetReportHistoryByCreator(int employeeId);
        Task<IEnumerable<ReportTracking>> GetByReportId(int reportId);
        Task<ReportTracking> GetLastTrackingByReportIdAsync(int reportId);
    }
}
