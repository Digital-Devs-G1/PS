using Application.DTO.Response.Response.EntityProxy;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.IRepositories.IQuery
{
    public interface IReportQuery
    {
        public Task<bool> ExistReportById(int id);

        public Report GetReport(int idReport);
        public Task<IList<ReportResponse>> GetPendingApprovals(int approverId);
    }
}
