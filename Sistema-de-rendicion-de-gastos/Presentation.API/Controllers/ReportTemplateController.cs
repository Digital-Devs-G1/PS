using Application.DTO.Request;
using Application.DTO.Response;
using Application.Interfaces.IServices.IVariableFields;
using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Presentation.Handlers;

namespace Presentation.API.Controllers
{
    [Route("api/")]
    [ApiController]
    [TypeFilter(typeof(ExceptionFilter))]
    public class ReportTemplateController : ControllerBase
    {
        private readonly IReportTemplateService _services;
        private readonly IMapper _mapper;

        public ReportTemplateController(IReportTemplateService services, IMapper mapper)
        {
            _services = services;
            _mapper = mapper;
        }

        [HttpGet("v1/Departament/{id}/ReportTemplates")]
        public async Task<IActionResult> GetTemplates ()
        {
            var templatesDepto = await _services.GetTemplatesBy(1);

            if(templatesDepto.Count() == 0)
            {
                return NotFound("No existe templates para ese Departamento."); 
            }

            return this.Ok(templatesDepto); 
        }

        [HttpPost("v1/ReportTemplate")]
        public async Task<IActionResult> Post([FromBody] ReportTemplateRequest request)
        {
            var departamentTemplate = this._mapper.Map<DepartmentTemplate>(request);
            var fieldTemplates = this._mapper.Map<List<FieldTemplate>>(request.FieldTemplates);

            await _services.AddTemplate(departamentTemplate, fieldTemplates);

            return this.Created("GetTemplatesByDepartamentId/{deptoId}", departamentTemplate);
        }

        [HttpPut("v1/ReportTemplate/{id}")]
        public async Task<IActionResult> Update([FromBody] UpdateReportTemplateRequest request)
        {
            var departamentTemplate = this._mapper.Map<DepartmentTemplate>(request);

            await _services.UpdateTemplate(departamentTemplate);

            return this.Ok(departamentTemplate);
        }
    }
}
