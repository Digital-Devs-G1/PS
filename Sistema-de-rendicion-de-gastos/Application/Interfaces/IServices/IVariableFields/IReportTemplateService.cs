using Application.DTO.Request;
using Application.DTO.Response.Response.EntityProxy;
using Domain.Entities;

namespace Application.Interfaces.IServices.IVariableFields
{
    public interface IReportTemplateService
    {
        public Task<IList<ReportTemplateResponse>> GetTemplatesBy();

        Task<ReportTemplateResponse> AddTemplate(ReportTemplateRequest request);

        Task<ReportTemplateResponse> UpdateTemplate(UpdateReportTemplateRequest temp, int reportId);
    }
}
