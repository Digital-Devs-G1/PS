using Application.DTO.Request;
using Application.DTO.Response;
using Application.DTO.Response.Response.EntityProxy;
using Application.Exceptions;
using Application.Interfaces.IMicroservicesClient;
using Application.Interfaces.IRepositories;
using Application.Interfaces.IServices;
using AutoMapper;
using Domain.Entities;
using System.Text;

namespace Application.UseCases
{
    public class FieldTemplateService : IReportFieldTemplateService
    {
        public readonly IReportTemplateFieldQuerys _query;
        public readonly IGenericCommand<ReportTemplateField> _commandGeneric;
        public readonly IFieldTemplateCommand _command;
        private readonly IMapper _mapper;
        private readonly ICompanyClient _companyClient;

        public FieldTemplateService(IReportTemplateFieldQuerys query, IGenericCommand<ReportTemplateField> commandGeneric, IFieldTemplateCommand command, IMapper mapper, ICompanyClient companyClient)
        {
            _query = query;
            _command = command;
            _commandGeneric = commandGeneric;
            _mapper = mapper;
            _companyClient = companyClient;
        }

        public async Task<IList<FieldTemplateResponse>> GetTemplatesFields(int reportTemplateId)
        {
            var deptoId = await _companyClient.GetDepartmentId();
            if (reportTemplateId < 1)
                throw new BadRequestException("El ID no puede ser 0.");
            var fields = await _query.GetResportTemplatesFieldsByDepartment(
                reportTemplateId,
                deptoId
            );
            if (fields.Count() == 0)
                throw new NotFoundException("No existe templates para ese Departamento.");
            IList<FieldTemplateResponse> list = new List<FieldTemplateResponse>();
            foreach (ReportTemplateField elem in fields)
                list.Add(new FieldTemplateResponse(elem));
            return list;
        }

        public async Task<FieldTemplateResponse> GetFirstTemplateById(int tempI)
        {
            var fieldTemp = await _query.GetFirstTemplateById(tempI);
            return new FieldTemplateResponse(fieldTemp);
        }

        public async Task CreateFieldTemplate (FieldTemplateRequest template, int departmentId)
        {
            if (await _query.GetTemplate(template.Name, departmentId) != null)
                throw new Exception(null);
            await _commandGeneric.Add(new ReportTemplateField
            {
                ReportTemplateId = departmentId,
                Name = template.Name,
                DataTypeId = template.DataTypeId,
                Enabled = true
            });
        }

        public async Task AddRange(List<ReportTemplateField> fields, int deptoTemplateId)
        {
            foreach (var field in fields) { field.ReportTemplateId = deptoTemplateId; }
            await _command.AddRange(fields);
        }

        
        public async Task DeleteFieldTemplatesById (int idTemplate)
        {/*
            if ((await _query.GetResportTemplatesFields(idTemplate)).Count() == 0)
                throw new Exception();
            await _command.DeleteRange (await _query.GetFirstTemplateById(idTemplate));*/
        }

        public async Task DeleteTemplateById(string tempName, int idTemplate)
        {
            if (await _query.GetTemplate(tempName, idTemplate) == null)
                throw new Exception(null);
            await _commandGeneric.Delete(await _query.GetTemplate(tempName, idTemplate));
        }

        //no implementado
        /*public async Task UpdateTemplates (FieldTemplateRequest template)
        {
            await _commandGeneric.Update(new FieldTemplate
            {
                DepartmentTemplateId = template.FieldTemplateId,
                Name = template.FieldNameId,
                DataTypeId = template.DataTypeId,
                Enabled = true
            });
        }*/

        public async Task<FieldTemplateResponse> UpdateField(UpdateFieldRequest request)
        {

            var updateField = this._mapper.Map<ReportTemplateField>(request);

            var field = await _query.GetTemplate(updateField.Name, updateField.ReportTemplateId);

            if (field == null)
            {
                throw new InvalidOperationException("El nombre del campo variable ya existe.");
            }

            field.DataTypeId = updateField.DataTypeId;
            field.Enabled = updateField.Enabled;

            await _command.Update(field);
            return _mapper.Map<FieldTemplateResponse>(field);   
        }
    }
}
