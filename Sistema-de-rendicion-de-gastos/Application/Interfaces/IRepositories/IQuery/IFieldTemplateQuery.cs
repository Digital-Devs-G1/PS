using Application.UseCases;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.IRepositories.IQuery
{
    public interface IFieldTemplateQuery
    {
        public Task<IList<FieldTemplate>> GetTemplate(int templateId);
        public Task<IList<FieldTemplate>> GetTemplatesById(int tempId);
    }
}
