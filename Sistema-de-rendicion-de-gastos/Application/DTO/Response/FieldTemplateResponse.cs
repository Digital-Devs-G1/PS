using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO.Response
{
    public class FieldTemplateResponse
    {
        private readonly FieldTemplate _fieldTemplate;

        public FieldTemplateResponse(FieldTemplate fieldTemplate)
        {
            _fieldTemplate = fieldTemplate;
        }

        public int FieldTemplateId { get { return _fieldTemplate.FieldTemplateId; } set { _fieldTemplate.FieldTemplateId = value; } }
        public string FieldNameId { get { return _fieldTemplate.FieldNameId; } set { _fieldTemplate.FieldNameId = value; } }

        public int DataTypeId { get { return _fieldTemplate.DataTypeId; } set { _fieldTemplate.DataTypeId = value; } }

        public bool Enabled { get { return _fieldTemplate.Enabled; } set { _fieldTemplate.Enabled = value; } }
    }
}
