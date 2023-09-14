using Application.Interfaces.IRepositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class VariableFieldQuery : IVariableFieldQuery
    {
        private DbContext _dbContext;

        public VariableFieldQuery(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IList<VariableField> GetTemplate(int templateId)
        {
            return _dbContext.Set<VariableField>().Where(x => x.ReportId == templateId).ToList();
        }
    }
}
