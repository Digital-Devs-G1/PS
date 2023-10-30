using Application.DTO.Request;
using Application.DTO.Response;
using Application.DTO.Response.Response.EntityProxy;
using Domain.Entities;

namespace Application.Interfaces.IServices
{
    public interface IFieldTemplateServices
    {
        public Task<IList<FieldTemplateResponse>> GetTemplatesById(int tempId);
        public Task<FieldTemplateResponse> GetFirstTemplateById(int tempId);
        public Task CreateFieldTemplate(FieldTemplateRequest template);
        public Task DeleteFieldTemplatesById(int idTemplate);
        public Task DeleteTemplateById(string tempName, int idTemplate);
        public Task UpdateTemplates(FieldTemplateRequest template);

        Task AddRange(List<FieldTemplate> fields, int deptoTemplateId);

        Task UpdateField(FieldTemplate field);
    }
}
