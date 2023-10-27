using Domain.Entities;

namespace Application.Interfaces.IRepositories
{
    public interface IFieldTemplateQuerys
    {
        Task<FieldTemplate> GetById(int id, string fieldName);

        public Task<IList<FieldTemplate>> GetTemplatesById(int tempId);
    }
}
