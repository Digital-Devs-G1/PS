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
    public class DepartmentTemplateServices : IDepartmentTemplateServices
    {
        public readonly IDepartmentTemplateQuery _query;

        public DepartmentTemplateServices(IDepartmentTemplateQuery query)
        {
            _query = query;
        }

        public async Task<IList<DepartmentTemplateResponse>> GetTemplatesByDeptoId(int deptoId)
        {
            IList<DepartmentTemplateResponse> list = new List<DepartmentTemplateResponse>();
            foreach (DepartmentTemplate elem in await _query.GetTemplatesByDeptoId(deptoId))
            {
                 list.Add(new DepartmentTemplateResponse(elem));
            }
            return list;
        }
    }
}
