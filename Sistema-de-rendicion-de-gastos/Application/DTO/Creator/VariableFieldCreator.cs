using Application.DTO.Response;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO.Creator
{
    public class VariableFieldCreator
    {
        public VariableFieldResponse Create(VariableField field)
        {
            return new VariableFieldResponse()
            {
                Label = field.NameId,
                Value = field.Value,
                DataType = field.DataTypeNav.Name,
            };
        }
    }
}
