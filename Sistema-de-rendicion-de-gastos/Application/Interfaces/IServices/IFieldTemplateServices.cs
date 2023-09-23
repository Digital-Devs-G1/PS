using Application.DTO.Request;
using Application.DTO.Response;

namespace Application.Interfaces.IServices
{
    public interface IFieldTemplateServices
    {
        public Task<IList<FieldTemplateResponse>> GetTemplatesById(int tempId);
        public Task<FieldTemplateResponse> GetFirstTemplateById(int tempId);
        public Task CreateTemplates (FieldTemplateRequest template);
        public Task DeleteTemplates (int idTemplate);
        public Task DeleteTemplate(string tempName, int idTemplate);
        public Task UpdateTemplates (FieldTemplateResponse template);
    }
}
