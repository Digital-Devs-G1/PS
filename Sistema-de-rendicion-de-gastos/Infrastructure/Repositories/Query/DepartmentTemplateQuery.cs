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

        public async Task<DepartmentTemplate> GetById(int id)
        {
            return await _context.DepartmentTemplates.Where(x => x.DepartmentTemplateId == id).FirstOrDefaultAsync();
        }

        //retorna los DeptoTemplate mediante un deptoId

        public async Task<bool> ExistDepartamentId(int id)
        {
            return await _context.DepartmentTemplates.AnyAsync(dt => dt.DepartmentId == id);
        }

        public async Task<IList<DepartmentTemplate>> GetTemplatesByDeptoId(int deptoId)
        {
            return await _context.DepartmentTemplates.Where(dt => dt.DepartmentId == deptoId)
                                                     .ToListAsync();
        }
    }
}
