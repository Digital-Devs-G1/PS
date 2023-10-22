using Application.DTO.Response.Response.EntityProxy;
using Application.Interfaces.IRepositories;
using Application.Interfaces.IRepositories.IQuery;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static Application.Enums.ReportOperationEnum;

namespace Infrastructure.Repositories.Query
{
    public class ReportQuery : IReportQuery
    {
        private readonly ReportsDbContext _context;

        public ReportQuery(ReportsDbContext context)
        {
            _context = context;
        }

        public async Task<bool> ExistReportById(int id)
        {
            return await _context.Reports.AnyAsync(r => r.ReportId == id);
        }

        public Report GetReport(int idReport)
        {
            throw new NotImplementedException();
        }

        public async Task<IList<ReportResponse>> GetPendingApprovals(int approverId)
        {
            return await _context.ReportTrackings
                .Include(x => x.ReportNav)
                .Include(x => x.ReportOperationNav)
                .Where(x => 
                    x.ReportNav.ApproverId == approverId &&
                    x.ReportOperationNav.ReportOperationId == (int)Create
                )
                .Select((x) => new ReportResponse()
                {
                    ReportId = x.ReportId,
                    Description = x.ReportNav.Description,
                    Amount = x.ReportNav.Amount,
                    DateTracking = x.TrackingDate
                })
                .ToListAsync();
        }
    }
}
