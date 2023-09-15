using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO.Response
{
    public class VariableFieldResponse
    {
        public required string Label { get; set; }
        public required string Value { get; set; }
        public required string DataType { get; set; }
    }
}
