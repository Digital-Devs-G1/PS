using Application.DTO.Response;
using Application.Interfaces.IRepositories;
using Application.Interfaces.IServices;
using Domain.Entities;

namespace Application.UseCases
{
    public class FieldTemplateServices : IFieldTemplateServices
    {
        public readonly IFieldTemplateQuerys _query;
        private readonly IFieldTemplateCommand _command;

        public FieldTemplateServices(IFieldTemplateQuerys query, IFieldTemplateCommand command)
        {
            _query = query;
            _command = command;
        }

        public async Task<IList<FieldTemplateResponse>> GetTemplateById(int tempId)
        {
            IList<FieldTemplateResponse> list = new List<FieldTemplateResponse>();
            foreach (FieldTemplate elem in await _query.GetTemplatesById(tempId))
            {
                list.Add(new FieldTemplateResponse(elem));
            }
            return list;
        }

        public async Task AddRange(List<FieldTemplate> fields, int deptoTemplateId)
        {
            foreach (var field in fields) { field.FieldTemplateId = deptoTemplateId; }
            await _command.AddRange(fields);
        }

        public async Task UpdateField(FieldTemplate updateField)
        {
            var field = await _query.GetById(updateField.FieldTemplateId, updateField.FieldNameId);

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
