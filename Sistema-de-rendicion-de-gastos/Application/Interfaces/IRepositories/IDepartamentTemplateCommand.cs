using Domain.Entities;

namespace Application.Interfaces.IRepositories
{
    public interface IDepartamentTemplateCommand
    {
        Task Add(DepartmentTemplate template);
    }
}
