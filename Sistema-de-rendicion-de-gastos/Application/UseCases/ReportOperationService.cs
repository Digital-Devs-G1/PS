using Application.Interfaces.IRepositories;
using Application.Interfaces.IServices;
using Domain.Entities;

namespace Application.UseCases
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
            return this.repository.GetByIdAsync(reportOperationId);
        }
    }
}
