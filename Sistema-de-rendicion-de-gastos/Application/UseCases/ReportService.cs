using Application.DTO.Request;
using Application.DTO.Response;
using Application.DTO.Response.ReportOperationNS;
using Application.Enums;
using Application.Interfaces.IRepositories;
using Application.Interfaces.IServices;
using Domain.Entities;
using System.Xml.Linq;

namespace Application.UseCases
{
    public class ReportService : IReportService
    {
        private readonly IGenericRepositoryQuerys<Report> repository;
        private readonly IGenericRepositoryCommand<Report> command;
        private readonly IReportTrackingService reportTrackingService;
        private readonly IReportOperationService reportOperationService;
        private readonly IVariableFieldService variableFieldService;
        private readonly IFieldTemplateService fieldTemplateService;

        public ReportService(
            IGenericRepositoryQuerys<Report> repository,
            IReportTrackingService reportTrackingService, 
            IReportOperationService reportOperationService, 
            IGenericRepositoryCommand<Report> command
            )
        {
            this.repository = repository;
            this.reportTrackingService = reportTrackingService;
            this.command = command;
            this.reportOperationService = reportOperationService;
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
                    Status = reportOperation.ReportOperationName,
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
                Status = reportOperation.ReportOperationName,
                DateTracking = lastTracking.TrackingDate,
            };

            return reportStatusResponse;
        }

        public void CheckField(IList<FieldTemplate> template, Dictionary<string, string> fields)
        {

        }

        public async Task AddReport(ReportRequest request, Dictionary<string, string> fields)
        {
            var template = await fieldTemplateService.GetTemplate(request.TemplateId);
            if (template.Count != fields.Count)
                throw new ArgumentException("Formato de template incorrecto. Cantidad de campos variables invalida");

            var report = new Report
            {
                EmployeeId = request.EmployeeId,
                Description = request.Description,
                Amount = request.Amount,
            };

            var entities = new List<VariableField>();
            for (int i = 0; i < template.Count; i++)
            {
                var name = template[i].FieldName;
                CheckField(template, fields);

                entities.Add(new VariableField()
                {
                    ReportId = report.ReportId,
                    NameId = name,
                    DataTypeId = template[i].DataTypeId,
                    Value = fields[name]
                });
            }

            await command.Add(report);

            await reportTrackingService.AddCreationTracking(report.ReportId, request.EmployeeId);

            await variableFieldService.AddFields(entities);
        }
    }
}
