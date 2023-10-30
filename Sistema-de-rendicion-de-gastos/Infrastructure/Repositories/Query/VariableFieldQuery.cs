using Application.Interfaces.IRepositories;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.Query
{
    public class VariableFieldQuery : IVariableFieldQuery
    {
        public readonly ReportsDbContext _context;

        public VariableFieldQuery(ReportsDbContext context)
        {
            _context = context;
        }

        public async Task<FieldTemplate> GetById(int id, string fieldName)
        {
            return await _context.FieldTemplates.Where(x => x.FieldTemplateId == id && x.FieldNameId == fieldName).FirstOrDefaultAsync();
        }

        public async Task<List<VariableField>> GetVariablesFieldByReportId (int reportId)
        {
            return await _context.VariableFields.Where(vf => vf.ReportId == reportId)
                                                .ToListAsync();
        }
    }
}
