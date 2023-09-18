using Application.DTO.Request;
using Application.Interfaces.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly IReportService reportService;

        public ReportController(IReportService reportService)
        {
            this.reportService = reportService;
        }

        [HttpGet("ReportStatus/{reportId}")]
        public async Task<IActionResult> GetReportStatus(int reportId)
        {
            var reportStatus = await reportService.GetReportStatusById(reportId);
            return this.Ok(reportStatus);
        }

        [HttpGet("ReportsStatus/{employeeId}")]
        public async Task<IActionResult> GetReportsStatus(int employeeId)
        {
            var reportsStatus = await reportService.GetReportsStatusById(employeeId);
            return this.Ok(reportsStatus);
        }

        [HttpPost("Report")]
        public async Task<IActionResult> AddReport([FromBody] ReportRequest request)
        {
            // falta agregar los datos de los variable fields.
            await this.reportService.AddReport(request);
            return this.Ok();
        }
    }
}
