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
        [Route("GetEmployeeReportInteractions/{id}")]
        public async Task<IActionResult> GetEmployeeReportInteractions(int id)
        {
            var traking = await _service.GetEmployeeReportInteractions(id);
            return Ok(traking);
        }
        
        [HttpGet]
        [Route("GetReportHistoryByCreator/{id}")]
        public async Task<IActionResult> GetReportHistoryByCreator(int id)
        {
            var traking = await _service.GetReportHistoryByCreator(id);
            return Ok(traking);
        }
    }
}