using Application.Interfaces.IRepositories;
using Domain.Entities;
using Infrastructure.Persistence;

namespace Infrastructure.Repositories.Command
{
    public class DepartmentTemplateCommand : IDepartamentTemplateCommand
    {
        private readonly ReportsDbContext _dbContext;

        public DepartmentTemplateCommand(ReportsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Add(DepartmentTemplate command)
        {
            if (_dbContext.DepartmentTemplates.Any(u => u.DepartmentTemplateName == command.DepartmentTemplateName))
            {
                throw new InvalidOperationException("El nombre del template ya existe.");
            }

            _dbContext.DepartmentTemplates.Add(command);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Update(DepartmentTemplate command)
        {
            _dbContext.DepartmentTemplates.Update(command);

            await _dbContext.SaveChangesAsync();
        }
    }
}
