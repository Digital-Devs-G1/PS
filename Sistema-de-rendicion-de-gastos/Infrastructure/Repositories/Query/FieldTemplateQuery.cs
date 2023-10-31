using Application.Interfaces.IRepositories.IQuery;
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

        public async Task<IList<ReportTemplateField>> GetTemplate(int templateId)
        {
            return await _context
                .Set<ReportTemplateField>()
                .Where(field=> field.ReportTemplateId == templateId)
                .ToListAsync();
        }

        public async Task<IList<ReportTemplateField>> GetTemplatesById(int tempId)
        {
            return await _context.ReportTemplateField.Where(ft => ft.ReportTemplateId == tempId)
                                                .ToListAsync();
        }
    }
}