using Application.DTO.Response;
using Application.Interfaces.IRepositories;
using Application.Interfaces.IServices;
using Domain.Entities;

namespace Application.UseCases
{
    public class DepartmentTemplateServices : IDepartmentTemplateServices
    {
        public readonly IDepartamentTemplateQuery _query;
        public readonly IDepartamentTemplateCommand _command;
        private readonly IFieldTemplateServices _fieldTemplateService;

        public DepartmentTemplateServices(IDepartamentTemplateQuery query, IDepartamentTemplateCommand command, IFieldTemplateServices fieldTemplateService)
        {
            _query = query;
            _command = command;
            _fieldTemplateService = fieldTemplateService;
        }

        public async Task<IList<DepartmentTemplateResponse>> GetTemplatesByDeptoId(int deptoId)
        {
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
    }
}
