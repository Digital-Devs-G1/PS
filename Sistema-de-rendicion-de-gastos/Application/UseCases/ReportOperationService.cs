using Application.Interfaces.IRepositories;
using Application.Interfaces.IServices;
using Domain.Entities;

namespace Application.UseCases
{
    public class ReportOperationService : IReportOperationService
    {
        private readonly IGenericRepository<ReportOperation> repository;

        public ReportOperationService(IGenericRepository<ReportOperation> repository)
        {
            this.repository = repository;
        }

        public Task<ReportOperation> GetById(int reportOperationId)
        {
            return this.repository.GetByIdAsync(reportOperationId);
        }
    }
}
