using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.IRepositories.IQuery
{
    public interface IDepartmentTemplateQuery
    {
        Task<ReportTemplate> GetById(int id);
        public Task<IList<ReportTemplate>> GetTemplatesByDeptoId(int deptoId);
        public Task<bool> ExistDepartamentId(int id);
    }
}
