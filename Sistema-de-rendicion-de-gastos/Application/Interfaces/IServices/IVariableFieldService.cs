using Application.DTO.Response;

namespace Application.Interfaces.IServices
{
    public interface IVariableFieldService
    {
        public IList<VariableFieldResponse> GetTemplate(int templateId);
    }
}
