﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class DataType
    {
        public required int DataTypeId { get; set; }
        public required string Name { get; set; }

        public ICollection<VariableField>? Fields { get; set; }
        public ICollection<FieldTemplate>? FieldTemplateNav { get; set; }
    }
}
