using Application.DTO.Response.Response.EntityProxy;
using Application.Interfaces.IMicroservices.Generic;
using Application.Interfaces.IMicroservicesClient;
using Application.Interfaces.IRepositories;
using Application.Interfaces.IRepositories.IQuery;
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
    public class DepartmentTemplateService : IReportTemplateService
    {
        private readonly IDepartmentTemplateQuery _query;
        private readonly IDepartamentTemplateCommand _command;
        private readonly ICompanyClient _companyClient;
        private readonly IFieldTemplateService _fieldTemplateService;

        public DepartmentTemplateService(
            IDepartmentTemplateQuery query,
            ICompanyClient companyClient,
            IDepartamentTemplateCommand command,
            IFieldTemplateService fieldTemplateService)
        {
            _query = query;
            _companyClient = companyClient;
            _command = command;
            _fieldTemplateService = fieldTemplateService;
        }

        public async Task<IList<DepartmentTemplateResponse>> GetTemplatesBy(int employeeId)
        {
            int deptoId = await _companyClient.GetDepartmentId( employeeId );
            IList<DepartmentTemplateResponse> list = new List<DepartmentTemplateResponse>();
            foreach (DepartmentTemplate elem in await _query.GetTemplatesByDeptoId(deptoId))
            {
                list.Add(new DepartmentTemplateResponse(elem));
            }
            return list;
        }

        public async Task AddTemplate(DepartmentTemplate temp, List<FieldTemplate> fields)
        {
            var deptoId = 1; //solicitar el id del departamente del usuario
            temp.DepartmentId = deptoId;
            await _command.Add(temp);

            await _fieldTemplateService.AddRange(fields, temp.DepartmentTemplateId);
        }

        public async Task UpdateTemplate(DepartmentTemplate temp)
        {
            var template = await _query.GetById(temp.DepartmentTemplateId);

            if (template == null)
            {
                throw new InvalidOperationException("No se encontró el template.");
            }

            template.DepartmentTemplateName = temp.DepartmentTemplateName;

            await _command.Update(template);
        }
    }
}
