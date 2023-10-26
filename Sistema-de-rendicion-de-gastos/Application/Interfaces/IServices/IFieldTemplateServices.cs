using Application.DTO.Response;
using Domain.Entities;

namespace Application.Interfaces.IServices
{
    public interface IFieldTemplateServices
    {
        public Task<IList<FieldTemplateResponse>> GetTemplateById(int tempId);

        Task AddRange(List<FieldTemplate> fields, int deptoTemplateId);
    }
}
