using Application.DTO.Response.ReportNS;
using Application.Exceptions;
using Application.Interfaces.IRepositories;
using Application.Interfaces.IRepositories.ICommand;
using Application.Interfaces.IServices;
using Application.Interfaces.IServices.IVariableFields;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.VariableFieldsService
{
    public class VariableFieldService : IVariableFieldService
    {
        private readonly IGenericCommand<VariableField> variableFieldCommand;
        public readonly IVariableFieldQuery _query;
        public readonly IReportService _reportServices;

        public VariableFieldService(IGenericCommand<VariableField> repository, IVariableFieldQuery query,
                                    IReportService reportService)
        {
            variableFieldCommand = repository;
            _query = query;
            _reportServices = reportService;
        }

        public async Task<bool> AddFields(IList<VariableField> fields)
        {
            return default;// await variableFieldCommand.AddAndCommit(fields);
        }

        public async Task<List<VariableFieldResponse>> GetVariableFieldResponseByReportId(int reportId)
        {
            if (reportId <= 0) throw new InvalidFormatIdException();

            bool validReportId = await _reportServices.ExistReportById(reportId);

            if (!validReportId) throw new NonExistentReferenceException();

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






