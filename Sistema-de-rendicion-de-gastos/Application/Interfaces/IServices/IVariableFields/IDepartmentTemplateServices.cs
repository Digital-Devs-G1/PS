using Application.DTO.Response.Response.EntityProxy;

namespace Application.Interfaces.IServices.IVariableFields
{
    public interface IDepartmentTemplateServices
    {
        public Task<IList<DepartmentTemplateResponse>> GetTemplatesByDeptoId(int deptoId);
    }
}
