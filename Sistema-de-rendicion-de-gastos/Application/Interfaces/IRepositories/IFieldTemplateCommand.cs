using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.IRepositories
{
    public interface IFieldTemplateCommand
    {
        Task AddRange(List<FieldTemplate> fields);

        public Task DeleteRange(FieldTemplate entity);

        Task Update(FieldTemplate command);
    }
}
