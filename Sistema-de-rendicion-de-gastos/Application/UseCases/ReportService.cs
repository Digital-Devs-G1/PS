using Application.DTO.Request;
using Application.DTO.Response.ReportOperationNS;
using Application.DTO.Response.Response.EntityProxy;
using Application.Enums;
using Application.Exceptions;
using Application.Interfaces;
using Application.Interfaces.IRepositories;
using Application.Interfaces.IRepositories.ICommand;
using Application.Interfaces.IRepositories.IQuery;
using Application.Interfaces.IServices;
using Application.Interfaces.IServices.IReportTraking;
using Application.Interfaces.IServices.IVariableFields;
using Application.UseCases.VariableFieldsService;
using Domain.Entities;
using System.Collections.Concurrent;
using System.Globalization;
using System.Text;
using static Application.Enums.DataTypeEnum;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Application.UseCases
{
    public class ReportService : IReportService
    {
        private readonly IGenericRepositoryQuerys<Report> repository;
        private readonly IGenericCommand<Report> _reportCommand;
        private readonly IGenericCommand<ReportTracking> _reportTrankingCommand;
        private readonly IReportTrackingQuery _reportTrackingQuery;

        private readonly IGenericCommand<VariableField> _variableFieldCommand;
        private readonly IReportQuery _reportQuery;
        private readonly IReportTrackingService reportTrackingService;
        private readonly IReportOperationService reportOperationService;
        private readonly IVariableFieldService variableFieldService;
        private readonly IReportTemplateFieldService fieldTemplateService;
        private readonly ICompanyApprover _companyApprover;

        public ReportService(
            IGenericRepositoryQuerys<Report> repository,
            IReportTrackingService reportTrackingService,
            IReportOperationService reportOperationService,
            IGenericCommand<Report> command,
            IVariableFieldService variableFieldService,
            IReportTemplateFieldService fieldTemplateService,
            IReportQuery reportQuery,
            IGenericCommand<ReportTracking> reportTrankingCommand,
            IGenericCommand<VariableField> variableFieldCommand,
            ICompanyApprover companyApprover,
            IReportTrackingQuery reportTrackingQuery)
        {
            this.repository = repository;
            this.reportTrackingService = reportTrackingService;
            this._reportCommand = command;
            this.variableFieldService = variableFieldService;
            this.fieldTemplateService = fieldTemplateService;
            this.reportOperationService = reportOperationService;
            _reportQuery = reportQuery;
            _reportTrankingCommand = reportTrankingCommand;
            _variableFieldCommand = variableFieldCommand;
            _companyApprover = companyApprover;
            _reportTrackingQuery = reportTrackingQuery;
        }

        public async Task<Report> GetById(int id)
        {
            return await repository.GetByIdAsync(id);
        }


        public async Task<List<ReportStatusResponse>> GetReportsStatusById(int employeeId)
        {
            //List<ReportStatusResponse> reportStatusResponses = new List<ReportStatusResponse>();
            
            if (employeeId < 0) 
                throw new InvalidTokenInformation();

            return await _reportTrackingQuery.GetEmployeeReportsStatus(employeeId);
            
            /*var filter = reports.Where(opt => opt.EmployeeId == employeeId);

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

            return reportStatusResponses;*/
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
            var templates = await fieldTemplateService.GetTemplatesFields(reportRequest.TemplateId);
            StringBuilder errorBuilder = new StringBuilder();
            if (templates.Count != reportRequest.Fields.Count)
                errorBuilder.Append("La cantidad de campos no coincide con las del template.");
            var fields = new List<VariableField>();
            foreach ( var field in templates)
            {
                var list = reportRequest.Fields.Where(f => f.Name.Equals(field.Name)).ToList();
                if (list.Count() == 0 )
                    errorBuilder.Append("No se encuentra el campo " + field.Name);
                else if(list.Count() > 1)
                    errorBuilder.Append("No se permiten nombres de campos repetidos.");
                var f = list[0];
                switch (field.DataTypeId)
                {
                    case (int)Int:
                        int i;
                        if(!int.TryParse(f.Value, out i))
                            errorBuilder.Append("El campo " + field.Name + " debia ser un entero, pero el tipo de dato recibido no tiene el formato adeacuado.");
                        break;
                    case (int)Str:
                        if(string.IsNullOrEmpty(f.Value))
                            errorBuilder.Append("El campo " + field.Name + " esta vacio.");
                        break;
                    case (int)DataTypeEnum.Date:
                        DateTime d;
                        if (DateTime.TryParseExact(f.Value, "yyyy--mm-dd", CultureInfo.CurrentCulture, DateTimeStyles.None, out d))
                            errorBuilder.Append("El campo " + field.Name + " debia ser un entero, pero el tipo de dato recibido no tiene el formato adeacuado.");
                        break;
                    case (int)Bool:
                        bool b;
                        if (!bool.TryParse(f.Value, out b))
                            errorBuilder.Append("El campo " + field.Name + " debia ser un booleano, pero el tipo de dato recibido no tiene el formato adeacuado.");
                        break;
                    case (int)Dec:
                        float floatNum;
                        if (!float.TryParse(f.Value, out floatNum))
                            errorBuilder.Append("El campo " + field.Name + " debia ser un float, pero el tipo de dato recibido no tiene el formato adeacuado.");
                        break;
                    default:
                        errorBuilder.Append("No se reconoce el tipo de dato del campo " + field.Name + ".");
                        break;
                };
                fields.Add(new VariableField()
                {
                    DataTypeId = field.DataTypeId,
                    Name = f.Name,
                    Value = f.Value,
                });
            }       
            if(reportRequest.Report.Amount <=0 )
                errorBuilder.Append("El monto es incorrecto");
            if (reportRequest.Report.Description.Equals(""))
                errorBuilder.Append("No se especifo descripcion");
            if (errorBuilder.Length > 0)
                throw new BadRequestException(errorBuilder.ToString());

            // CLIENT COMPANY READ APPROVER
            int approverId = await _companyApprover.GetApproverId();

            var report = new Report()
            {
                EmployeeId = employeeId,
                Description = reportRequest.Report.Description,
                Amount = reportRequest.Report.Amount,
                ApproverId = approverId,
                date = DateTime.Now,
                VariableFieldCol = fields
            };

            var tracking = new ReportTracking()
            {
                ReportId = report.ReportId,
                ReportOperationId = 1,
                TrackingDate = DateTime.Now,
                EmployeeId = employeeId,
                ReportNav = report
            };

            await _reportTrankingCommand.Add(tracking);

            return report.ReportId;
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