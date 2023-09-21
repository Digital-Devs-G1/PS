using Application.Interfaces.IRepositories.IQuery;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.Query
{
    public class DepartmentTemplateQuery : IDepartamentTemplateQuery
    {
        public readonly ReportsDbContext _context;

        public DepartmentTemplateQuery(ReportsDbContext context)
        {
            _context = context;
        }
        //retorna los DeptoTemplate mediante un deptoId
        public async Task<IList<DepartmentTemplate>> GetTemplatesByDeptoId(int deptoId)
        {
            return await _context.DepartmentTemplates.Where(dt => dt.DepartmentId == deptoId)
                                                     .ToListAsync();
        }
    }
}
