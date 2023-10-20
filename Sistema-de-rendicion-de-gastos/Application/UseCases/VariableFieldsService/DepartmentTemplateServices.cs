using Application.DTO.Response.Response.EntityProxy;
using Application.Interfaces.IRepositories.IQuery;
using Application.Interfaces.IServices.IVariableFields;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.VariableFieldsService
{
    public class DepartmentTemplateServices : IDepartmentTemplateServices
    {
        public readonly IDepartamentTemplateQuery _query;

        public DepartmentTemplateServices(IDepartamentTemplateQuery query)
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
