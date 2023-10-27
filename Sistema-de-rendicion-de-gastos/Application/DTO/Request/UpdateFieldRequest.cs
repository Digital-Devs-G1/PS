namespace Application.DTO.Request
{
    public class UpdateFieldRequest
    {
        public int FieldTemplateId { get; set; }

        public string FieldName { get; set; }

        public int DataType { get; set; }

        public bool Enabled { get; set; }
    }
}
