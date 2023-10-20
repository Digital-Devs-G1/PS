using Application.Interfaces.IServices.IReportTraking;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

namespace Presentation.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportTrackingController : ControllerBase
    {
        private readonly IReportTrackingService _service;



        public int employeeId = 1;



        public ReportTrackingController(IReportTrackingService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("GetEmployeeReportInteractions/{employeeId}")]
        public async Task<IActionResult> GetEmployeeReportInteractions(int employeeId)
        {
            var traking = await _service.GetEmployeeReportInteractions(employeeId);
            return Ok(traking);
        }
        
        [HttpGet]
        [Route("GetReportHistoryByCreator/{employeeId}")]
        public async Task<IActionResult> GetReportHistoryByCreator(int employeeId)
        {
            var traking = await _service.GetReportHistoryByCreator(employeeId);
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
        public async Task<IActionResult> AcceptReport(
            [FromRoute(Name = "id")][Required] int reportId
            )
        {
            await _service.AddAcceptTracking(reportId, employeeId);
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
            await _service.AddDismissTracking(reportId, employeeId);
            return NoContent();
        }
    }
}