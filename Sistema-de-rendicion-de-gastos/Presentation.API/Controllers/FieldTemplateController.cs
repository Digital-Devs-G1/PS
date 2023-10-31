using Application.DTO.Request;
using Application.DTO.Response.Response.EntityProxy;
using Application.Interfaces.IServices;
using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Presentation.API.Handlers;
using Presentation.Handlers;

namespace Presentation.API.Controllers
{
    [Route("api/")]
    [ApiController]
    [TypeFilter(typeof(ExceptionFilter))]
    public class FieldTemplateController : ControllerBase
    {
        private readonly IReportTemplateFieldService _service;

        public FieldTemplateController(
            IReportTemplateFieldService services)
        {
            _service = services;
        }

        [HttpGet("v1/ReportTemplate/{id}/ReportTemplateFields")]
        [ProducesResponseType(typeof(UnauthorizedHttpResult), 401)]
        [ProducesResponseType(typeof(IList<FieldTemplateResponse>), 200)]
        [ProducesResponseType(typeof(ErrorResponse), 400)]
        [ProducesResponseType(typeof(ErrorResponse), 404)]
        [ProducesResponseType(typeof(ErrorResponse), 422)]
        [Authorize]
        public async Task<IActionResult> GetReportTemplateFields(
            [FromRoute(Name ="id")] uint reportTemplateId)
        {
            var fields = await _service.GetTemplatesFields((int)reportTemplateId);
            return Ok(fields);
        }

        /*
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
            var fieldResponse = await _services.UpdateField(request);
            return this.Ok(fieldResponse);
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
        
        [HttpDelete("v1/ReportTemplateField/{id}/{name}")]
        public async Task<IActionResult> DeleteTemplete(uint id, string name)
        {
            if (id<1 & string.IsNullOrEmpty(name))
            {
                return BadRequest("El ID no puede ser 0.");
            }
            await _services.DeleteTemplateById(name, (int)id);
            return this.Ok();
        }*/
    }
}
