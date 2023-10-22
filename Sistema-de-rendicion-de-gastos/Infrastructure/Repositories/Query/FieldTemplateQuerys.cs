using Application.Interfaces.IRepositories;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.Query
{
    public class FieldTemplateQuerys : IFieldTemplateQuerys
    {
        public readonly ReportsDbContext _context;

        public FieldTemplateQuerys(ReportsDbContext context)
        {
            _context = context;
        }

        public async Task<IList<FieldTemplate>> GetTemplatesById(int tempId)
        {
            return await _context.FieldTemplates.Where(ft => ft.DepartmentTemplateId == tempId)
                                                .ToListAsync();
        }

        public async Task<FieldTemplate> GetFirstTemplateById(int tempId)
        {
            return await _context.FieldTemplates.Where(ft => ft.DepartmentTemplateId == tempId).FirstOrDefaultAsync();
        }

        public async Task<FieldTemplate> GetTemplate(string tempName, int tempId)
        {
            var result = await _context.FieldTemplates.FindAsync(new object[] { tempId, tempName });
            return result;
        }
    }
}
