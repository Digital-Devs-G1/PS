using Application.DTO.Response;
using Application.Interfaces.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentTemplateController : ControllerBase
    {
        private readonly IDepartmentTemplateServices _services;

        public DepartmentTemplateController(IDepartmentTemplateServices services)
        {
            _services = services;
        }

        [HttpGet("GetTemplatesByDepartamentId/{deptoId}")]
        public async Task<IActionResult> GetTemplatesByDepartamentId (int deptoId)
        {
            var templatesDepto = await _services.GetTemplatesByDeptoId(deptoId);
            return this.Ok(templatesDepto);
        }

        //[HttpPost("AddDeptoTemplate")]
        //public IActionResult AddDepartamentTemplated(DepartamentTemplateResponse deptoTemp)
        //{
        //    var nuevoDeptTemp = _services.Add(deptoTemp);
        //    return new JsonResult(nuevoDeptTemp);
        //}

    }
}
