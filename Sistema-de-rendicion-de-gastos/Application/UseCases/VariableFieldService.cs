using Application.DTO.Creator;
using Application.DTO.Response;
using Application.Interfaces.IRepositories;
using Application.Interfaces.IServices;
using Domain.Entities;

namespace Application.UseCases
{
    public class VariableFieldService : IVariableFieldService
    {
        private IVariableFieldQuery _repository;
        private VariableFieldCreator _creator;

        public VariableFieldService(IVariableFieldQuery repository)
        {
            _repository = repository;
            _creator = new VariableFieldCreator();
        }

        public IList<VariableFieldResponse> GetTemplate(int templateId)
        {
            IList<VariableFieldResponse> list = new List<VariableFieldResponse>();
            IList<VariableField> entities = _repository.GetTemplate(templateId);
            foreach (VariableField entity in entities)
            {
                list.Add(_creator.Create(entity));
            }
            return list;
        }
    }
}
