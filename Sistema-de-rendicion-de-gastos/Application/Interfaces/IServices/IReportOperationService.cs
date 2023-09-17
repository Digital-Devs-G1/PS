using Domain.Entities;

namespace Application.Interfaces.IServices
{
    public interface IReportOperationService
    {
        Task<ReportOperation> GetById(int reportOperationId);
    }
}
