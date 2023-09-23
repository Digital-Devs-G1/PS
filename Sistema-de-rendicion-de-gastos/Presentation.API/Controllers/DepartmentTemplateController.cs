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
        public async Task<IActionResult> GetTemplatesByDepartamentId (int id)
        {
            var templatesDepto = await _services.GetTemplatesByDeptoId(id);
            return this.Ok(templatesDepto);
        }
    }
}
