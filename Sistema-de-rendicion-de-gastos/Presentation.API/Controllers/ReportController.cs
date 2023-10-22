using Application.DTO.Request;
using Application.DTO.Response.Response.EntityProxy;
using Application.Interfaces.IServices;
using Microsoft.AspNetCore.Mvc;
using Presentation.API.Handlers;
using Presentation.Handlers;
using Swashbuckle.AspNetCore.Annotations;

namespace Presentation.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [TypeFilter(typeof(ExceptionFilter))]
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

        [HttpGet("/PendingApprovals")]
        [SwaggerResponse(
            statusCode: 200,
            type: typeof(ReportResponse),
            description: "Reportes pendientes de aprobar por el aprovador.")
        ]
        [SwaggerResponse(
            statusCode: 400,
            type: typeof(ErrorResponseExample),
            description: "Bad Request")
        ]
        [SwaggerResponse(
            statusCode: 404,
            type: typeof(ErrorResponseExample),
            description: "Not Found")
        ]
        public async Task<IActionResult> GetPendingApprovals(
            [FromQuery] int approverId
            )
        {
            var reportsStatus = await reportService.GetPendingApprovals(approverId);
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