using Application.DTO.Response.Response.EntityProxy;
using Domain.Entities;

namespace Application.Interfaces.IServices.IVariableFields
{
    public interface IReportTemplateService
    {
        public Task<IList<DepartmentTemplateResponse>> GetTemplatesBy(int deptoId);

        Task AddTemplate(DepartmentTemplate temp, List<FieldTemplate> fields);

        Task UpdateTemplate(DepartmentTemplate temp);
    }
}
