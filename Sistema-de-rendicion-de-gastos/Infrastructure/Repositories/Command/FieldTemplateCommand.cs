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

        public async Task AddRange(List<FieldTemplate> fields)
        {
            foreach (var field in fields)
            {
                if (_context.FieldTemplates.Any(x => x.Name == field.Name && x.DepartmentTemplateId == field.DepartmentTemplateId))
                {
                    throw new InvalidOperationException($"El nombre del campo variable {field.Name} ya existe.");
                }

                _context.FieldTemplates.Add(field);
            }

            await _context.SaveChangesAsync();
        }

        public async Task DeleteRange(FieldTemplate entity)
        { 
            List<FieldTemplate> fields = await _context.FieldTemplates.Where(f => f.DepartmentTemplateId == entity.DepartmentTemplateId).ToListAsync();
            _context.FieldTemplates.RemoveRange(fields);
            await _context.SaveChangesAsync();
        }

        public async Task Update(FieldTemplate command)
        {
            _context.FieldTemplates.Update(command);

            await _context.SaveChangesAsync();
        }
    }
}
