
using Application.DTO.Request;
using Application.DTO.Response;
using Application.DTO.Response.Response.EntityProxy;
using Application.Interfaces.IMicroservicesClient;
using Application.Interfaces.IServices;
using Application.Interfaces.IServices.IVariableFields;
using AutoMapper;
using Domain.Entities;
using Infrastructure.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Presentation.API.Handlers;
using Presentation.Handlers;
using System.IdentityModel.Tokens.Jwt;

namespace Presentation.API.Controllers
{
    [Route("api/")]
    [ApiController]
    [TypeFilter(typeof(ExceptionFilter))]
    public class ReportTemplateController : ControllerBase
    {
        private readonly IReportTemplateService _reportTemplateService;
        private readonly IReportFieldTemplateService _fieldTemplateService;

        public ReportTemplateController(
            IReportTemplateService services,
            IReportFieldTemplateService fieldTemplateService
            )
        {
            _reportTemplateService = services;
            _fieldTemplateService = fieldTemplateService;
        }

        [HttpGet("v1/ReportTemplate/{id}/ReportTemplateFields")]
        [ProducesResponseType(typeof(UnauthorizedHttpResult), 401)]
        [ProducesResponseType(typeof(IList<FieldTemplateResponse>), 200)]
        [ProducesResponseType(typeof(ErrorResponse), 400)]
        [ProducesResponseType(typeof(ErrorResponse), 404)]
        [ProducesResponseType(typeof(ErrorResponse), 422)]
        [Authorize]
        public async Task<IActionResult> GetReportTemplateFields(
            [FromRoute(Name = "id")] uint reportTemplateId)
        {
            var fields = await _fieldTemplateService.GetTemplatesFields((int)reportTemplateId);
            return Ok(fields);
        }

        [HttpGet("v1/ReportTemplate")]
        [ProducesResponseType(typeof(UnauthorizedHttpResult), 401)]
        [ProducesResponseType(typeof(ErrorResponse), 404)]
        [ProducesResponseType(typeof(ErrorResponse), 422)]
        [ProducesResponseType(typeof(List<ReportTemplateResponse>), 200)]
        [Authorize]
        public async Task<IActionResult> GetTemplates ()
        {
            var templatesDepto = await _reportTemplateService.GetTemplatesBy();
            return this.Ok(templatesDepto); 
        }

        [HttpPost("v1/ReportTemplate")]
        public async Task<IActionResult> Post([FromBody] ReportTemplateRequest request)
        {
            var reportTemplate = await _reportTemplateService.AddTemplate(request);

            return this.Created("v1/ReportTemplates", reportTemplate);
        }

        [HttpPut("v1/ReportTemplate/{id}")]
        public async Task<IActionResult> Update(
            [FromBody] UpdateReportTemplateRequest request, 
            [FromRoute(Name ="id")] int reportId)
        {

            var reportTemplate = await _reportTemplateService.UpdateTemplate(request, reportId);

            return this.Ok(reportTemplate);
        }
    }
}
