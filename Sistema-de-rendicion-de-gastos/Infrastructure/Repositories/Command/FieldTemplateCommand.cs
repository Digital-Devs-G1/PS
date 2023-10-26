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
                _dbContext.FieldTemplates.Add(field);
            }

            await _dbContext.SaveChangesAsync();
        }
    }
}
