using Application.Interfaces.IRepositories;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class ReportTrackingRepository : IReportTrackingRepository
    {
        private readonly DbContext context;
        private readonly DbSet<ReportTracking> entity;

        public ReportTrackingRepository(DbContext context)
        {
            this.context = context;
            this.entity = context.Set<ReportTracking>();
        }

        public async Task<IEnumerable<ReportTracking>> GetByReportId(int reportId)
        {
            return await entity.Where(e => e.ReportId == reportId).ToListAsync();
        }

        public async Task<ReportTracking> GetLastTrackingByReportIdAsync(int reportId)
        {
            var trackings = await entity.Where(e => e.ReportId == reportId).ToListAsync();
            return trackings.OrderByDescending(e => e.DateTracking).FirstOrDefault();
        }
    }
}
