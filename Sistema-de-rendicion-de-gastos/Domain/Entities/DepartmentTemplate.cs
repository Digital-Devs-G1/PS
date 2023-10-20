namespace Domain.Entities
{
    public class DepartmentTemplate : BaseEntity
    {
        // PK
        public required int DepartmentTemplateId { get; set; }

        // FK
        //public ICollection<FieldTemplate>? FieldTemplateCol { get; set; }

        //DATA
        public required int DepartmentId { get; set; }
        public required string DepartmentTemplateName { get; set; }
    }
}
