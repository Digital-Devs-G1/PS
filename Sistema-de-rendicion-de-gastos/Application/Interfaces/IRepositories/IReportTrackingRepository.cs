using Domain.Entities;

namespace Application.Interfaces.IRepositories
{
    public interface IReportTrackingRepository
    {
        Task<IEnumerable<ReportTracking>> GetByReportId(int reportId);

        Task<ReportTracking> GetLastTrackingByReportIdAsync(int reportId);
    }
}
