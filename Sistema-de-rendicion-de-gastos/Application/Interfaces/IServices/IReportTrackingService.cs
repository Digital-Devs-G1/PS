using Domain.Entities;

namespace Application.Interfaces.IServices
{
    public interface IReportTrackingService
    {
        Task<IEnumerable<ReportTracking>> GetByReportId(int reportId);

        Task<ReportTracking> GetLastTrackingByReportId(int reportId);
    }
}
