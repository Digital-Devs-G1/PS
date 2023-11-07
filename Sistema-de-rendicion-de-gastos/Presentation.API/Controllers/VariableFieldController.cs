using Application.DTO.Response.ReportNS;
using Application.Interfaces.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Presentation.API.Handlers;
using Presentation.Handlers;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

namespace Presentation.API.Controllers
{
    [Route("api/")]
    [ApiController]
    [TypeFilter(typeof(ExceptionFilter))]
    public class VariableFieldController : ControllerBase
    {
        public readonly IVariableFieldServices _services;

        public VariableFieldController(IVariableFieldServices services)
        {
            _services = services;
        }

        [HttpGet]
        [Route("v1/Report/{id}/VariableFields")]
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
        public async Task<IActionResult> GetVariableFieldById (
            [FromRoute(Name = "id")][Required] int reportId
            )
        {
            var result = await _services.GetVariableFieldResponseByReportId(reportId);
            return Ok(result);
        }
    }
}
