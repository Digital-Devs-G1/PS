using Application.DTO.Request;
using Application.DTO.Response;
using Application.DTO.Response.ReportOperationNS;
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
        }

        public async Task<Report> GetById(int id)
        {
            return await repository.GetByIdAsync(id);
        }

        public async Task<List<Report>> GetAll()
        {
            var reports = await this.repository.GetAllAsync();
            return reports.ToList();
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
                var reportOperation = await this.reportOperationService.GetById(lastTracking.ReportOperationId);

                ReportStatusResponse reportStatusResponse = new ReportStatusResponse
                {
                    ReportId = report.ReportId,
                    Description = report.Description,
                    Amount = report.Amount,
                    Status = Enum.GetName(typeof(ReportOperationEnum), lastTracking.ReportOperationId),
                    DateTracking = lastTracking.TrackingDate,
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
            var reportOperation = await this.reportOperationService.GetById(lastTracking.ReportOperationId);

            ReportStatusResponse reportStatusResponse = new ReportStatusResponse
            {
                ReportId = report.ReportId,
                Description = report.Description,
                Amount = report.Amount,
                Status = Enum.GetName(typeof(ReportOperationEnum), lastTracking.ReportOperationId),
                DateTracking = lastTracking.TrackingDate,
            };

            return reportStatusResponse;
        }

        public async Task AddReport(ReportRequest request)
        {
            var report = new Report
            {
                EmployeeId = request.EmployeeId,
                Description = request.Description,
                Amount = request.Amount,
            };

            await this.repository.Add(report);

            await this.reportTrackingService.AddCreationTracking(report.ReportId, request.EmployeeId);
        }
    }
}
