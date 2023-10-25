using Application.DTO.Response;
using Application.Interfaces.IServices.IVariableFields;
using Microsoft.AspNetCore.Http;
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
    public class DepartmentTemplateController : ControllerBase
    {
        private readonly IDepartmentTemplateServices _services;

        public DepartmentTemplateController(IDepartmentTemplateServices services)
        {
            _services = services;
        }

        [HttpGet]
        [Route("v1/Departament/{id}/templates")]

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
        public async Task<IActionResult> GetTemplatesByDepartamentId ([FromRoute(Name = "id")][Required] int departmentId)
        {
            var templatesDepto = await _services.GetTemplatesByDeptoId(departmentId);
            return this.Ok(templatesDepto); 
        }
    }
}
