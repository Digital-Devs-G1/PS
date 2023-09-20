using Application.Interfaces.IRepositories;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.Query
{
    public class FieldTemplateQuery : IFieldTemplateQuery
    {
        private ReportsDbContext _context;

        public FieldTemplateQuery(ReportsDbContext context)
        {
            _context = context;
        }

        public async Task<IList<FieldTemplate>> GetTemplate(int templateId)
        {
            return await _context
                .Set<FieldTemplate>()
                .Where(field=> field.FieldTemplateId == templateId)
                .ToListAsync();
        }
    }
}