using Application.Exceptions;
using Application.Interfaces;
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
        private readonly ICompanyApprover _companyApprover;
        //private readonly ICompanyClient _companyClient;

        public AddReportTrackingService(
            IGenericCommand<ReportTracking> command
, IReportService repoportService,
IReportTrackingQuery reportTrackingQuery,
ICompanyApprover companyApprover,
IGenericCommand<Report> reportCommand)//ICompanyClient companyClient)
        {
            this._reportTrankingCommand = command;
            _repoportService = repoportService;
            this._reportTrackingQuery = reportTrackingQuery;
            _companyApprover = companyApprover;
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

        private async Task<Report> ValidateTrakingOpperationRequest(int reportId, int employeeId)
        {
            if (reportId < 1)
                throw new BadRequestException("El id de reporte tiene un formato invalido");
            StringBuilder errorBuilder = new StringBuilder();
            Report report = await _repoportService.GetById(reportId);
            if (report == null)
                throw new NotFoundException("El reporte no existe en la base de datos");
            if(report.ApproverId != employeeId)
                errorBuilder.Append("El reporte no tiene asignado como aprobador al empleado que solicita la aprobacion");
            var tracking = await _reportTrackingQuery.GetLastTrackingByReportIdAsync(reportId);
            if (tracking.ReportOperationId == (int)Approval)
                errorBuilder.Append("El reporte ya fue aprovado previamente");
            else if (tracking.ReportOperationId == (int)Refuse)
                errorBuilder.Append("El reporte ya fue rechazado previamente");
            if (errorBuilder.Length > 0)
                throw new ConflictException(errorBuilder.ToString());
            return report;
        }

        public async Task AddAcceptTracking(int reportId, int employeeId)
        {
            var report = await ValidateTrakingOpperationRequest(reportId, employeeId);
            int approverId = await _companyApprover.GetNextApproverId(report.Amount);
            int originalApprover;
            int operation;
            if (approverId > 0)
            {
                originalApprover = (int)report.ApproverId;
                report.ApproverId = approverId;
                operation = (int)Review;
            }
            else
            {
                originalApprover = (int)report.ApproverId;
                report.ApproverId = null;
                operation = (int)Approval;
            }
            await AddTracking(
                operation,
                originalApprover,
                report
            );
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
            var report = await ValidateTrakingOpperationRequest(reportId, employeeId);
            int originalApprover = (int)report.ApproverId;
            report.ApproverId = null;
            await AddTracking(
                (int)Refuse,
                originalApprover,
                report
            );
            /* 
             * NOTIFICAR AL APROBADOR
             * 
             * SI NO HAY APROBADOR 
             *      DAR POR APROBADO
             *      NOTIFICAR AL EMPLEADO 
             * 
             */
        }

        private async Task<ReportTracking> AddTracking(
            int operationId,
            int approverId,
            Report report
            )
        {
            var tracking = new ReportTracking
            {
                ReportNav = report,
                ReportOperationId = operationId,
                TrackingDate = DateTime.Now,
                EmployeeId = approverId
            };
            await _reportTrankingCommand.Add(tracking);
            return tracking;
        }

    }
}
