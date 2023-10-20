using Application.DTO.Request;
using Application.DTO.Response;
using Application.Interfaces.IRepositories;
using Application.Interfaces.IServices;
using Domain.Entities;

namespace Application.UseCases
{
    public class FieldTemplateServices : IFieldTemplateServices
    {
        public readonly IFieldTemplateQuerys _query;
        public readonly IGenericRepositoryCommand<FieldTemplate> _commandGeneric;
        public readonly IFieldTemplateCommands _command;

        public FieldTemplateServices(IFieldTemplateQuerys query, IGenericRepositoryCommand<FieldTemplate> commandGeneric, IFieldTemplateCommands command)
        {
            _query = query;
            _command = command;
            _commandGeneric = commandGeneric;
        }
        public async Task<IList<FieldTemplateResponse>> GetTemplatesById(int tempId)
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

        public async Task CreateFieldTemplate (FieldTemplateRequest template)
        {
            if (await _query.GetTemplate(template.FieldNameId, template.FieldTemplateId) != null)
                throw new Exception(null);
            await _commandGeneric.Add(new FieldTemplate
            {
                FieldTemplateId = template.FieldTemplateId,
                FieldNameId = template.FieldNameId,
                DataTypeId = template.DataTypeId,
                Enabled = true
            });
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
        public async Task UpdateTemplates (FieldTemplateRequest template)
        {
            await _commandGeneric.Update(new FieldTemplate
            {
                FieldTemplateId = template.FieldTemplateId,
                FieldNameId = template.FieldNameId,
                DataTypeId = template.DataTypeId,
                Enabled = true
            });
        }
    }
}
