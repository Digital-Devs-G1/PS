using Application.Exceptions;
using Application.Interfaces.IRepositories;
using Application.Interfaces.IServices.IReportTraking;
using Domain.Entities;

using static Application.Enums.ReportOperationEnum;

namespace Application.UseCases.ReportTrackingService
{
    public class AddReportTrackingService : IAddReportTrackingService
    {
        private readonly IGenericCommand<ReportTracking> command;

        public AddReportTrackingService(
            IGenericCommand<ReportTracking> command
            )
        {
            this.command = command;
        }

        public async Task AddCreationTracking(int reportId, int employeeId)
        {
            await AddTracking(reportId, employeeId, (int)Create);


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
            await AddTracking(reportId, employeeId, (int)Approval);

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
            int reportId,
            int employeeId,
            int operationId
            )
        {
            if (reportId < 1)
                throw new InvalidFormatIdException("Id de reporte incorrecto.");
            var tracking = new ReportTracking
            {
                ReportId = reportId,
                EmployeeId = employeeId,
                ReportOperationId = operationId,
                TrackingDate = DateTime.Now,
            };
            await command.Add(tracking);
        }
    }
}
