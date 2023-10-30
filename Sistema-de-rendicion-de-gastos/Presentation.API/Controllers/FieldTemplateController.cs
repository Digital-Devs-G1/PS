using Application.DTO.Request;
using Application.Interfaces.IServices;
using Microsoft.AspNetCore.Mvc;
using Presentation.Handlers;

namespace Presentation.API.Controllers
{
    [Route("api/")]
    [ApiController]
    [TypeFilter(typeof(ExceptionFilter))]
    public class FieldTemplateController : ControllerBase
    {
        private readonly IFieldTemplateServices _services;

        public FieldTemplateController(IFieldTemplateServices services)
        {
            _services = services;
        }

        [HttpGet("v1/Templates/{id}")]
        public async Task<IActionResult> GetTemplateById(uint id)
        {
            if (id < 1) 
            {
                return BadRequest("El ID no puede ser 0.");  
            }
            var templates = await _services.GetTemplatesById((int)id);

            if (templates.Count() == 0)
            {
                return NotFound("No existe templates para ese Departamento."); 
            }
            return this.Ok(templates);
        }

        [HttpPost("v1/Template")]
        public async Task<IActionResult> CreateTemplate(FieldTemplateRequest template)
        {
            if (template == null) 
            {
                return BadRequest("El ID no puede ser 0."); 
            }
            await _services.CreateFieldTemplate(template);
            return new JsonResult(template) { StatusCode = 201 };
        }

        [HttpDelete("v1/Templates/{id}")]
        public async Task<IActionResult> DeleteTempletes(uint id)
        {
            if (id < 1)
            {
                return BadRequest("El ID no puede ser 0.");
            }
            await _services.DeleteFieldTemplatesById((int)id);
            return this.Ok();
        }   
        [HttpDelete("v1/Template/{id}/{name}")]
        public async Task<IActionResult> DeleteTemplete(uint id, string name)
        {
            if (id<1 & string.IsNullOrEmpty(name))
            {
                return BadRequest("El ID no puede ser 0.");
            }
            await _services.DeleteTemplateById(name, (int)id);
            return this.Ok();
        }
    }
}
