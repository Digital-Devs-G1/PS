using Application.DTO.Request;
using AutoMapper;
using Domain.Entities;

namespace Application.DTO
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            //this.CreateMap<ReportTracking, ReportTrackingResponse>();
            this.CreateMap<DepartamentTemplateRequest, DepartmentTemplate>();
            this.CreateMap<DepartamentTemplateNameRequest, DepartmentTemplate>();
            this.CreateMap<FieldRequest, FieldTemplate>()
                .ForMember(dest => dest.FieldNameId, opt => opt.MapFrom(src => src.FieldName))
                .ForMember(dest => dest.DataTypeId, opt => opt.MapFrom(src => src.DataType));
            this.CreateMap<UpdateFieldRequest, FieldTemplate>()
                .ForMember(dest => dest.FieldNameId, opt => opt.MapFrom(src => src.FieldName))
                .ForMember(dest => dest.DataTypeId, opt => opt.MapFrom(src => src.DataType));
        }
    }
}
