using Application.Interfaces.IRepositories;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
