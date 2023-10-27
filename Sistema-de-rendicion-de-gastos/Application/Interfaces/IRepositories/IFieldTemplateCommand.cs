using Domain.Entities;

namespace Application.Interfaces.IRepositories
{
    public interface IFieldTemplateCommand
    {
        Task AddRange(List<FieldTemplate> fields);

        Task Update(FieldTemplate command);
    }
}
