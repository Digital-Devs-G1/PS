namespace Domain.Entities
{
    public class DepartmentTemplate
    {
        // PK
        public int DepartmentTemplateId { get; set; }

        // FK
        //public ICollection<FieldTemplate>? FieldTemplateCol { get; set; }

        //DATA
        public int DepartmentId { get; set; }
        public required string DepartmentTemplateName { get; set; }
    }
}
