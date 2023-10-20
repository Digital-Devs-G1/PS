using Application.DTO.Response;
using Application.Interfaces.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.API.Controllers
{
    [Route("api/")]
    [ApiController]
    public class DepartmentTemplateController : ControllerBase
    {
        private readonly IDepartmentTemplateServices _services;

        public DepartmentTemplateController(IDepartmentTemplateServices services)
        {
            _services = services;
        }

        [HttpGet("v1/Departament/{id}/templates")]
        public async Task<IActionResult> GetTemplatesByDepartamentId (uint id)
        {
            if(id == 0) 
            {
                return BadRequest("El ID no puede ser 0."); 
            }

            var templatesDepto = await _services.GetTemplatesByDeptoId((int)id);

            if(templatesDepto.Count() == 0)
            {
                return NotFound("No existe templates para ese Departamento."); 
            }

            return this.Ok(templatesDepto); 
        }
    }
}
