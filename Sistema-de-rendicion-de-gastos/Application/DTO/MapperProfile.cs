using Application.DTO.Request;
using Application.DTO.Response.Response.EntityProxy;
using AutoMapper;
using Domain.Entities;

namespace Application.DTO
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            //this.CreateMap<ReportTracking, ReportTrackingResponse>();
            CreateMap<ReportTemplate, ReportTemplateResponse>();
            CreateMap<ReportTemplateRequest, ReportTemplate>();
            CreateMap<FieldTemplateRequest, ReportTemplateField>();
        }
    }
}
