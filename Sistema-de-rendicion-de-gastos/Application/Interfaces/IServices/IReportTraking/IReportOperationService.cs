using Domain.Entities;

namespace Application.Interfaces.IServices.IReportTraking
{
    public interface IReportOperationService
    {
        Task<ReportOperation> GetById(int reportOperationId);
    }
}
