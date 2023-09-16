using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class DeptoTemplate
    {
        public required int TemplateId { get; set; }
        public ICollection<FieldTemplate>? FieldTemplateCollec { get; set; }
        public required int DeptoId { get; set; }
        public required string Name { get; set; }
    }
}
