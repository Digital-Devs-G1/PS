using Application.Exceptions;
using Application.Interfaces.IServices.IReportTraking;
using Infrastructure.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Presentation.API.Handlers;
using Presentation.Handlers;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

namespace Presentation.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [TypeFilter(typeof(ExceptionFilter))]
    public class ReportTrackingController : ControllerBase
    {
        private readonly IReportTrackingService _getService;
        private readonly IAddReportTrackingService _addService;
        private readonly IJwtHelper jwtHelper;

        public ReportTrackingController(
            IReportTrackingService service,
            IAddReportTrackingService addService,
            IJwtHelper jwtHelper)
        {
            _getService = service;
            _addService = addService;
            this.jwtHelper = jwtHelper;
        }

        [HttpGet]
        [Route("GetEmployeeReportInteractions/{employeeId}")]
        public async Task<IActionResult> GetEmployeeReportInteractions(int employeeId)
        {
            var traking = await _getService.GetEmployeeReportInteractions(employeeId);
            return Ok(traking);
        }
        
        [HttpGet]
        [Route("GetReportHistoryByCreator/{employeeId}")]
        public async Task<IActionResult> GetReportHistoryByCreator(int employeeId)
        {
            var traking = await _getService.GetReportHistoryByCreator(employeeId);
            return Ok(traking);
        }

        [HttpPost]
        [Route("Accept/{id}")]
        [SwaggerResponse(
            statusCode: 204,
            description: "NoContent")
        ]
        [SwaggerResponse(
            statusCode: 400,
            type: typeof(ErrorResponseExample),
            description: "Bad Request")
        ]
        [Authorize]
        public async Task<IActionResult> AcceptReport(
            [FromRoute(Name = "id")][Required] int reportId
            )
        {
            await _addService.AddAcceptTracking(
                reportId, 
                jwtHelper.GetEmployeeId()
            );
            return NoContent();
        }

        [HttpPost]
        [Route("Dismiss/{id}")]
        [SwaggerResponse(
            statusCode: 204,
            description: "NoContent")
        ]
        [SwaggerResponse(
            statusCode: 400,
            type: typeof(ErrorResponseExample),
            description: "Bad Request")
        ]
        public async Task<IActionResult> DismissReport(
            [FromRoute(Name = "id")][Required] int reportId
            )
        {
            await _addService.AddDismissTracking(
                reportId,
                jwtHelper.GetEmployeeId()
            );
            return NoContent();
        }
    }
}