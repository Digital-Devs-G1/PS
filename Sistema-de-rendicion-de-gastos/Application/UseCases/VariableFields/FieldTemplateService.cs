using Application.DTO.Response.Response.EntityProxy;
using Application.Interfaces.IRepositories.IQuery;
using Application.Interfaces.IServices.IVariableFields;
using Domain.Entities;

namespace Application.UseCases.VariableFields
{
    public class FieldTemplateService : IFieldTemplateService
    {
        private IFieldTemplateQuery _repository;

        public FieldTemplateService(IFieldTemplateQuery repository)
        {
            _repository = repository;
        }

        public Task<IList<FieldTemplate>> GetTemplate(int templateId)
        {
            return _repository.GetTemplate(templateId);
        }
        public async Task<IList<FieldTemplateResponse>> GetTemplateById(int tempId)
        {
            IList<FieldTemplateResponse> list = new List<FieldTemplateResponse>();
            foreach (FieldTemplate elem in await _repository.GetTemplatesById(tempId))
            {
                list.Add(new FieldTemplateResponse(elem));
            }
            return list;
        }
    }
}
