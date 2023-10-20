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
    public class VariableFieldQuery : IVariableFieldQuery
    {
        public readonly ReportsDbContext _context;

        public VariableFieldQuery(ReportsDbContext context)
        {
            _context = context;
        }

        public async Task<List<VariableField>> GetVariablesFieldByReportId (int reportId)
        {
            return await _context.VariableFields.Where(vf => vf.ReportId == reportId)
                                                .ToListAsync();
        }
    }
}
