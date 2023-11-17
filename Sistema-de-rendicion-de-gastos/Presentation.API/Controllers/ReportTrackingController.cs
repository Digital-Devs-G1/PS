using Application.Exceptions;
using Application.Interfaces.IServices.IReportTraking;
using Infrastructure.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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
    public class ReportTrackingController : ControllerBase
    {
        private readonly IReportTrackingService _getService;
        private readonly IAddReportTrackingService _addService;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly IJwtHelper jwtHelper;

        public ReportTrackingController(
            IReportTrackingService service,
            IAddReportTrackingService addService,
            IJwtHelper jwtHelper,
            IHttpContextAccessor httpContextAccessor)
        {
            _getService = service;
            _addService = addService;
            this.jwtHelper = jwtHelper;
            this.httpContextAccessor = httpContextAccessor;
        }
        /*
        [HttpGet]
        [Route("GetEmployeeReportInteractions/{employeeId}")]
        public async Task<IActionResult> GetEmployeeReportInteractions(int employeeId)
        {
            var traking = await _getService.GetEmployeeReportInteractions(employeeId);
            return Ok(traking);
        }*/
        /*
        [HttpGet]
        [Route("GetReportHistoryByCreator/{employeeId}")]
        public async Task<IActionResult> GetReportHistoryByCreator(int employeeId)
        {
            var traking = await _getService.GetReportHistoryByCreator(employeeId);
            return Ok(traking);
        }
        */
        [HttpPost]
        [Route("{id}/Accept")]
        [SwaggerResponse(
            statusCode: 204,
            description: "NoContent")
        ]
        [SwaggerResponse(
            statusCode: 400,
            type: typeof(ErrorResponse),
            description: "Bad Request")
        ]
        [Authorize]
        public async Task<IActionResult> AcceptReport(
            [FromRoute(Name = "id")][Required] int reportId
            )
        {
            var employeeId = new JwtHelper(httpContextAccessor).GetEmployeeId();
            await _addService.AddAcceptTracking(
                reportId, 
                employeeId
            );
            return NoContent();
        }

        [HttpPost]
        [Route("{id}/Dismiss")]
        [SwaggerResponse(
            statusCode: 204,
            description: "NoContent")
        ]
        [SwaggerResponse(
            statusCode: 400,
            type: typeof(ErrorResponse),
            description: "Bad Request")
        ]
        public async Task<IActionResult> DismissReport(
            [FromRoute(Name = "id")][Required] int reportId
            )
        {
            var employeeId = new JwtHelper(httpContextAccessor).GetEmployeeId();
            await _addService.AddDismissTracking(
                reportId,employeeId
            );
            return NoContent();
        }
    }
}