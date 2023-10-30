using Application.DTO.Request;
using Application.Interfaces.IServices;
using Application.Interfaces.IServices.IVariableFields;
using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
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
        private readonly Application.Interfaces.IServices.IDepartmentTemplateServices _services;
        private readonly IMapper _mapper;

        public DepartmentTemplateController(Application.Interfaces.IServices.IDepartmentTemplateServices services, IMapper mapper)
        {
            _services = services;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("v1/Departament/{id}/templates")]


        public async Task<IActionResult> GetTemplatesByDepartamentId ([FromRoute(Name = "id")][Required] int departmentId)
        {
            var templatesDepto = await _services.GetTemplatesByDeptoId(departmentId);
            return this.Ok(templatesDepto); 
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] DepartamentTemplateRequest request)
        {
            var departamentTemplate = this._mapper.Map<DepartmentTemplate>(request);
            var fieldTemplates = this._mapper.Map<List<FieldTemplate>>(request.FieldTemplates);

            await _services.AddTemplate(departamentTemplate, fieldTemplates);

            return this.Created("GetTemplatesByDepartamentId/{deptoId}", departamentTemplate);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] DepartamentTemplateNameRequest request)
        {
            var departamentTemplate = this._mapper.Map<DepartmentTemplate>(request);

            await _services.UpdateTemplate(departamentTemplate);

            return this.Ok(departamentTemplate);
        }
    }
}
