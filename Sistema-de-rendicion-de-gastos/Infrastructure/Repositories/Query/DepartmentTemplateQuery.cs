using Application.Interfaces.IRepositories.IQuery;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.Query
{
    public class DepartmentTemplateQuery : IDepartmentTemplateQuery
    {
        public readonly ReportsDbContext _context;

        public DepartmentTemplateQuery(ReportsDbContext context)
        {
            _context = context;
        }

        public async Task<ReportTemplate> GetById(int id)
        {
            return await _context.ReportTemplate.Where(x => x.ReportTemplateId == id).FirstOrDefaultAsync();
        }

        public async Task<bool> ExistDepartamentId(int id)
        {
            return await _context.ReportTemplate.AnyAsync(dt => dt.DepartmentId == id);
        }

        public async Task<IList<ReportTemplate>> GetTemplatesByDeptoId(int deptoId)
        {
            return await _context.ReportTemplate.Where(dt => dt.DepartmentId == deptoId)
                                                     .ToListAsync();
        }
    }
}
