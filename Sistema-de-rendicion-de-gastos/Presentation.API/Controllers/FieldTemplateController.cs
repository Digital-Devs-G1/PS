using Application.DTO.Request;
using Application.Interfaces.IServices;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.API.Controllers
{
    [Route("api/")]
    [ApiController]
    public class FieldTemplateController : ControllerBase
    {
        private readonly IFieldTemplateServices _services;

        public FieldTemplateController(IFieldTemplateServices services)
        {
            _services = services;
        }

        [HttpGet("v1/Templates/{id}")]
        public async Task<IActionResult> GetTemplateById(int id)
        {
            var templatesDepto = await _services.GetTemplatesById(id);
            return this.Ok(templatesDepto);
        }

        [HttpPost("v1/Template")]
        public async Task<IActionResult> CreateTemplate(FieldTemplateRequest template)
        {
            await _services.CreateTemplates(template);
            return this.Ok();
        }

        [HttpDelete("v1/Templates/{id}")]
        public async Task<IActionResult> DeleteTempletes(int id)
        {
            await _services.DeleteTemplates(id);
            return this.Ok();
        }   
        [HttpDelete("v2/Template/{id}{name}")]
        public async Task<IActionResult> DeleteTemplete(int id, string name)
        {
            await _services.DeleteTemplate(name, id);
            return this.Ok();
        }
    }
}
