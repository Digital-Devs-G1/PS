using Application.DTO.Response;
using Application.Interfaces.IServices.IVariableFields;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Presentation.Handlers;

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

        [HttpGet("v1/Departament/{id}/templates")]
        public async Task<IActionResult> GetTemplates ()
        {
            var templatesDepto = await _services.GetTemplatesBy(1);

            if(templatesDepto.Count() == 0)
            {
                return NotFound("No existe templates para ese Departamento."); 
            }

            return this.Ok(templatesDepto); 
        }
    }
}
