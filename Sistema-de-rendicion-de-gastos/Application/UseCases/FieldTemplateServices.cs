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
    }
}
