using Application.DTO.Response.ReportOperationNS;
using Application.Interfaces.IRepositories;
using Application.Interfaces.IServices;
using Domain.Entities;

namespace Application.UseCases
{
    public class ReportTrackingService : IReportTrackingService
    {
        private IReportTrackingQuery _repository;

        public ReportTrackingService(IReportTrackingQuery repository)
        {
            _repository = repository;
        }

        public async Task<IList<ReportInteraction>> GetEmployeeReportInteractions(int employeeId)
        {
            return await _repository.GetEmployeeReportInteractions(employeeId);
        }

        public async Task<IList<ReportOperationHistory>> GetReportHistoryByCreator(int employeeId)
        {
            return await _repository.GetReportHistoryByCreator(employeeId);
        }

        public Task<IEnumerable<ReportTracking>> GetByReportId(int reportId)
        {
            return _repository.GetByReportId(reportId);
        }

        public Task<ReportTracking> GetLastTrackingByReportId(int reportId)
        {
            return _repository.GetLastTrackingByReportIdAsync(reportId);
        }

    }
}