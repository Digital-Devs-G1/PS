using Application.DTO.Request;
using Application.DTO.Response;
using Application.DTO.Response.Response.EntityProxy;
using Application.Interfaces.IRepositories;
using Application.Interfaces.IServices;
using Domain.Entities;

namespace Application.UseCases
{
    public class FieldTemplateService : IFieldTemplateService
    {
        public readonly IFieldTemplateQuerys _query;
        public readonly IGenericCommand<FieldTemplate> _commandGeneric;
        public readonly IFieldTemplateCommand _command;

        public FieldTemplateService(IFieldTemplateQuerys query, IGenericCommand<FieldTemplate> commandGeneric, IFieldTemplateCommand command)
        {
            _query = query;
            _command = command;
            _commandGeneric = commandGeneric;
        }
        public async Task<IList<DTO.Response.Response.EntityProxy.FieldTemplateResponse>> GetTemplatesById(int tempId)
        {
            IList<FieldTemplateResponse> list = new List<FieldTemplateResponse>();
            foreach (FieldTemplate elem in await _query.GetTemplatesById(tempId))
            {
                list.Add(new FieldTemplateResponse(elem));
            }
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
            await _commandGeneric.Add(new FieldTemplate
            {
                DepartmentTemplateId = departmentId,
                Name = template.Name,
                DataTypeId = template.DataTypeId,
                Enabled = true
            });
        }

        public async Task AddRange(List<FieldTemplate> fields, int deptoTemplateId)
        {
            foreach (var field in fields) { field.DepartmentTemplateId = deptoTemplateId; }
            await _command.AddRange(fields);
        }

        public async Task DeleteFieldTemplatesById (int idTemplate)
        {
            if ((await _query.GetTemplatesById(idTemplate)).Count() == 0)
                throw new Exception();
            await _command.DeleteRange (await _query.GetFirstTemplateById(idTemplate));
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

        public async Task UpdateField(FieldTemplate updateField)
        {
            var field = await _query.GetTemplate(updateField.Name, updateField.DepartmentTemplateId);

            if (field == null)
            {
                throw new InvalidOperationException("El nombre del campo variable ya existe.");
            }

            field.DataTypeId = updateField.DataTypeId;
            field.Enabled = updateField.Enabled;

            await _command.Update(field);
        }
    }
}
