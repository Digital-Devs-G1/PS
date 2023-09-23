using Application.Interfaces.IRepositories;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.Command
{
    public class FieldTemplateCommands : IFieldTemplateCommands
    {
        public readonly ReportsDbContext _context;

        public FieldTemplateCommands(ReportsDbContext context)
        {
            _context = context;
        }

        public async Task DeleteRange(FieldTemplate entity)
        { 
            List<FieldTemplate> fields = await _context.FieldTemplates.Where(f => f.FieldTemplateId == entity.FieldTemplateId).ToListAsync();
            _context.FieldTemplates.RemoveRange(fields);
            await _context.SaveChangesAsync();
        }
    }
}
