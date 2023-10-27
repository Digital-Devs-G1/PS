using Application.DTO.Request;
using Application.Interfaces.IServices;
using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FieldTemplateController : ControllerBase
    {
        private readonly IFieldTemplateServices _services;
        private readonly IMapper _mapper;

        public FieldTemplateController(IFieldTemplateServices services, IMapper mapper)
        {
            _services = services;
            _mapper = mapper;
        }

        [HttpGet("GetTemplatesById/{tempId}")]
        public async Task<IActionResult> GetTemplateById(int tempId)
        {
            var templatesDepto = await _services.GetTemplateById(tempId);
            return this.Ok(templatesDepto);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateFieldRequest request)
        {
            var field = this._mapper.Map<FieldTemplate>(request);
            await _services.UpdateField(field);
            return this.Ok(field);
        }
    }
}
