using Application.Interfaces.IRepositories;
using Application.Interfaces.IServices;
using Domain.Entities;

namespace Application.UseCases
{
    public class FieldTemplateService : IFieldTemplateService
    {
        private IFieldTemplateQuery _repository;

        public FieldTemplateService(IFieldTemplateQuery repository)
        {
            _repository = repository;
        }

        public Task<IList<FieldTemplate>> GetTemplate(int templateId)
        {
            return _repository.GetTemplate(templateId);
        }
    }
}
