using Application.Exceptions;
using Application.Interfaces.IRepositories;
using Application.Interfaces.IRepositories.IQuery;
using Application.Interfaces.IServices;
using Application.Interfaces.IServices.IReportTraking;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using System.Text;
using static Application.Enums.ReportOperationEnum;

namespace Application.UseCases.ReportTrackingService
{
    public class AddReportTrackingService : IAddReportTrackingService
    {
        private readonly IGenericCommand<ReportTracking> _reportTrankingCommand;
        private readonly IGenericCommand<Report> _reportCommand;
        private readonly IReportTrackingQuery _reportTrackingQuery;
        private readonly IReportService _repoportService;
        //private readonly ICompanyClient _companyClient;

        public AddReportTrackingService(
            IGenericCommand<ReportTracking> command
, IReportService repoportService,
IReportTrackingQuery reportTrackingQuery,
IGenericCommand<Report> reportCommand)//ICompanyClient companyClient)
        {
            this._reportTrankingCommand = command;
            _repoportService = repoportService;
            this._reportTrackingQuery = reportTrackingQuery;
            _reportCommand = reportCommand;
            // _companyClient = companyClient;
        }


        public async Task AddCreationTracking(int reportId, int employeeId)
        {
         
            //await AddTracking((int)Create);


            /*
             * 
             * RECUPERAR APROBADOR
             * 
             * ASIGNAR APROBADOR AL REPORT
             * 
             * NOTIFICAR AL APROBADOR
             * 
             * SI NO HAY APROBADOR DE MAS JERARQUIA
             *      DAR POR APROBADO
             *      NOTIFICAR AL EMPLEADO 
             * 
             */

        }

        private async Task<Report> ValidateTrakingOpperationRequest(int reportId)
        {
            if (reportId < 1)
                throw new BadRequestException("El id de reporte tiene un formato invalido");

            StringBuilder errorBuilder = new StringBuilder();
            Report report = await _repoportService.GetById(reportId);
            if (report == null)
                errorBuilder.Append("El reporte no existe en la base de datos");
            else
            {
                var tracking = await _reportTrackingQuery.GetLastTrackingByReportIdAsync(reportId);
                if (tracking.ReportOperationId == (int)Approval)
                    errorBuilder.Append("El reporte ya fue aprovado previamente");
                else if (tracking.ReportOperationId == (int)Refuse)
                    errorBuilder.Append("El reporte ya fue rechazado previamente");
            }
            if (errorBuilder.Length > 0)
                throw new BadRequestException(errorBuilder.ToString());
            return report;
        }

        public async Task AddAcceptTracking(int reportId, int employeeId)
        {
            var report = await ValidateTrakingOpperationRequest(reportId);
            await AddTracking((int)Approval, employeeId, reportId);
            // recuperar el SIGUIENTE APROBADOR 
            int approverId = 1;
            if (approverId == employeeId)
                report.ApproverId = null;
            else
                report.ApproverId = approverId;
            await _reportCommand.Update(report);
            /* 
             * NOTIFICAR AL APROBADOR
             * 
             * SI NO HAY APROBADOR 
             *      DAR POR APROBADO
             *      NOTIFICAR AL EMPLEADO 
             * 
             */
        }

        public async Task AddDismissTracking(int reportId, int employeeId)
        {
            var report = await ValidateTrakingOpperationRequest(reportId);
            await AddTracking((int)Refuse, employeeId, reportId);
            report.ApproverId = null;
            await _reportCommand.Update(report);
            /* 
             * NOTIFICAR AL APROBADOR
             * 
             * SI NO HAY APROBADOR 
             *      DAR POR APROBADO
             *      NOTIFICAR AL EMPLEADO 
             * 
             */
        }

        private async Task AddTracking(
            int operationId,
            int employeeId,
            int reportId
            )
        {
            if (reportId < 1)
                throw new InvalidFormatIdException("Id de reporte incorrecto.");
            var tracking = new ReportTracking
            {
                ReportId = reportId,
                ReportOperationId = operationId,
                TrackingDate = DateTime.Now,
                EmployeeId = employeeId
            };
            await _reportTrankingCommand.Add(tracking);
        }

    }
}
