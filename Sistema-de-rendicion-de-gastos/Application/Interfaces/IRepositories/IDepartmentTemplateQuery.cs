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
        public Task<IList<DepartmentTemplate>> GetTemplatesByDeptoId(int deptoId);
        public Task<bool> ExistDepartamentId(int id);
    }
}
