using Application.DTO.Response;
using Application.DTO.Response.Response.EntityProxy;
using Domain.Entities;

namespace Application.Interfaces.IServices
{
    public interface IDepartmentTemplateServices
    {
        public Task<IList<DepartmentTemplateResponse>> GetTemplatesByDeptoId (int deptoId);

        Task AddTemplate(DepartmentTemplate temp, List<FieldTemplate> fields);

        Task UpdateTemplate(DepartmentTemplate temp);
    }
}
