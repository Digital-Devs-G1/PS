using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.IRepositories
{
    public interface IDepartamentTemplateQuery
    {
        Task<DepartmentTemplate> GetById(int id);

        public Task<IList<DepartmentTemplate>> GetTemplatesByDeptoId(int deptoId);
    }
}
