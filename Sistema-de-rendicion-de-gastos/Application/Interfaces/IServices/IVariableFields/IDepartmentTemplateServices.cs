using Application.DTO.Response;


namespace Application.Interfaces.IServices.IVariableFields
{
    public interface IDepartmentTemplateServices
    {
        public Task<IList<DepartmentTemplateResponse>> GetTemplatesByDeptoId(int deptoId);
    }
}
