using Application.DTO.Request;
using Application.Interfaces.IServices;
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

        [HttpGet("GetEmployeeReportsStatus/{employeeId}")]
        public async Task<IActionResult> GetEmployeeReportsStatus(int employeeId)
        {
            var reportsStatus = await reportService.GetReportsStatusById(employeeId);
            return this.Ok(reportsStatus);
        }

        [HttpPost("Report")]
        public async Task<IActionResult> AddReport(
            [FromBody] ReportRequest request,
            [FromQuery(Name = "fields")] List<string> fields
            )
        {
            await this.reportService.AddReport(request, fields);
            return this.Ok();
        }
    }
}