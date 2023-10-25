using Application.DTO.Response.Response.EntityProxy;
using Application.Interfaces.IServices.IVariableFields;
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
        public readonly IVariableFieldService _services;

        public VariableFieldController(IVariableFieldService services)
        {
            _services = services;
        }

        [HttpGet]
        [Route("VariableFields/{id}")]

        [SwaggerResponse(
            statusCode: 200,
            type: typeof(ReportResponse),
            description: "Campos variables del Reporte {id}")
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

        public async Task<IActionResult> GetVariableFieldById ([FromRoute(Name = "id")][Required] int reportId)
        {
            var result = await _services.GetVariableFieldResponseByReportId(reportId);
            return this.Ok(result);
        }
    }
}
