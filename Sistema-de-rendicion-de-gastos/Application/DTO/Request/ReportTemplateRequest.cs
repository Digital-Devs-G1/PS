namespace Application.DTO.Request
{
    public class ReportTemplateRequest
    {
        public required string ReportTemplateName { get; set; }

        public required List<FieldTemplateRequest> FieldTemplates { get; set; }
    }
}
