using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.IServices.IVariableFields
{
    public interface IVariableFieldService
    {
        public Task<bool> AddFields(IList<VariableField> fields);
    }
}
