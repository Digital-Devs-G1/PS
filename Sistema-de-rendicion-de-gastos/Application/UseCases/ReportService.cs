using Application.DTO.Response;
using Application.Enums;
using Application.Interfaces.IRepositories;
using Application.Interfaces.IServices;
using Domain.Entities;

namespace Application.UseCases
{
    public class ReportService : IReportService
    {
        private readonly IGenericRepositoryQuerys<Report> repository;
        private readonly IReportTrackingService reportTrackingService;
        private readonly IReportOperationService reportOperationService;
        public ReportService(IGenericRepositoryQuerys<Report> repository, IReportTrackingService reportTrackingService, IReportOperationService reportOperationService)
        {
            this.repository = repository;
            this.reportTrackingService = reportTrackingService;
            this.reportOperationService = reportOperationService;
        }

        public async Task<Report> GetById(int id)
        {
            return await repository.GetByIdAsync(id);
        }

        public async Task<List<ReportStatusResponse>> GetReportsStatusById(int employeeId)
        {
            List<ReportStatusResponse> reportStatusResponses = new List<ReportStatusResponse>();
            var reports = await this.repository.GetAllAsync();
            var filter = reports.Where(opt => opt.EmployeeId == employeeId);
            
            foreach (var report in filter)
            {
                var lastTracking = await this.reportTrackingService.GetLastTrackingByReportId(report.ReportId);
                if (lastTracking == null)
                {
                    throw new ArgumentException($"No se han realizado operaciones sobre este reporte");
                }
                //var reportOperation = await this.reportOperationService.GetById(lastTracking.ReportOperationId);

                ReportStatusResponse reportStatusResponse = new ReportStatusResponse
                {
                    Id = report.ReportId,
                    Description = report.Description,
                    Amount = report.Amount,
                    Status = Enum.GetName(typeof(ReportOperationEnum), lastTracking.ReportOperationId),
                    DateTracking = lastTracking.DateTracking,
                };

                reportStatusResponses.Add(reportStatusResponse);
            }

            return reportStatusResponses;
        }

        public async Task<ReportStatusResponse> GetReportStatusById(int reportId)
        {
            var report = await this.GetById(reportId);
            if (report == null)
            {
                throw new ArgumentException("El reporte no existe.");
            }
            var lastTracking = await this.reportTrackingService.GetLastTrackingByReportId(reportId);
            if (lastTracking == null)
            {
                throw new ArgumentException($"No se han realizado operaciones sobre este reporte");
            }
            //var reportOperation = await this.reportOperationService.GetById(lastTracking.ReportOperationId);

            ReportStatusResponse reportStatusResponse = new ReportStatusResponse
            {
                Id = report.ReportId,
                Description = report.Description,
                Amount = report.Amount,
                Status = Enum.GetName(typeof(ReportOperationEnum), lastTracking.ReportOperationId),
                DateTracking = lastTracking.DateTracking,
            };

            return reportStatusResponse;
        }
    }
}
