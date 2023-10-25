using Application.DTO.Response.Response.EntityProxy;
using Application.Exceptions;
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
        public readonly IDepartmentTemplateQuery _query;

        public DepartmentTemplateServices(IDepartmentTemplateQuery query)
        {
            _query = query;
        }

        public async Task<IList<DepartmentTemplateResponse>> GetTemplatesByDeptoId(int deptoId)
        {
            if (deptoId <= 0)
                throw new InvalidFormatIdException();

            var templatesList = await _query.GetTemplatesByDeptoId(deptoId);
            if(templatesList.Count() == 0)
                throw new NonExistentReferenceException();

            IList<DepartmentTemplateResponse> departentResponseList = new List<DepartmentTemplateResponse>();
            foreach (DepartmentTemplate elem in templatesList)
            {
                departentResponseList.Add(new DepartmentTemplateResponse(elem));
            }
            return departentResponseList;
        }
    }
}
