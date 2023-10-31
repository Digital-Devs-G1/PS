using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.IRepositories
{
    public interface IReportTemplateFieldQuerys
    {
        public Task<IList<ReportTemplateField>> GetResportTemplatesFieldsByDepartment(
            int tempId,
            int departmentId
        );
        public Task<ReportTemplateField> GetFirstTemplateById(int tempId);
        public Task<ReportTemplateField> GetTemplate(string tempName, int tempId);
    }
}
