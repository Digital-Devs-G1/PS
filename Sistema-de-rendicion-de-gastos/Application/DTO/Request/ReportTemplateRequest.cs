namespace Application.DTO.Request
{
    public class ReportTemplateRequest
    {
        public string ReportTemplateName { get; set; }

        public List<FieldTemplateRequest> FieldTemplates { get; set; }
    }
}
