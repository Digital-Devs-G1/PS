using Application.Exceptions;
using Application.Interfaces.IRepositories;
using Application.Interfaces.IRepositories.Microservices;
using Application.Interfaces.IServices.IReportTraking;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using static Application.Enums.ReportOperationEnum;

namespace Application.UseCases.ReportTrackingService
{
    public class AddReportTrackingService : IAddReportTrackingService
    {
        private readonly IGenericCommand<ReportTracking> command;
        private readonly IMicroserviceClient microserviceClient;

        public AddReportTrackingService(
            IGenericCommand<ReportTracking> command, 
            IMicroserviceClient microserviceClient)
        {
            this.command = command;
            this.microserviceClient = microserviceClient;
        }

        public async Task AddCreationTracking()
        {
            await AddTracking((int)Create);


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

        public async Task AddAcceptTracking(int reportId, int employeeId)
        {
            string eid = await microserviceClient.sendRequest(
                "https://localhost:7296/api/Employee/GetDepartmentByEmployee"
            );



            //await AddTracking(reportId, employeeId, (int)Approval);

            /*
             * 
             * RECUPERAR SIGUIENTE APROBADOR 
             * 
             * ASIGNAR APROBADOR AL REPORT
             * 
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
            await AddTracking(reportId, employeeId, (int)Refuse);

            /*
            * 
            * 
            * NOTIFICAR AL EMPLEADO
            * 
            * 
            */

        }

        private async Task AddTracking(
            int operationId,
            int? reportId = null
            )
        {
            if (reportId < 1)
                throw new InvalidFormatIdException("Id de reporte incorrecto.");
            var tracking = new ReportTracking
            {
                ReportId = reportId,
                ReportOperationId = operationId,
                TrackingDate = DateTime.Now,
            };
            await command.Add(tracking);
        }
    }
}
