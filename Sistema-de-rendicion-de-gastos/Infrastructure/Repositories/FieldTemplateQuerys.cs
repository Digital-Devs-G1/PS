using Application.Interfaces.IRepositories;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class FieldTemplateQuerys : IFieldTemplateQuerys
    {
        public readonly ReportsDbContext _context;

        public FieldTemplateQuerys(ReportsDbContext context)
        {
            _context = context;
        }

        public async Task<FieldTemplate> GetById(int id, string fieldName)
        {
            return await _context.FieldTemplates.Where(x => x.FieldTemplateId == id && x.FieldNameId == fieldName).FirstOrDefaultAsync();
        }

        public async Task<IList<FieldTemplate>> GetTemplatesById(int tempId)
        {
            return await _context.FieldTemplates.Where(ft => ft.FieldTemplateId == tempId)
                                                .ToListAsync();
        }
    }
}
