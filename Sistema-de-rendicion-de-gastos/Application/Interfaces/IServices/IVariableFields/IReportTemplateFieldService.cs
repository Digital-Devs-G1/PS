using Application.DTO.Request;
using Application.DTO.Response;
using Application.DTO.Response.Response.EntityProxy;
using Domain.Entities;

namespace Application.Interfaces.IServices
{
    public interface IReportTemplateFieldService
    {
        public Task<IList<FieldTemplateResponse>> GetTemplatesFields(int tempId);
        public Task<FieldTemplateResponse> GetFirstTemplateById(int tempId);
        public Task CreateFieldTemplate(FieldTemplateRequest template, int departmentId);

        Task AddRange(List<ReportTemplateField> fields, int deptoTemplateId);

        public Task DeleteFieldTemplatesById(int idTemplate);
        public Task DeleteTemplateById(string tempName, int idTemplate);
        //public Task UpdateTemplates(FieldTemplateRequest template);
        Task<FieldTemplateResponse> UpdateField(UpdateFieldRequest field);
    }
}
