using Application.DTO.Response;
using Application.Interfaces.IRepositories;
using Application.Interfaces.IServices;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases
{
    public class FieldTemplateServices : IFieldTemplateServices
    {
        public readonly IFieldTemplateQuerys _query;

        public FieldTemplateServices(IFieldTemplateQuerys query)
        {
            _query = query;
        }

        public async Task<IList<FieldTemplateResponse>> GetTemplateById(int tempId)
        {
            IList<FieldTemplateResponse> list = new List<FieldTemplateResponse>();
            foreach (FieldTemplate elem in await _query.GetTemplatesById(tempId))
            {
                list.Add(new FieldTemplateResponse(elem));
            }
            return list;
        }
    }
}
