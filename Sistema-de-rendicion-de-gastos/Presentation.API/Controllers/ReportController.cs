using Application.DTO.Request;
using Application.DTO.Response.ReportNS;
using Application.DTO.Response.Response.EntityProxy;
using Application.Interfaces.IServices;
using Infrastructure.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Presentation.API.Handlers;
using Presentation.Handlers;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

namespace Presentation.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [TypeFilter(typeof(ExceptionFilter))]
    public class ReportController : ControllerBase
    {
        private readonly IReportService reportService;
        public readonly IVariableFieldServices _fieldService;
        private readonly IHttpContextAccessor httpContextAccessor;

        public ReportController(
            IReportService reportService, 
            IHttpContextAccessor httpContextAccessor, 
            IVariableFieldServices fieldService
            )
        {
            this.reportService = reportService;
            this.httpContextAccessor = httpContextAccessor;
            _fieldService = fieldService;
        }
        /*
        [HttpGet("ReportStatus/{reportId}")]
        public async Task<IActionResult> GetReportStatus(int reportId)
        {
            var reportStatus = await reportService.GetReportStatusById(reportId);
            return this.Ok(reportStatus);
        }*/

        [HttpGet("")]
        [Authorize]
        public async Task<IActionResult> GetEmployeeReportsStatus()
        {
            var employeeId = new JwtHelper(httpContextAccessor).GetEmployeeId();
            var reportsStatus = await reportService.GetReportsStatusById(employeeId);
            return this.Ok(reportsStatus);
        }

        [HttpGet]
        [Route("{id}/VariableFields")]
        [SwaggerResponse(
            statusCode: 400,
            type: typeof(ErrorResponse),
            description: "Bad Request")
        ]
        [SwaggerResponse(
            statusCode: 404,
            type: typeof(ErrorResponse),
            description: "Not Found")
        ]
        [SwaggerResponse(
            statusCode: 200,
            type: typeof(List<VariableFieldResponse>),
            description: "Ok")
        ]
        [Authorize]
        public async Task<IActionResult> GetVariableFieldById(
            [FromRoute(Name = "id")][Required] int reportId
            )
        {
            var result = await _fieldService.GetVariableFieldResponseByReportId(reportId);
            return Ok(result);
        }

        [HttpGet("PendingApprovals")]
        [SwaggerResponse(
            statusCode: 200,
            type: typeof(ReportResponse),
            description: "Reportes pendientes de aprobar por el aprovador.")
        ]
        [SwaggerResponse(
            statusCode: 400,
            type: typeof(ErrorResponse),
            description: "Bad Request")
        ]
        [SwaggerResponse(
            statusCode: 404,
            type: typeof(ErrorResponse),
            description: "Not Found")
        ]
        [Authorize]
        public async Task<IActionResult> GetPendingApprovals()
        {
            var employeeId = new JwtHelper(httpContextAccessor).GetEmployeeId();
            var reportsStatus = await reportService.GetPendingApprovals(employeeId);
            return Ok(reportsStatus);
        }
        
        [HttpPost]
        public async Task<IActionResult> AddReport(
            [FromBody] AddReportRequest report
            )
        {
            var employeeId = new JwtHelper(httpContextAccessor).GetEmployeeId();
            int id = await reportService.AddReport(report, employeeId);
            return Created("/api/Report/" + id, id);
        }
    }
}