using Application.Interfaces.IRepositories;
using Application.Interfaces.IServices;
using Domain.Entities;

namespace Application.UseCases
{
    public class ReportTrackingService : IReportTrackingService
    {
        private readonly IReportTrackingRepository repository;
        public ReportTrackingService(IReportTrackingRepository repository)
        {
            this.repository = repository;
        }

        public Task<IEnumerable<ReportTracking>> GetByReportId(int reportId)
        {
            return repository.GetByReportId(reportId);
        }

        public Task<ReportTracking> GetLastTrackingByReportId(int reportId)
        {
            return repository.GetLastTrackingByReportIdAsync(reportId);
        }
    }
}
