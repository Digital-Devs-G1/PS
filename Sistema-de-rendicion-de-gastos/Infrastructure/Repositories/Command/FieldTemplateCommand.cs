using Application.Interfaces.IRepositories;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.Command
{
    public class FieldTemplateCommand : IFieldTemplateCommand
    {
        public readonly ReportsDbContext _context;

        public FieldTemplateCommand(ReportsDbContext context)
        {
            _context = context;
        }

        public async Task AddRange(List<ReportTemplateField> fields)
        {
            foreach (var field in fields)
            {
                if (_context.ReportTemplateField.Any(x => x.Name == field.Name && x.ReportTemplateId == field.ReportTemplateId))
                {
                    throw new InvalidOperationException($"El nombre del campo variable {field.Name} ya existe.");
                }

                _context.ReportTemplateField.Add(field);
            }

            await _context.SaveChangesAsync();
        }

        public async Task DeleteRange(ReportTemplateField entity)
        { 
            List<ReportTemplateField> fields = await _context.ReportTemplateField.Where(f => f.ReportTemplateId == entity.ReportTemplateId).ToListAsync();
            _context.ReportTemplateField.RemoveRange(fields);
            await _context.SaveChangesAsync();
        }

        public async Task Update(ReportTemplateField command)
        {
            _context.ReportTemplateField.Update(command);

            await _context.SaveChangesAsync();
        }
    }
}
