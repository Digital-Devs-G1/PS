using Application.DTO.Response.ReportOperationNS;
using Application.Interfaces.IRepositories.ICommand;
using Application.Interfaces.IRepositories.IQuery;
using Application.Interfaces.IServices.IReportTraking;
using Domain.Entities;
using System.Diagnostics;
using static Application.Enums.ReportOperationEnum;

namespace Application.UseCases.ReportTrackingService
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
            await AddTracking(reportId, employeeId, (int)Create);
        }

        public async Task AddAcceptTracking(int reportId, int employeeId)
        {
            await AddTracking(reportId, employeeId, (int)Approval);
        }

        public async Task AddDismissTracking(int reportId, int employeeId)
        {
            await AddTracking(reportId, employeeId, (int)Refuse);
        }

        private async Task AddTracking(
            int reportId, 
            int employeeId,
            int operationId
            )
        {
            var tracking = new ReportTracking
            {
                ReportId = reportId,
                EmployeeId = employeeId,
                ReportOperationId = operationId,
                TrackingDate = DateTime.Now,
            };
            await command.AddAndCommit(tracking);
        }
    }
}