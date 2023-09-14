using Application.DTO.Response;
using Domain.Entities;

namespace Application.Interfaces.IRepositories
{
    public interface IVariableFieldQuery
    {
        public IList<VariableField> GetTemplate(int templateId);
    }
}
