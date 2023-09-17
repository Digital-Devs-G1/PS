using Application.Interfaces.IServices;
using Application.UseCases;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Presentation.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportTrackingController : ControllerBase
    {
        private IReportTrackingService _service;

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
