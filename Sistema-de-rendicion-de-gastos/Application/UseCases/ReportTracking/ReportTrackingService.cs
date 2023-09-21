using Application.DTO.Response.ReportOperationNS;
using Application.Interfaces.IRepositories.ICommand;
using Application.Interfaces.IRepositories.IQuery;
using Application.Interfaces.IServices.IReportTraking;
using Domain.Entities;

namespace Application.UseCases.ReportTracking
{
    public class ReportTrackingService : IReportTrackingService
    {
        private IReportTrackingQuery _repository;
        private readonly IGenericRepositoryCommand<ReportTracking> command;

        public ReportTrackingService(IReportTrackingQuery repository, IGenericRepositoryCommand<ReportTracking> command)
        {
            _repository = repository;
            this.command = command;
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

        public async Task AddCreationTracking(int reportId, int employeeId)
        {
            var tracking = new ReportTracking
            {
                ReportId = reportId,
                EmployeeId = employeeId,
                ReportOperationId = 1,
                TrackingDate = DateTime.Now,
            };
            await command.AddAndCommit(tracking);
        }
    }
}