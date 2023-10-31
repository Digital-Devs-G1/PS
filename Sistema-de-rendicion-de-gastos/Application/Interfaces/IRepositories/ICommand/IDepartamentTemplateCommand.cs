using Domain.Entities;

namespace Application.Interfaces.IRepositories
{
    public interface IDepartamentTemplateCommand
    {
        Task Add(ReportTemplate template);

        Task Update(ReportTemplate command);
    }
}
