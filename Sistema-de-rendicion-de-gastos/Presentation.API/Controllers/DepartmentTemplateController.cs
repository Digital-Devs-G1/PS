using Application.DTO.Request;
using Application.Interfaces.IServices;
using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentTemplateController : ControllerBase
    {
        private readonly IDepartmentTemplateServices _services;
        private readonly IMapper _mapper;

        public DepartmentTemplateController(IDepartmentTemplateServices services, IMapper mapper)
        {
            _services = services;
            _mapper = mapper;
        }

        [HttpGet("GetTemplatesByDepartamentId/{deptoId}")]
        public async Task<IActionResult> GetTemplatesByDepartamentId (int deptoId)
        {
            var templatesDepto = await _services.GetTemplatesByDeptoId(deptoId);
            return this.Ok(templatesDepto);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] DepartamentTemplateRequest request)
        {
            var departamentTemplate = this._mapper.Map<DepartmentTemplate>(request);
            var fieldTemplates = this._mapper.Map<List<FieldTemplate>>(request.FieldTemplates);

            await _services.AddTemplate(departamentTemplate, fieldTemplates);

            return this.Created("GetTemplatesByDepartamentId/{deptoId}", new { });
        }

    }
}
