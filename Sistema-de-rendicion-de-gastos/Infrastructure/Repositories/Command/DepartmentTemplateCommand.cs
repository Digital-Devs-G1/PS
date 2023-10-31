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

        public async Task Add(ReportTemplate command)
        {
            if (_dbContext.ReportTemplate.Any(u => u.ReportTemplateName == command.ReportTemplateName))
            {
                throw new InvalidOperationException("El nombre del template ya existe.");
            }

            _dbContext.ReportTemplate.Add(command);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Update(ReportTemplate command)
        {
            _dbContext.ReportTemplate.Update(command);

            await _dbContext.SaveChangesAsync();
        }
    }
}
