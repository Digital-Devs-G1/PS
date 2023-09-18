using Application.Interfaces.IServices;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportTrackingController : ControllerBase
    {
        private readonly IReportTrackingService _service;

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
    }
}