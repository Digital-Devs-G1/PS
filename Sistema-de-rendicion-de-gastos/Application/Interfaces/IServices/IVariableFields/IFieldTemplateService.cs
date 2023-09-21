using Application.DTO.Response;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.IServices.IVariableFields
{
    public interface IFieldTemplateService
    {
        public Task<IList<FieldTemplate>> GetTemplate(int templateId);
        public Task<IList<FieldTemplateResponse>> GetTemplateById(int tempId);
    }
}
