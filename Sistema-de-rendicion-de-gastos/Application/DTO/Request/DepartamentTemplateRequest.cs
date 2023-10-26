namespace Application.DTO.Request
{
    public class DepartamentTemplateRequest
    {
        public string DepartmentTemplateName { get; set; }

        public List<FieldTemplateRequest> FieldTemplates { get; set; }
    }
}
