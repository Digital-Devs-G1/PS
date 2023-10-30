using Application.DTO.Request;
using Application.Interfaces.IServices;
using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Presentation.Handlers;

namespace Presentation.API.Controllers
{
    [Route("api/")]
    [ApiController]
    [TypeFilter(typeof(ExceptionFilter))]
    public class FieldTemplateController : ControllerBase
    {
        private readonly IFieldTemplateService _services;
        private readonly IMapper _mapper;

        public FieldTemplateController(
            IFieldTemplateService services,
            IMapper mapper)
        {
            _services = services;
            _mapper = mapper;
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

            //RECUPERAR ID DEL DEPARTAMENTO

            await _services.CreateFieldTemplate(template, 1);
            return new JsonResult(template) { StatusCode = 201 };
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateFieldRequest request)
        {
            var field = this._mapper.Map<FieldTemplate>(request);
            await _services.UpdateField(field);
            return this.Ok(field);
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
