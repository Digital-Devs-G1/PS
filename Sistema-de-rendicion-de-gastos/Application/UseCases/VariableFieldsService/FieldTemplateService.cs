using Application.DTO.Request;
using Application.DTO.Response.Response.EntityProxy;
using Application.Interfaces.IRepositories.IQuery;
using Application.Interfaces.IServices;
using Application.Interfaces.IServices.IVariableFields;
using Domain.Entities;

namespace Application.UseCases.VariableFieldsService
{
    public class FieldTemplateService : IFieldTemplateServices
    {
        private IFieldTemplateQuery _repository;

        public FieldTemplateService(IFieldTemplateQuery repository)
        {
            _repository = repository;
        }

        public Task CreateFieldTemplate(FieldTemplateRequest template)
        {
            throw new NotImplementedException();
        }

        public Task DeleteFieldTemplatesById(int idTemplate)
        {
            throw new NotImplementedException();
        }

        public Task DeleteTemplateById(string tempName, int idTemplate)
        {
            throw new NotImplementedException();
        }

        public Task<FieldTemplateResponse> GetFirstTemplateById(int tempId)
        {
            throw new NotImplementedException();
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

        public Task<IList<FieldTemplateResponse>> GetTemplatesById(int tempId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateTemplates(FieldTemplateRequest template)
        {
            throw new NotImplementedException();
        }
    }
}
