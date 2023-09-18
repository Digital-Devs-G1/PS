using Application.DTO.Response;
using Application.Interfaces.IRepositories;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class ReportTrackingQuery : IReportTrackingQuery
    {
        private ReportsDbContext _dbContext;

        public ReportTrackingQuery(ReportsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<ReportTracking>> GetByReportId(int reportId)
        {
            return await _dbContext
                .Set<ReportTracking>()
                .Where(e => e.ReportId == reportId)
                .ToListAsync();
        }

        public async Task<ReportTracking> GetLastTrackingByReportIdAsync(int reportId)
        {
            var trackings = await _dbContext.Set<ReportTracking>()
                .Where(e => e.ReportId == reportId)
                .ToListAsync();
            return trackings.OrderByDescending(e => e.DateTracking).FirstOrDefault();
        }

        /// <summary>
        /// Retorna todos los reportes con los que interactuo un empleado, ya sea para
        /// crearlos, aprobarlos, etc. Para cada reporte se especifica como y cuando fue
        /// dicha interaccion.
        /// </summary>
        /// <param name="employeeId">ID del empleado que interactuo con los reportes.</param>
        /// <returns>Lista de Historiales de operacion que el empleado realizo en cada uno de los 
        /// reportes en cuestion.</returns>
        public async Task<IList<ReportOperationHistory>> GetEmployeeReportInteractions(int employeeId)
        {
            var resultado = await _dbContext
                .Set<ReportTracking>()
                .Include(reportTracking => reportTracking.ReportOperationNav)
                .Where(reportTracking => reportTracking.EmployeeId == employeeId)
                .GroupBy(tracking => tracking.ReportId)
                .Select(group => new ReportOperationHistory()
                {
                    ReportId = group.Key,
                    Operations = group.ToList()
                })
                .ToListAsync();
            return resultado;
        }

        /// <summary>
        /// Retorna la lista de operaciones realizadas (por multiples empleados) sobre cada 
        /// uno de los reportes creador por un empleado en partituclar.
        /// </summary>
        /// <param name="employeeId">ID del empleado que los creo.</param>
        /// <returns>Lista de historiales de operacion de reportes creados por un empleado
        /// en particular.</returns>
        public async Task<IList<ReportOperationHistory>> GetReportHistoryByCreator(int employeeId)
        {
            var resultado = await _dbContext
                .Set<ReportTracking>()
                .Include(reportTracking => reportTracking.ReportOperationNav)
                .Where(rt => rt.ReportNav!.EmployeeId == employeeId)
                .GroupBy(tracking => tracking.ReportId)
                .Select(group => new ReportOperationHistory()
                {
                    ReportId = group.Key,
                    Operations = group.ToList()
                })
                .ToListAsync();
            return resultado;
        }
    }
}
