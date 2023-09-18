using Application.DTO.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.IServices
{
    public interface IFieldTemplateServices
    {
        public Task<IList<FieldTemplateResponse>> GetTemplateById(int tempId);
    }
}
