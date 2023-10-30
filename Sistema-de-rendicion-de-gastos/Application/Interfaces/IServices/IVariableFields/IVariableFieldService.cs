using Application.DTO.Response.ReportNS;
using Domain.Entities;

namespace Application.Interfaces.IServices.IVariableFields
{
    public interface IVariableFieldService
    {
        public Task<bool> AddFields(IList<VariableField> fields);
        public Task<List<VariableFieldResponse>> GetVariableFieldResponseByReportId(int reportId);
    }
}
