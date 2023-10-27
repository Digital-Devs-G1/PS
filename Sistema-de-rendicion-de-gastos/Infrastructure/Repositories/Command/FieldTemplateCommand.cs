using Application.Interfaces.IRepositories;
using Domain.Entities;
using Infrastructure.Persistence;

namespace Infrastructure.Repositories.Command
{
    public class FieldTemplateCommand : IFieldTemplateCommand
    {
        private readonly ReportsDbContext _dbContext;

        public FieldTemplateCommand(ReportsDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task AddRange(List<FieldTemplate> fields)
        {
            foreach (var field in fields)
            {
                if (_dbContext.FieldTemplates.Any(x => x.FieldNameId == field.FieldNameId && x.FieldTemplateId == field.FieldTemplateId))
                {
                    throw new InvalidOperationException($"El nombre del campo variable {field.FieldNameId} ya existe.");
                }

                _dbContext.FieldTemplates.Add(field);
            }

            await _dbContext.SaveChangesAsync();
        }

        public async Task Update(FieldTemplate command)
        {
            if (_dbContext.FieldTemplates.Any(x => x.FieldNameId == command.FieldNameId && x.FieldTemplateId != command.FieldTemplateId))
            {
                throw new InvalidOperationException("El nombre del campo variable ya existe.");
            }

            _dbContext.FieldTemplates.Update(command);

            await _dbContext.SaveChangesAsync();
        }
    }
}
