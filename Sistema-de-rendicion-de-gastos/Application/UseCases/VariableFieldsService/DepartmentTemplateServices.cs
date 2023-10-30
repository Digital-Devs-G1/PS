using Application.DTO.Response.Response.EntityProxy;
using Application.Interfaces.IMicroservices.Generic;
using Application.Interfaces.IMicroservicesClient;
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
        private readonly IDepartmentTemplateQuery _query;
        private readonly ICompanyClient _companyClient;

        public DepartmentTemplateServices(
            IDepartmentTemplateQuery query, 
            ICompanyClient companyClient
            )
        {
            _query = query;
            _companyClient = companyClient;
        }

        public async Task<IList<DepartmentTemplateResponse>> GetTemplatesBy(int employeeId)
        {
            int deptoId = await _companyClient.GetDepartmentId( employeeId );
            IList<DepartmentTemplateResponse> list = new List<DepartmentTemplateResponse>();
            foreach (DepartmentTemplate elem in await _query.GetTemplatesByDeptoId(deptoId))
            {
                list.Add(new DepartmentTemplateResponse(elem));
            }
            return list;
        }
    }
}
