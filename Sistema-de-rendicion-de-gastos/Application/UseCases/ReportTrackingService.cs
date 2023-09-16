using Application.DTO.Response;
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

        public async Task<IList<ReportOperationHistory>> GetEmployeeReportInteractions(int employeeId)
        {
            return await _repository.GetEmployeeReportInteractions(employeeId);
        }

        public async Task<IList<ReportOperationHistory>> GetReportHistoryByCreator(int employeeId)
        {
            return await _repository.GetReportHistoryByCreator(employeeId);
        }
    }
}
