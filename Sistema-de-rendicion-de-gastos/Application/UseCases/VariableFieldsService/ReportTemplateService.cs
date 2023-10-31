using Application.DTO.Request;
using Application.DTO.Response.Response.EntityProxy;
using Application.Exceptions;
using Application.Interfaces.IMicroservices.Generic;
using Application.Interfaces.IMicroservicesClient;
using Application.Interfaces.IRepositories;
using Application.Interfaces.IRepositories.IQuery;
using Application.Interfaces.IServices;
using Application.Interfaces.IServices.IVariableFields;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.VariableFieldsService
{
    public class ReportTemplateService : IReportTemplateService
    {
        private readonly IDepartmentTemplateQuery _reportTemplateQuery;
        private readonly IDepartamentTemplateCommand _command;
        private readonly ICompanyClient _companyClient;
        private readonly IReportTemplateFieldService _fieldTemplateService;
        private readonly IMapper _mapper;
        private readonly IGenericRepositoryQuerys<DataType> _getDataType;

        public ReportTemplateService(
            IDepartmentTemplateQuery query,
            ICompanyClient companyClient,
            IDepartamentTemplateCommand command,
            IReportTemplateFieldService fieldTemplateService,
            IMapper mapper,
            IGenericRepositoryQuerys<DataType> getDataType)
        {
            _reportTemplateQuery = query;
            _companyClient = companyClient;
            _command = command;
            _fieldTemplateService = fieldTemplateService;
            _mapper = mapper;
            _getDataType = getDataType;
        }

        public async Task<IList<ReportTemplateResponse>> GetTemplatesBy()
        {
            var deptoId = await _companyClient.GetDepartmentId();
            var templates = await _reportTemplateQuery.GetTemplatesByDeptoId(deptoId);
            if (templates.Count() == 0)
                throw new NotFoundException("No existe templates para ese Departamento.");

            IList<ReportTemplateResponse> list = new List<ReportTemplateResponse>();
            foreach (var elem in templates)
            {
                list.Add(new ReportTemplateResponse()
                    { 
                        ReportTemplateId = (int)elem.ReportTemplateId,
                        ReportTemplateName = elem.ReportTemplateName
                    }
                );
            }
            return list;
        }

        public async Task<ReportTemplateResponse> AddTemplate(ReportTemplateRequest request)
        {
            var deptoId = await _companyClient.GetDepartmentId();

            var fieldTemplates = this._mapper.Map<List<ReportTemplateField>>(request.FieldTemplates);
            StringBuilder errorBuilder = new StringBuilder();
            if (string.IsNullOrEmpty(request.ReportTemplateName))
                errorBuilder.Append("No se especifico el nombre del template de reporte.");
            foreach(var field in fieldTemplates)
            {
                if (string.IsNullOrEmpty(field.Name))
                    errorBuilder.Append("No se especifico el nombre del campo " + field.Name + ".");
                if (field.DataTypeId < 1)
                    errorBuilder.Append("El tipo de dato recibido tiene un formato invalido para el campo " + field.Name + ".");
                else
                {
                    var datatype = await _getDataType.GetByIdAsync(field.DataTypeId);
                    if (datatype == null)
                        errorBuilder.Append("No existe el tipo de dato recibido para el campo " + field.Name + ".");
                }
                field.Enabled = true;
            }
            if (errorBuilder.Length > 0)
                throw new BadRequestException(errorBuilder.ToString());
            var reportTemplate = new ReportTemplate()
            {
                ReportTemplateName = request.ReportTemplateName,
                DepartmentId = deptoId
            };
            await _command.Add(reportTemplate);
            reportTemplate.ReportTemplateFieldsCol = fieldTemplates;
            foreach (var field in fieldTemplates)
                field.ReportTemplateId = (int) reportTemplate.ReportTemplateId;
            await _command.Update(reportTemplate);
            return _mapper.Map<ReportTemplateResponse>(reportTemplate);
        }

        public async Task<ReportTemplateResponse> UpdateTemplate(UpdateReportTemplateRequest request, int reportId)
        {
            var template = await _reportTemplateQuery.GetById(reportId);

            if (template == null)
            {
                throw new InvalidOperationException("No se encontró el template.");
            }

            template.ReportTemplateName = request.ReportTemplateName;

            await _command.Update(template);
            return _mapper.Map<ReportTemplateResponse>(template);
        }
    }
}
