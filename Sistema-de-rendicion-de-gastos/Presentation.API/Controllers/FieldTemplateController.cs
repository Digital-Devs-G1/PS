using Application.Interfaces.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FieldTemplateController : ControllerBase
    {
        private readonly IFieldTemplateServices _services;
        
        public FieldTemplateController(IFieldTemplateServices services)
        {
            _services = services;
        }
        
        [HttpGet("GetTemplatesById/{tempId}")]
        public async Task<IActionResult> GetTemplateById(int tempId)
        {
            var templatesDepto = await _services.GetTemplateById(tempId);
            return this.Ok(templatesDepto);
        }
    }
}
