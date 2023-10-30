using Application.DTO.Response.ReportNS;
using Application.Exceptions;
using Application.Interfaces.IRepositories;
using Application.Interfaces.IServices;

namespace Application.UseCases
{
    public class VariableFieldServices : IVariableFieldServices
    {
        public readonly IVariableFieldQuery _query;
        public readonly IReportService _reportServices;

        public VariableFieldServices(IVariableFieldQuery query, IReportService reportServices)
        {
            _query = query;
            _reportServices = reportServices;
        }

        public async Task<List<VariableFieldResponse>> GetVariableFieldResponseByReportId(int reportId)
        {
            if(reportId <= 0) throw new InvalidFormatIdException("El id debe ser un entero positivo");

            bool validReportId = await _reportServices.ExistReportById(reportId);

            if(!validReportId) throw new NonExistentReferenceException($"No existe un reporte con el id {reportId}"); 

            List<VariableFieldResponse> responseListField = new List<VariableFieldResponse>();
            var VariableFieldList = await _query.GetVariablesFieldByReportId(reportId);
            foreach (var item in VariableFieldList)
            {
                responseListField.Add(new VariableFieldResponse
                {
                    Label = item.Name,
                    Value = item.Value,
                    DataType = item.DataTypeId
                });
            }
            return responseListField;
        }
    }
}
