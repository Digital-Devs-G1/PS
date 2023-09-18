using Application.Interfaces.IRepositories;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class VariableFieldQuery : IVariableFieldQuery
    {
        private ReportsDbContext _dbContext;

        public VariableFieldQuery(ReportsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IList<VariableField> GetTemplate(int templateId)
        {
            return _dbContext.Set<VariableField>().Where(x => x.ReportId == templateId).ToList();
        }
    }
}
