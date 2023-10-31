namespace Domain.Entities
{
    public class ReportTemplate : BaseEntity
    {
        // PK
        public int? ReportTemplateId { get; set; }

        // FK
        public ICollection<ReportTemplateField>? ReportTemplateFieldsCol { get; set; }

        //DATA
        public required int DepartmentId { get; set; }
        public required string ReportTemplateName { get; set; }
    }
}
