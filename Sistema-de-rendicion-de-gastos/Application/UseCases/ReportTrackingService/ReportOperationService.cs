using Application.Interfaces.IRepositories.IQuery;
using Application.Interfaces.IServices.IReportTraking;
using Domain.Entities;

namespace Application.UseCases.ReportTrackingService
{
    public class ReportOperationService : IReportOperationService
    {
        private readonly IGenericRepositoryQuerys<ReportOperation> repository;

        public ReportOperationService(IGenericRepositoryQuerys<ReportOperation> repository)
        {
            this.repository = repository;
        }

        public Task<ReportOperation> GetById(int reportOperationId)
        {
            return repository.GetByIdAsync(reportOperationId);
        }
    }
}
