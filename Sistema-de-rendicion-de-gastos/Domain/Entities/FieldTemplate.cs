namespace Domain.Entities
{
    public class FieldTemplate
    {
        // PK
        public int FieldTemplateId { get; set; }
        public string FieldNameId { get; set; }

        // FK
        public int DataTypeId { get; set; }
        public DataType? DataTypeNav { get; set; }

        // DATA
        public bool Enabled { get; set; }
    }
}
