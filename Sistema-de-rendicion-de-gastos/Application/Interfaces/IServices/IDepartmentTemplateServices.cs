using Application.DTO.Response;


namespace Application.Interfaces.IServices
{
    public interface IDepartmentTemplateServices
    {
        public Task<IList<DepartmentTemplateResponse>> GetTemplatesByDeptoId (int deptoId);
    }
}
