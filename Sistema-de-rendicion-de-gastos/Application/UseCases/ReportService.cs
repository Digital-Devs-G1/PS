using Application.Dto.Response.StatusResponseNS;
using Application.DTO.Request;
using Application.DTO.Response.ReportOperationNS;
using Application.DTO.Response.Response.EntityProxy;
using Application.Exceptions;
using Application.Interfaces.IRepositories;
using Application.Interfaces.IRepositories.ICommand;
using Application.Interfaces.IRepositories.IQuery;
using Application.Interfaces.IServices;
using Application.Interfaces.IServices.IReportTraking;
using Application.Interfaces.IServices.IVariableFields;
using Application.UseCases.VariableFieldsService;
using Domain.Entities;
using System.Collections.Concurrent;
using System.Text;

namespace Application.UseCases
{
    public class ReportService : IReportService
    {
        private readonly IGenericRepositoryQuerys<Report> repository;
        private readonly IGenericCommand<Report> _reportCommand;
        private readonly IReportQuery _reportQuery;
        private readonly IReportTrackingService reportTrackingService;
        private readonly IReportOperationService reportOperationService;
        private readonly IVariableFieldService variableFieldService;
        private readonly IFieldTemplateServices fieldTemplateService;
        private readonly IServiceResponseFactory responseFactory;

        public ReportService(
            IGenericRepositoryQuerys<Report> repository,
            IReportTrackingService reportTrackingService,
            IReportOperationService reportOperationService,
            IGenericCommand<Report> command,
            IVariableFieldService variableFieldService,
            IFieldTemplateServices fieldTemplateService,
            IServiceResponseFactory responseFactory,
            IReportQuery reportQuery)
        {
            this.repository = repository;
            this.reportTrackingService = reportTrackingService;
            this._reportCommand = command;
            this.variableFieldService = variableFieldService;
            this.fieldTemplateService = fieldTemplateService;
            this.reportOperationService = reportOperationService;
            this.responseFactory = responseFactory;
            _reportQuery = reportQuery;
        }

        public async Task<Report> GetById(int id)
        {
            return await repository.GetByIdAsync(id);
        }

        public async Task<List<Report>> GetAll()
        {
            var reports = await repository.GetAllAsync();
            return reports.ToList();
        }

        public async Task<List<ReportStatusResponse>> GetReportsStatusById(int employeeId)
        {
            List<ReportStatusResponse> reportStatusResponses = new List<ReportStatusResponse>();
            var reports = await repository.GetAllAsync();
            var filter = reports.Where(opt => opt.EmployeeId == employeeId);

            foreach (var report in filter)
            {
                var lastTracking = await reportTrackingService.GetLastTrackingByReportId(report.ReportId);
                if (lastTracking == null)
                {
                    throw new ArgumentException($"No se han realizado operaciones sobre este reporte");
                }
                var reportOperation = await reportOperationService.GetById(lastTracking.ReportOperationId);

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
            var report = await GetById(reportId);
            if (report == null)
            {
                throw new ArgumentException("El reporte no existe.");
            }
            var lastTracking = await reportTrackingService.GetLastTrackingByReportId(reportId);
            if (lastTracking == null)
            {
                throw new ArgumentException($"No se han realizado operaciones sobre este reporte");
            }
            var reportOperation = await reportOperationService.GetById(lastTracking.ReportOperationId);

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

        public bool TryCast(int type, string value)
        {
            return true;
        }

        public async Task<int> AddReport(AddReportRequest reportRequest, int employeeId)
        {
            var templates = await fieldTemplateService.GetTemplatesById(reportRequest.TemplateId);
            StringBuilder errorBuilder = new StringBuilder();
            if (templates.Count != reportRequest.Fields.Count)
                errorBuilder.Append("La cantidad de campos no coincide con las del template.");
            foreach ( var field in templates)
            {
                var f = reportRequest.Fields.Where(f => f.Name.Equals(field.Name));
                if ( f.Count() == 0 )
                    errorBuilder.Append("No se encuentra el campo " + field.Name);
                else if(field.DataTypeId != f.ElementAt(0).DataTypeId)
                    errorBuilder.Append("El tipo de dato del campo " + field.Name + " es incorrecto");
                else if(f.Count() > 1)
                    errorBuilder.Append("No se permiten nombres de campos repetidos.");
            }       
            if(reportRequest.Report.Amount <=0 )
                errorBuilder.Append("El monto es incorrecto");
            if (reportRequest.Report.Description.Equals(""))
                errorBuilder.Append("No se especifo descripcion");
            if (errorBuilder.Length > 0)
                throw new BadRequestException(errorBuilder.ToString());

            // CLIENT COMPANY READ APPROVER
            int approverId = 1;

            var fields = new List<VariableField>();
            foreach ( var field in reportRequest.Fields)
            {
                fields.Add(new VariableField()
                {
                    DataTypeId = field.DataTypeId,
                    Name = field.Name,
                    Value = field.Value,
                });
            }

            // BEGIN TRANSATION
            var report = new Report()
            {
                EmployeeId = employeeId,
                Description = reportRequest.Report.Description,
                Amount = reportRequest.Report.Amount,
                ApproverId = approverId,
                VariableFieldCol = fields,
                date = DateTime.Now,
            };

            await _reportCommand.Add(report);

            // END TRANSACTION
            return report.ReportId;
        }

        private bool CheckVariableFields(
            IList<FieldTemplate> template,
            List<string> fields,
            ConcurrentBag<StatusResponse> errors
            )
        {
            int errorsCount = errors.Count;
            for (int i = 0; i < template.Count; i++)
            {
                int j = i * 2;
                var name = template[i].Name;
                if (name.CompareTo(fields[j]) != 0)
                    errors.Add(responseFactory.UnexpectedField(name, fields[j]));
                var type = template[i].DataTypeId;
                if (!TryCast(type, fields[j + 1]))
                    errors.Add(responseFactory.UnexpectedDataType(type, fields[j + 1]));
            }
            return errorsCount == errors.Count;
        }

        private IList<VariableField> CreateVariableFields(
            IList<FieldTemplate> template,
            List<string> fields,
            Report report
            )
        {
            var entities = new List<VariableField>();
            for (int i = 0; i < template.Count; i++)
            {
                int j = i * 2 + 1;
                entities.Add(new VariableField()
                {
                   
                    ReportId = report.ReportId,
                    Name = template[i].Name,
                    DataTypeId = template[i].DataTypeId,
                    Value = fields[j]
                });
            }
            return entities;
        }

        public async Task<bool> ExistReportById(int reportId)
        {
            return await _reportQuery.ExistReportById(reportId);
        }

        public async Task<IList<ReportResponse>> GetPendingApprovals(int approverId)
        {
            if (approverId < 1)
                throw new InvalidFormatIdException("Id de aprovador invalido. ");
            var reports = await _reportQuery.GetPendingApprovals(approverId);
            if (reports == null || reports.Count == 0)
                throw new NoFilterMatchesException("No hay nada por aprovar. ");
            return reports;
        }

    }
}